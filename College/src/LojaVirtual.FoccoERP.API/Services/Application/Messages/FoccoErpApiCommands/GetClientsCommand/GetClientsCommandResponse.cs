using Domain.ValueObjects;
using System.Runtime.Serialization;
namespace Application.Messages
{
    [DataContract]
	public partial class GetClientsCommandResponse 
	{
        [DataMember]
        public GetClientsResponse GetClientsResponse { get; set; }
    } 
}
