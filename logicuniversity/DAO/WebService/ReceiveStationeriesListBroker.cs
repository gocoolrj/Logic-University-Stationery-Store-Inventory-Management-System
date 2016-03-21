using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class ReceiveStationeriesListBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public ReceiveStationeriesList[] GetReceiveStationeriesList()
        {

            var query = from u in ctx.requisitionByDeptDetails
                        join q in ctx.catalogues on u.item_code equals q.item_code
                        join w in ctx.categories on q.catg_id equals w.catg_id
                        select new { u.req_quantity, w.name, q.description, u.req_dept_id };

            List<ReceiveStationeriesList> list = new List<ReceiveStationeriesList>();

            foreach (var element in query)
            {
                ReceiveStationeriesList gvModel = new ReceiveStationeriesList();
                gvModel.category = element.name;
                gvModel.description = element.description;
                gvModel.quantity = element.req_quantity.ToString();
                gvModel.id = element.req_dept_id.ToString();
                list.Add(gvModel);
            }
            return list.ToArray();
        }

    }
}