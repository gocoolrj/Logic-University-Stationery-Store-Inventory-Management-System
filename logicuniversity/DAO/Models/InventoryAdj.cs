using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class InventoryAdj
    {
        string voucher_id;

        public string Voucher_id
        {
            get { return voucher_id; }
            set { voucher_id = value; }
        }
        DateTime date_issue;

        public DateTime Date_issue
        {
            get { return date_issue; }
            set { date_issue = value; }
        }
        int emp_supervisor_id;

        public int Emp_supervisor_id
        {
            get { return emp_supervisor_id; }
            set { emp_supervisor_id = value; }
        }
        int emp_auth_id;

        public int Emp_auth_id
        {
            get { return emp_auth_id; }
            set { emp_auth_id = value; }
        }
    }
}