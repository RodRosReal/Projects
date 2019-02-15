using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class Settings
    {
        public string BaseUrl { get; set; }

        public RequestAccess RequestAccess { get; set; }

    }
}
