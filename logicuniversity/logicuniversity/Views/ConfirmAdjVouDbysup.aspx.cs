using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ConfirmAdjVouDbysup : System.Web.UI.Page
    {
        InvAdjController iac = new InvAdjController();
        string vid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Supervisor")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {
                        lblVouNo.Text += Request.QueryString["vid"];
                        lblDateIssue.Text += Request.QueryString["dateissue"];
                        vid = Request.QueryString["vid"];
                        if (iac.getInvAdjDList1(vid) != null)
                        {
                            gvInvAdjD.DataSource = iac.getInvAdjDList1(vid);
                            gvInvAdjD.DataBind();
                        }
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }



        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            iac.UpdateInvAdj(Request.QueryString["vid"], Convert.ToInt32(Session["user_id"]), 0, "Approved");
            Response.Redirect("~/Views/ConfirmAdjVoubysup.aspx");
        }
    }
}