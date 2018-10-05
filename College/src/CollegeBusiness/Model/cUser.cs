using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollegeBusiness.Model
{
    public class cUser
    {
        public long userId { get; set; }
        public long enterpriseId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string cel { get; set; }
        public string cpf { get; set; }
        public string password { get; set; }
        public string ip { get; set; }
    }
}
