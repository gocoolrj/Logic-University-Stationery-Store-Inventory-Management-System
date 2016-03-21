using Entity;
using logicuniversity.Controllers;
using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class Amend_Employee_Profile : System.Web.UI.Page
    {

        StationeryDBEntities sat = new StationeryDBEntities();
        CreateEmpController list = new CreateEmpController();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getrole.Items.Clear();
               getrole.DataSource = list.getRoleID();
               
                getrole.DataValueField = "role_id";
                getrole.DataTextField = "role1";
                getrole.DataBind();
                getrole.Items.Insert(0, "---Select---");

                GridView1.Visible = false;
            }

        }

        protected void getrole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   if (!IsPostBack)
            //      {
            ViewList.Visible = true;
            GridView1.Visible = true;

            int Role_ID = Int32.Parse(getrole.SelectedValue);
            GridView1.DataSource = list.getEmployeeByRole(Role_ID);
            GridView1.DataBind();
            //  }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AmendEmp.Visible = true;


            EmpID.Text = GridView1.SelectedRow.Cells[0].Text;
            EmpName.Text = GridView1.SelectedRow.Cells[1].Text;
            EmpEmail.Text = GridView1.SelectedRow.Cells[2].Text;
            EmpRole.Text = GridView1.SelectedRow.Cells[3].Text;
            Dept.Text = GridView1.SelectedRow.Cells[4].Text;
            EmpPassword.Text = GridView1.SelectedRow.Cells[5].Text;

            EmpRole.DataSource = list.getRoleID();
            EmpRole.DataValueField = "role_id";
            EmpRole.DataTextField = "role1";
            EmpRole.DataBind();
            EmpRole.Items.Insert(0, "---Select---");

            Dept.DataSource = list.getDeptID();
            Dept.DataValueField = "dept_id";
            Dept.DataTextField = "dept_name";
            Dept.DataBind();
            Dept.Items.Insert(0, "---Select---");


        }

        protected void UpdateEmployee_Click(object sender, EventArgs e)
        {

            int EMPID = int.Parse(EmpID.Text);

            list.modiyEmp(EMPID, EmpName.Text.ToString(), EmpEmail.Text.ToString(), Convert.ToInt32(EmpRole.SelectedValue), Convert.ToInt32(Dept.SelectedValue), EmpPassword.Text.ToString());

            Response.Redirect("~/Views/AmendInform.aspx");


        }

        protected void DeleteEmployee_Click(object sender, EventArgs e)
        {
            int EMPId = int.Parse(EmpID.Text);

            list.DeleteEmp(EMPId);
            Response.Redirect("~/Views/AmendInform.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            ViewList.Visible = true;
            GridView1.Visible = true;
            int id = Convert.ToInt32(SearchBox.Text);


            GridView1.DataSource = list.getEmployeeByID(id);
            GridView1.DataBind();
        }

    }
}