using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class InventoryAdjDetail
    {
        string voucher_id;

        public string Voucher_id
        {
            get { return voucher_id; }
            set { voucher_id = value; }
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
        string reason;

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }
}