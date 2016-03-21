using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ViewRequisitionListReject : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = ef.getViewIssuedRequisitonDetail(Session["req_id"].ToString());
            GridView1.DataBind();
            GridView1.Columns[3].Visible = false;
            Label1.Text = GridView1.Rows[0].Cells[3].Text;
        }
    }
}