using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    public class cUserExercise
    {
        public long userExerciseId { get; set; }
        public string question { get; set; }
        public string reply { get; set; }
        public string correction { get; set; }
        public int order { get; set; }
        public int replyContent { get; set; }
    }
}
