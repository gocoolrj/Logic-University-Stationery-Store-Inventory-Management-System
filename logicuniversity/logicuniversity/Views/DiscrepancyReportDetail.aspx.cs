using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class DiscrepancyReportDetail : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Session["voucher_id"].ToString();
            GridView1.DataSource = ef.getDiscrepancyDetail(s);
            GridView1.DataBind();
        }
    }
}