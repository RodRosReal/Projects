using System;
using Application.Interfaces;
using Application.Messages;

namespace Application.Services
{
	public class ApiCommand : ApiCommandBase
	{
		#region Constructor
		protected ApiCommand()
		{

		}
		#endregion
		
		#region Operation Methods Implementation
		public override GetAcademyResponse OnGetAcademyExecute(GetAcademyRequest request)
        {
            var response = new GetAcademyResponse();
            //<IMPLEMENT HERE>
            return response;
        }
		#endregion
	}
}
