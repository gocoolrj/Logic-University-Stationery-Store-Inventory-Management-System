using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using logicuniversity.DAO;
using Entity;

namespace logicuniversity.Controllers
{
    public class view_stockLevelController
    {
        StockLevelFacade slf = new StockLevelFacade();
        StationeryDBEntities ctx = new StationeryDBEntities();

        public List<View_stock> GetStockLevel()
        {
            var query = (from x in ctx.stockLevels
                         join
                             y in ctx.catalogues on x.item_code equals y.item_code
                         join
                             z in ctx.inventories on x.item_code equals z.item_code

                         select new View_stock
                         {
                             Item_code = x.item_code,
                             Description = y.description,
                             Location = z.bin,
                             UOM = y.unit,
                             Qoh = (int)x.balance,
                             ReorderLvl = (int)y.reorder_level,
                             ReorderQty = (int)y.reorder_quantity
                         }).ToList();
            return query;
        }

        public List<ReorderStockLevel> getreorderlevel()
        {
            return slf.getreorderlevel();
        }
        public class View_stock
        {
            string item_code;
            string description;
            string location; 
            string uom;
            int qoh;
            int reorderlvl;
            int reorderqty;

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
            public string Location
            {
                get { return location; }
                set { location = value; }
            }
            public string UOM
            {
                get { return uom; }
                set { uom = value; }
            }
            public int Qoh
            {
                get { return qoh; }
                set { qoh = value; }
            }
            public int ReorderLvl
            {
                get { return reorderlvl; }
                set { reorderlvl = value; }
            }
            public int ReorderQty
            {
                get { return reorderqty; }
                set { reorderqty = value; }
            }
        }

    }
}