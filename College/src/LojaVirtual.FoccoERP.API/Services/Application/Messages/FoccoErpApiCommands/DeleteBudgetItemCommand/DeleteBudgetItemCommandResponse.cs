using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class DeleteBudgetItemCommandResponse 
	{
        [DataMember]
        public DeleteBudgetItemResponse DeleteBudgetItemResponse { get; set; }
    } 
}
