using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Report;
namespace logicuniversity.Views
{
    public partial class POReport : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dt = (DataTable)Session["rptDt"];
            }
            catch (Exception ex)
            {

            }

            purchaseOrderReport rpt = new purchaseOrderReport();
            rpt.SetDataSource(dt);
            crpt.ReportSource = rpt;
            crpt.RefreshReport();
        }
    }
}