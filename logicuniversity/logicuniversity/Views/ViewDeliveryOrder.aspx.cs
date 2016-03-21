using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ViewDeliveryOrder : System.Web.UI.Page
    {
        DeliveryOrderController dvc = new DeliveryOrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (dvc.getDOList().Count() > 0)
                {
                    gvdo.DataSource = dvc.getDOList();
                    gvdo.DataBind();
                }
                else
                {
                    lblmsg.Visible = true;
                }
            }
        }

        protected void gvdo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ViewDeliveryDetails.aspx?poid=" + gvdo.SelectedRow.Cells[0].Text);
        }
    }
}