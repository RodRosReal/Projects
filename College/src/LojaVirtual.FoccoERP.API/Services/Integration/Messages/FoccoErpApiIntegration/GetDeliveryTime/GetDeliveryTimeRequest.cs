using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class GetDeliveryTimeRequest 
	{
        public int CodeTo { get; set; }
        public int CodeFrom { get; set; }
    } 
}
