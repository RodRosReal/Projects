using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class ListStocksRequest 
	{
        [DataMember]
        public string ItemCode { get; set; }
    } 
}
