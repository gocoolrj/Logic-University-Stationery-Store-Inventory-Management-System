using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ViewRequisitionListHead : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = ef.getIssuedRequisitionList();
                GridView1.DataBind();
            }
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            string[] args = new string[2];
            args = e.CommandArgument.ToString().Split(';');
            Session["req_id"] = args[0];
            Session["status"] = args[1];

            string x = Session["status"].ToString();

            if (x == "Approved")
            {
                Server.Transfer("ViewRequisitionListApprove.aspx", true);
            }
            else if (Session["status"].ToString() == "Rejected")
            {
                Server.Transfer("ViewRequisitionListReject.aspx", true);
            }
        }

    }
}