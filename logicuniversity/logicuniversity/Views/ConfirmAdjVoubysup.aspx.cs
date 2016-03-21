using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ConfirmAdjVoubysup : System.Web.UI.Page
    {
        InvAdjController iac = new InvAdjController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Supervisor")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {
                        gvAdjVou.DataSource = iac.getInvAdjList("sup");
                        gvAdjVou.DataBind();
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }


        }

        protected void gvAdjVou_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ConfirmAdjVouDbysup.aspx?vid=" + Server.UrlEncode(gvAdjVou.SelectedRow.Cells[0].Text) + "&dateissue=" + Server.UrlEncode(gvAdjVou.SelectedRow.Cells[1].Text));
        }
    }
}