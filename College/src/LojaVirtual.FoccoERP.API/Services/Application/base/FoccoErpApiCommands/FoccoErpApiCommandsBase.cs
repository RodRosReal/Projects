using System;
using Application.Interfaces;
using Application.Messages;

namespace Application.Services
{
	public abstract partial class FoccoErpApiCommandsBase : IFoccoErpApiCommands
	{
		#region Constructor
		protected FoccoErpApiCommandsBase()
		{
				
			GetItemsCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	GetItemsCommandExecute += OnGetItemsCommandExecute;
        	GetItemsCommandComplete += OnFoccoErpApiCommandsComplete;
        	GetItemsCommandError += OnFoccoErpApiCommandsError;
				
			GetClientsCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	GetClientsCommandExecute += OnGetClientsCommandExecute;
        	GetClientsCommandComplete += OnFoccoErpApiCommandsComplete;
        	GetClientsCommandError += OnFoccoErpApiCommandsError;
				
			GetClientItemsCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	GetClientItemsCommandExecute += OnGetClientItemsCommandExecute;
        	GetClientItemsCommandComplete += OnFoccoErpApiCommandsComplete;
        	GetClientItemsCommandError += OnFoccoErpApiCommandsError;
				
			GetStockItemCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	GetStockItemCommandExecute += OnGetStockItemCommandExecute;
        	GetStockItemCommandComplete += OnFoccoErpApiCommandsComplete;
        	GetStockItemCommandError += OnFoccoErpApiCommandsError;
				
			GetPaymentConditionsCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	GetPaymentConditionsCommandExecute += OnGetPaymentConditionsCommandExecute;
        	GetPaymentConditionsCommandComplete += OnFoccoErpApiCommandsComplete;
        	GetPaymentConditionsCommandError += OnFoccoErpApiCommandsError;
				
			CreateBudgetItemCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	CreateBudgetItemCommandExecute += OnCreateBudgetItemCommandExecute;
        	CreateBudgetItemCommandComplete += OnFoccoErpApiCommandsComplete;
        	CreateBudgetItemCommandError += OnFoccoErpApiCommandsError;
				
			UpdateBudgetItemCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	UpdateBudgetItemCommandExecute += OnUpdateBudgetItemCommandExecute;
        	UpdateBudgetItemCommandComplete += OnFoccoErpApiCommandsComplete;
        	UpdateBudgetItemCommandError += OnFoccoErpApiCommandsError;
				
			UpdateBudgetPaymentConditionCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	UpdateBudgetPaymentConditionCommandExecute += OnUpdateBudgetPaymentConditionCommandExecute;
        	UpdateBudgetPaymentConditionCommandComplete += OnFoccoErpApiCommandsComplete;
        	UpdateBudgetPaymentConditionCommandError += OnFoccoErpApiCommandsError;
				
			GetBudgetCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	GetBudgetCommandExecute += OnGetBudgetCommandExecute;
        	GetBudgetCommandComplete += OnFoccoErpApiCommandsComplete;
        	GetBudgetCommandError += OnFoccoErpApiCommandsError;
				
			DeleteBudgetItemCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	DeleteBudgetItemCommandExecute += OnDeleteBudgetItemCommandExecute;
        	DeleteBudgetItemCommandComplete += OnFoccoErpApiCommandsComplete;
        	DeleteBudgetItemCommandError += OnFoccoErpApiCommandsError;
				
			DeleteBudgetCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	DeleteBudgetCommandExecute += OnDeleteBudgetCommandExecute;
        	DeleteBudgetCommandComplete += OnFoccoErpApiCommandsComplete;
        	DeleteBudgetCommandError += OnFoccoErpApiCommandsError;
				
			CreateOrderCommandInitialization += OnFoccoErpApiCommandsInitialization;
        	CreateOrderCommandExecute += OnCreateOrderCommandExecute;
        	CreateOrderCommandComplete += OnFoccoErpApiCommandsComplete;
        	CreateOrderCommandError += OnFoccoErpApiCommandsError;
				
		}
		#endregion
		
