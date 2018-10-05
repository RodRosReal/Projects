using CollegeBusiness;
using CollegeBusiness.Model;
using CollegeBusiness.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI
{
    public partial class Forgot : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool AjaxForgot(string email)
        {
            return cBusinessAjax.Forgot(new cEmail()
                {
                    EmailTo = email
                });
        }
    }
}