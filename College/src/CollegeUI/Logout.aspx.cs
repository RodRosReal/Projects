using CollegeBusiness.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI
{
    public partial class Logout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _business.Logout();
        }
    }
}