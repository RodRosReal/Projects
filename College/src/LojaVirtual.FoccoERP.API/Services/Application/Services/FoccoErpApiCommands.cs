using Application.Messages;
using Application.Services;
using Domain.ValueObjects;
using Infrastructure.FoccoErpApi;
using System;

namespace Application.Services
{
    public class FoccoErpApiCommands : FoccoErpApiCommandsBase
	{
        protected readonly ApiCommands _apiCommands;

        #region Constructor
        public FoccoErpApiCommands(Settings settings)
		{
            _apiCommands = new ApiCommands(settings);
        }
		#endregion
		
		#region Operation Methods Implementation
		public override GetItemsCommandResponse OnGetItemsCommandExecute(GetItemsCommandRequest request)
        {
            var response = new GetItemsCommandResponse();
            try
            {
                response.GetItemsResponse = _apiCommands.ApiGetItems(request.GetItemsRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override GetClientsCommandResponse OnGetClientsCommandExecute(GetClientsCommandRequest request)
        {
            var response = new GetClientsCommandResponse();
            try
            {
                response.GetClientsResponse = _apiCommands.ApiGetClients();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override GetClientItemsCommandResponse OnGetClientItemsCommandExecute(GetClientItemsCommandRequest request)
        {
            var response = new GetClientItemsCommandResponse();
            try
            {
                response.GetClientItemsResponse = _apiCommands.ApiGetClientItems(request.GetClientItemsRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override GetStockItemCommandResponse OnGetStockItemCommandExecute(GetStockItemCommandRequest request)
        {
            var response = new GetStockItemCommandResponse();
            try
            {
                response.GetStockItemResponse = _apiCommands.ApiGetStockItem(request.GetStockItemRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override GetPaymentConditionsCommandResponse OnGetPaymentConditionsCommandExecute(GetPaymentConditionsCommandRequest request)
        {
            var response = new GetPaymentConditionsCommandResponse();
            try
            {
                response.GetPaymentConditionsResponse = _apiCommands.ApiGetPaymentConditions();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override CreateBudgetItemCommandResponse OnCreateBudgetItemCommandExecute(CreateBudgetItemCommandRequest request)
        {
            var response = new CreateBudgetItemCommandResponse();
            try
            {
                response.CreateBudgetItemResponse = _apiCommands.ApiCreateBudgetItem(request.CreateBudgetItemRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override UpdateBudgetItemCommandResponse OnUpdateBudgetItemCommandExecute(UpdateBudgetItemCommandRequest request)
        {
            var response = new UpdateBudgetItemCommandResponse();
            try
            {
                response.UpdateBudgetItemResponse = _apiCommands.ApiUpdateBudgetItem(request.UpdateBudgetItemRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override UpdateBudgetPaymentConditionCommandResponse OnUpdateBudgetPaymentConditionCommandExecute(UpdateBudgetPaymentConditionCommandRequest request)
        {
            var response = new UpdateBudgetPaymentConditionCommandResponse();
            try
            {
                response.UpdateBudgetPaymentConditionResponse = _apiCommands.ApiUpdateBudgetPaymentCondition(request.UpdateBudgetPaymentConditionRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override GetBudgetCommandResponse OnGetBudgetCommandExecute(GetBudgetCommandRequest request)
        {
            var response = new GetBudgetCommandResponse();
            try
            {
                response.GetBudgetResponse = _apiCommands.ApiGetBudget(request.GetBudgetRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override DeleteBudgetItemCommandResponse OnDeleteBudgetItemCommandExecute(DeleteBudgetItemCommandRequest request)
        {
            var response = new DeleteBudgetItemCommandResponse();
            try
            {
                response.DeleteBudgetItemResponse = _apiCommands.ApiDeleteBudgetItem(request.DeleteBudgetItemRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override DeleteBudgetCommandResponse OnDeleteBudgetCommandExecute(DeleteBudgetCommandRequest request)
        {
            var response = new DeleteBudgetCommandResponse();
            try
            {
                response.DeleteBudgetResponse = _apiCommands.ApiDeleteBudget(request.DeleteBudgetRequest);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }

        public override CreateOrderCommandResponse OnCreateOrderCommandExecute(CreateOrderCommandRequest request)
        {
            var response = new CreateOrderCommandResponse();
            try
            {
                response.CreateOrderResponse = _apiCommands.ApiCreateOrder(request.CreateOrderRequest);
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
