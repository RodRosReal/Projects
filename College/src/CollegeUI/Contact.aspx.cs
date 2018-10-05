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
    public partial class Contact : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cEnterprise enterprise = _business.GetEnterprise();
                wucContact._enterprise = enterprise;
            }
        }

        [WebMethod]
        public static bool AjaxContact(string name, string email, string message)
        {
            return cBusinessAjax.SendContact(name, email, message);
        }
    }
}