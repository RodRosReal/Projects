using Domain.Dto;
using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetAcademyResponse 
	{
        [DataMember]
        public AcademyDto Academy { get; set; }
    } 
}
