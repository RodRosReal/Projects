using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class CreateBudgetItemCommandRequest 
	{
        [DataMember]
        public CreateBudgetItemRequest CreateBudgetItemRequest { get; set; }
    } 
}
