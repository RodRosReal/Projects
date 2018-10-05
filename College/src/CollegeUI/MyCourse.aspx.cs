using CollegeBusiness.Model;
using CollegeBusiness.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollegeUI
{
    public partial class MyCourse : BaseSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cCourse course = _business.GetMyCourse(_courseId, _enrollmentId);
                if (course != null)
                {
                    ltCourse.Text = course.name;
                    ltCourseHead.Text = course.name;
                }
                rptModule.DataSource = course.modules;
                rptModule.DataBind();
            }
        }
        protected void rptModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cModule module = (cModule)e.Item.DataItem;

                Literal ltModuleTitle = (Literal)e.Item.FindControl("ltModuleTitle");
                ltModuleTitle.Text = "Módulo " + _business.ToRoman(e.Item.ItemIndex + 1);

                HyperLink hyModule = (HyperLink)e.Item.FindControl("hyModule");
                hyModule.Text = module.name;
                hyModule.Attributes.Add("href", "javascript:void(0);");
                if (module.status != cEnum.statusModule.Close)
                    //hyModule.Attributes.Add("onclick", "javascript:popupCentral('courses/Module.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&m=" + cWebCrypto.Encrypt(module.moduleId.ToString()) + "',770,484,'yes');return false;");
                    hyModule.Attributes.Add("onclick", "javascript:popupCentral('courses/Training.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&enroll=" + cWebCrypto.Encrypt(_enrollmentId.ToString()) + "&m=" + cWebCrypto.Encrypt(module.moduleId.ToString()) + "',770,484,'yes');return false;");

                Literal ltStatusModule = (Literal)e.Item.FindControl("ltStatusModule");
                ltStatusModule.Text = cEnum.GetEnumDescription(module.status);

                Repeater rptBlock = (Repeater)e.Item.FindControl("rptBlock");
                rptBlock.DataSource = module.blocks;
                rptBlock.DataBind();

                HyperLink hyResource = (HyperLink)e.Item.FindControl("hyResource");
                hyResource.Text = module.resource.name;
                hyResource.Attributes.Add("href", "javascript:void(0);");
                if (module.resource.status != cEnum.statusResource.Close)
                    //hyResource.Attributes.Add("onclick", "javascript:popupCentral('courses/Resource.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&m=" + cWebCrypto.Encrypt(module.moduleId.ToString()) + "',770,484,'yes');return false;");
                    hyResource.Attributes.Add("onclick", "javascript:popupCentral('courses/Training.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&enroll=" + cWebCrypto.Encrypt(_enrollmentId.ToString()) + "&m=" + cWebCrypto.Encrypt(module.moduleId.ToString()) + "&r=" + cWebCrypto.Encrypt(module.resource.resourdeId.ToString()) + "',770,484,'yes');return false;");

                Literal ltStatusResource = (Literal)e.Item.FindControl("ltStatusResource");
                ltStatusResource.Text = cEnum.GetEnumDescription(module.resource.status);

                HyperLink hyTest = (HyperLink)e.Item.FindControl("hyTest");
                hyTest.Text = "Prova";
                hyTest.Attributes.Add("href", "javascript:void(0);");
                if (module.statusTest != cEnum.statusTest.Close)
                {
                    if (module.statusTest == cEnum.statusTest.Open)
                    {
                        hyTest.Attributes.Add("onclick", "javascript:bootbox.dialog({ message: 'Você possui um total de " + ConfigurationManager.AppSettings["TestTime"] + " minutos para execução desta prova. Deseja iniciar agora?', title: 'Iniciar Prova', buttons: { cancel: { label: 'Cancelar', className: 'btn-default', callback: function() { bootbox.hideAll(); } }, success: { label: 'Iniciar', className: 'btn-primary', callback: function() {popupCentral('courses/Test.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&enroll=" + cWebCrypto.Encrypt(_enrollmentId.ToString()) + "&m=" + cWebCrypto.Encrypt(module.moduleId.ToString()) + "&s=" + cWebCrypto.Encrypt(((int)module.statusTest).ToString()) + "',770,484,'yes');} }, }});return false;");
                    }
                    else
                    {
                        hyTest.Attributes.Add("onclick", "javascript:popupCentral('courses/Test.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&enroll=" + cWebCrypto.Encrypt(_enrollmentId.ToString()) + "&m=" + cWebCrypto.Encrypt(module.moduleId.ToString()) + "&s=" + cWebCrypto.Encrypt(((int)module.statusTest).ToString()) + "',770,484,'yes');return false;");
                    }
                }
                Literal ltStatusTest = (Literal)e.Item.FindControl("ltStatusTest");
                ltStatusTest.Text = cEnum.GetEnumDescription(module.statusTest);
            }
        }

        protected void rptBlock_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cBlock block = (cBlock)e.Item.DataItem;

                HyperLink hyBlock = (HyperLink)e.Item.FindControl("hyBlock");
                hyBlock.Text = block.name;
                hyBlock.Attributes.Add("href", "javascript:void(0);");
                if (block.status != cEnum.statusBlock.Close)
                    //hyBlock.Attributes.Add("onclick", "javascript:popupCentral('courses/Block.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&m=" + cWebCrypto.Encrypt(block.moduleId.ToString()) + "&b=" + cWebCrypto.Encrypt(block.blockId.ToString()) + "',770,484,'yes');return false;");
                    hyBlock.Attributes.Add("onclick", "javascript:popupCentral('courses/Training.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&enroll=" + cWebCrypto.Encrypt(_enrollmentId.ToString()) + "&b=" + cWebCrypto.Encrypt(block.blockId.ToString()) + "',770,484,'yes');return false;");

                Literal ltStatusBlock = (Literal)e.Item.FindControl("ltStatusBlock");
                ltStatusBlock.Text = cEnum.GetEnumDescription(block.status);

                HyperLink hyExercise = (HyperLink)e.Item.FindControl("hyExercise");
                hyExercise.Text = "Exercícios";
                hyExercise.Attributes.Add("href", "javascript:void(0);");
                if (block.statusExercise != cEnum.statusExercise.Close)
                    hyExercise.Attributes.Add("onclick", "javascript:popupCentral('courses/Exercise.aspx?ac=" + cWebCrypto.Encrypt(_enterpriseId.ToString()) + "&user=" + cWebCrypto.Encrypt(_login.userId.ToString()) + "&c=" + cWebCrypto.Encrypt(_courseId.ToString()) + "&enroll=" + cWebCrypto.Encrypt(_enrollmentId.ToString()) + "&m=" + cWebCrypto.Encrypt(block.moduleId.ToString()) + "&b=" + cWebCrypto.Encrypt(block.blockId.ToString()) + "',770,484,'yes');return false;");

                Literal ltStatusExercise = (Literal)e.Item.FindControl("ltStatusExercise");
                ltStatusExercise.Text = cEnum.GetEnumDescription(block.statusExercise);
            }
        }
    }
}