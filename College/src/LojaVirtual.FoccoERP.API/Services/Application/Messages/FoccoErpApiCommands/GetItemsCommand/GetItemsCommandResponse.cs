using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
    [DataContract]
	public partial class GetItemsCommandResponse 
	{
        [DataMember]
        public GetItemsResponse GetItemsResponse { get; set; }
    } 
}