		#region Operation Events
		
		public event Action< GetItemsCommandRequest, GetItemsCommandResponse> GetItemsCommandInitialization;
		public event Func< GetItemsCommandRequest, GetItemsCommandResponse> GetItemsCommandExecute;
		public event Action< GetItemsCommandRequest, GetItemsCommandResponse> GetItemsCommandComplete;
		public event Action< GetItemsCommandRequest, GetItemsCommandResponse, Exception> GetItemsCommandError;
		
		public event Action< GetClientsCommandRequest, GetClientsCommandResponse> GetClientsCommandInitialization;
		public event Func< GetClientsCommandRequest, GetClientsCommandResponse> GetClientsCommandExecute;
		public event Action< GetClientsCommandRequest, GetClientsCommandResponse> GetClientsCommandComplete;
		public event Action< GetClientsCommandRequest, GetClientsCommandResponse, Exception> GetClientsCommandError;
		
		public event Action< GetClientItemsCommandRequest, GetClientItemsCommandResponse> GetClientItemsCommandInitialization;
		public event Func< GetClientItemsCommandRequest, GetClientItemsCommandResponse> GetClientItemsCommandExecute;
		public event Action< GetClientItemsCommandRequest, GetClientItemsCommandResponse> GetClientItemsCommandComplete;
		public event Action< GetClientItemsCommandRequest, GetClientItemsCommandResponse, Exception> GetClientItemsCommandError;
		
		public event Action< GetStockItemCommandRequest, GetStockItemCommandResponse> GetStockItemCommandInitialization;
		public event Func< GetStockItemCommandRequest, GetStockItemCommandResponse> GetStockItemCommandExecute;
		public event Action< GetStockItemCommandRequest, GetStockItemCommandResponse> GetStockItemCommandComplete;
		public event Action< GetStockItemCommandRequest, GetStockItemCommandResponse, Exception> GetStockItemCommandError;
		
		public event Action< GetPaymentConditionsCommandRequest, GetPaymentConditionsCommandResponse> GetPaymentConditionsCommandInitialization;
		public event Func< GetPaymentConditionsCommandRequest, GetPaymentConditionsCommandResponse> GetPaymentConditionsCommandExecute;
		public event Action< GetPaymentConditionsCommandRequest, GetPaymentConditionsCommandResponse> GetPaymentConditionsCommandComplete;
		public event Action< GetPaymentConditionsCommandRequest, GetPaymentConditionsCommandResponse, Exception> GetPaymentConditionsCommandError;
		
		public event Action< CreateBudgetItemCommandRequest, CreateBudgetItemCommandResponse> CreateBudgetItemCommandInitialization;
		public event Func< CreateBudgetItemCommandRequest, CreateBudgetItemCommandResponse> CreateBudgetItemCommandExecute;
		public event Action< CreateBudgetItemCommandRequest, CreateBudgetItemCommandResponse> CreateBudgetItemCommandComplete;
		public event Action< CreateBudgetItemCommandRequest, CreateBudgetItemCommandResponse, Exception> CreateBudgetItemCommandError;
		
		public event Action< UpdateBudgetItemCommandRequest, UpdateBudgetItemCommandResponse> UpdateBudgetItemCommandInitialization;
		public event Func< UpdateBudgetItemCommandRequest, UpdateBudgetItemCommandResponse> UpdateBudgetItemCommandExecute;
		public event Action< UpdateBudgetItemCommandRequest, UpdateBudgetItemCommandResponse> UpdateBudgetItemCommandComplete;
		public event Action< UpdateBudgetItemCommandRequest, UpdateBudgetItemCommandResponse, Exception> UpdateBudgetItemCommandError;
		
