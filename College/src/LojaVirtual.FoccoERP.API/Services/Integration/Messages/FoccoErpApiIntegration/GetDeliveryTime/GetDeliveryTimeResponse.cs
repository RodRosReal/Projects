using Domain.ValueObjects.Base;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class GetDeliveryTimeResponse 
	{
        public List<DeliveryTime> DeliveryTime { get; set; }
    } 
}
