using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace logicuniversity.WebService
{
    public class updateUnfulfillItemBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public void updateunfulfillitem(WCF_UpdateUnfulfillItem w)
        {
            var para1 = ctx.catalogues.FirstOrDefault(o => o.description == w.desc);
            var para2 = ctx.departments.FirstOrDefault(x => x.dept_name == w.deptname);

            unfulfill uf = new unfulfill();
            uf.item_code = para1.item_code;
            uf.dept_id = para2.dept_id;
            uf.quantity = Convert.ToInt16(w.quantity);
            uf.unfufil_date = DateTime.Now;
            uf.remark = w.remarks;

            ctx.unfulfills.Add(uf);
            ctx.SaveChanges();






        }
    }
}