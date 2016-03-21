using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Unfulfill
    {
        int id;

            public int Id
            {
              get { return id; }
              set { id = value; }
            }
       string item_code;

            public string Item_code
            {
                get { return item_code; }
                set { item_code = value; }
            }
            int dept_id;

            public int Dept_id
            {
                get { return dept_id; }
                set { dept_id = value; }
            }

            int quantity;

            public int Quantity
            {
                get { return quantity; }
                set { quantity = value; }
            }
            DateTime unfufil_date;

            public DateTime Unfufil_date
            {
                get { return unfufil_date; }
                set { unfufil_date = value; }
            }
            string remark;

            public string Remark
            {
                get { return remark; }
                set { remark = value; }
            }
            string req_id;

            public string Req_id
            {
                get { return req_id; }
                set { req_id = value; }
            }
            string reference;

            public string Reference
            {
                get { return reference; }
                set { reference = value; }
            }
    }
}