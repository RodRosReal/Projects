using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetBudgetCommandRequest 
	{
        [DataMember]
        public GetBudgetRequest GetBudgetRequest { get; set; }
    } 
}
