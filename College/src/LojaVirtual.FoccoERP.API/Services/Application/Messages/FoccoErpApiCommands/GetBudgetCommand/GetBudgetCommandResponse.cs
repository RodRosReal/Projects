using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetBudgetCommandResponse 
	{
        [DataMember]
        public GetBudgetResponse GetBudgetResponse { get; set; }
    } 
}
