using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class UpdateBudgetPaymentConditionCommandResponse 
	{
        [DataMember]
        public UpdateBudgetPaymentConditionResponse UpdateBudgetPaymentConditionResponse { get; set; }
    } 
}
