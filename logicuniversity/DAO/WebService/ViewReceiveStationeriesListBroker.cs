using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class ViewReceiveStationeriesListBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public ViewReceiveStationeriesList[] GetViewReceiveStationeriesList()
        {
            var query = from tt in ctx.requisitions
                        where tt.dept_id == 5
                        join xx in ctx.employees on tt.req_emp_id equals xx.emp_id
                        select new { xx.emp_name, tt.req_date, tt.req_id };

            List<ViewReceiveStationeriesList> list = new List<ViewReceiveStationeriesList>();

            foreach (var element in query)
            {
                ViewReceiveStationeriesList gvModel = new ViewReceiveStationeriesList();
                gvModel.Req_id = element.req_id.ToString();
                gvModel.Emp_name = element.emp_name;
                gvModel.Date = element.req_date.ToString();
                list.Add(gvModel);
            }
            return list.ToArray();
        }
    }
}