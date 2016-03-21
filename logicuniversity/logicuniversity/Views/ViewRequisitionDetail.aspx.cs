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
    public partial class ViewRequisitionDetail : System.Web.UI.Page
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        List<CategoryDetail> list = new List<CategoryDetail>();
        static List<UnfulfilledItems> list1 = new List<UnfulfilledItems>();
        static List<CategoryDetail> list2 = new List<CategoryDetail>();
        EFFacade ef = new EFFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            int req_id = (int)Session["reqId"];
            if (!IsPostBack)
            {
                InitData(req_id);
            }
        }

        private void InitData(int req_id)
        {
            /*get basic info*/
            var item = ctx.requisitions.FirstOrDefault(x => x.req_id == req_id);
            lab_status.Text = item.req_status;
            if(item.req_status.Equals("Rejected"))
            {
                text_reason.Text = item.req_reason;
                reason.Visible = true;
                text_reason.Visible = true;
            }
            lab_reqtime.Text = item.req_date.ToString();
            var head = ctx.employees.FirstOrDefault(x => x.emp_id == item.approve_emp_id);
            if (head != null)
            {
                lab_approvename.Text = head.emp_name;
                lab_approvedate.Text = item.approve_date.ToString();
            }
            var receiver = ctx.employees.FirstOrDefault(x => x.emp_id == item.received_emp_id);
            if (receiver != null)
            {
                lab_receivename.Text = receiver.emp_name;
                lab_receivedate.Text = item.received_date.ToString();
            }
            /*get unfulfilleditem*/
            if (list2.Count == 0 && list1.Count == 0)
            {
                list1 = ef.getUnfulfillitems(req_id);
            }
            UnfulfillitemGridView.DataSource = list1;
            UnfulfillitemGridView.DataBind();

            /*get original requisition*/
            var req = from o in ctx.requisitions
                      where o.req_id == req_id
                      join p in ctx.requisitionDetails on o.req_id equals p.req_id
                      join q in ctx.catalogues on p.item_code equals q.item_code
                      join r in ctx.categories on q.catg_id equals r.catg_id
                      select new { r.name, q.description, p.req_quantity };

            foreach (var re in req)
            {
                CategoryDetail ca = new CategoryDetail();
                ca.Name = re.name;
                ca.Description = re.description;
                ca.Quantity = (int)re.req_quantity;
                list.Add(ca);
            }

            OriginalrequisitionGridView.DataSource = list;
            OriginalrequisitionGridView.DataBind();
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            Server.Transfer("ViewRequisitionList.aspx", true);
        }

        protected void OriginalrequisitionGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OriginalrequisitionGridView.PageIndex = e.NewPageIndex;
            OriginalrequisitionGridView.DataSource = list;
            OriginalrequisitionGridView.DataBind();
        }

        protected void UnfulfillitemGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UnfulfillitemGridView.PageIndex = e.NewPageIndex;
            UnfulfillitemGridView.DataSource = list1;
            UnfulfillitemGridView.DataBind();
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            /* find the item in gridview and delete it */
            string code = UnfulfillitemGridView.DataKeys[row.RowIndex].Value.ToString().Trim();
            UnfulfilledItems ui = null;
            foreach (UnfulfilledItems u in list1)
            {
                if (u.Item_code == code)
                {
                    ui = u;
                }
            }
            list1.Remove(ui);
            UnfulfillitemGridView.DataSource = list1;
            UnfulfillitemGridView.DataBind();

            CategoryDetail c = new CategoryDetail();
            c.Item_code = ui.Item_code;
            c.Quantity = ui.Quantity;
            c.Description = ui.Description;
            c.Name = ui.Name;

            list2.Add(c);
            /* add to the draft requisition */
            employee emp = ef.findEmployeeById(ui.Req_id);
            requisition req = ef.getDraftrequisition(emp.emp_id);
            if (req != null)//have draft requisition
            {

                var item = ctx.requisitionDetails.FirstOrDefault(x => x.item_code == ui.Item_code && x.req_id == req.req_id);


                if (item != null)
                {
                    item.req_quantity += ui.Quantity;
                    ctx.SaveChanges();
                }//plus quantity on exsiting item
                else
                {
                    requisitionDetail reqdetail = new requisitionDetail();
                    reqdetail.req_id = req.req_id;
                    reqdetail.item_code = ui.Item_code;
                    reqdetail.req_quantity = ui.Quantity;
                    ctx.requisitionDetails.Add(reqdetail);    /*insert the unfulfilled items into exsiting table*/
                    ctx.SaveChanges();
                    var unfulfill = ctx.unfulfills.FirstOrDefault(x => x.id == ui.Id);
                    unfulfill.status = "fulfilled";
                    ctx.SaveChanges();
                }  //have table no session

                if (Session["items"] != null) //have table have session
                {
                    List<CategoryDetail> list = ef.addItemsToList(c, (List<CategoryDetail>)Session["items"]);
                    Session["items"] = list;
                }

            }
            else//no table 
            {
                if (Session["items"] != null) //no table have session
                {
                    List<CategoryDetail> list = ef.addItemsToList(c, (List<CategoryDetail>)Session["items"]);
                    Session["items"] = list;
                }
                else  //no table no session
                {
                    requisition reqnew = new requisition();
                    reqnew.dept_id = emp.dept_id;
                    reqnew.req_emp_id = emp.emp_id;
                    reqnew.req_status = "Draft";
                    requisition reqv = ctx.requisitions.Add(reqnew);              /*create a new object*/
                    ctx.SaveChanges();

                    requisitionDetail reqdetail = new requisitionDetail();
                    reqdetail.req_id = reqv.req_id;
                    reqdetail.item_code = ui.Item_code;
                    reqdetail.req_quantity = ui.Quantity;
                    ctx.requisitionDetails.Add(reqdetail);
                    ctx.SaveChanges();

                    var unfulfill = ctx.unfulfills.FirstOrDefault(x => x.id == ui.Id);
                    unfulfill.status = "fulfilled";
                    ctx.SaveChanges();
                }
            }
        }

        protected void AddAll_Click(object sender, EventArgs e)
        {
            if (UnfulfillitemGridView.Rows.Count > 0)
            {
                int id = (int)Session["UserID"];
                List<requisitionDetail> list = new List<requisitionDetail>();
                foreach (GridViewRow row in UnfulfillitemGridView.Rows)
                {
                    requisitionDetail reqdetail = new requisitionDetail();
                    reqdetail.item_code = UnfulfillitemGridView.DataKeys[row.RowIndex].Value.ToString().Trim();
                    reqdetail.req_quantity = Convert.ToInt32(row.Cells[3].Text.ToString());
                    list.Add(reqdetail);
                }

                List<CategoryDetail> listc = new List<CategoryDetail>();
                UnfulfillitemGridView.DataSource = listc;
                UnfulfillitemGridView.DataBind();
                foreach (requisitionDetail reqd in list)
                {
                    CategoryDetail c = new CategoryDetail();
                    c.Item_code = reqd.item_code;
                    c.Quantity = (int)reqd.req_quantity;
                    var i = ctx.catalogues.FirstOrDefault(x => x.item_code == reqd.item_code);
                    int igid = i.catg_id;
                    var j = ctx.categories.FirstOrDefault(y => y.catg_id == igid);
                    c.Name = j.name;
                    c.Description = i.description;
                    listc.Add(c);
                }

                list2.AddRange(listc);
                var req = ctx.requisitions.FirstOrDefault(x => x.req_emp_id == id && x.req_status == "Draft");
                if (req != null)
                {
                    ef.addAllUnfulfilledItem(list, req.req_id);
                    if (Session["items"] != null)
                    {
                        List<CategoryDetail> listx = ef.addListTolist(listc, (List<CategoryDetail>)Session["items"]);
                        Session["items"] = listx;
                    }
                }
                else
                {
                    if (Session["items"] != null)
                    {
                        List<CategoryDetail> listy = ef.addListTolist(listc, (List<CategoryDetail>)Session["items"]);
                        Session["items"] = listy;
                    }
                    else
                    {
                        requisition reqnew = new requisition();
                        reqnew.dept_id = req.dept_id;
                        reqnew.req_emp_id = req.req_emp_id;
                        reqnew.req_status = "Draft";
                        ctx.requisitions.Add(reqnew);              /*create a new object*/
                        ctx.SaveChanges();
                        ef.addAllUnfulfilledItem(list, reqnew.req_id);
                    }
                }
            }
        }
    }
}