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
    public partial class Exercise : BaseSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_moduleId > 0 && _enrollmentId > 0 && _blockId > 0)
            {
                if (!IsPostBack)
                {
                    LoadData();
                }
            }
        }

        protected void LoadData()
        {
            if (_session)
            {
                rptExercise.DataSource = _business.GetExercises(_blockId, _enrollmentId);
                rptExercise.DataBind();
            }
        }

        protected void rptExercise_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                cUserExercise item = (cUserExercise)e.Item.DataItem;

                Literal ltExercise = (Literal)e.Item.FindControl("ltExercise");
                ltExercise.Text = item.question;

                TextBox txReply = (TextBox)e.Item.FindControl("txReply");
                txReply.Text = item.reply;
                txReply.ReadOnly = !string.IsNullOrEmpty(item.reply);

                PlaceHolder phCorrection = (PlaceHolder)e.Item.FindControl("phCorrection");
                phCorrection.Visible = (!string.IsNullOrEmpty(item.reply) && !string.IsNullOrEmpty(item.correction) ? true : false);

                TextBox txCorrection = (TextBox)e.Item.FindControl("txCorrection");
                txCorrection.Text = item.correction;
                txCorrection.ReadOnly = true;

                Button btnSave = (Button)e.Item.FindControl("btnSave");
                btnSave.CommandArgument = cWebCrypto.Encrypt(item.userExerciseId.ToString());
                btnSave.Visible = string.IsNullOrEmpty(item.reply);
            }
        }

        protected void rptExercise_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "save")
            {
                TextBox txReply = (TextBox)e.Item.FindControl("txReply");
                if (!string.IsNullOrEmpty(txReply.Text))
                {
                    bool ret = _business.SetUserExercise(Convert.ToInt64(cWebCrypto.Decrypt(e.CommandArgument.ToString())), txReply.Text);
                    if (ret)
                    {
                        LoadData();
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
}