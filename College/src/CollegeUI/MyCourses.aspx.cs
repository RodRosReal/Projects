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
    public partial class MyCourses : BaseSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptMyCourses.DataSource = _business.GetMyCourses();
                rptMyCourses.DataBind();
            }
        }
        protected void rptMyCourses_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cCourse item = (cCourse)e.Item.DataItem;

                HyperLink hyCourse = (HyperLink)e.Item.FindControl("hyCourse");
                hyCourse.Text = item.name; 
                hyCourse.NavigateUrl = "Course.aspx?c=" + cWebCrypto.Encrypt(item.courseId.ToString());
                
                Literal ltPerformance = (Literal)e.Item.FindControl("ltPerformance");
                ltPerformance.Text = _business.GetMyCoursePerformance(item.courseId, item.enrollmentId).ToString();

                Literal ltSummary = (Literal)e.Item.FindControl("ltSummary");
                ltSummary.Text = item.summary;

                HiddenField hddEnrollmentId = (HiddenField)e.Item.FindControl("hddEnrollmentId");
                hddEnrollmentId.Value = cWebCrypto.Encrypt(item.enrollmentId.ToString());

                HiddenField hddCourseId = (HiddenField)e.Item.FindControl("hddCourseId");
                hddCourseId.Value = cWebCrypto.Encrypt(item.courseId.ToString());

                HyperLink hyMyCourse = (HyperLink)e.Item.FindControl("hyMyCourse");
                PlaceHolder phSendCode = (PlaceHolder)e.Item.FindControl("phSendCode");
                
                if (!string.IsNullOrEmpty(item.codeTrasaction))
                {
                    hyMyCourse.NavigateUrl = "MyCourse.aspx?enroll=" + cWebCrypto.Encrypt(item.enrollmentId.ToString()) + "&c=" + cWebCrypto.Encrypt(item.courseId.ToString());
                }
                else
                {
                    hyMyCourse.Visible = false;
                    phSendCode.Visible = true;
                }
            }
        }

        [WebMethod]
        public static bool AjaxSendCode(string code, string enrollment, string course)
        {
            return cBusinessAjax.AjaxSendCode(code, enrollment, course);
        }
    }
}