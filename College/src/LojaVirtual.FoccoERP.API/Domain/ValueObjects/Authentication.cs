using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class Authentication
    {
        public string Token { get; set; }
        public bool IsSuccessful { get; set; }
    }

    public class RequestAccess
    {
        public string ClientID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool KillOtherSessions { get; set; }
    }
}
