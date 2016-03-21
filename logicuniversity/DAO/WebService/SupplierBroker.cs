using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class SupplierBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public supplier[] getActiveSupplierList()
        {
            var res = from o in ctx.suppliers
                      where o.sup_rank == "1st" || o.sup_rank == "2nd" || o.sup_rank == "3rd"
                      select o;
            return res.ToArray();
        }
    }
}