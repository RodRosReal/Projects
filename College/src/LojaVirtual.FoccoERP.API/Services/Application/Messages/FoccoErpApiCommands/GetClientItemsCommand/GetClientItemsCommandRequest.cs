using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetClientItemsCommandRequest 
	{
        [DataMember]
        public GetClientItemsRequest GetClientItemsRequest { get; set; }
    } 
}
