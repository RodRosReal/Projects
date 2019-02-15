using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetStockItemCommandResponse 
	{
        [DataMember]
        public GetStockItemResponse GetStockItemResponse { get; set; }
    } 
}
