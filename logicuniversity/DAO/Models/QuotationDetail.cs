using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class QuotationDetail
    {
        int quo_id;

        public int Quo_id
        {
            get { return quo_id; }
            set { quo_id = value; }
        }
        string itemCode;

        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }
        Decimal price;

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}