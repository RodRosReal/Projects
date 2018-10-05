using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    public class cUserTest
    {
        public long userTestId { get; set; }
        public string question { get; set; }
        public string reply { get; set; }
        public string correction { get; set; }
        public DateTime initDate { get; set; }
        public bool enabledEdit { get; set; }
    }
}
