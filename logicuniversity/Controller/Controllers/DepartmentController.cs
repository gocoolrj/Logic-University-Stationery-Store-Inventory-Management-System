using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace logicuniversity.Controllers
{
    public class DepartmentController
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public List<department> getAll()
        {
            var res = (from o in ctx.departments
                       select o).ToList();
            return res;
        }
    }
}