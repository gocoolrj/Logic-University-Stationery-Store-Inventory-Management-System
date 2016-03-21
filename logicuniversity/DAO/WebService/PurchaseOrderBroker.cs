using logicuniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class PurchaseOrderBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public purchaseOrder[] getPurchasaeOrderList()
        {
            var po = from o in ctx.purchaseOrders
                     select o;
            
            return po.ToArray();
        }

        public purchaseOrder getPurchaseOrder(string id)
        {
            var po = (from o in ctx.purchaseOrders
                      where o.po_id == id
                      select o).SingleOrDefault();

            return po;
        }
        public purchaseOrder[] getPurchasaeOrderPendingList()
        {
            var po = from o in ctx.purchaseOrders
                     where o.status == "Pending"
                     select o;

            return po.ToArray();
        }

        public purchaseOrder getPurchaseOrderPending(string id)
        {
            var po = (from o in ctx.purchaseOrders
                      where o.po_id == id && o.status=="Pending"
                      select o).SingleOrDefault();

            return po;
        }

        public void updatePO(PurchaseOrder p)
        {
            purchaseOrder po = getPurchaseOrder(p.Po_id);
            if(po!=null)
            {
                po.po_approvedate = System.DateTime.Today;
                po.remark = p.Remark;
                po.status = p.Status;
                ctx.SaveChanges();
            }
        }

        public PurchaseOrderDetails[] getPurchaseOrderDetail(string id)
        {
            var podlist = (from pod in ctx.purchaseOrderDetails
                           join
                               c in ctx.catalogues on pod.item_code equals c.item_code
                           where pod.po_id == id
                           select new PurchaseOrderDetails { Po_id = pod.po_id, Item_code = pod.item_code, Desc = c.description, Quantity = (int)pod.quantity, Price = (decimal)pod.price, Amount = (decimal)(pod.quantity * pod.price) });
            return podlist.ToArray();
        }
    
        public stationery_po_report_view[] getStationeryOrder(DateTime fromDate, DateTime toDate)
        {
            var res = (from o in ctx.stationery_po_report_view
                       where (o.po_date >= fromDate.Date && o.po_date <= toDate.Date)
                       select o).ToArray();
            return res;

        }
    }
}