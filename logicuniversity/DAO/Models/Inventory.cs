using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Inventory
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
        string bin;

        public string Bin
        {
            get { return bin; }
            set { bin = value; }
        }
    }
}