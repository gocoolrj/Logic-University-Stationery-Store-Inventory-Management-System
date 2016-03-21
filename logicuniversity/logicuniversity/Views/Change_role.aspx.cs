using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class Change_role : System.Web.UI.Page
    {
        CreateEmpController cec = new CreateEmpController();

        protected void Page_Load(object sender, EventArgs e)
        {

            string emp_name = (string)(Session["emp_name"]).ToString();
            int emp_id = Convert.ToInt32(Session["emp_id"]);

            if (Session["emp_name"] != null)
            {
                NameLbl.Text = emp_name;
            }
            if (Session["emp_id"] != null)
            {
                IDLbl.Text = emp_id.ToString();
            }


            if (!IsPostBack)
            {
                roleid.DataSource = cec.getRoleID();
                roleid.DataValueField = "role_id";
                roleid.DataTextField = "role1";
                roleid.DataBind();
                roleid.Items.Insert(0, "---Select---");
            }





        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int emp_id = Convert.ToInt32(Session["emp_id"]);


            cec.ChangeRole(emp_id, Convert.ToInt32(roleid.SelectedValue));
            Response.Redirect("~/Views/representative_home.aspx");

        }
    }
}