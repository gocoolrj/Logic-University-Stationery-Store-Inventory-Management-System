using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Controllers;

namespace logicuniversity.Views
{
    public partial class view_stocklevel : System.Web.UI.Page
    {
        SupplierController sc = new SupplierController();
        view_stockLevelController vsl = new view_stockLevelController();
        CategoryController cc = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Store Clerk")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {
//----------------------------Improvements done by VKR---------------------------------------------------
                        gvStockLvl.DataSource = vsl.GetStockLevel();
                        gvStockLvl.DataBind();
                        //ddlCat.DataSource = cc.GetCategories();
                        //ddlCat.DataValueField = "catg_id";
                        //ddlCat.DataTextField = "name";
                        //ddlCat.DataBind();

                        //ddlCat.Items.Insert(0, "--- Select --- ");
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }
        }
        
        protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlCat.SelectedIndex > 0)
            //{
            //    int catid = Convert.ToInt32(ddlCat.SelectedItem.Value);
            //    gvStockLvl.DataSource = vsl.GetStockLevel(catid);
            //    gvStockLvl.DataBind();
            //}
        }

        protected void btnMPO_Click(object sender, EventArgs e)
        {
            Server.Transfer("MakePurchaseOrder.aspx",true);
        }

        protected void gvStockLvl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
} 