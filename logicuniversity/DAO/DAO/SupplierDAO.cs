using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class SupplierFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public List<supplier> GetSuppliers()
        {
            List<string> rank = new List<string>() { "1st", "2nd", "3rd" };
            var slist = (from s in ctx.suppliers where rank.Contains(s.sup_rank) orderby s.sup_rank select s);
            return slist.ToList();
        }

        public supplier GetSupplier(string name)
        {
            return (from s in ctx.suppliers where s.sup_name == name select s).FirstOrDefault();
        }
    }
}