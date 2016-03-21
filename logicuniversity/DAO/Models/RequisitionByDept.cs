using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class RequisitionByDept
    {
        int req_dept_id;

        public int Req_dept_id
        {
            get { return req_dept_id; }
            set { req_dept_id = value; }
        }
        int dept_id;

        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }
        int emp_id;

        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }
        DateTime req_date;

        public DateTime Req_date
        {
            get { return req_date; }
            set { req_date = value; }
        }
        string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}