using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class SyncClientsProductsResponse 
	{
        [DataMember]
        public SyncItems SyncClientsProducts { get; set; }
    } 
}
