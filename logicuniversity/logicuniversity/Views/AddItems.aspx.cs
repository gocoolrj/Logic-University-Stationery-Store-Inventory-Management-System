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
    public partial class AddItems : System.Web.UI.Page
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        EFFacade ef = new EFFacade();
        static List<CategoryDetail> list = new List<CategoryDetail>();
        List<CategoryDetail> list1 = new List<CategoryDetail>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Employee")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {
                        BindData();
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }


            
        }

        private void BindData()
        {
            List<CategoryType> list1 = ef.getCategories();
            CategoryType c = new CategoryType();
            c.Catg_id = 0;
            c.Name = "All";
            list1.Insert(0, c);
            DropDownList1.DataSource = list1;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Catg_id";
            DropDownList1.DataBind();
            list = ef.getCategoriesList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.ToString() == "All")
            {
                list = ef.getCategoriesList();
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
            else
            {
                string name = DropDownList1.SelectedItem.ToString();
                list = ef.getCategoriesListByType(name);
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        }

        protected void pageChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("MakeRequisition.aspx", true);
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<CategoryDetail> listdetail = new List<CategoryDetail>();
                listdetail = (List<CategoryDetail>)Session["items"];
                List<CategoryDetail> templist = new List<CategoryDetail>();
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    TextBox t1 = (TextBox)gvr.FindControl("txtQty");
                    if (t1.Text != "")
                    {
                        CategoryDetail ca = null;
                        string code = GridView1.DataKeys[gvr.RowIndex].Value.ToString().Trim();
                        var item = ctx.catalogues.FirstOrDefault(x => x.item_code == code);
                        if (listdetail != null)
                        {
                            foreach (CategoryDetail c in listdetail)
                            {
                                if (c.Item_code == code)
                                {
                                    c.Quantity = c.Quantity + Convert.ToInt32(t1.Text.ToString());
                                    listdetail.Remove(c);
                                    templist.Add(c);
                                    ca = c;
                                    break;
                                }
                            }
                            if (ca != null)
                            {

                            }
                            else
                            {
                                ca = new CategoryDetail();
                                ca.Catg_id = item.catg_id;
                                ca.Description = item.description;
                                ca.Item_code = item.item_code;
                                ca.Quantity = Convert.ToInt32(t1.Text.ToString());
                                var cat = ctx.categories.FirstOrDefault(x => x.catg_id == item.catg_id);
                                ca.Name = cat.name;
                                templist.Add(ca);
                            }
                        }
                        else
                        {
                            ca = new CategoryDetail();
                            ca.Catg_id = item.catg_id;
                            ca.Description = item.description;
                            ca.Item_code = item.item_code;
                            ca.Quantity = Convert.ToInt32(t1.Text.ToString());
                            var cat = ctx.categories.FirstOrDefault(x => x.catg_id == item.catg_id);
                            ca.Name = cat.name;
                            templist.Add(ca);
                        }
                        t1.Text = "";
                    }
                }
                if (listdetail != null)
                {
                    listdetail.InsertRange(0, templist);
                }
                else
                {
                    Session["items"] = templist;
                }

            }
        }
    }
}
