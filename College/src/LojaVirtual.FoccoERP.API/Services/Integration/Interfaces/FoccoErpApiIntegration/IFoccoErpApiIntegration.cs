using System.CodeDom.Compiler;
using System.ServiceModel;
using Integration.Messages;

namespace Integration.Interfaces
{
	[GeneratedCode("Service Generator", "1.0")]
	[ServiceContract]
	public partial interface IFoccoErpApiIntegration
	{
		[OperationContract]
		SyncProductsResponse SyncProducts (SyncProductsRequest request);
		[OperationContract]
		SyncClientsProductsResponse SyncClientsProducts (SyncClientsProductsRequest request);
		[OperationContract]
		ListPricesResponse ListPrices (ListPricesRequest request);
		[OperationContract]
		ListStocksResponse ListStocks (ListStocksRequest request);
		[OperationContract]
		CreateBudgetResponse CreateBudget (CreateBudgetRequest request);
		[OperationContract]
		CreateOrderResponse CreateOrder (CreateOrderRequest request);
		[OperationContract]
		SyncPaymentMethodsResponse SyncPaymentMethods (SyncPaymentMethodsRequest request);
		[OperationContract]
		GetDeliveryTimeResponse GetDeliveryTime (GetDeliveryTimeRequest request);
		[OperationContract]
		SaveDeliveryTimeResponse SaveDeliveryTime (SaveDeliveryTimeRequest request);
			
	}
}
