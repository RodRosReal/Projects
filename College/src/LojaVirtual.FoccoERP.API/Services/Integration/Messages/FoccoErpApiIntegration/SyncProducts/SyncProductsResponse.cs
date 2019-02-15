using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Integration.Messages
{
    [DataContract]
    public partial class SyncProductsResponse
    {
        [DataMember]
        public SyncItems SyncProducts { get; set; }
    }
}
