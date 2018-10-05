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
    public partial class MyAccont : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              cUser user = _business.GetUser();
              if (user != null)
              {
                  name.Text = user.name;
                  surname.Text = user.surname;
                  cpf.Text = user.cpf;
                  email.Text = user.email;
                  tel.Text = user.tel;
                  cel.Text = user.cel;
              }
            }
        }

        [WebMethod]
        public static string AjaxSetUser(cUser user)
        {
            user.ip = cWebHelper.GetRemoteIp;
            return cBusinessAjax.SetUser(user);
        }
    }
}