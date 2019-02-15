using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class CreateOrderCommandResponse 
	{
        [DataMember]
        public CreateOrderResponse CreateOrderResponse { get; set; }
    } 
}
