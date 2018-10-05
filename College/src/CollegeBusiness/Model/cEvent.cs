using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    public class cEvent
    {
        public long eventId { get; set; }
        public string name { get; set; }
        public DateTime dateInit { get; set; }
        public DateTime? dateFinish { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }
}
