using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class PurchaseOrderDetail
    {
        string po_id;

        public string Po_id
        {
            get { return po_id; }
            set { po_id = value; }
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
        Decimal price;

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}