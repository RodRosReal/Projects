using System.CodeDom.Compiler;
using System.ServiceModel;
using Application.Messages;

namespace Application.Interfaces
{
	[GeneratedCode("Service Generator", "1.0")]
	[ServiceContract]
	public partial interface IFoccoErpApiCommands
	{
		[OperationContract]
		GetItemsCommandResponse GetItemsCommand (GetItemsCommandRequest request);
		[OperationContract]
		GetClientsCommandResponse GetClientsCommand (GetClientsCommandRequest request);
		[OperationContract]
		GetClientItemsCommandResponse GetClientItemsCommand (GetClientItemsCommandRequest request);
		[OperationContract]
		GetStockItemCommandResponse GetStockItemCommand (GetStockItemCommandRequest request);
		[OperationContract]
		GetPaymentConditionsCommandResponse GetPaymentConditionsCommand (GetPaymentConditionsCommandRequest request);
		[OperationContract]
		CreateBudgetItemCommandResponse CreateBudgetItemCommand (CreateBudgetItemCommandRequest request);
		[OperationContract]
		UpdateBudgetItemCommandResponse UpdateBudgetItemCommand (UpdateBudgetItemCommandRequest request);
		[OperationContract]
		UpdateBudgetPaymentConditionCommandResponse UpdateBudgetPaymentConditionCommand (UpdateBudgetPaymentConditionCommandRequest request);
		[OperationContract]
		GetBudgetCommandResponse GetBudgetCommand (GetBudgetCommandRequest request);
		[OperationContract]
		DeleteBudgetItemCommandResponse DeleteBudgetItemCommand (DeleteBudgetItemCommandRequest request);
		[OperationContract]
		DeleteBudgetCommandResponse DeleteBudgetCommand (DeleteBudgetCommandRequest request);
		[OperationContract]
		CreateOrderCommandResponse CreateOrderCommand (CreateOrderCommandRequest request);
			
	}
}
