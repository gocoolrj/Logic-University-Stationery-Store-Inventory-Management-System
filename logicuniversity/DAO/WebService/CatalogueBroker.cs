using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class CatalogueBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
         public catalogue[] getCatalogueList()
        {
            var cata = from o in ctx.catalogues
                       select o;
           return cata.ToArray();
        }
        
         public catalogue[] getCatalogue(string id)
         {



             int x = Int32.Parse(id);
             var res = from o in ctx.catalogues
                       where o.catg_id == x
                       select o;
             return res.ToArray();
         }

         public view_cataloguePrice[] getCataloguePrice(string id)
         {
             int x = Int32.Parse(id);
             var res = from o in ctx.view_cataloguePrice
                       where o.catg_id == x
                       select o;
             return res.ToArray();
         }
        
         public stationery_inventory_view getInventory(string item_code)
         {
             var res = (from o in ctx.stationery_inventory_view
                        where o.item_code == item_code
                        select o).FirstOrDefault();
             return res;
         }
         public stationery_inventory_view[] getInventoryAll()
         {
             var res = (from o in ctx.stationery_inventory_view
                        select o).ToArray();
             return res;
         }
        
    }
}