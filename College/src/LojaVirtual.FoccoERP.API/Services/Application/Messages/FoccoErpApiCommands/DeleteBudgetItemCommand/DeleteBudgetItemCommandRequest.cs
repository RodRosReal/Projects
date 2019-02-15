using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class DeleteBudgetItemCommandRequest 
	{
        [DataMember]
        public DeleteBudgetItemRequest DeleteBudgetItemRequest { get; set; }
    } 
}
