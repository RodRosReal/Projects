using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
    [DataContract]
    public partial class GetItemsCommandRequest
    {
        [DataMember]
        public GetItemsRequest GetItemsRequest { get; set; }
    }
}