		public event Action< UpdateBudgetPaymentConditionCommandRequest, UpdateBudgetPaymentConditionCommandResponse> UpdateBudgetPaymentConditionCommandInitialization;
		public event Func< UpdateBudgetPaymentConditionCommandRequest, UpdateBudgetPaymentConditionCommandResponse> UpdateBudgetPaymentConditionCommandExecute;
		public event Action< UpdateBudgetPaymentConditionCommandRequest, UpdateBudgetPaymentConditionCommandResponse> UpdateBudgetPaymentConditionCommandComplete;
		public event Action< UpdateBudgetPaymentConditionCommandRequest, UpdateBudgetPaymentConditionCommandResponse, Exception> UpdateBudgetPaymentConditionCommandError;
		
		public event Action< GetBudgetCommandRequest, GetBudgetCommandResponse> GetBudgetCommandInitialization;
		public event Func< GetBudgetCommandRequest, GetBudgetCommandResponse> GetBudgetCommandExecute;
		public event Action< GetBudgetCommandRequest, GetBudgetCommandResponse> GetBudgetCommandComplete;
		public event Action< GetBudgetCommandRequest, GetBudgetCommandResponse, Exception> GetBudgetCommandError;
		
		public event Action< DeleteBudgetItemCommandRequest, DeleteBudgetItemCommandResponse> DeleteBudgetItemCommandInitialization;
		public event Func< DeleteBudgetItemCommandRequest, DeleteBudgetItemCommandResponse> DeleteBudgetItemCommandExecute;
		public event Action< DeleteBudgetItemCommandRequest, DeleteBudgetItemCommandResponse> DeleteBudgetItemCommandComplete;
		public event Action< DeleteBudgetItemCommandRequest, DeleteBudgetItemCommandResponse, Exception> DeleteBudgetItemCommandError;
		
		public event Action< DeleteBudgetCommandRequest, DeleteBudgetCommandResponse> DeleteBudgetCommandInitialization;
		public event Func< DeleteBudgetCommandRequest, DeleteBudgetCommandResponse> DeleteBudgetCommandExecute;
		public event Action< DeleteBudgetCommandRequest, DeleteBudgetCommandResponse> DeleteBudgetCommandComplete;
		public event Action< DeleteBudgetCommandRequest, DeleteBudgetCommandResponse, Exception> DeleteBudgetCommandError;
		
		public event Action< CreateOrderCommandRequest, CreateOrderCommandResponse> CreateOrderCommandInitialization;
		public event Func< CreateOrderCommandRequest, CreateOrderCommandResponse> CreateOrderCommandExecute;
		public event Action< CreateOrderCommandRequest, CreateOrderCommandResponse> CreateOrderCommandComplete;
		public event Action< CreateOrderCommandRequest, CreateOrderCommandResponse, Exception> CreateOrderCommandError;
		#endregion
		
		#region Abstract Service Methods
		public virtual void OnFoccoErpApiCommandsInitialization(FoccoErpApiCommandsRequest request, FoccoErpApiCommandsResponse response) {}
      	public virtual void OnFoccoErpApiCommandsComplete(FoccoErpApiCommandsRequest request, FoccoErpApiCommandsResponse response) {}
        public virtual void OnFoccoErpApiCommandsError(FoccoErpApiCommandsRequest request, FoccoErpApiCommandsResponse response, Exception exception) { throw exception; }
		#endregion
		
		#region Abstract Operation Methods
				
		public abstract GetItemsCommandResponse OnGetItemsCommandExecute(GetItemsCommandRequest request);
				
		public abstract GetClientsCommandResponse OnGetClientsCommandExecute(GetClientsCommandRequest request);
				
		public abstract GetClientItemsCommandResponse OnGetClientItemsCommandExecute(GetClientItemsCommandRequest request);
				
		public abstract GetStockItemCommandResponse OnGetStockItemCommandExecute(GetStockItemCommandRequest request);
				
		public abstract GetPaymentConditionsCommandResponse OnGetPaymentConditionsCommandExecute(GetPaymentConditionsCommandRequest request);
				
		public abstract CreateBudgetItemCommandResponse OnCreateBudgetItemCommandExecute(CreateBudgetItemCommandRequest request);
				
		public abstract UpdateBudgetItemCommandResponse OnUpdateBudgetItemCommandExecute(UpdateBudgetItemCommandRequest request);
				
