using CollegeBusiness.Model;
using CollegeBusiness.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI
{
    public partial class Events : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptEvents.DataSource = _business.GetEvents();
                rptEvents.DataBind();
            }
        }
        protected void rptEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string[] myDateTimePatterns = new string[] { "MM/dd/yy", "MM/dd/yyyy" };
                CultureInfo ci = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = ci.DateTimeFormat;

                cEvent item = (cEvent)e.Item.DataItem;

                Literal ltMonth = (Literal)e.Item.FindControl("ltMonth");
                ltMonth.Text = dtfi.AbbreviatedMonthGenitiveNames[item.dateInit.Month-1].ToUpper();

                Literal ltDay = (Literal)e.Item.FindControl("ltDay");
                ltDay.Text = String.Format("{0:dd}", item.dateInit);

                Literal ltEvent = (Literal)e.Item.FindControl("ltEvent");
                ltEvent.Text = item.name;

                Literal ltHour = (Literal)e.Item.FindControl("ltHour");
                ltHour.Text = String.Format("{0:HH:mm}", item.dateInit) + (item.dateFinish.HasValue ? " - " + String.Format("{0:HH:mm}", item.dateFinish.Value) : "");

                HyperLink hyEvent = (HyperLink)e.Item.FindControl("hyEvent");
                hyEvent.Text = "Assista";
                hyEvent.Attributes.Add("video", item.url);

                Literal ltDescription = (Literal)e.Item.FindControl("ltDescription");
                ltDescription.Text = item.description;

                if (e.Item.ItemIndex == 0)
                {
                    Literal ltVideo = (Literal)e.Item.FindControl("ltVideo");
                    ltVideo.Text = "<iframe class=\"iframe urlFeaturedEvent\" frameborder=\"0\" allowfullscreen=\"\"></iframe>";
                    hddUrlFeaturedEvent.Value = item.url;
                }
            }
        }
    }
}