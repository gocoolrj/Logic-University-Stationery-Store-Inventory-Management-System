using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Employee
    {
        int emp_id;

        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }
        string emp_name;

        public string Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }
        int role_id;

        public int Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }
        int dept_id;

        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }
        string emp_email;

        public string Emp_email
        {
            get { return emp_email; }
            set { emp_email = value; }
        }
        string emp_password;

        public string Emp_password
        {
            get { return emp_password; }
            set { emp_password = value; }
        }
    }
}