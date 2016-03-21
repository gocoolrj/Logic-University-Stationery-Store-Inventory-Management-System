using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class PurchaseOrder
    {
        string po_id;

        public string Po_id
        {
            get { return po_id; }
            set { po_id = value; }
        }
        string sup_code;

        public string Sup_code
        {
            get { return sup_code; }
            set { sup_code = value; }
        }
        DateTime po_date;

        public DateTime Po_date
        {
            get { return po_date; }
            set { po_date = value; }
        }
        DateTime po_duedate;

        public DateTime Po_duedate
        {
            get { return po_duedate; }
            set { po_duedate = value; }
        }
        DateTime po_approvedate;

        public DateTime Po_approvedate
        {
            get { return po_approvedate; }
            set { po_approvedate = value; }
        }
        int dep_id;

        public int Dep_id
        {
            get { return dep_id; }
            set { dep_id = value; }
        }
        string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}