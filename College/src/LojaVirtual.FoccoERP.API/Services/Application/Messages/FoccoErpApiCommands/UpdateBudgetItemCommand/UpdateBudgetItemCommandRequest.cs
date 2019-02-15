using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class UpdateBudgetItemCommandRequest 
	{
        [DataMember]
        public UpdateBudgetItemRequest UpdateBudgetItemRequest { get; set; }
    } 
}
