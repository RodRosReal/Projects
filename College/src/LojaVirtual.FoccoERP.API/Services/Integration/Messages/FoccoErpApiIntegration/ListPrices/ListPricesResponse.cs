using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class ListPricesResponse 
	{
        [DataMember]
        public ListBudgetItem ListPrices { get; set; }
    } 
}
