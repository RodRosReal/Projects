using CollegeBusiness.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI.wuc
{
    public partial class Events : System.Web.UI.UserControl
    {
        public List<cEvent> _events;
        public int _qtd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptEvents.DataSource = _events.Take(_qtd);
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
                hyEvent.Attributes.Add("href", item.url);
            }
        }
    }
}