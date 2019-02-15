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
    public partial class SyncItemsFactory : IntegrationFactory
    {
        private readonly IFoccoWebProdutoRepository _produtoRepository = new FoccoWebProdutoRepository();

        public SyncItemsFactory() : base()
        {
        }

        public SyncItems SyncProducts(int batchRecords, int skip)
        {
            var response = new SyncItems();

            _produtoRepository.ExecuteSqlCommand("TRUNCATE TABLE FoccoWebApiProduto;");

            var apiReq = new GetItemsCommandRequest()
            {
                GetItemsRequest = new GetItemsRequest() { Skip = skip, Take = 250 }
            };

            while (true)
            {
                var apiResp = base._foccoErpApiCommands.GetItemsCommand(apiReq);

                if (apiResp.Success && apiResp.GetItemsResponse.Rows != null)
                {
                    var rows = apiResp.GetItemsResponse.Rows.DistinctBy(x => x.ID, null);
                    foreach (var row in rows)
                    {
                        InsertProduct(row);
                        response.TotalProcessedRows += 1;
                    }

                    base._unitOfWork.Commit();

                    response.TotalRowCount = apiResp.GetItemsResponse.TotalRowCount;
                }
                //else if (!apiResp.Success)
                //    throw apiResp.Exception;
                else
                {
                    response.EndOfRecords = true;
                    break;
                }


                var controller = (response.TotalProcessedRows + apiReq.GetItemsRequest.Take) - batchRecords;

                if (controller <= 0)
                    apiReq.GetItemsRequest.Skip += apiReq.GetItemsRequest.Take;
                else
                {
                    if (apiReq.GetItemsRequest.Take > controller)
                        apiReq.GetItemsRequest.Skip += (apiReq.GetItemsRequest.Take - controller);
                    else
                        break;
                }
            }

            return response;
        }

        private void InsertProduct(Product row)
        {
            if (!_produtoRepository.Exists(x => x.Id == row.ID))
            {
                var item = new FoccoWebApiProduto();

                item.Id = row.ID;
                item.Codigo = row.Codigo;
                item.Descricao = row.Descricao;
                item.Fornecedor = string.IsNullOrEmpty(row.Fornecedor) ? "Sem Fornecedor" : row.Fornecedor;

                _produtoRepository.Insert(item);
            }
        }
    }
}
