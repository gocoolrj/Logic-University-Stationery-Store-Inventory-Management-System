using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class UpdateStockCard_1 : System.Web.UI.Page
    {
        EFFacade cb = new EFFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GridView1.Caption = "Item List";
                //GridView1.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
                //GridView1.PageSize = 15;
                BindData();                
            }
        }

        private void BindData()
        {
            List<CategoryType> list1 = cb.getCategories();
            CategoryType c = new CategoryType();
            c.Catg_id = 0;
            c.Name = "All";
            list1.Insert(0, c);
            ddlCategory.DataSource = list1;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Catg_id";
            ddlCategory.DataBind();
            var a = cb.getCatalogueList();
            GridView1.DataSource = a;
            GridView1.DataBind();
        }

        protected void ddlCategory_SelectedIndexChange(object o, EventArgs e)
        {
            if (ddlCategory.SelectedItem.ToString() == "All")
            {
                BindData();
            }
            else
            {
                string name = ddlCategory.SelectedItem.ToString();
                GridView1.DataSource = cb.getCategoriesListByType(name);
                GridView1.DataBind();
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Session["item_code"] = e.CommandArgument.ToString();
            Response.Redirect(String.Format("UpdateStockCard_2.aspx"));
        }
    }
}