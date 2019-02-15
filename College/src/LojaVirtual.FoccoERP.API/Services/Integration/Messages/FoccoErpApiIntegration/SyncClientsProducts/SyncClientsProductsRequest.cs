using System.Runtime.Serialization;
namespace Integration.Messages
{
    [DataContract]
    public partial class SyncClientsProductsRequest
    {
        [DataMember]
        public int BatchRecords { get; set; }

        [DataMember]
        public int Skip { get; set; }

        [DataMember]
        public int CodigoCliente { get; set; }

        [DataMember]
        public long CnpjCpf { get; set; }
    }
}
