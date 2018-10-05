using CollegeBusiness.Model;
using CollegeBusiness.Util;
using CollegeData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace CollegeBusiness
{
    public partial class cBusinessWeb
    {
        public readonly CollegeEntities _context;
        public readonly long _enterpriseId;

        public cBusinessWeb(long enterpriseId)
        {
            _context = cDataContextFactory.GetDataContext();
            _enterpriseId = enterpriseId;
        }

        public void Logout()
        {
            HttpContext.Current.Session["USER"] = null;
            HttpContext.Current.Session["ERROR"] = null;
            HttpContext.Current.Response.Redirect("~/Default.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()), true);
        }

        public cLogin GetLogged()
        {
            cLogin login = new cLogin();
            if (HttpContext.Current.Session["USER"] != null)
            {
                login = (cLogin)HttpContext.Current.Session["USER"];
                if (login.enterpriseId == _enterpriseId)
                {
                    return login;
                }
            }
            return login;
        }
    }
}
