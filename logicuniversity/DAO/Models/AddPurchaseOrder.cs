using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class AddPurchaseOrder
    {
        string itemcode, desc;
        decimal price, amount;
        int qty;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Itemcode
        {
            get { return itemcode; }
            set { itemcode = value; }
        }

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

    }
}