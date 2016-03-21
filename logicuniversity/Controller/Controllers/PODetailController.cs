using logicuniversity.DAO;
using logicuniversity.Models;
using logicuniversity.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace logicuniversity.Controllers
{
    public class PODetailController
    {
        PODetailFacade podf = new PODetailFacade();
        StationeryDBEntities ctx = new StationeryDBEntities();

        public int AddPOD(string poid)
        {
            List<AddPurchaseOrder> podlist = HttpContext.Current.Session["apolist"] as List<AddPurchaseOrder>;
            int i = 0;

            foreach (AddPurchaseOrder p in podlist)
            {
                purchaseOrderDetail pod = new purchaseOrderDetail();
                pod.po_id = poid;
                pod.item_code = p.Itemcode;
                pod.quantity = p.Qty;
                pod.price = p.Price;
                i = podf.AddPOD(pod);
            }
            return i;
        }


        public void AddPODD(PurchaseOrderDetails p)
        {
            purchaseOrderDetail pod = new purchaseOrderDetail();
            pod.po_id = p.Po_id;
            pod.item_code = p.Item_code;
            pod.quantity = p.Quantity;
            pod.price = p.Price;
            int i=podf.AddPOD(pod);
        }

        public List<customPurchaseOrderDetail> getpurchaseorderdetail(string catid)
        {
            var query = (from x in ctx.purchaseOrderDetails
                         join
                             y in ctx.catalogues on x.item_code equals y.item_code
                         join
                             z in ctx.purchaseOrders on x.po_id equals z.po_id
                         where x.po_id == catid
                         select new customPurchaseOrderDetail
                         {

                             Po_id = x.po_id,
                             Description = y.description,
                             Quantity = (int)x.quantity,
                             Price = (decimal)x.price,
                             Net_amount = (int)x.price * (decimal)x.quantity,
                             Total = (int)x.price * ((decimal)x.price * (int)x.quantity)
                         }).ToList();
            return query;
        }
    }

    public class customPurchaseOrderDetail
    {
        string po_id;
        string description;
        int quantity;
        decimal price;
        decimal net_amount;
        decimal total;

        public string Po_id
        {
            get { return po_id; }
            set { po_id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public decimal Net_amount
        {
            get { return net_amount; }
            set { net_amount = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}