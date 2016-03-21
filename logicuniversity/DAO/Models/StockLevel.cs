using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class StockLevel
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
        int balance;

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}