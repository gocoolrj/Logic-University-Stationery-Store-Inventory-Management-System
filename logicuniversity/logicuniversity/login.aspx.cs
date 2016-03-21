using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Controllers;

namespace logicuniversity
{
    public partial class login : System.Web.UI.Page
    {
        string email;
        string password;
        bool check;
        string user_role;
        int emp_id;
        int dept_id;
        int flag;
        string emp_name;
        string dept_phone;
        loginController lc = new loginController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text != "" && txtPassword.Text != "")
            {
                email = txtUserID.Text;
                password = txtPassword.Text;
                check = lc.checkUserNamePassword(email, password);

                if (check)
                {
                    lblerror.Text = "";
                    emp_id = lc.getUserID(email);
                    user_role = lc.getUserRole(email);
                    dept_id = lc.getDeptID(email, password);
                    emp_name = lc.getUserName(email, password);
                    dept_phone = lc.getDeptPhone(email, password);
                    Session["user_role"] = user_role;
                    Session["user_id"] = emp_id;
                    Session["email"] = email;
                    Session["dept_id"] = dept_id;
                    Session["emp_name"] = emp_name;
                    Session["emp_id"] = emp_id;
                    Session["dept_phone"] = dept_phone;
                    Session["depthead_id"] = emp_id;
                    if (user_role == "Head")
                    {
                        flag = lc.checkHead(emp_id);
                        if (flag == 1)
                        { Response.Redirect(string.Format("~/Views/delegatesucc.aspx")); }
                        else
                        { Response.Redirect(string.Format("~/Views/head_home.aspx")); }
                      //  Response.Redirect(string.Format("~/Views/head_home.aspx"));
                    }
                    else if (user_role == "Manager")
                    {
                        Response.Redirect(string.Format("~/Views/manager_home.aspx"));
                    }
                    else if (user_role == "Store Clerk")
                    {
                        Response.Redirect(string.Format("~/Views/clerk_home.aspx"));
                    }
                    else if (user_role == "Supervisor")
                    {
                        Response.Redirect(string.Format("~/Views/supervisor_home.aspx"));
                    }
                    else if (user_role == "Representative")
                    {
                        Response.Redirect(string.Format("~/Views/representative_home.aspx"));
                    }
                    else if (user_role == "Employee")
                    {
                        Response.Redirect(string.Format("~/Views/employee_home.aspx"));
                    }
                }
                else
                {
                    lblerror.Text = "Wrong User Name and Password";
                }
            }
        }
    }
}