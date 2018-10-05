using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CollegeBusiness.Util;

namespace CollegeBusiness.Model
{
    [Serializable]
    public class cCourse
    {
        public long courseId { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public int order { get; set; }
        public double performance { get; set; }
        public string description { get; set; }
        public string coin { get; set; }
        public decimal value { get; set; }
        public List<cModule> modules{ get; set; }
        public string paymentTrasaction { get; set; }
        public string codeTrasaction { get; set; }
        public long enrollmentId { get; set; }
        public DateTime dateEnrollment { get; set; }
        public long userId { get; set; }
    }
    [Serializable]
    public class cModule
    {
        public long moduleId { get; set; }
        public string name { get; set; }
        public string page { get; set; }
        public cEnum.statusModule status { get; set; }
        public int order { get; set; }
        public List<cBlock> blocks { get; set; }
        public cResource resource { get; set; }
        public cEnum.statusTest statusTest { get; set; }
    }
    [Serializable]
    public class cResource
    {
        public long resourdeId { get; set; }
        public string name { get; set; }
        public string page { get; set; }
        public cEnum.statusResource status { get; set; }
    }
    [Serializable]
    public class cBlock
    {
        public long blockId { get; set; }
        public long moduleId { get; set; }
        public string name { get; set; }
        public string page { get; set; }
        public cEnum.statusBlock status { get; set; }
        public int order { get; set; }
        public cEnum.statusExercise statusExercise { get; set; }
    }
}
