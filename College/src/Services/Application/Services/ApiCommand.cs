using Application.Factories;
using Application.Messages;
using Infrastructure.Repositories.Relational.Mappers;
using System;

namespace Application.Services
{
    public class ApiCommand : ApiCommandBase
	{
		#region Constructor
		public ApiCommand()
		{
            InitializeMappers.Configure();
        }
		#endregion
		
		#region Operation Methods Implementation
		public override GetAcademyResponse OnGetAcademyExecute(GetAcademyRequest request)
        {
            var academyFactory = new AcademyFactory();
            var response = new GetAcademyResponse();
            try
            {
                response.Academy = academyFactory.GetAcademy(request.AcademyId).Result;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = ex.Message;
            }
            return response;
        }
		#endregion
	}
}
