using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class StockCard
    {
        string item_code;

        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        string quantity;

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}