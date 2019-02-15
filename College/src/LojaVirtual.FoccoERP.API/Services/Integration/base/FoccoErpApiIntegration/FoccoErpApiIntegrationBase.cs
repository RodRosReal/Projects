using System;
using Integration.Interfaces;
using Integration.Messages;

namespace Integration.Services
{
	public abstract partial class FoccoErpApiIntegrationBase : IFoccoErpApiIntegration
	{
		#region Constructor
		protected FoccoErpApiIntegrationBase()
		{
				
			SyncProductsInitialization += OnFoccoErpApiIntegrationInitialization;
        	SyncProductsExecute += OnSyncProductsExecute;
        	SyncProductsComplete += OnFoccoErpApiIntegrationComplete;
        	SyncProductsError += OnFoccoErpApiIntegrationError;
				
			SyncClientsProductsInitialization += OnFoccoErpApiIntegrationInitialization;
        	SyncClientsProductsExecute += OnSyncClientsProductsExecute;
        	SyncClientsProductsComplete += OnFoccoErpApiIntegrationComplete;
        	SyncClientsProductsError += OnFoccoErpApiIntegrationError;
				
			ListPricesInitialization += OnFoccoErpApiIntegrationInitialization;
        	ListPricesExecute += OnListPricesExecute;
        	ListPricesComplete += OnFoccoErpApiIntegrationComplete;
        	ListPricesError += OnFoccoErpApiIntegrationError;
				
			ListStocksInitialization += OnFoccoErpApiIntegrationInitialization;
        	ListStocksExecute += OnListStocksExecute;
        	ListStocksComplete += OnFoccoErpApiIntegrationComplete;
        	ListStocksError += OnFoccoErpApiIntegrationError;
				
			CreateBudgetInitialization += OnFoccoErpApiIntegrationInitialization;
        	CreateBudgetExecute += OnCreateBudgetExecute;
        	CreateBudgetComplete += OnFoccoErpApiIntegrationComplete;
        	CreateBudgetError += OnFoccoErpApiIntegrationError;
				
			CreateOrderInitialization += OnFoccoErpApiIntegrationInitialization;
        	CreateOrderExecute += OnCreateOrderExecute;
        	CreateOrderComplete += OnFoccoErpApiIntegrationComplete;
        	CreateOrderError += OnFoccoErpApiIntegrationError;
				
			SyncPaymentMethodsInitialization += OnFoccoErpApiIntegrationInitialization;
        	SyncPaymentMethodsExecute += OnSyncPaymentMethodsExecute;
        	SyncPaymentMethodsComplete += OnFoccoErpApiIntegrationComplete;
        	SyncPaymentMethodsError += OnFoccoErpApiIntegrationError;
				
			GetDeliveryTimeInitialization += OnFoccoErpApiIntegrationInitialization;
        	GetDeliveryTimeExecute += OnGetDeliveryTimeExecute;
        	GetDeliveryTimeComplete += OnFoccoErpApiIntegrationComplete;
        	GetDeliveryTimeError += OnFoccoErpApiIntegrationError;
				
			SaveDeliveryTimeInitialization += OnFoccoErpApiIntegrationInitialization;
        	SaveDeliveryTimeExecute += OnSaveDeliveryTimeExecute;
        	SaveDeliveryTimeComplete += OnFoccoErpApiIntegrationComplete;
        	SaveDeliveryTimeError += OnFoccoErpApiIntegrationError;
				
		}
		#endregion
		
		#region Operation Events
		
		public event Action< SyncProductsRequest, SyncProductsResponse> SyncProductsInitialization;
		public event Func< SyncProductsRequest, SyncProductsResponse> SyncProductsExecute;
		public event Action< SyncProductsRequest, SyncProductsResponse> SyncProductsComplete;
		public event Action< SyncProductsRequest, SyncProductsResponse, Exception> SyncProductsError;
		
