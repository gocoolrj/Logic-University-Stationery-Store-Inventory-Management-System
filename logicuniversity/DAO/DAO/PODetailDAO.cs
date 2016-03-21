using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class PODetailFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public int AddPOD(purchaseOrderDetail p)
        {
            ctx.purchaseOrderDetails.Add(p);
            return ctx.SaveChanges();
        }
    }
}