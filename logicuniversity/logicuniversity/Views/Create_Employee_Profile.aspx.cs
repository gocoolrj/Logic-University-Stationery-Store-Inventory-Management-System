using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class Create_Employee_Profile : System.Web.UI.Page
    {

        CreateEmpController cec = new CreateEmpController();
        //public void Clear()
        //{
        //    empnameid.Text = "";
        //    empmailid.Text = "";
        //    passwordid.Text = "";
        //}
        protected void Page_Load(object sender, EventArgs e)
        {



            //roleid.Items.Clear();
            //deptid.Items.Clear();
            //roleid.Items.Add("3");
            //roleid.Items.Add("4");
            //roleid.Items.Add("5");
            //roleid.Items.Clear();
            roleid.DataSource = cec.getRoleID();
            roleid.DataValueField = "role_id";
            roleid.DataTextField = "role1";
            roleid.DataBind();
            roleid.Items.Insert(0, "---Select---");

            //deptid.Items.Clear();
            deptid.DataSource = cec.getDeptID();
            deptid.DataValueField = "dept_id";
            deptid.DataTextField = "dept_name";
            deptid.DataBind();
            deptid.Items.Insert(0, "---Select---");

        }

        protected void Create_Click(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {


                cec.createEmployee(empnameid.Text.ToString(), empmailid.Text.ToString(), Convert.ToInt16(roleid.SelectedValue), Convert.ToInt16(deptid.SelectedValue), passwordid.Text.ToString());
                Response.Redirect("~/Views/DisplayID.aspx");




            }

        }




    }
}