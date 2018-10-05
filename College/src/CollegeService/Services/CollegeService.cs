using System;
using CollegeService.Interfaces;
using CollegeService.Messages;

namespace CollegeService.Services
{
	public class CollegeService : CollegeServiceBase
	{
		#region Constructor
		protected CollegeService()
		{

		}
		#endregion
		
		#region Operation Methods Implementation
		public override FirstMethodResponse OnFirstMethodExecute(FirstMethodRequest request)
        {
            var response = new FirstMethodResponse();
            //<IMPLEMENT HERE>
            return response;
        }
		#endregion
	}
}
