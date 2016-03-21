using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{


    public partial class Update_Dept : System.Web.UI.Page
    {
        public int colid;

        UpdateDeptController upc = new UpdateDeptController();
        SendMail sm = new SendMail();


        protected void Page_Load(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.ToString("MM-dd-yyyy h:mmt");

            int dept_id = Convert.ToInt32(Session["dept_id"]);
            string Contact = (string)(Session["dept_phone"]).ToString();
            string emp_name = (string)(Session["emp_name"]).ToString();

            if (Session["dept_id"] != null)
            {
                DepartID.Text = dept_id.ToString();
            }
            if (Session["dept_phone"] != null)
            {
                DeptContact.Text = Contact;
            }
            if (Session["emp_name"] != null)
            {
                DeptHead.Text = emp_name;
            }
            else
            {
                Response.Redirect("~/view/head_home.appx");
            }
            if (!IsPostBack)
            {
                Collectionid.Items.Clear();
                Collectionid.DataSource = upc.GetColID();
                Collectionid.DataValueField = "col_id";
                Collectionid.DataTextField = "col_location";
                Collectionid.DataBind();
                Collectionid.Items.Insert(0, "---Select---");

                Employeelist.Items.Clear();
                Employeelist.DataSource = upc.GetAllEmployee(dept_id);


                //      Employeelist.DataValueField = "emp_name";
                //    Employeelist.DataTextField = "emp_name";
                Employeelist.DataBind();
                Employeelist.Items.Insert(0, "---Select---");

            }
        }

        protected void updatedept_Click(object sender, EventArgs e)
        {
            int dept_id = Convert.ToInt32(Session["dept_id"]);



            int COLID = Int32.Parse(Collectionid.SelectedValue);
            if (IsPostBack == true)
            {
                upc.updateDept(dept_id, Convert.ToInt32(Collectionid.SelectedValue));
                upc.updateEmp(Employeelist.SelectedValue.ToString());
            }



            string empname = Employeelist.SelectedItem.Value;
            String emailfrom = "123Logicuniversity@gmail.com ";
            string subject = View.Text + "notification.";
            String body = View.Text + " notification.The department ID is" + Session["dept_id"] + "and Dep Rep name is" + empname;
            upc.SendEmail(emailfrom, upc.GetClerkMail(COLID), subject, body);
            upc.SendEmail(emailfrom, upc.GetEmEmail(empname), subject, body);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);

            //     Response.Redirect("~/Views/head_home.aspx");







        }

        protected void Canceldept_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/head_home.aspx");
        }

        //protected void Collectionid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int colid = Convert.ToInt16(Collectionid.SelectedValue);
        //    string s = colid.ToString();
        //}
    }
}