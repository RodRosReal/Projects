using CollegeBusiness.Model;
using CollegeBusiness.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI.courses
{
    public partial class Training : BaseSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_courseId > 0 && _enrollmentId > 0 && _session)
            {
                cCourse course = _business.GetMyCourseStatus(_login.userId, _courseId, _enrollmentId);

                string namePag = course.modules.Where(x => (_moduleId != 0 && _resourceId == 0)  && x.moduleId == _moduleId ).Select(x => x.page).FirstOrDefault();
                if (string.IsNullOrEmpty(namePag))
                {
                    namePag = course.modules.Where(x => _resourceId != 0 && x.moduleId == _moduleId).Select(x => x.resource.page).FirstOrDefault();
                    if (string.IsNullOrEmpty(namePag))
                    {
                        namePag = course.modules.SelectMany(x => x.blocks.Where(y => _blockId != 0 && y.blockId == _blockId).Select(y => y.page)).FirstOrDefault();
                    }
                }

                Response.Redirect(namePag + "?credential=" + cWebCrypto.Encrypt(cSerialize.XmlSerialize(new cCredential()
                                                                                    {
                                                                                        enterpriseId = _enterpriseId,
                                                                                        userId = _login.userId,
                                                                                        enrollmentId = _enrollmentId,
                                                                                        courseId = _courseId
                                                                                    })));
            }
        }
    }
}