using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    public class cLogin
    {
        public long enterpriseId { get; set; }
        public long userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public List<cTeacher> teacher { get; set; }
    }

    public class cTeacher
    {
        public string courseId { get; set; }
        public string couseName { get; set; }
    }
}
