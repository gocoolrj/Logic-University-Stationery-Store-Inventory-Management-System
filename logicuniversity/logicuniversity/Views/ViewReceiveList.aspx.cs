using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.DAO;
using Entity;

namespace logicuniversity.Views
{
    public partial class ViewReceiveList : System.Web.UI.Page
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            int DeptId = Convert.ToInt16(Session["dept_id"].ToString());
            List<ReceiveStationeriesListTable> list = ef.getReceiveStationeriesList(DeptId);
         
            gvReceiveStationeriesList.DataSource = list;
            gvReceiveStationeriesList.DataBind();
        }
        protected void commandLinkView(object sender, CommandEventArgs e)
        {
           // Session["Req_Dept_ID"] = e.CommandArgument.ToString();
            Response.Redirect(string.Format("~/Views/receive_stationeries.aspx"));
        }

        protected void LinkButtonDetail_Click(object sender, EventArgs e)
        {
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string reqisitionid = row.Cells[0].Text;
            Session["Req_Dept_ID"] = reqisitionid;
        }

    }
}