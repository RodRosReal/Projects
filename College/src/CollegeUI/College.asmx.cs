using CollegeBusiness;
using CollegeBusiness.Model;
using CollegeBusiness.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CollegeUI
{
    /// <summary>
    /// Summary description for College
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class College : System.Web.Services.WebService
    {

        [WebMethod]
        public cCourse GetStatusCourse(string credential)
        {
            cCourse course = new cCourse();
            cCredential access = (cCredential)cSerialize.XmlDeserialize(typeof(cCredential), cWebCrypto.Decrypt(credential)); 
            try
            {
                cBusinessWeb business = new cBusinessWeb(access.enterpriseId);
                return business.GetMyCourseStatus(access.userId, access.courseId, access.enrollmentId);
            }
            catch
            {

            }
            return course;
        }
    }
}
