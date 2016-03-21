using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class StockLevelFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public List<ReorderStockLevel> getreorderlevel()
        {
            var qry = (from sl in ctx.stockLevels
                       join
                           c in ctx.catalogues on sl.item_code equals c.item_code
                       where sl.balance < c.reorder_level
                       select new ReorderStockLevel
                       {
                           Catg_id = c.category.name,
                           Item_code = c.item_code,
                           Description = c.description,
                           Reorder_level = (int)c.reorder_level,
                           UOM = c.unit,
                           Balance = (int)sl.balance
                       }).ToList();
            return qry;
        }

    }

    public class ReorderStockLevel
    {
        string catg_id;
        string item_code;
        string description;
        string uom;
        int reorder_level;
        int balance;

        public string Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }

        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string UOM
        {
            get { return uom; }
            set { uom = value; }
        }

        public int Reorder_level
        {
            get { return reorder_level; }
            set { reorder_level = value; }
        }
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}