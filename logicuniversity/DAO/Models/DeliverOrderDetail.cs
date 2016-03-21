using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class DeliverOrderDetail
    {
        string do_id;

        public string Do_id
        {
            get { return do_id; }
            set { do_id = value; }
        }

        string item_code;

        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}