using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class CategoryBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public category[] getCategoryList()
        {
            var cata = from o in ctx.categories
                       select o;
            return cata.ToArray();
        }
    }
}