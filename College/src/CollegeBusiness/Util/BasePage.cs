using System;
using System.Web.UI;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Linq;
using CollegeBusiness.Model;

namespace CollegeBusiness.Util
{
    public class BasePage : System.Web.UI.Page
    {
        public cBusinessWeb _business;
        public long _enterpriseId;
        public cLogin _login;
        public long _courseId;        
        public long _enrollmentId;
        public long _moduleId;
        public long _resourceId;
        public long _blockId;
        public int _testStatus;
        public BasePage()
        {
            _enterpriseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["ac"]));
            _courseId = (HttpContext.Current.Request.QueryString["c"] != null ? Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["c"])) : 0);
            _enrollmentId = (HttpContext.Current.Request.QueryString["enroll"] != null ? Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["enroll"])) : 0);
            _moduleId = (HttpContext.Current.Request.QueryString["m"] != null ? Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["m"])) : 0);
            _resourceId = (HttpContext.Current.Request.QueryString["r"] != null ? Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["r"])) : 0);
            _blockId = (HttpContext.Current.Request.QueryString["b"] != null ? Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["b"])) : 0);
            _testStatus = (HttpContext.Current.Request.QueryString["s"] != null ? Convert.ToInt32(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["s"])) : 0);
            _business = new cBusinessWeb(_enterpriseId);
            this.Init += new EventHandler(BasePage_Init);
        }

        protected void BasePage_Init(object sender, EventArgs e)
        {
            _login = _business.GetLogged();
        }
    }
}
