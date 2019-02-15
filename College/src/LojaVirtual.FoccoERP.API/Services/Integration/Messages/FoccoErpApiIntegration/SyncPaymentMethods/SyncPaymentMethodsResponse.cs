using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class SyncPaymentMethodsResponse 
	{
        [DataMember]
        public SyncItems SyncPaymentMethods { get; set; }
    } 
}
