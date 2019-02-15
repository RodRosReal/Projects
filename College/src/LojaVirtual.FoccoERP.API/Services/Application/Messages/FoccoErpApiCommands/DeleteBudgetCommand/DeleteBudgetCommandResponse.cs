using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class DeleteBudgetCommandResponse 
	{
        [DataMember]
        public DeleteBudgetResponse DeleteBudgetResponse { get; set; }
    } 
}
