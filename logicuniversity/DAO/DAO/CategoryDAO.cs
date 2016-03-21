using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class CategoryFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public List<category> GetCategories()
        {
            var catlist = from x in ctx.categories select x;
            return catlist.ToList();
        }
    }
}