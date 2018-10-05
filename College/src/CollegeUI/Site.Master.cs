using CollegeBusiness.Model;
using CollegeBusiness.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI
{
    public partial class Site : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hddLogged.Value = _login.userId == 0 ? "False" : "True";
            hddBaseQueryString.Value = "?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + (_login.userId == 0 ? "" : "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()));
            hddEspQueryString.Value = "?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + (_login.userId == 0 ? "" : "&user=" + cWebCrypto.Encrypt(_login.userId.ToString())) + (_courseId > 0 ? "" : "&c=" + cWebCrypto.Encrypt(_courseId.ToString()));

            if (!IsPostBack)
            {
                imgLogo.ImageUrl = "~/assets/" + _enterpriseId + "/logo.png";
            }
        }
    }
}