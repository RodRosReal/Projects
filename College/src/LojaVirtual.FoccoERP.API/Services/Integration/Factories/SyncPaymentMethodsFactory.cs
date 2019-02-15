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
        private readonly IFoccoWebFormaPagamentoRepository _foccoWebFormaPagamentoRepository = new FoccoWebFormaPagamentoRepository();

        public SyncItems SyncPaymentMethods()
        {
            var response = new SyncItems();

            _foccoWebFormaPagamentoRepository.ExecuteSqlCommand("UPDATE FoccoWebApiFormaPagamento SET Ativo = 0;");

            var apiReq = new GetPaymentConditionsCommandRequest();

            var apiResp = base._foccoErpApiCommands.GetPaymentConditionsCommand(apiReq);

            if (apiResp.Success && apiResp.GetPaymentConditionsResponse.Rows != null)
            {
                var rows = apiResp.GetPaymentConditionsResponse.Rows.DistinctBy(x => x.ID, null);
                foreach (var row in rows)
                {
                    InsertUpdatePaymentMethods(row);
                    response.TotalProcessedRows += 1;
                }

                base._unitOfWork.Commit();

                response.TotalRowCount = apiResp.GetPaymentConditionsResponse.Rows.Count;
            }

            response.EndOfRecords = true;

            return response;
        }

        private void InsertUpdatePaymentMethods(PaymentCondition row)
        {
            var item = _foccoWebFormaPagamentoRepository.Get(x => x.CodigoForma == row.Codigo && x.IdForma  == row.ID);

            if (item == null)
            {
                item = new FoccoWebApiFormaPagamento();

                item.IdForma = row.ID;
                item.CodigoForma = row.Codigo;
                item.Descricao = row.Descricao;
                item.Ativo = true;

                _foccoWebFormaPagamentoRepository.Insert(item);
            }
            else
            {
                if (!item.Ativo)
                {
                    item.Ativo = true;
                    _foccoWebFormaPagamentoRepository.Update(item);
                }
            }
        }
    }
}
