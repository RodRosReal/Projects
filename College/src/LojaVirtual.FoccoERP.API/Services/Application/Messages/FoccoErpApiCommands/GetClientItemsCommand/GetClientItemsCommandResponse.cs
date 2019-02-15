using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
    [DataContract]
	public partial class GetClientItemsCommandResponse 
	{
        [DataMember]
        public GetClientItemsResponse GetClientItemsResponse { get; set; }
    } 
}
