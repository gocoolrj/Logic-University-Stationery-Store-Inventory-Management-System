using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class DeliverOrder
    {
        string do_id;

        public string Do_id
        {
            get { return do_id; }
            set { do_id = value; }
        }

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

        DateTime do_date;

        public DateTime Do_date
        {
            get { return do_date; }
            set { do_date = value; }
        }

        int dept_id;

        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }
        
        
    }
}