using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Catalogue
    {
        string item_code;

        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
        int catg_id;

        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        int reorder_level;

        public int Reorder_level
        {
            get { return reorder_level; }
            set { reorder_level = value; }
        }
        int reorder_quantity;

        public int Reorder_quantity
        {
            get { return reorder_quantity; }
            set { reorder_quantity = value; }
        }
        string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
    }
}