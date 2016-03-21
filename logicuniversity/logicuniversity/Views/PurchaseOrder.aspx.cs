using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Controllers;
using Entity;

namespace logicuniversity.Views
{

    public partial class PurchaseOrder : System.Web.UI.Page
    {
        POController poc = new POController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Supervisor")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {
                        List<purchaseOrder> poList = new List<purchaseOrder>();
                        poList = poc.getpurchaseorder();
                        gvPO.DataSource = poList;
                        gvPO.DataBind();


                    }
                    //else
                    //{
                    //    Response.Redirect(string.Format("~/login.aspx")); 
                    //}
                    
                }
            }
            
        }

        protected void gvPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrderDetail.aspx?poid=" + gvPO.SelectedRow.Cells[0].Text);
        }
       
    }
}
