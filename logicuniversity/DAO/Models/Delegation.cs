using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class delegation
    {

        int Emp_id; DateTime StartDate; DateTime ToDate; String status; int role1;
        String Empname;

        public String Empname1
        {
            get { return Empname; }
            set { Empname = value; }
        }

        public Int32 Role1
        {
            get { return role1; }
            set { role1 = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime ToDate1
        {
            get { return ToDate; }
            set { ToDate = value; }
        }


        public DateTime StartDate1
        {
            get { return StartDate; }
            set { StartDate = value; }
        }

        public int Emp_id1
        {
            get { return Emp_id; }
            set { Emp_id = value; }
        }


    }


}