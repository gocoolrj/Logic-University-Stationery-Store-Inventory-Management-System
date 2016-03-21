using logicuniversity.DAO;
using logicuniversity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using Entity;

namespace logicuniversity.Controllers
{
    public class POController
    {

      
        POFacade pof = new POFacade();
        StationeryDBEntities ctx = new StationeryDBEntities();

        public List<AddPurchaseOrder> GetItemPrices(int catid, string supcode)
        {
            return pof.GetItemPrices(catid, supcode);
        }

        public string AddPurchaseOrder(string supcode, decimal net, string duedate)
        {
            purchaseOrder po = new purchaseOrder();
            int po_id = 0;

            var poid = pof.GetPOID();
            if(poid!=null)
            {
                int id = Convert.ToInt32(poid.Split('O')[1]);
                po_id = id + 1;
            }
            else
            {
                po_id = 1;
            }

            po.po_id = "PO000" + po_id;
            po.sup_code=supcode;
            po.po_date = System.DateTime.Now.Date;
            po.po_duedate = Convert.ToDateTime(duedate);
            po.net_amount = net;
            po.status = "Pending";
            return pof.AddPurchaseOrder(po);
        }

        public void UpdatePO(string id)
        {
            pof.UpdatePO(id);
        }

        public List<purchaseOrder> getpurchaseorder()
        {
            var query = (from x in ctx.purchaseOrders
                         select x).ToList();
            return query;
        }

        public void updatepurchaseorder(string id)
        {

            var query = (from x in ctx.purchaseOrders
                         where x.po_id == id
                         select x).FirstOrDefault();

            if (query != null)
            {
                query.status = "Approved";
                ctx.SaveChanges();
            }

        }
        public void rejectpurchaseorder(string id)
        {

            var query = (from x in ctx.purchaseOrders
                         where x.po_id == id
                         select x).FirstOrDefault();

            if (query != null)
            {
                query.status = "Rejected";
                ctx.SaveChanges();
            }

        }

        
        public List<category> GetCategory()
        {
            var res = (from o in ctx.categories
                       select o).ToList();
            return res;
        }
        public List<catalogue> GetCatalogue(int id)
        {
            var res = (from o in ctx.catalogues
                       where o.catg_id == id
                       select o).ToList();
            return res;
        }
        public List<stationery_po_report_view> GetAll()
        {

            var res = (from o in ctx.stationery_po_report_view
                       // where o.item_code == x
                       select o).ToList();
            return res;
            // DataTable dt = LINQResultToDataTable(res);
        }
        public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;
            if (Linqlist == null) return dt;
            foreach (T Record in Linqlist)
            {
                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public List<stationery_po_report_view> SearchReportByItemCode(string code, DateTime fromDate, DateTime toDate)
        {
            var res = (from o in ctx.stationery_po_report_view
                       where o.item_code == code && (o.po_date >= fromDate.Date && o.po_date <= toDate.Date) && o.status == "Approved"
                       select o).ToList();
            return res;
        }
        public List<stationery_po_report_view> SearchReportByCategory(int catg_id, DateTime fromDate, DateTime toDate)// all catalogue
        {
            var res = (from o in ctx.stationery_po_report_view
                       where o.catg_id == catg_id && (o.po_date >= fromDate.Date && o.po_date <= toDate.Date) && o.status == "Approved"
                       select o).ToList();
            return res;





            //var catgIDgroup = (from x in res group x.catg_id by x.catg_id into grp orderby grp.Key select grp).ToList();
        }


    }
}