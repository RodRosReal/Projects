using System;
using Application.Interfaces;
using Application.Messages;

namespace Application.Services
{
	public abstract partial class ApiCommandBase : IApiCommand
	{
		#region Constructor
		protected ApiCommandBase()
		{
				
			GetAcademyInitialization += OnApiCommandInitialization;
        	GetAcademyExecute += OnGetAcademyExecute;
        	GetAcademyComplete += OnApiCommandComplete;
        	GetAcademyError += OnApiCommandError;
				
		}
		#endregion
		
		#region Operation Events
		
		public event Action< GetAcademyRequest, GetAcademyResponse> GetAcademyInitialization;
		public event Func< GetAcademyRequest, GetAcademyResponse> GetAcademyExecute;
		public event Action< GetAcademyRequest, GetAcademyResponse> GetAcademyComplete;
		public event Action< GetAcademyRequest, GetAcademyResponse, Exception> GetAcademyError;
		#endregion
		
		#region Abstract Service Methods
		public virtual void OnApiCommandInitialization(ApiCommandRequest request, ApiCommandResponse response) {}
      	public virtual void OnApiCommandComplete(ApiCommandRequest request, ApiCommandResponse response) {}
        public virtual void OnApiCommandError(ApiCommandRequest request, ApiCommandResponse response, Exception exception) { throw exception; }
		#endregion
		
		#region Abstract Operation Methods
				
		public abstract GetAcademyResponse OnGetAcademyExecute(GetAcademyRequest request);
		#endregion
		
		#region Operation Implementations
				
		public virtual GetAcademyResponse GetAcademy(GetAcademyRequest request) {
			var response = new GetAcademyResponse();
			try {
				// Raise Initialization Event
				var initialization = GetAcademyInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = GetAcademyExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = GetAcademyComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = GetAcademyError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				#endregion
	}
}
