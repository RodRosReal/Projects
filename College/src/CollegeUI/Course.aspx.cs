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
    public partial class Course : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cCourse course = _business.GetCourse(_courseId);
                if (course != null)
                {
                    ltCourseName.Text = course.name;
                    ltCourseNameLocal.Text = course.name;
                    imgCourseContent.ImageUrl = "assets/" + _enterpriseId.ToString() + "/courses/course-" + course.courseId.ToString() + ".jpg";


                    ltCourseContent.Text = course.description;
                    if (course.value == 0)
                    {
                        ltCourseValue.Text = "Com Código de Matrícula";
                        ltObs.Text = "Para se matricular neste curso é necessário possuir um Código de Matrícula válido.";
                    }
                    else
                    {
                        ltCourseValue.Text = string.Format("{0} {1}", cEnum.GetEnumDescription((cEnum.TypeMoney)Enum.Parse(typeof(cEnum.TypeMoney), course.coin, true)), course.value);
                        ltObs.Text = "Para se matricular neste curso será necessário adquirir um Código de Matrícula válido.";
                    }

                    if (course.userId == 0)
                    {
                        ltEnrollment.Text = "Inscreva-se";
                        hyEnrollment.NavigateUrl = "Login.aspx";
                        hyEnrollment.CssClass = "baseQueryString btn btn-theme";
                    }
                    else if (course.enrollmentId > 0)
                    {
                        ltCourseValue.Visible = false;
                        ltEnrollment.Text = "Já Matriculado";
                        ltObs.Visible = false;
                        hyEnrollment.NavigateUrl = "MyCourses.aspx";
                        hyEnrollment.CssClass = "espQueryString btn btn-theme";
                    }
                    else
                    {
                        ltEnrollment.Text = "Inscreva-se";
                        hyEnrollment.NavigateUrl = "javascript:void(0)";
                        hyEnrollment.CssClass = "btn btn-theme";
                        hyEnrollment.Attributes.Add("onclick", "SetEnrollment();");
                    }
                }
            }
        }

        [WebMethod]
        public static bool AjaxSetEnrollment()
        {
            return cBusinessAjax.AjaxSetEnrollment();
        }
    }
}