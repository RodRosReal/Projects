using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetStockItemCommandRequest 
	{
        [DataMember]
        public GetStockItemRequest GetStockItemRequest { get; set; }
    } 
}
