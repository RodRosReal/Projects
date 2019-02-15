using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Net;

namespace Infrastructure.FoccoErpApi
{
    public class ApiCommands : ApiClient
    {
        public readonly ApiAuthentication _apiAuthentication;

        public ApiCommands(Settings settings) : base(settings)
        {
            _apiAuthentication = new ApiAuthentication(settings);
        }

        public GetItemsResponse ApiGetItems(GetItemsRequest getItemsRequest)
        {
            var getItemsResponse = new GetItemsResponse();
            try
            {
                getItemsResponse = this.ExecuteApiGetItems(getItemsRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    getItemsResponse = this.ExecuteApiGetItems(getItemsRequest);
                }
            }

            return getItemsResponse;
        }

        public GetClientsResponse ApiGetClients()
        {
            var getClientsResponse = new GetClientsResponse();
            try
            {
                getClientsResponse.Rows = this.ExecuteApiGetClients();
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    getClientsResponse.Rows = this.ExecuteApiGetClients();
                }
            }

            return getClientsResponse;
        }

        public GetClientItemsResponse ApiGetClientItems(GetClientItemsRequest getClientItemsRequest)
        {
            var getClientItemsResponse = new GetClientItemsResponse();
            try
            {
                getClientItemsResponse = this.ExecuteApiGetClientItems(getClientItemsRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    getClientItemsResponse = this.ExecuteApiGetClientItems(getClientItemsRequest);
                }
            }
            return getClientItemsResponse;
        }

        public GetStockItemResponse ApiGetStockItem(GetStockItemRequest GetStockItemRequest)
        {
            var GetStockItemResponse = new GetStockItemResponse();
            try
            {
                GetStockItemResponse = this.ExecuteApiGetStockItem(GetStockItemRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    GetStockItemResponse = this.ExecuteApiGetStockItem(GetStockItemRequest);
                }
            }
            return GetStockItemResponse;
        }

        public GetPaymentConditionsResponse ApiGetPaymentConditions()
        {
            var GetPaymentConditionsResponse = new GetPaymentConditionsResponse();
            try
            {
                GetPaymentConditionsResponse.Rows = this.ExecuteApiGetPaymentConditions();
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    GetPaymentConditionsResponse.Rows = this.ExecuteApiGetPaymentConditions();
                }
            }

