using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Controllers
{
    public class CatalogueController
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public List<catalogue> GetCatalogue(int id)
        {
            var res = (from o in ctx.catalogues
                       where o.catg_id == id
                       select o).ToList();
            return res;
        }
    }
}