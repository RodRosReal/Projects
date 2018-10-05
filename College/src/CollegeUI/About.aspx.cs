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
    public partial class About : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cEnterprise enterprise = _business.GetEnterprise();
                imgAbout.ImageUrl = "assets/" + _enterpriseId.ToString() + "/about/about.jpg";
                ltAbout.Text = enterprise.description;

                cTestimonial testimonial = _business.GetTestimonials().FirstOrDefault();
                ltTestimonial.Text = testimonial.testimonial;
                ltTestimonialName.Text = testimonial.autor;
                ltTestimonialLocal.Text = testimonial.local;

                wucContact._enterprise = enterprise;
            }
        }
    }
}