            return GetPaymentConditionsResponse;
        }

        public CreateBudgetItemResponse ApiCreateBudgetItem(CreateBudgetItemRequest createBudgetItemRequest)
        {
            var CreateBudgetItemResponse = new CreateBudgetItemResponse();
            try
            {
                CreateBudgetItemResponse = this.ExecuteApiCreateBudgetItem(createBudgetItemRequest);
                if (CreateBudgetItemResponse.Rows != null)
                    CreateBudgetItemResponse.Rows[0].CodigoItem = createBudgetItemRequest.CodigoItem;
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    CreateBudgetItemResponse = this.ExecuteApiCreateBudgetItem(createBudgetItemRequest);
                }
            }

            return CreateBudgetItemResponse;
        }

        public UpdateBudgetItemResponse ApiUpdateBudgetItem(UpdateBudgetItemRequest UpdateBudgetItemRequest)
        {
            var UpdateBudgetItemResponse = new UpdateBudgetItemResponse();
            try
            {
                UpdateBudgetItemResponse = this.ExecuteApiUpdateBudgetItem(UpdateBudgetItemRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    UpdateBudgetItemResponse = this.ExecuteApiUpdateBudgetItem(UpdateBudgetItemRequest);
                }
            }

            return UpdateBudgetItemResponse;
        }

        public UpdateBudgetPaymentConditionResponse ApiUpdateBudgetPaymentCondition(UpdateBudgetPaymentConditionRequest UpdateBudgetPaymentConditionRequest)
        {
            var UpdateBudgetPaymentConditionResponse = new UpdateBudgetPaymentConditionResponse();
            try
            {
                UpdateBudgetPaymentConditionResponse = this.ExecuteApiUpdateBudgetPaymentCondition(UpdateBudgetPaymentConditionRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    UpdateBudgetPaymentConditionResponse = this.ExecuteApiUpdateBudgetPaymentCondition(UpdateBudgetPaymentConditionRequest);
                }
            }
            return UpdateBudgetPaymentConditionResponse;
        }

        public GetBudgetResponse ApiGetBudget(GetBudgetRequest GetBudgetRequest)
        {
            var GetBudgetResponse = new GetBudgetResponse();
            try
            {
                GetBudgetResponse = this.ExecuteApiGetBudget(GetBudgetRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    GetBudgetResponse = this.ExecuteApiGetBudget(GetBudgetRequest);
                }
            }
            return GetBudgetResponse;
        }

        public DeleteBudgetItemResponse ApiDeleteBudgetItem(DeleteBudgetItemRequest DeleteBudgetItemRequest)
        {
            var DeleteBudgetItemResponse = new DeleteBudgetItemResponse();
            try
            {
                DeleteBudgetItemResponse = this.ExecuteApiDeleteBudgetItem(DeleteBudgetItemRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    DeleteBudgetItemResponse = this.ExecuteApiDeleteBudgetItem(DeleteBudgetItemRequest);
                }
            }
            return DeleteBudgetItemResponse;
        }

        public DeleteBudgetResponse ApiDeleteBudget(DeleteBudgetRequest DeleteBudgetRequest)
        {
            var DeleteBudgetResponse = new DeleteBudgetResponse();
            try
            {
                DeleteBudgetResponse = this.ExecuteApiDeleteBudget(DeleteBudgetRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    DeleteBudgetResponse = this.ExecuteApiDeleteBudget(DeleteBudgetRequest);
                }
            }
            return DeleteBudgetResponse;
        }

        public CreateOrderResponse ApiCreateOrder(CreateOrderRequest CreateOrderRequest)
        {
            var CreateOrderResponse = new CreateOrderResponse();
            try
            {
                CreateOrderResponse = this.ExecuteApiCreateOrder(CreateOrderRequest);
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    _apiAuthentication.GetToken(true);
                    CreateOrderResponse = this.ExecuteApiCreateOrder(CreateOrderRequest);
                }
            }
            return CreateOrderResponse;
        }




        private GetItemsResponse ExecuteApiGetItems(GetItemsRequest getItemsRequest)
        {
            return base.ExecutePost<GetItemsResponse>("api/Commands/Comercial.Ecommerce.WebServices.GetItensCommand", getItemsRequest, _apiAuthentication._authToken.Token);
        }

        private List<Client> ExecuteApiGetClients()
        {
            return base.ExecutePost<List<Client>>("api/Commands/Comercial.Ecommerce.WebServices.GetClientesCommand", _apiAuthentication._authToken.Token);
        }

        private GetClientItemsResponse ExecuteApiGetClientItems(GetClientItemsRequest getClientItemsRequest)
        {
            return base.ExecutePost<GetClientItemsResponse>("api/Commands/Comercial.Ecommerce.WebServices.GetItensClienteCommand", getClientItemsRequest, _apiAuthentication._authToken.Token);
        }

        private GetStockItemResponse ExecuteApiGetStockItem(GetStockItemRequest getStockItemRequest)
        {
            return base.ExecutePost<GetStockItemResponse>("api/Commands/Comercial.Ecommerce.WebServices.GetEstoqueItemCommand", getStockItemRequest, _apiAuthentication._authToken.Token);
        }

        private List<PaymentCondition> ExecuteApiGetPaymentConditions()
        {
            return base.ExecutePost<List<PaymentCondition>>("api/Commands/Comercial.Ecommerce.WebServices.GetCondicoesPagamentoCommand", _apiAuthentication._authToken.Token);
        }

        private CreateBudgetItemResponse ExecuteApiCreateBudgetItem(CreateBudgetItemRequest createBudgetItemRequest)
        {
            return base.ExecutePost<CreateBudgetItemResponse>("api/Commands/Comercial.Ecommerce.WebServices.CriaItemOrcamentoCommand", createBudgetItemRequest, _apiAuthentication._authToken.Token);
        }

        private UpdateBudgetItemResponse ExecuteApiUpdateBudgetItem(UpdateBudgetItemRequest UpdateBudgetItemRequest)
        {
            return base.ExecutePost<UpdateBudgetItemResponse>("api/Commands/Comercial.Ecommerce.WebServices.AtualizaItemOrcamentoCommand", UpdateBudgetItemRequest, _apiAuthentication._authToken.Token);
        }

        private UpdateBudgetPaymentConditionResponse ExecuteApiUpdateBudgetPaymentCondition(UpdateBudgetPaymentConditionRequest UpdateBudgetPaymentConditionRequest)
        {
            return base.ExecutePost<UpdateBudgetPaymentConditionResponse>("api/Commands/Comercial.Ecommerce.WebServices.AtualizaCondPagamentoCommand", UpdateBudgetPaymentConditionRequest, _apiAuthentication._authToken.Token);
        }

        private GetBudgetResponse ExecuteApiGetBudget(GetBudgetRequest GetBudgetRequest)
        {
            return base.ExecutePost<GetBudgetResponse>("api/Commands/Comercial.Ecommerce.WebServices.GetOrcamentoCommand", GetBudgetRequest, _apiAuthentication._authToken.Token);
        }

        private DeleteBudgetItemResponse ExecuteApiDeleteBudgetItem(DeleteBudgetItemRequest DeleteBudgetItemRequest)
        {
            return base.ExecutePost<DeleteBudgetItemResponse>("api/Commands/Comercial.Ecommerce.WebServices.ApagaItemOrcamentoCommand", DeleteBudgetItemRequest, _apiAuthentication._authToken.Token);
        }

        private DeleteBudgetResponse ExecuteApiDeleteBudget(DeleteBudgetRequest DeleteBudgetRequest)
        {
            return base.ExecutePost<DeleteBudgetResponse>("api/Commands/Comercial.Ecommerce.WebServices.ApagaOrcamentoCommand", DeleteBudgetRequest, _apiAuthentication._authToken.Token);
        }

        private CreateOrderResponse ExecuteApiCreateOrder(CreateOrderRequest CreateOrderRequest)
        {
            return base.ExecutePost<CreateOrderResponse>("api/Commands/Comercial.Ecommerce.WebServices.CriaPedidoCommand", CreateOrderRequest, _apiAuthentication._authToken.Token);
        }
    }
}