		public event Action< SyncClientsProductsRequest, SyncClientsProductsResponse> SyncClientsProductsInitialization;
		public event Func< SyncClientsProductsRequest, SyncClientsProductsResponse> SyncClientsProductsExecute;
		public event Action< SyncClientsProductsRequest, SyncClientsProductsResponse> SyncClientsProductsComplete;
		public event Action< SyncClientsProductsRequest, SyncClientsProductsResponse, Exception> SyncClientsProductsError;
		
		public event Action< ListPricesRequest, ListPricesResponse> ListPricesInitialization;
		public event Func< ListPricesRequest, ListPricesResponse> ListPricesExecute;
		public event Action< ListPricesRequest, ListPricesResponse> ListPricesComplete;
		public event Action< ListPricesRequest, ListPricesResponse, Exception> ListPricesError;
		
		public event Action< ListStocksRequest, ListStocksResponse> ListStocksInitialization;
		public event Func< ListStocksRequest, ListStocksResponse> ListStocksExecute;
		public event Action< ListStocksRequest, ListStocksResponse> ListStocksComplete;
		public event Action< ListStocksRequest, ListStocksResponse, Exception> ListStocksError;
		
		public event Action< CreateBudgetRequest, CreateBudgetResponse> CreateBudgetInitialization;
		public event Func< CreateBudgetRequest, CreateBudgetResponse> CreateBudgetExecute;
		public event Action< CreateBudgetRequest, CreateBudgetResponse> CreateBudgetComplete;
		public event Action< CreateBudgetRequest, CreateBudgetResponse, Exception> CreateBudgetError;
		
		public event Action< CreateOrderRequest, CreateOrderResponse> CreateOrderInitialization;
		public event Func< CreateOrderRequest, CreateOrderResponse> CreateOrderExecute;
		public event Action< CreateOrderRequest, CreateOrderResponse> CreateOrderComplete;
		public event Action< CreateOrderRequest, CreateOrderResponse, Exception> CreateOrderError;
		
		public event Action< SyncPaymentMethodsRequest, SyncPaymentMethodsResponse> SyncPaymentMethodsInitialization;
		public event Func< SyncPaymentMethodsRequest, SyncPaymentMethodsResponse> SyncPaymentMethodsExecute;
		public event Action< SyncPaymentMethodsRequest, SyncPaymentMethodsResponse> SyncPaymentMethodsComplete;
		public event Action< SyncPaymentMethodsRequest, SyncPaymentMethodsResponse, Exception> SyncPaymentMethodsError;
		
		public event Action< GetDeliveryTimeRequest, GetDeliveryTimeResponse> GetDeliveryTimeInitialization;
		public event Func< GetDeliveryTimeRequest, GetDeliveryTimeResponse> GetDeliveryTimeExecute;
		public event Action< GetDeliveryTimeRequest, GetDeliveryTimeResponse> GetDeliveryTimeComplete;
		public event Action< GetDeliveryTimeRequest, GetDeliveryTimeResponse, Exception> GetDeliveryTimeError;
		
		public event Action< SaveDeliveryTimeRequest, SaveDeliveryTimeResponse> SaveDeliveryTimeInitialization;
		public event Func< SaveDeliveryTimeRequest, SaveDeliveryTimeResponse> SaveDeliveryTimeExecute;
		public event Action< SaveDeliveryTimeRequest, SaveDeliveryTimeResponse> SaveDeliveryTimeComplete;
		public event Action< SaveDeliveryTimeRequest, SaveDeliveryTimeResponse, Exception> SaveDeliveryTimeError;
		#endregion
		
		#region Abstract Service Methods
		public virtual void OnFoccoErpApiIntegrationInitialization(FoccoErpApiIntegrationRequest request, FoccoErpApiIntegrationResponse response) {}
      	public virtual void OnFoccoErpApiIntegrationComplete(FoccoErpApiIntegrationRequest request, FoccoErpApiIntegrationResponse response) {}
        public virtual void OnFoccoErpApiIntegrationError(FoccoErpApiIntegrationRequest request, FoccoErpApiIntegrationResponse response, Exception exception) { throw exception; }
		#endregion
		
