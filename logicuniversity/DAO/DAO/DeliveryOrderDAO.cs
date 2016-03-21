using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class DeliveryOrderFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public deliverOrder getDO(string poid)
        {
            var res = (from d in ctx.deliverOrders where d.po_id == poid select d).SingleOrDefault();
            if (res != null)
                return res;
            else
                return null;
        }

        public List<purchaseOrder> getDOList()
        {
            
            var dolist = (from po in ctx.purchaseOrders where po.status == "Approved" && po.deliver_status!="Delivered" select po).ToList();
            return dolist;
        }

        public List<SelectedDODList> getDODPendingList(string poid)
        {
            var dodlist = (from pod in ctx.purchaseOrderDetails
                           join po in ctx.purchaseOrders on pod.po_id equals po.po_id
                           join s in ctx.suppliers on po.sup_code equals s.sup_code
                           join c in ctx.catalogues on pod.item_code equals c.item_code
                           where pod.po_id == poid
                           select new SelectedDODList { Po_id = pod.po_id, Sup_name = s.sup_name, Item_code = pod.item_code, Item_name = c.description, Qty = (int)pod.quantity, Price = (decimal)pod.price, Status = "Pending" });
            return dodlist.ToList();
        }

        public List<SelectedDODList> getDODList(string poid)
        {
            var dodlist = (from pod in ctx.purchaseOrderDetails
                           join po in ctx.purchaseOrders on pod.po_id equals po.po_id
                           join s in ctx.suppliers on po.sup_code equals s.sup_code
                           join c in ctx.catalogues on pod.item_code equals c.item_code
                           where pod.po_id == poid && !(from u in ctx.unfulfills select u.item_code).Contains(pod.item_code)
                           select new SelectedDODList { Po_id = pod.po_id, Sup_name = s.sup_name, Item_code = pod.item_code, Item_name = c.description, Qty = (int)pod.quantity, Price = (decimal)pod.price, Status = "Delivered" }).Union
                         (from pod in ctx.purchaseOrderDetails
                          join po in ctx.purchaseOrders on pod.po_id equals po.po_id
                          join s in ctx.suppliers on po.sup_code equals s.sup_code
                          join c in ctx.catalogues on pod.item_code equals c.item_code
                          where pod.po_id == poid && (from u in ctx.unfulfills select u.item_code).Contains(pod.item_code)
                          select new SelectedDODList { Po_id = pod.po_id, Sup_name = s.sup_name, Item_code = pod.item_code, Item_name = c.description, Qty = (int)pod.quantity, Price = (decimal)pod.price, Status = "Pending" });

            return dodlist.ToList();
        }

        public string GetDODID()
        {
            var res = (from d in ctx.deliverOrders orderby d.do_id descending select d).FirstOrDefault();
            if (res != null)
                return res.do_id;
            else
                return null;
        }

        public string Check(string poid)
        {
            var res = (from d in ctx.deliverOrders where d.po_id == poid select d.po_id).Union
                (from u in ctx.unfulfills where u.@ref == poid select u.@ref).FirstOrDefault();
            if (res != null)
                return res;
            else
                return null;
        }

        public int CheckforDeliver(string poid)
        {
            var pores = (from po in ctx.purchaseOrders
                         join pod in ctx.purchaseOrderDetails on po.po_id equals pod.po_id
                         where po.po_id == poid
                         select po).ToList();

            var dores = (from d in ctx.deliverOrders
                         join dod in ctx.deliverOrderDetails on d.do_id equals dod.do_id
                         where d.po_id == poid
                         select d).ToList();

            if (pores.Count() == dores.Count())
                return 1;
            else
                return 0;
        }

        public string AddDO(deliverOrder d)
        {
            ctx.deliverOrders.Add(d);
            ctx.SaveChanges();
            return d.do_id;
        }

        public int AddDOD(deliverOrderDetail dd)
        {
            ctx.deliverOrderDetails.Add(dd);
            return ctx.SaveChanges();
        }
    }

    public class SelectedDODList
    {
        string po_id, sup_name, item_code, item_name, status;
        int qty;
        decimal price;

        public string Po_id
        {
            get { return po_id; }
            set { po_id = value; }
        }

        public string Sup_name
        {
            get { return sup_name; }
            set { sup_name = value; }
        }

        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}