using logicuniversity.Controllers;
using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Models;
namespace logicuniversity.Views
{
    public partial class Delegate_Authority : System.Web.UI.Page
    {
        int dept_id; string pName; int emp_id;
        DelegateAuthorityControl da = new DelegateAuthorityControl();
        SendMail sm = new SendMail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dept_id = Convert.ToInt16(Session["dept_id"]);
                GridView1.DataSource = da.getEmployeeListORef(dept_id);
                GridView1.DataBind();
            }


        }

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {
            //Calendar2.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            //Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            //TextBox2.Text = Calendar2.SelectedDate.ToShortDateString();
            //  Calendar2.Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((TextBox1.Text.ToString() == "") && (TextBox2.Text.ToString() == ""))

            //{
            //    RequiredFieldValidator1.Visible = true;
            //    RequiredFieldValidator2.Visible = true;

            // }

            // else if (TextBox1.Text.ToString() == "") { RequiredFieldValidator1.Visible = true; }
            // else if(TextBox2.Text.ToString() == ""){RequiredFieldValidator2.Visible = true; }
            // else
            // {
            labelEmployeeID.Visible = true;
            labelEmployeeName.Visible = true;
            labelEmailAddress.Visible = true;

            pName = GridView1.SelectedRow.Cells[0].Text;
            Console.WriteLine(pName);
            this.emp_id = Int32.Parse(pName);
            Rolename rl = da.getEmployeeInfoORef(emp_id);
            Label1.Visible = true;
            label2.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;

            labelEmployeeID.Text = rl.Emp_id.ToString();
            labelEmployeeName.Text = rl.Emp_name.ToString();
            labelEmailAddress.Text = rl.Email.ToString();
            BtnYes.Visible = true;
            BtnNo.Visible = true;

        }

        // }

        protected void BtnYes_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text.ToString() == "") && (TextBox2.Text.ToString() == ""))
            {
                RequiredFieldValidator1.Visible = true;
                RequiredFieldValidator2.Visible = true;

            }

            else if (TextBox1.Text.ToString() == "") { RequiredFieldValidator1.Visible = true; }
            else if (TextBox2.Text.ToString() == "") { RequiredFieldValidator2.Visible = true; }
            else
            {
                da.updateEmployeeORef(int.Parse(labelEmployeeID.Text));
                string datestring = Request.Form[TextBox1.UniqueID];
                string datestring1 = Request.Form[TextBox2.UniqueID];
                da.storeDelegationORef(Convert.ToInt32(labelEmployeeID.Text), datestring, datestring1, Convert.ToInt32(Session["depthead_id"]));
                String from = "team2.2015.dipsa@gmail.com";
                String to = da.getEmployeeInfoORef(Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text)).Email.ToString();
                String body = "You have been delegated with the authority of Department Head for the time period " + TextBox1.Text + " to " + TextBox2.Text;
                String subject = "Authority Delegated";
                sm.sendEmail(from, to, subject, body);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delegated Successfully')", true);
                Response.Redirect("~/Views/delegatesucc.aspx");





            }
        }
        protected void BtnNo_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            label2.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;

            labelEmployeeID.Visible = false;
            labelEmployeeName.Visible = false;
            labelEmailAddress.Visible = false;
            BtnYes.Visible = false;
            BtnNo.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // da.unDelegateAuthority(Convert.ToInt16(Session["dept_id"]));
        }
    }


}

