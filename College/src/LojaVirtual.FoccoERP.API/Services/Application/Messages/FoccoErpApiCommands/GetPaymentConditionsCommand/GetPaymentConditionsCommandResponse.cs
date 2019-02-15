using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetPaymentConditionsCommandResponse 
	{
        [DataMember]
        public GetPaymentConditionsResponse GetPaymentConditionsResponse { get; set; }
    } 
}
