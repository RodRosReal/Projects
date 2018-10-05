using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    [Serializable]
    public class cCredential
    {
        public long enterpriseId { get; set; }
        public long userId { get; set; }
        public long courseId { get; set; }
        public long enrollmentId { get; set; }
    }
}
