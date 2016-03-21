using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class CollectionBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public collectionPoint getcollectionPoint(string dept_id)
        {
            int x = Int32.Parse(dept_id);
            var cata = (from o in ctx.collectionPoints
                        join p in ctx.departments on o.col_id equals p.col_id
                        where p.dept_id == x
                        select o).FirstOrDefault();
            return cata;
        }

    }
}