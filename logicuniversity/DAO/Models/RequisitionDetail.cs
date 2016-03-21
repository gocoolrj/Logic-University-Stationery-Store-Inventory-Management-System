using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class RequisitionDetail
    {
        string req_id;

        public string Req_id
        {
            get { return req_id; }
            set { req_id = value; }
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