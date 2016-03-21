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
    public partial class ViewRequisitionList : System.Web.UI.Page
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        List<SelfRequisition> list = new List<SelfRequisition>();
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Employee")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {
                        init();
                        reqlistview.DataSource = list;
                        reqlistview.DataBind();
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }

            
        }

        private void init()
        {   
            int id =0;
            try
            {
                id = (int)Session["user_id"];
            }catch
            {
                Response.Redirect("~/login.aspx",true);
            }
            
            list = ef.getSelfRequisitions(id.ToString());
        }

        protected void reqSearch_Click(object sender, EventArgs e)
        {
            string starttime = startdate.Text.ToString();
            string endtime = enddate.Text.ToString();
            
            List<SelfRequisition> list = new List<SelfRequisition>();
            if (starttime.Equals("") || endtime.Equals(""))
            {
                errmessage.Visible = true;
                errmessage.Text = "please select time";
                return;
            }
            DateTime start = DateTime.Parse(starttime);
            DateTime end = DateTime.Parse(endtime);
            if (start.CompareTo(end) > 0)
            {
                
                errmessage.Visible = true;
                errmessage.Text = "start time can't be later than end";
            }
            else
            {
                var reqs = ctx.requisitions.Where(a => a.req_date > start && a.req_date < end).ToList();

                foreach (var r in reqs)
                {
                    SelfRequisition se = new SelfRequisition();
                    se.Emp_id =(int)r.req_emp_id;
                    se.Req_id = r.req_id;
                    se.Dept_id = (int)r.dept_id;
                    se.Status = r.req_status;
                    se.Req_date = (DateTime)r.req_date;
                    list.Add(se);
                }
                reqlistview.DataSource = list;
                reqlistview.DataBind(); 
            }
                 
        }

        protected void reqlistview_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            ListViewItem li = reqlistview.Items[e.NewSelectedIndex];
            Label label = (Label)li.FindControl("reqId");
            Session["reqId"] = Convert.ToInt32(label.Text.ToString());
            Server.Transfer("ViewRequisitionDetail.aspx", true);
        }

    }
}