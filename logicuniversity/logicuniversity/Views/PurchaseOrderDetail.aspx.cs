using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Controllers;

namespace logicuniversity.Views
{
    public partial class PurchaseOrderDetail : System.Web.UI.Page
    {
        PODetailController pocd = new PODetailController();
        POController poc = new POController();
        string po_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            po_id = Request.QueryString["poid"];
            if (!IsPostBack)
            {
                
                List<customPurchaseOrderDetail> podList = new List<customPurchaseOrderDetail>();
                podList = pocd.getpurchaseorderdetail(po_id);
                gvPOD.DataSource = podList;
                gvPOD.DataBind();
                
                //if (Session["UserID"] != null)
                //{
                //    if (Session["UserID"].ToString() == "supervisor")// in entity we will check with employee's role
                //    {
                //        if (!IsPostBack)
                //        {
                //            List<customPurchaseOrderDetail> podList = new List<customPurchaseOrderDetail>();
                //            podList = pocd.getpurchaseorderdetail(po_id);
                //            gvPOD.DataSource = podList;
                //            gvPOD.DataBind();
                //        }
                //        else
                //        {
                //            Response.Redirect(string.Format("~/login.aspx"));
                //        }
                //    }
                //}
            }
        }

        protected void btnApv_Click(object sender, EventArgs e)
        {
           
            poc.updatepurchaseorder(po_id);
            Response.Redirect(string.Format("~/Views/PurchaseOrder.aspx"));
           
            
        }

        protected void btnRej_Click(object sender, EventArgs e)
        {
           
            poc.rejectpurchaseorder(po_id);
            Response.Redirect(string.Format("~/Views/PurchaseOrder.aspx"));
        }
       
    }
}
    