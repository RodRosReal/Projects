using CollegeBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI.wuc
{
    public partial class Testimonials : System.Web.UI.UserControl
    {
        public List<cTestimonial> _testimonials;
        public long _enterpriseId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptTestimonial.DataSource = _testimonials;
                rptTestimonial.DataBind();
            }
        }

        protected void rptTestimonial_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cTestimonial testimonial = (cTestimonial)e.Item.DataItem;

                Panel pnTestimonial = (Panel)e.Item.FindControl("pnTestimonial");
                if(e.Item.ItemIndex == 0)
                {
                    pnTestimonial.CssClass = "item active";
                }else{
                    pnTestimonial.CssClass = "item";
                }

                Literal ltTestimonial = (Literal)e.Item.FindControl("ltTestimonial");
                ltTestimonial.Text = testimonial.testimonial;

                Literal ltTestimonialName = (Literal)e.Item.FindControl("ltTestimonialName");
                ltTestimonialName.Text = testimonial.autor;

                Literal ltTestimonialLocal = (Literal)e.Item.FindControl("ltTestimonialLocal");
                ltTestimonialLocal.Text = testimonial.local;

                Image imgTestimonial = (Image)e.Item.FindControl("imgTestimonial");
                imgTestimonial.ImageUrl = "~/assets/" + _enterpriseId + "/testimonials/profile-" + testimonial.testimonialId + ".jpg";
            }
        }
    }
}