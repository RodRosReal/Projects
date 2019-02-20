using System.Runtime.Serialization;
namespace Application.Messages
{
	[DataContract]
	public partial class GetAcademyRequest 
	{
        [DataMember]
        public int AcademyId { get; set; }
    } 
}
