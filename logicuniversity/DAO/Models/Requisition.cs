using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Requisition
    {
        string req_id;

        public string Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        int dept_id;

        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }
        int emp_head_id;

        public int Emp_head_id
        {
            get { return emp_head_id; }
            set { emp_head_id = value; }
        }
        DateTime req_date;

        public DateTime Req_date
        {
            get { return req_date; }
            set { req_date = value; }
        }
        DateTime approve_date;

        public DateTime Approve_date
        {
            get { return approve_date; }
            set { approve_date = value; }
        }
        int approve_emp_id;

        public int Approve_emp_id
        {
            get { return approve_emp_id; }
            set { approve_emp_id = value; }
        }
        int received_emp_id;

        public int Received_emp_id
        {
            get { return received_emp_id; }
            set { received_emp_id = value; }
        }
        DateTime received_date;

        public DateTime Received_date
        {
            get { return received_date; }
            set { received_date = value; }
        }
    }
}