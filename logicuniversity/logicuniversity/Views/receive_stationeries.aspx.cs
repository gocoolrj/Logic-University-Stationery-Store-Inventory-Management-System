using Entity;
using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class receive_stationeries : System.Web.UI.Page
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            int DeptId = Convert.ToInt16(Session["DeptID"].ToString());
            tbDeptName.Text = ef.getDeptNameDisplay(DeptId);
            tbCollPoint.Text = ef.getCollpointDisplay(DeptId);
            tbDeliBy.Text = ef.getDeliveryByDisplay(DeptId);

            //gridview
            int ReqDeptID = Convert.ToInt16(Session["Req_Dept_ID"].ToString());
            List<GVTable> listGTtable = ef.getReceiveStationeriesDetail(ReqDeptID);

            if (!IsPostBack)
            {
                gvReceiveStationeries.DataSource = listGTtable;
                gvReceiveStationeries.DataBind();
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //send Email

            //update unfulfilled table
            int DeptId = Convert.ToInt16(Session["DeptID"].ToString());

            foreach (GridViewRow gvr in gvReceiveStationeries.Rows)
            {
                if (((TextBox)gvr.FindControl("tbProblemItems")).Text.ToString() != "")
                {
                    string code = gvReceiveStationeries.DataKeys[gvr.RowIndex].Value.ToString().Trim();
                    var item = ctx.catalogues.FirstOrDefault(d => d.item_code == code);
                    unfulfill addData = new unfulfill();
                    addData.item_code = item.item_code;
                    addData.dept_id = DeptId;
                    addData.unfufil_date = DateTime.Now;
                    addData.quantity = Convert.ToInt16(((TextBox)gvr.FindControl("tbProblemItems")).Text.ToString());
                    addData.remark = ((TextBox)gvr.FindControl("tbReason")).Text.ToString();
                    ctx.unfulfills.Add(addData);
                    ctx.SaveChanges();
                }
            }
            Response.Redirect(string.Format("~/Views/representative_home.aspx"));
        }
    }
}
