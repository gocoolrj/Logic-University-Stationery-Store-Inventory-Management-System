using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ApproveRequisition : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = ef.getPeddingRequisitionList();
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('There is none requisition to handle for now!');</script>");
                }
                else {

                }
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Session["Req_id"] = e.CommandArgument;
            Response.Redirect(string.Format("ApproveRequisitionDetail.aspx"));
        }


    }
}