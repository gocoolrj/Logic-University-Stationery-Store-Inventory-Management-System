using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ApproveRequisitionDetail : System.Web.UI.Page
    {
        EFFacade facade = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            var a = facade.getRequisitionItemByID(Convert.ToInt16((Session["Req_id"].ToString())));
            GridView1.DataSource = a;
            GridView1.DataBind();
        }

        protected void ApproveBtn_Click(object sender, EventArgs e)
        {
            string reason="";
            try
            {
                if (TextBox1.Text.ToString().Equals(""))
                {
                    reason = TextBox1.Text.ToString();
                }
                facade.ApproveRequisition(Convert.ToInt32(Session["Req_id"].ToString()), Convert.ToInt32(Session["user_id"].ToString()),reason);
            }
            catch (Exception e1)
            {
                
                Response.Redirect("~/login.aspx", true);
            }
           
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Successfully!');</script>");
        }

        protected void RejectBtn_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                string reason = TextBox1.Text;
                facade.RejectRequisition(Convert.ToInt16(Session["Req_id"].ToString()), reason);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Successfully!');</script>");
                Server.Transfer("ApproveRequisition.aspx", true);
            }       
        }
    }
}