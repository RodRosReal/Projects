using Domain.ValueObjects.Base;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Integration.Messages
{
	[DataContract]
	public partial class CreateBudgetRequest 
	{
        [DataMember]
        public int ClientCode { get; set; }

        [DataMember]
        public long CnpjCpf { get; set; }

        [DataMember]
        public List<BagItem> Items { get; set; }
    } 
}
