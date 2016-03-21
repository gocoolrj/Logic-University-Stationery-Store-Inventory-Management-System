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
    public partial class MakeRequisition : System.Web.UI.Page
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        EFFacade ef = new EFFacade();
        static EmployeeRequisitionDetail reqd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<CategoryDetail> l = (List<CategoryDetail>)Session["items"];
                EmployeeRequisitionDetail reqDetail = (EmployeeRequisitionDetail)Session["reqInfo"];
                /*the first time make requisition or clean out all the items*/
                if (l == null && reqDetail == null)
                {
                    DataExsistBind();
                    List<CategoryDetail> li = (List<CategoryDetail>)Session["items"];
                    if (li == null)
                    {
                        reqGridView.DataSource = new List<CategoryDetail>();
                        reqGridView.DataBind();
                    }
                    else
                    {
                        reqGridView.DataSource = Session["items"];
                        reqGridView.DataBind();
                    }
                }
                else
                {
                    reqGridView.DataSource = Session["items"];
                    reqGridView.DataBind();
                }
            }
        }

        private void DataExsistBind()
        {
            List<CategoryDetail> list = new List<CategoryDetail>();
            int id = (int)Session["user_id"];
            /* first time login record basic information of employee */
            EmployeeRequisitionDetail reqDetail = new EmployeeRequisitionDetail();
            /* assign the basic infomation */
            var employee = ctx.employees.FirstOrDefault(x => x.emp_id == id);
            reqDetail.Dept_id = (int)employee.dept_id;
            reqDetail.Requst_emp_id = employee.emp_id;
            reqDetail.Status = "Draft";
            requisition draft = ef.getDraftrequisition(id);
            /*if have some draft requisition 
              get out and edit agin*/
            if (draft != null)
            {
                reqDetail.Req_id = draft.req_id;
                Session["reqInfo"] = reqDetail;
                /* get out the detail items and put into a list */
                var detail = from p in ctx.requisitionDetails
                             where p.req_id == draft.req_id
                             select p;
                foreach (var de in detail)
                {
                    CategoryDetail cate = new CategoryDetail();
                    cate.Item_code = de.item_code;
                    cate.Quantity = (int)de.req_quantity;
                    list.Add(cate);
                }
                /* assign other value to Category object in list */
                foreach (CategoryDetail ca in list)
                {
                    var c = from o in ctx.catalogues
                            where o.item_code == ca.Item_code
                            join p in ctx.categories on o.catg_id equals p.catg_id
                            select new { o.catg_id, o.description, p.name };
                    foreach (var c1 in c)
                    {
                        ca.Catg_id = c1.catg_id;
                        ca.Description = c1.description;
                        ca.Name = c1.name;
                    }
                }
                Session["items"] = list;
            }
            else
            {
                reqd = reqDetail;
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("AddItems.aspx", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<CategoryDetail> list = (List<CategoryDetail>)Session["items"];
            EmployeeRequisitionDetail reqDetail = (EmployeeRequisitionDetail)Session["reqInfo"];
            if (reqDetail == null)
            {
                Session["reqInfo"] = reqd;
                reqDetail = reqd;
            }
            var q = ctx.requisitions.FirstOrDefault(m => m.req_id == reqDetail.Req_id);
            if (q != null)
            {
                q.req_status = "Pending";
                q.req_date = DateTime.Now;
                ctx.SaveChanges();
            }
            else
            {
                requisition req = new requisition();
                req.req_id = reqDetail.Req_id;
                req.dept_id = reqDetail.Dept_id;
                req.req_emp_id = reqDetail.Requst_emp_id;
                req.req_date = DateTime.Now;
                req.req_status = "Pending";
                ctx.requisitions.Add(req);
                ctx.SaveChanges();
                ef.UpdateReqDetail(list, req.req_id);
            }
            Session["items"] = null;
            Session["reqInfo"] = null;
            reqd = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Submitted Successfully!');</script>");
            Server.Transfer("employee_home.aspx", true);
         
        }

        protected void reqGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string code = reqGridView.DataKeys[e.RowIndex].Value.ToString().Trim();
            CategoryDetail ca = null;
            List<CategoryDetail> list = (List<CategoryDetail>)Session["items"];
            foreach (CategoryDetail c in list)
            {
                if (c.Item_code == code)
                {
                    ca = c;
                    break;
                }
            }
            list.Remove(ca);
            Session["items"] = list;
            reqGridView.DataSource = Session["items"];
            reqGridView.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<CategoryDetail> list = (List<CategoryDetail>)Session["items"];
            if (list != null) //won't save empty
            {
                EmployeeRequisitionDetail reqDetail = (EmployeeRequisitionDetail)Session["reqInfo"];
                if (reqDetail == null)
                {
                    Session["reqInfo"] = reqd;
                    reqDetail = reqd;
                }
                var q = ctx.requisitions.FirstOrDefault(m => m.req_id == reqDetail.Req_id);

                if (q != null)
                {
                    ef.UpdateReqDetail(list, reqDetail.Req_id); //save again
                }
                else
                {
                    requisition req = new requisition();
                    req.dept_id = reqDetail.Dept_id;
                    req.req_emp_id = reqDetail.Requst_emp_id;
                    req.req_status = reqDetail.Status;
                    requisition req1 = ctx.requisitions.Add(req);
                    ctx.SaveChanges();
                    ef.UpdateReqDetail(list, req1.req_id);
                }
                Session["items"] = null;
                Session["reqInfo"] = null;
                reqd = null;
            
            }
        }
    }
}