using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    public class cFaq
    {
        public long faqId { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public int order { get; set; }
    }
}
