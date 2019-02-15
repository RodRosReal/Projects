using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class CreateOrderCommandRequest 
	{
        [DataMember]
        public CreateOrderRequest CreateOrderRequest { get; set; }
    } 
}
