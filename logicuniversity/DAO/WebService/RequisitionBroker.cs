using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using logicuniversity.DAO;
using Entity;
namespace logicuniversity.WebService
{
    public class RequisitionBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        EFFacade ef = new EFFacade();

        public Retrieval[] getRetrivement()
        {
            List<Stationery1> list = ef.getStationeryByItemName();
            List<Retrieval> listr = new List<Retrieval>();
            foreach(Stationery1 s in list)
            {
                Retrieval r = new Retrieval();
                string item_code = s.Item_code;
                var cate = ctx.catalogues.FirstOrDefault(x => x.item_code == item_code);
                var name =ctx.categories.FirstOrDefault(x=>x.catg_id==cate.catg_id);
                r.Name = name.name;
                r.Description = s.Description;
                listr.Add(r);
            }
            return listr.ToArray();
        }

        

    
        public stationery_trend_report_view[] getDeptReqList(String dept_id, DateTime fromDate, DateTime toDate)
        {
            int x = Int32.Parse(dept_id);
            var res = (from o in ctx.stationery_trend_report_view
                       where o.dept_id == x && (o.req_date >= fromDate.Date && o.req_date <= toDate.Date)
                       select o).ToArray();
            return res;

        }



        public stationery_trend_report_view[] getRequisitionByItemCode(string item_code)
        {
            var res = (from o in ctx.stationery_trend_report_view
                       where o.item_code == item_code
                       select o).ToArray();
            return res;
        }
      
        public stationery_trend_report_view[] getRetrimentDetail(string item_code, DateTime fromDate, DateTime toDate)
        {
            var res = (from o in ctx.stationery_trend_report_view
                       where o.item_code == item_code && (o.req_date >= fromDate.Date && o.req_date <= toDate.Date)
                       select o).ToArray();
            return res;
        }

        public bool updateReqistionByDeptDetail(RequisitionByDeptDetail rq)
        {
            bool check = false;
            var qry = (from rd in ctx.requisitionByDeptDetails where rd.req_dept_id == rq.Req_dept_id && rd.item_code == rq.Item_code select rd).FirstOrDefault();
            if (qry != null)
            {
                qry.req_quantity = rq.Req_quantity;
                ctx.SaveChanges();
                check = true;
            }
            return check;
        }


        //internal bool updateReqistionByDeptDetail(RequisitionByDeptDetail rq)
        //{
        //    throw new NotImplementedException();
        //}
    }
}