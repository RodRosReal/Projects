using Domain.ValueObjects.Base;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class CreateOrderResponse 
	{
        public Order Order { get; set; }
    } 
}
