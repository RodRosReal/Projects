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
    public partial class Videos : System.Web.UI.UserControl
    {
        public List<cEvent> _events;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptVideos.DataSource = _events.Take(20);
                rptVideos.DataBind();
            }
        }

        protected void rptVideos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cEvent item = (cEvent)e.Item.DataItem;

                Panel pnVideo = (Panel)e.Item.FindControl("pnVideo");
                if (e.Item.ItemIndex == 0)
                {
                    pnVideo.CssClass = "item active";
                }
                else
                {
                    pnVideo.CssClass = "item";
                }

                Literal ltVideo = (Literal)e.Item.FindControl("ltVideo");
                ltVideo.Text = "<iframe class='video-iframe' src='" + item.url + "' frameborder='0' allowfullscreen=''></iframe>";
            }
        }
    }
}