using Application.Messages;
using Domain.Entities.Relacional;
using Domain.Repositories;
using Domain.ValueObjects;
using Domain.ValueObjects.Base;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Relational;
using LojaVirtual.FoccoERP.API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration.Factories
{
    public class BudgetFactory : IntegrationFactory
    {
        private readonly IFoccoWebProdutoRepository _produtoRepository = new FoccoWebProdutoRepository();

        public BudgetFactory() : base()
        {
        }

        public ListBudgetItem CreateBudget(List<BagItem> Items, int clientCode, long cnpjCpf, bool deleteBudget, bool AcceptErrors)
        {
            var response = new ListBudgetItem();

            var createBudgetItemCommandResponse = new CreateBudgetItemCommandResponse();

            int? budgetId = null;
            foreach (var item in Items)
            {
                var request = new CreateBudgetItemCommandRequest()
                {
                    CreateBudgetItemRequest = new CreateBudgetItemRequest()
                    {
                        OrcamentoId = budgetId,
                        CnpjCpf = cnpjCpf,
                        CodigoCliente = clientCode,
                        CodigoCondPagamento = 55,
                        CodigoRepresentante = null,
                        CodigoItem = item.ItemCode,
                        MascaraId = null,
                        Quantidade = item.Quantity
                    }
                };

                createBudgetItemCommandResponse = base._foccoErpApiCommands.CreateBudgetItemCommand(request);

                if (!createBudgetItemCommandResponse.Success)
                {
                    if (AcceptErrors)
                        return response;
                    else
                        throw new Exception("Erro ao criar item");
                }

                if (createBudgetItemCommandResponse.CreateBudgetItemResponse.Rows != null)
                {
                    var budget = createBudgetItemCommandResponse.CreateBudgetItemResponse.Rows.FirstOrDefault();

                    response.Items.Add(budget);
                    budgetId = budget.BudgetId;
                }
            }

            if (deleteBudget && budgetId.HasValue)
                base._foccoErpApiCommands.DeleteBudgetCommand(new DeleteBudgetCommandRequest() { DeleteBudgetRequest = new DeleteBudgetRequest() { BudgetId = budgetId.Value } });

            return response;
        }

        public Order CreateBudget(int budgetId, int paymentConditionCode)
        {
            this.UpdateBudgetPaymentCondition(budgetId, paymentConditionCode);

            var createOrderCommandResponse = new CreateOrderCommandResponse();

            createOrderCommandResponse = base._foccoErpApiCommands.CreateOrderCommand(new CreateOrderCommandRequest() { CreateOrderRequest = new CreateOrderRequest() { BudgetId = budgetId } });

            if (!createOrderCommandResponse.Success)
                throw createOrderCommandResponse.Exception;

            if (createOrderCommandResponse.CreateOrderResponse == null || createOrderCommandResponse.CreateOrderResponse.Order == null)
                throw new Exception("Erro ao criar pedido");


            return createOrderCommandResponse.CreateOrderResponse.Order;
        }

        public void UpdateBudgetPaymentCondition(int budgetId, int paymentConditionCode)
        {
            var updateBudgetPaymentConditionCommandResponse = new UpdateBudgetPaymentConditionCommandResponse();

            var req = new UpdateBudgetPaymentConditionCommandRequest()
            {
                UpdateBudgetPaymentConditionRequest = new UpdateBudgetPaymentConditionRequest()
                {
                    BudgetId = budgetId,
                    PaymentConditionCode = paymentConditionCode
                }
            };

            updateBudgetPaymentConditionCommandResponse = base._foccoErpApiCommands.UpdateBudgetPaymentConditionCommand(req);

            if (!updateBudgetPaymentConditionCommandResponse.Success)
                throw updateBudgetPaymentConditionCommandResponse.Exception;

            if (updateBudgetPaymentConditionCommandResponse.UpdateBudgetPaymentConditionResponse == null ||
                updateBudgetPaymentConditionCommandResponse.UpdateBudgetPaymentConditionResponse.BudgetPaymentCondition == null)
                throw new Exception("Erro ao atualizar formas de pagamento");
        }
    }
}
