using System;
using CollegeService.Interfaces;
using CollegeService.Messages;

namespace CollegeService.Services
{
	public abstract partial class CollegeServiceBase : ICollegeService
	{
		#region Constructor
		protected CollegeServiceBase()
		{
				
			FirstMethodInitialization += OnCollegeServiceInitialization;
        	FirstMethodExecute += OnFirstMethodExecute;
        	FirstMethodComplete += OnCollegeServiceComplete;
        	FirstMethodError += OnCollegeServiceError;
				
		}
		#endregion
		
		#region Operation Events
		
		public event Action< FirstMethodRequest, FirstMethodResponse> FirstMethodInitialization;
		public event Func< FirstMethodRequest, FirstMethodResponse> FirstMethodExecute;
		public event Action< FirstMethodRequest, FirstMethodResponse> FirstMethodComplete;
		public event Action< FirstMethodRequest, FirstMethodResponse, Exception> FirstMethodError;
		#endregion
		
		#region Abstract Service Methods
		public virtual void OnCollegeServiceInitialization(CollegeServiceRequest request, CollegeServiceResponse response) {}
      	public virtual void OnCollegeServiceComplete(CollegeServiceRequest request, CollegeServiceResponse response) {}
        public virtual void OnCollegeServiceError(CollegeServiceRequest request, CollegeServiceResponse response, Exception exception) { throw exception; }
		#endregion
		
		#region Abstract Operation Methods
				
		public abstract FirstMethodResponse OnFirstMethodExecute(FirstMethodRequest request);
		#endregion
		
		#region Operation Implementations
				
		public virtual FirstMethodResponse FirstMethod(FirstMethodRequest request) {
			var response = new FirstMethodResponse();
			try {
				// Raise Initialization Event
				var initialization = FirstMethodInitialization;
				if (initialization != null) initialization(request, response);
				// Raise Execute Event
				var execute = FirstMethodExecute;
				if (execute != null) response = execute(request);
				// Raise Complete Event
				var complete = FirstMethodComplete;
				if (complete != null) complete(request, response);
			}
			catch (Exception exception) {
				// Raise Error Event
				var error = FirstMethodError;
				if (error != null) error(request, response, exception);
			}
			return response;
		}
				#endregion
	}
}
