using System.CodeDom.Compiler;
using System.ServiceModel;
using CollegeService.Messages;

namespace CollegeService.Interfaces
{
	[GeneratedCode("Softm�vel Service Generator", "1.0")]
	[ServiceContract]
	public partial interface ICollegeService
	{
		[OperationContract]
		FirstMethodResponse FirstMethod (FirstMethodRequest request);
			
	}
}
