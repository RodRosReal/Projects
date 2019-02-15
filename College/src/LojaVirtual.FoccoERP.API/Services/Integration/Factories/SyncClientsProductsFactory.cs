using Application.Messages;
using Domain.Core;
using Domain.Entities.Relacional;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Relational;
using LojaVirtual.FoccoERP.API.Infrastructure.Repositories;

namespace Integration.Factories
{
    public partial class SyncItemsFactory
    {
        private readonly IFoccoWebClienteProdutoRepository _clienteprodutoRepository = new FoccoWebClienteProdutoRepository();
        
        public SyncItems SyncClientsProducts(int batchRecords, int skip, int clientCode, long cnpjCpf)
        {
            var response = new SyncItems();

            if (skip == 0)
                _clienteprodutoRepository.ExecuteSqlCommand("UPDATE FoccoWebApiClienteProduto SET Ativo = 0 WHERE CodigoCliente = " + clientCode + ";");

            var apiReq = new GetClientItemsCommandRequest()
            {
                GetClientItemsRequest = new GetClientItemsRequest() { Skip = skip, Take = 250, CodigoCliente = clientCode, CnpjCpf = cnpjCpf }
            };

            while (true)
            {
                var apiResp = base._foccoErpApiCommands.GetClientItemsCommand(apiReq);

                if (apiResp.Success && apiResp.GetClientItemsResponse.ClientItems.Rows != null)
                {
                    var rows = apiResp.GetClientItemsResponse.ClientItems.Rows.DistinctBy(x => x.ID, null);
                    foreach (var row in rows)
                    {
                        InsertUpdateClientProduct(clientCode, row);
                        response.TotalProcessedRows += 1;
                    }

                    base._unitOfWork.Commit();

                    response.TotalRowCount = apiResp.GetClientItemsResponse.ClientItems.TotalRowCount;
                }
                else
                {
                    response.EndOfRecords = true;
                    break;
                }


                var controller = (response.TotalProcessedRows + apiReq.GetClientItemsRequest.Take) - batchRecords;

                if (controller <= 0)
                    apiReq.GetClientItemsRequest.Skip += apiReq.GetClientItemsRequest.Take;
                else
                {
                    if (apiReq.GetClientItemsRequest.Take > controller)
                        apiReq.GetClientItemsRequest.Skip += (apiReq.GetClientItemsRequest.Take - controller);
                    else
                        break;
                }
            }

            return response;
        }

        private void InsertUpdateClientProduct(int clientCode, ClientItem row)
        {
            var item = _clienteprodutoRepository.Get(x => x.CodigoCliente == clientCode && x.IdProduto == row.ID);

            if (item == null)
            {
                item = new FoccoWebApiClienteProduto();

                item.IdProduto = row.ID;
                item.CodigoProduto = row.Codigo;
                item.CodigoCliente = clientCode;
                item.Ativo = true;

                _clienteprodutoRepository.Insert(item);
            }
            else
            {
                if (!item.Ativo)
                {
                    item.Ativo = true;
                    _clienteprodutoRepository.Update(item);
                }
            }
        }
    }
}
