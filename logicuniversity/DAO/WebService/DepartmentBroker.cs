using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class DepartmentBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public department getDepartment(string id)
        {
            int x = Int32.Parse(id);
            var cata = (from o in ctx.departments
                        where o.dept_id == x
                        select o).FirstOrDefault();
            return cata;
        }

        

        public department[] getDepartmentAll()
        {
            var res = (from o in ctx.departments
                       select o).ToArray();
            return res;
        }
    }
}