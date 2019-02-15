using System;

namespace Domain.ValueObjects
{
    public class BaseResponse
    {
        public bool Success
        {
            get
            {
                if (this.Exception != null)
                    return false;
                else
                    return true;
            }
        }

        public Exception Exception { get; set; }

        public string Message { get; set; }
    }
}
