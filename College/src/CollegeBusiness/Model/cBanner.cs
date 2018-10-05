using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    public class cBanner
    {
        public long bannerId { get; set; }
        public string mainCaption { get; set; }
        public string secondaryCaption { get; set; }
        public DateTime dateInit { get; set; }
        public DateTime? dateFinish { get; set; }
    }
}
