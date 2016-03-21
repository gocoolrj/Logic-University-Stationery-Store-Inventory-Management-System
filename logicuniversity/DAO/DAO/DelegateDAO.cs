using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class DelegateFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public void AddDelegate(delegation d)
        {
            ctx.delegations.Add(d);
            ctx.SaveChanges();
        }
    }
}