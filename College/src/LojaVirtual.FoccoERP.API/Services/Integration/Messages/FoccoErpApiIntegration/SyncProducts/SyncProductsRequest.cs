using System.Runtime.Serialization;
namespace Integration.Messages
{
    [DataContract]
    public partial class SyncProductsRequest
    {
        [DataMember]
        public int BatchRecords { get; set; }

        [DataMember]
        public int Skip { get; set; }
    }
}
