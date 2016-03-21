using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Report;
using logicuniversity.Controllers;
namespace logicuniversity.Views
{
    public partial class RequisitionTrendReport : System.Web.UI.Page
    {
        DataTable dt;
        RequisitionController rc = new RequisitionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            dt = (DataTable)Session["finalData"];
            //}
            //catch (Exception ex)
            //{

            //}

            // List<stationery_trend_report_view> reportList = rc.GetAll();
            // dt = rc.LINQResultToDataTable(reportList);
            TrendByDept rpt = new TrendByDept();
            rpt.SetDataSource(dt);
            crpt.ReportSource = rpt;
            crpt.RefreshReport();
        }
    }
}