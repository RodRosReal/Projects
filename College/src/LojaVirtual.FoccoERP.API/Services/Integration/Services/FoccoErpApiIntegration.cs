using Domain.Core;
using Domain.Repositories;
using Domain.ValueObjects.Base;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Relational;
using Integration.Factories;
using Integration.Messages;
using Integration.Services;
using System;
using System.Linq;

namespace Integration.Services
{
    public class FoccoErpApiIntegration : FoccoErpApiIntegrationBase
    {
        public readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        #region Constructor
        public FoccoErpApiIntegration()
        {

        }
        #endregion

        #region Operation Methods Implementation
        public override SyncProductsResponse OnSyncProductsExecute(SyncProductsRequest request)
        {
            var syncItemsFactory = new SyncItemsFactory();
            var response = new SyncProductsResponse();

            try
            {
                response.SyncProducts = syncItemsFactory.SyncProducts(request.BatchRecords, request.Skip);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override SyncClientsProductsResponse OnSyncClientsProductsExecute(SyncClientsProductsRequest request)
        {
            var syncItemsFactory = new SyncItemsFactory();
            var response = new SyncClientsProductsResponse();

            try
            {
                response.SyncClientsProducts = syncItemsFactory.SyncClientsProducts(request.BatchRecords, request.Skip, request.CodigoCliente, request.CnpjCpf);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override ListPricesResponse OnListPricesExecute(ListPricesRequest request)
        {
            var budgetFactory = new BudgetFactory();
            var response = new ListPricesResponse();

            try
            {
                response.ListPrices = budgetFactory.CreateBudget(request.Items, request.ClientCode, request.CnpjCpf, true, true);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override ListStocksResponse OnListStocksExecute(ListStocksRequest request)
        {
            var stockFactory = new StockFactory();
            var response = new ListStocksResponse();

            try
            {
                response.ListStocks = stockFactory.ListStocks(request.ItemCode);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override CreateBudgetResponse OnCreateBudgetExecute(CreateBudgetRequest request)
        {
            var budgetFactory = new BudgetFactory();
            var response = new CreateBudgetResponse();

            try
            {
                response.CreateBudget = budgetFactory.CreateBudget(request.Items, request.ClientCode, request.CnpjCpf, false, false);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override CreateOrderResponse OnCreateOrderExecute(CreateOrderRequest request)
        {
            var budgetFactory = new BudgetFactory();
            var response = new CreateOrderResponse();

            try
            {
                var budget = budgetFactory.CreateBudget(request.Items, request.ClientCode, request.CnpjCpf, false, false);
                if (budget.Items != null && budget.Items.Any())
                {
                    response.Order = budgetFactory.CreateBudget(budget.Items.FirstOrDefault().BudgetId, request.PaymentConditionCode);
                }
                else
                    throw new Exception("Nenhum item foi criado no orçamento");
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override SyncPaymentMethodsResponse OnSyncPaymentMethodsExecute(SyncPaymentMethodsRequest request)
        {
            var syncItemsFactory = new SyncItemsFactory();
            var response = new SyncPaymentMethodsResponse();

            try
            {
                response.SyncPaymentMethods = syncItemsFactory.SyncPaymentMethods();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override GetDeliveryTimeResponse OnGetDeliveryTimeExecute(GetDeliveryTimeRequest request)
        {
            IFoccoWebPrazoRepository repository = new FoccoWebPrazoRepository();
            var response = new GetDeliveryTimeResponse();

            try
            {
                response.DeliveryTime = repository.Query(x => (request.CodeTo == 0 || x.CodigoEmpresaPara == request.CodeTo) &&
                                                              (request.CodeFrom == 0 || x.CodigoEmpresaDe == request.CodeFrom))
                                                   .Select(x => new DeliveryTime()
                                                   {
                                                       Id = x.Id,
                                                       From = x.CodigoEmpresaDe,
                                                       To = x.CodigoEmpresaPara,
                                                       TimeInDays = x.PrazoDias
                                                   }).ToList();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }

        public override SaveDeliveryTimeResponse OnSaveDeliveryTimeExecute(SaveDeliveryTimeRequest request)
        {
            IFoccoWebPrazoRepository repository = new FoccoWebPrazoRepository();
            var response = new SaveDeliveryTimeResponse();

            try
            {
                var item = repository.Get(request.DeliveryTime.Id);
                item.CodigoEmpresaDe = request.DeliveryTime.From;
                item.CodigoEmpresaPara = request.DeliveryTime.To;
                item.PrazoDias = request.DeliveryTime.TimeInDays;
                repository.Update(item);
                this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }

            return response;
        }
        #endregion
    }
}
