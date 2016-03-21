using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Controllers;
using logicuniversity.DAO;

namespace logicuniversity.Views
{
    public partial class Reorderlvl : System.Web.UI.Page
    {

        view_stockLevelController slc = new view_stockLevelController();
        protected void Page_Load(object sender, EventArgs e)
        {

            //string x = Session["user_role"].ToString();

            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Store Clerk")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {
                        gvReoderLvl.DataSource = slc.getreorderlevel();
                        gvReoderLvl.DataBind();


                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }
        }

        protected void btnro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakePurchaseOrder.aspx");
        }

    }
}