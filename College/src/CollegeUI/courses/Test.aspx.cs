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
    public partial class Test : BaseSession
    {
        cEnum.statusTest _statusTest = new cEnum.statusTest();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_courseId > 0 && _moduleId > 0 && _enrollmentId > 0 && _testStatus > 0 && _session)
                {
                    _statusTest = (cEnum.statusTest)_testStatus;
                    if (_statusTest == cEnum.statusTest.Open)
                    {
                        _business.CreateTest(_moduleId, _enrollmentId);
                    }
                    LoadData();
                }
            }
        }

        protected void LoadData(cEnum.statusTest status = cEnum.statusTest.None)
        {
            if (status == cEnum.statusTest.None)
            {
                _statusTest = (cEnum.statusTest)_testStatus;
            }
            else
            {
                _statusTest = status;
            }

            if (_statusTest == cEnum.statusTest.Failing)
            {
                countdown_dashboard.Visible = false;
                pnlCreateNewTest.Visible = true;
            }
            else
            {
                countdown_dashboard.Visible = true;
                pnlCreateNewTest.Visible = false;
            }

            rptTest.DataSource = _business.GetTests(_moduleId, _enrollmentId);
            rptTest.DataBind();
        }

        protected void rptTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cUserTest item = (cUserTest)e.Item.DataItem;

                Literal ltTest = (Literal)e.Item.FindControl("ltTest");
                ltTest.Text = item.question;

                TextBox txReply = (TextBox)e.Item.FindControl("txReply");
                txReply.Text = item.reply;
                txReply.ReadOnly = !item.enabledEdit;

                PlaceHolder phCorrection = (PlaceHolder)e.Item.FindControl("phCorrection");
                phCorrection.Visible = (string.IsNullOrEmpty(item.correction) ? false : true);

                TextBox txCorrection = (TextBox)e.Item.FindControl("txCorrection");
                txCorrection.Text = item.correction;
                txCorrection.ReadOnly = true;

                Button btnSave = (Button)e.Item.FindControl("btnSave");
                btnSave.CommandArgument = cWebCrypto.Encrypt(item.userTestId.ToString());
                btnSave.Visible = item.enabledEdit;

                hddInitDate.Value = item.initDate.ToString();
                DateTime date = item.initDate.AddMinutes(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TestTime"]));
                hddDay.Value = date.Day.ToString();
                hddMonth.Value = date.Month.ToString();
                hddYear.Value = date.Year.ToString();
                hddHour.Value = date.Hour.ToString();
                hddMin.Value = date.Minute.ToString();
                hddSec.Value = date.Second.ToString();
            }
        }

        protected void rptTest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "save")
            {
                DateTime endTime = DateTime.Now;
                TimeSpan span = endTime.Subtract(Convert.ToDateTime(hddInitDate.Value).AddMinutes(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TestTime"])));
                if (span.TotalMinutes > 6)
                {
                    pnMsg.Visible = true;
                    hddStatus.Value = "3";
                }
                else
                {
                    TextBox txReply = (TextBox)e.Item.FindControl("txReply");
                    if (!string.IsNullOrEmpty(txReply.Text))
                    {
                        bool ret = _business.SetUserTest(Convert.ToInt64(cWebCrypto.Decrypt(e.CommandArgument.ToString())), txReply.Text);
                        if (ret)
                        {
                            pnMsg.Visible = true;
                            hddStatus.Value = "1";
                        }
                        else
                        {
                            pnMsg.Visible = true;
                            hddStatus.Value = "0";
                        }
                    }
                    else
                    {
                        pnMsg.Visible = true;
                        hddStatus.Value = "2";
                    }
                }
            }
        }

        protected void btnCreateNewTest_Click(object sender, EventArgs e)
        {
            _business.CreateTest(_moduleId, _enrollmentId);
            LoadData(cEnum.statusTest.Progress);
        }
    }
}