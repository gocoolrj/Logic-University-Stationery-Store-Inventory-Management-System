using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.DAO;
namespace logicuniversity.Views
{
    public partial class delegatesucc : System.Web.UI.Page
    {
        DelegateAuthorityControl da = new DelegateAuthorityControl();
        customDelegation c;
        int employeeid;
        protected void Page_Load(object sender, EventArgs e)
        {
            c = da.getdelegatedEmployee(Convert.ToInt16(Session["dept_id"]));
            try
            {
                LblEmplname.Text = c.Empname1;
                LblFrmDate.Text = c.StartDate1.Date.ToString();
                LblToDate.Text = c.ToDate1.Date.ToString();
                employeeid = c.Emp_id1;
            }

            catch (Exception e1) { Response.Redirect(string.Format("~/Views/head_home.aspx")); }

        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delegate_Authority.aspx");
        }

        protected void BtnUndelegate_Click(object sender, EventArgs e)
        {
            try
            {

                da.unDelegateEmployee(employeeid);
            }
            catch (Exception e2) { Response.Write("Employee already undelegated"); }
            finally
            {
                Response.Redirect("UnDelegateSuccess.aspx");
            }
        }
    }
}