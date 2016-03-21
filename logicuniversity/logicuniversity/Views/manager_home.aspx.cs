using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.DAO;
namespace logicuniversity.Views
{
    public partial class manager_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Manager")// in entity we will check with employee's role
                {
                    EFFacade ef = new EFFacade();
                    int empId = Convert.ToInt16(Session["user_id"].ToString());
                    string name = ef.getEmpName(empId);
                    lblName.Text = name;
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }
        }
    }
}