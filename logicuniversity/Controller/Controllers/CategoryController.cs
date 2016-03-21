using Entity;
using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Controllers
{
    public class CategoryController
    {
        CategoryFacade cf = new CategoryFacade();

        public List<category> GetCategories()
        {
            return cf.GetCategories();
        }
        public List<category> GetAll()
        {
            StationeryDBEntities ctx = new StationeryDBEntities();
            List<category> list = new List<category>();
            var res = (from o in ctx.categories
                       select o).ToList();
            return res;
        }
    }
}