using System;
using System.Web.UI;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Linq;
using System.IO;
using CollegeData;
using CollegeBusiness.Model;

namespace CollegeBusiness.Util
{
    public class BaseMaster : MasterPage
    {
        public cBusinessWeb _business;
        public long _enterpriseId;
        public cLogin _login;
        public long _courseId;

        public BaseMaster()
        {
            _enterpriseId = Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["ac"]));
            _courseId = (HttpContext.Current.Request.QueryString["c"] != null ? Convert.ToInt64(cWebCrypto.Decrypt(HttpContext.Current.Request.QueryString["c"])) : 0);
            _business = new cBusinessWeb(_enterpriseId);
            this.Init += new EventHandler(BaseMaster_Init);
        }

        protected void BaseMaster_Init(object sender, EventArgs e)
        {
            Response.AddHeader("P3P", "CP=\"IDC DSP COR CURa ADM ADMa DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT PHY ONL COM STA\"");
            ACAD_ACADEMIAS academia = _business.GetAcademy();
            if (academia != null)
            {
                _login = _business.GetLogged();

                Page.Title = academia.NM_ACADEMIA;

                HtmlLink css = new HtmlLink();
                css.Href = "assets/" + _enterpriseId.ToString() + "/favicon.ico";
                css.Attributes["rel"] = "shortcut icon";
                css.Attributes["type"] = "image/x-icon";
                Page.Header.Controls.Add(css);

                css = new HtmlLink();
                css.Href = "assets/" + _enterpriseId.ToString() + "/favicon.ico";
                css.Attributes["rel"] = "icon";
                css.Attributes["type"] = "image/ico";
                Page.Header.Controls.Add(css);

                HtmlMeta meta = new HtmlMeta();

                meta = new HtmlMeta();
                meta.Name = "description";
                meta.Content = academia.TX_META_DESCRIPTION;
                Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "keywords";
                meta.Content = academia.TX_META_KEYWORDS;
                Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "robots";
                meta.Content = academia.TX_META_ROBOTS;
                Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "googlebot";
                meta.Content = academia.TX_META_GOOGLEBOT;
                Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "generator";
                meta.Content = academia.TX_META_GENERATOR;
                Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "revisit-after";
                meta.Content = academia.TX_META_REVISITE_AFTER;
                Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "date";
                meta.Content = DateTime.Now.ToString("yyyy-MM-dd");
                meta.Scheme = "YYYY-MM-DD";
                Page.Header.Controls.Add(meta);
            }
        }
    }
}