		public abstract UpdateBudgetPaymentConditionCommandResponse OnUpdateBudgetPaymentConditionCommandExecute(UpdateBudgetPaymentConditionCommandRequest request);
				
		public abstract GetBudgetCommandResponse OnGetBudgetCommandExecute(GetBudgetCommandRequest request);
				
		public abstract DeleteBudgetItemCommandResponse OnDeleteBudgetItemCommandExecute(DeleteBudgetItemCommandRequest request);
				
		public abstract DeleteBudgetCommandResponse OnDeleteBudgetCommandExecute(DeleteBudgetCommandRequest request);
				
		public abstract CreateOrderCommandResponse OnCreateOrderCommandExecute(CreateOrderCommandRequest request);
		#endregion
		
		#region Operation Implementations
				
		public virtual GetItemsCommandResponse GetItemsCommand(GetItemsCommandRequest request) {
			var response = new GetItemsCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = GetItemsCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetItemsCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetItemsCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetItemsCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetClientsCommandResponse GetClientsCommand(GetClientsCommandRequest request) {
			var response = new GetClientsCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = GetClientsCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetClientsCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetClientsCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetClientsCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetClientItemsCommandResponse GetClientItemsCommand(GetClientItemsCommandRequest request) {
			var response = new GetClientItemsCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = GetClientItemsCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetClientItemsCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetClientItemsCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetClientItemsCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetStockItemCommandResponse GetStockItemCommand(GetStockItemCommandRequest request) {
			var response = new GetStockItemCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = GetStockItemCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetStockItemCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetStockItemCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetStockItemCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetPaymentConditionsCommandResponse GetPaymentConditionsCommand(GetPaymentConditionsCommandRequest request) {
			var response = new GetPaymentConditionsCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = GetPaymentConditionsCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetPaymentConditionsCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetPaymentConditionsCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetPaymentConditionsCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual CreateBudgetItemCommandResponse CreateBudgetItemCommand(CreateBudgetItemCommandRequest request) {
			var response = new CreateBudgetItemCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = CreateBudgetItemCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = CreateBudgetItemCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = CreateBudgetItemCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = CreateBudgetItemCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual UpdateBudgetItemCommandResponse UpdateBudgetItemCommand(UpdateBudgetItemCommandRequest request) {
			var response = new UpdateBudgetItemCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = UpdateBudgetItemCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = UpdateBudgetItemCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = UpdateBudgetItemCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = UpdateBudgetItemCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual UpdateBudgetPaymentConditionCommandResponse UpdateBudgetPaymentConditionCommand(UpdateBudgetPaymentConditionCommandRequest request) {
			var response = new UpdateBudgetPaymentConditionCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = UpdateBudgetPaymentConditionCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = UpdateBudgetPaymentConditionCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = UpdateBudgetPaymentConditionCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = UpdateBudgetPaymentConditionCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual GetBudgetCommandResponse GetBudgetCommand(GetBudgetCommandRequest request) {
			var response = new GetBudgetCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = GetBudgetCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetBudgetCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetBudgetCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetBudgetCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual DeleteBudgetItemCommandResponse DeleteBudgetItemCommand(DeleteBudgetItemCommandRequest request) {
			var response = new DeleteBudgetItemCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = DeleteBudgetItemCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = DeleteBudgetItemCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = DeleteBudgetItemCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = DeleteBudgetItemCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual DeleteBudgetCommandResponse DeleteBudgetCommand(DeleteBudgetCommandRequest request) {
			var response = new DeleteBudgetCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = DeleteBudgetCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = DeleteBudgetCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = DeleteBudgetCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = DeleteBudgetCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				
		public virtual CreateOrderCommandResponse CreateOrderCommand(CreateOrderCommandRequest request) {
			var response = new CreateOrderCommandResponse();
			try {
				// Raise Initialization Event
				var initialization = CreateOrderCommandInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = CreateOrderCommandExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = CreateOrderCommandComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = CreateOrderCommandError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				#endregion
	}
}
