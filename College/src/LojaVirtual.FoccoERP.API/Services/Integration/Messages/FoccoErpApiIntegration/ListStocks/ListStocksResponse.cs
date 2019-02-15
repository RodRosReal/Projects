using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class ListStocksResponse 
	{
        [DataMember]
        public ListStocks ListStocks { get; set; }
    } 
}
