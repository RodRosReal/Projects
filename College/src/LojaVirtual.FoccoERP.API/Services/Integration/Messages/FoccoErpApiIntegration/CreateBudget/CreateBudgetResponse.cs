using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class CreateBudgetResponse 
	{
        [DataMember]
        public ListBudgetItem CreateBudget { get; set; }
    } 
}
