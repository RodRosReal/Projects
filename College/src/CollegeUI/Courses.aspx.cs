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
    public partial class Courses : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<cArea> areas = _business.GetCourses();
                rptTabs.DataSource = areas;
                rptTabs.DataBind();

                rptTab.DataSource = areas;
                rptTab.DataBind();

                cEnterprise enterprise = _business.GetEnterprise();
                wucContact._enterprise = enterprise;

                wucTestimonials._testimonials = _business.GetTestimonials();
                wucTestimonials._enterpriseId = _enterpriseId;
            }
        }

        protected void rptTabs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cArea item = (cArea)e.Item.DataItem;

                Literal ltTabs = (Literal)e.Item.FindControl("ltTabs");
                if (e.Item.ItemIndex == 0)
                {
                    ltTabs.Text = "<li class=\"active\"><a href=\"#tab1\" data-toggle=\"tab\">" + item.name + "</a></li>";
                }
                else
                {
                    ltTabs.Text = "<li><a href=\"#tab" + (e.Item.ItemIndex + 1).ToString() + "\" data-toggle=\"tab\">" + item.name + "</a></li>";
                }
            }
        }

        protected void rptTab_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cArea item = (cArea)e.Item.DataItem;

                Panel pnTab = (Panel)e.Item.FindControl("pnTab");
                pnTab.ID = "tab" + (e.Item.ItemIndex + 1).ToString();
                if (e.Item.ItemIndex == 0)
                    pnTab.CssClass = "tab-pane active";
                else
                    pnTab.CssClass = "tab-pane";

                Repeater rptTabContent = (Repeater)e.Item.FindControl("rptTabContent");
                rptTabContent.DataSource = item.courses;
                rptTabContent.DataBind();
            }
        }

        protected void rptTabContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cCourse item = (cCourse)e.Item.DataItem;

                HyperLink hyCourse = (HyperLink)e.Item.FindControl("hyCourse");
                hyCourse.Text = item.name;
                hyCourse.NavigateUrl = "Course.aspx?c=" + cWebCrypto.Encrypt(item.courseId.ToString());

                Image imgCourse = (Image)e.Item.FindControl("imgCourse");
                imgCourse.ImageUrl = "assets/" + _enterpriseId.ToString() + "/courses/course-thumb-" + item.courseId.ToString() + ".jpg";
            }
        }
    }
}