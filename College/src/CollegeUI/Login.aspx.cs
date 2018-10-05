using CollegeBusiness;
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
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string AjaxLogin(string email, string password)
        {
            return cBusinessAjax.Login(email, password);
        }
    }
}