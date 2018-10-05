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
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptBanners.DataSource = _business.GetBanners();
                rptBanners.DataBind();

                wucTestimonials._testimonials = _business.GetTestimonials();
                wucTestimonials._enterpriseId = _enterpriseId;

                List<cEvent> events = _business.GetEvents();
                wucEvents._events = events;
                wucEvents._qtd = 2;
                wucVideos._events = events;
            }
        }

        protected void rptBanners_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cBanner item = (cBanner)e.Item.DataItem;

                Image imgBanner = (Image)e.Item.FindControl("imgBanner");
                imgBanner.ImageUrl = "~/assets/"+ _enterpriseId +"/slides/slide-"+item.bannerId+".jpg";

                Literal ltMainCaption = (Literal)e.Item.FindControl("ltMainCaption");
                ltMainCaption.Text = item.mainCaption;

                Literal ltSecondaryCaption = (Literal)e.Item.FindControl("ltSecondaryCaption");
                ltSecondaryCaption.Text = item.secondaryCaption;
            }
        }

        [WebMethod]
        public static List<cTeacher> AjaxGetTeacher()
        {
            return cBusinessAjax.GetLogged().teacher;
        }
    }
}