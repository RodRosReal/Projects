using CollegeBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI.wuc
{
    public partial class Contact : System.Web.UI.UserControl
    {
        public cEnterprise _enterprise;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(_enterprise.tel))
                {
                    phTel.Visible = true;
                    ltTel.Text = _enterprise.tel;
                }
                ltEmail.Text = _enterprise.email;
            }
        }
    }
}