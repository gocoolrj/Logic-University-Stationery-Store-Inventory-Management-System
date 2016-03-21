using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class RequisitionByDeptDetail
    {
        int req_dept_id;

        public int Req_dept_id
        {
            get { return req_dept_id; }
            set { req_dept_id = value; }
        }
        string item_code;

        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
        int req_quantity;

        public int Req_quantity
        {
            get { return req_quantity; }
            set { req_quantity = value; }
        }
    }
}