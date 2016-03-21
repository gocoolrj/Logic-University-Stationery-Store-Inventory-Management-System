
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.DAO;

namespace logicuniversity.Views
{
    public partial class DiscrepancyReport : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = ef.getDiscrepancy();
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("AddNewDiscrepancy.aspx", true);
        }

        protected void LinkButton2_OnCommand(object sender, CommandEventArgs e)
        {
            Session["voucher_id"] = e.CommandArgument.ToString();
            Server.Transfer("DiscrepancyReportDetail.aspx", true);
        }
    }
}