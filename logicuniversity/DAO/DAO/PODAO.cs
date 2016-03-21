using logicuniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;



namespace logicuniversity.DAO
{
    public class POFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public List<AddPurchaseOrder> GetItemPrices(int catid, string supcode)
        {
            var res = (from cat in ctx.categories
                       join
                           c in ctx.catalogues on cat.catg_id equals c.catg_id
                       join
                           qd in ctx.quotationDetails on c.item_code equals qd.itemCode
                       join
                           q in ctx.quotations on qd.quo_id equals q.quo_id
                       where cat.catg_id == catid && q.sup_code == supcode
                       select new AddPurchaseOrder { Itemcode = c.item_code, Desc = c.description, Price = (decimal)(qd.price) }).ToList();

            return res;
        }

        public string GetPOID()
        {
            var res = (from po in ctx.purchaseOrders orderby po.po_id descending select po.po_id).ToArray();
            int a = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (a < Convert.ToInt32(res[i].Split('O')[1]))
                {
                    a = Convert.ToInt32(res[i].Split('O')[1]);
                }
            }
            string po_id = "PO000" + a;
            if (res != null)
                return po_id;
            else
                return null;
        }

        public string AddPurchaseOrder(purchaseOrder p)
        {
            ctx.purchaseOrders.Add(p);
            ctx.SaveChanges();
            return p.po_id;
        }

        public void UpdatePO(string id)
        {
            var qry = (from po in ctx.purchaseOrders where po.po_id == id select po).FirstOrDefault();
            if (qry != null)
            {
                qry.deliver_status = "Delivered";
                ctx.SaveChanges();
            }
        }
    }
}