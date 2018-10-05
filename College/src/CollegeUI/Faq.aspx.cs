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
    public partial class Faq : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptFaq.DataSource = _business.GetFaq();
                rptFaq.DataBind();

                cEnterprise enterprise = _business.GetEnterprise();
                wucContact._enterprise = enterprise;
            }
        }
        protected void rptFaq_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cFaq faq = (cFaq)e.Item.DataItem;

                HyperLink hyCollapse = (HyperLink)e.Item.FindControl("hyCollapse");
                hyCollapse.Text = faq.question; 
                hyCollapse.Attributes.Add("href", "#collapse-" + (e.Item.ItemIndex + 1).ToString());

                Literal ltAnswer = (Literal)e.Item.FindControl("ltAnswer");
                ltAnswer.Text = Server.HtmlDecode(faq.answer);

                Panel pnCollapse = (Panel)e.Item.FindControl("pnCollapse");                
                pnCollapse.ID = "collapse-" + (e.Item.ItemIndex + 1).ToString();
            }
        }
    }
}