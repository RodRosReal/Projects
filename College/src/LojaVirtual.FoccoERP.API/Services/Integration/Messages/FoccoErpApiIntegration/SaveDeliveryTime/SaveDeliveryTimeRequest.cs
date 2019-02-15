using Domain.ValueObjects.Base;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class SaveDeliveryTimeRequest 
	{
        public DeliveryTime DeliveryTime { get; set; }
    } 
}
