using System;
using System.Web.UI;

namespace CollegeBusiness.Util
{
    public class BaseSession : BasePage
    {
        public bool _session = true;
        public BaseSession()
        {
            this.Init += new EventHandler(BaseSession_Init);
        }

        protected void BaseSession_Init(object sender, EventArgs e)
        {
            if (Session["USER"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.UtcNow.ToString(), "$(function() {if ((window.opener) && (window.opener.location)){$(window.opener.location).attr('href', '../Login.aspx?ac=' + $.QueryString('ac')); window.close();}else{$(location).attr('href', '../Login.aspx?ac=' + $.QueryString('ac'));}});", true);
                _session = false;
            }
        }
    }
}
