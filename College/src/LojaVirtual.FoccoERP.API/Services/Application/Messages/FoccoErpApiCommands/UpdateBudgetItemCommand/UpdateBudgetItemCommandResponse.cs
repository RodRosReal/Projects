using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class UpdateBudgetItemCommandResponse 
	{
        [DataMember]
        public UpdateBudgetItemResponse UpdateBudgetItemResponse { get; set; }
    } 
}
