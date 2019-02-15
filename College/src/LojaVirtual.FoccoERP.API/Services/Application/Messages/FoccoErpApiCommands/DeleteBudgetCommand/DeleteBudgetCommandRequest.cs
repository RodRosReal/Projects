using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class DeleteBudgetCommandRequest 
	{
        [DataMember]
        public DeleteBudgetRequest DeleteBudgetRequest { get; set; }
    } 
}
