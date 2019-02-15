using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class UpdateBudgetPaymentConditionCommandRequest 
	{
        [DataMember]
        public UpdateBudgetPaymentConditionRequest UpdateBudgetPaymentConditionRequest { get; set; }
    } 
}