		#region Abstract Operation Methods
				
		public abstract SyncProductsResponse OnSyncProductsExecute(SyncProductsRequest request);
				
		public abstract SyncClientsProductsResponse OnSyncClientsProductsExecute(SyncClientsProductsRequest request);
				
		public abstract ListPricesResponse OnListPricesExecute(ListPricesRequest request);
				
		public abstract ListStocksResponse OnListStocksExecute(ListStocksRequest request);
				
		public abstract CreateBudgetResponse OnCreateBudgetExecute(CreateBudgetRequest request);
				
		public abstract CreateOrderResponse OnCreateOrderExecute(CreateOrderRequest request);
				
		public abstract SyncPaymentMethodsResponse OnSyncPaymentMethodsExecute(SyncPaymentMethodsRequest request);
				
		public abstract GetDeliveryTimeResponse OnGetDeliveryTimeExecute(GetDeliveryTimeRequest request);
				
		public abstract SaveDeliveryTimeResponse OnSaveDeliveryTimeExecute(SaveDeliveryTimeRequest request);
		#endregion
		
		#region Operation Implementations
				
		public virtual SyncProductsResponse SyncProducts(SyncProductsRequest request) {
			var response = new SyncProductsResponse();
			try {
				// Raise Initialization Event
				var initialization = SyncProductsInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = SyncProductsExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = SyncProductsComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = SyncProductsError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual SyncClientsProductsResponse SyncClientsProducts(SyncClientsProductsRequest request) {
			var response = new SyncClientsProductsResponse();
			try {
				// Raise Initialization Event
				var initialization = SyncClientsProductsInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = SyncClientsProductsExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = SyncClientsProductsComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = SyncClientsProductsError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual ListPricesResponse ListPrices(ListPricesRequest request) {
			var response = new ListPricesResponse();
			try {
				// Raise Initialization Event
				var initialization = ListPricesInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = ListPricesExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = ListPricesComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = ListPricesError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual ListStocksResponse ListStocks(ListStocksRequest request) {
			var response = new ListStocksResponse();
			try {
				// Raise Initialization Event
				var initialization = ListStocksInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = ListStocksExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = ListStocksComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = ListStocksError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual CreateBudgetResponse CreateBudget(CreateBudgetRequest request) {
			var response = new CreateBudgetResponse();
			try {
				// Raise Initialization Event
				var initialization = CreateBudgetInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = CreateBudgetExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = CreateBudgetComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = CreateBudgetError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual CreateOrderResponse CreateOrder(CreateOrderRequest request) {
			var response = new CreateOrderResponse();
			try {
				// Raise Initialization Event
				var initialization = CreateOrderInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = CreateOrderExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = CreateOrderComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = CreateOrderError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual SyncPaymentMethodsResponse SyncPaymentMethods(SyncPaymentMethodsRequest request) {
			var response = new SyncPaymentMethodsResponse();
			try {
				// Raise Initialization Event
				var initialization = SyncPaymentMethodsInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = SyncPaymentMethodsExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = SyncPaymentMethodsComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = SyncPaymentMethodsError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetDeliveryTimeResponse GetDeliveryTime(GetDeliveryTimeRequest request) {
			var response = new GetDeliveryTimeResponse();
			try {
				// Raise Initialization Event
				var initialization = GetDeliveryTimeInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetDeliveryTimeExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetDeliveryTimeComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetDeliveryTimeError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual SaveDeliveryTimeResponse SaveDeliveryTime(SaveDeliveryTimeRequest request) {
			var response = new SaveDeliveryTimeResponse();
			try {
				// Raise Initialization Event
				var initialization = SaveDeliveryTimeInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = SaveDeliveryTimeExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = SaveDeliveryTimeComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = SaveDeliveryTimeError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				#endregion
	}
}
