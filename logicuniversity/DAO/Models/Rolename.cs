using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Rolename
    {

        String emp_name, role1, email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        int emp_id;

        public String Role1
        {
            get { return role1; }
            set { role1 = value; }
        }

        public String Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }

        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }


    }
}