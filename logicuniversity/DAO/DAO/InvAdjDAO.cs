using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class InvAdjFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public string AddInvAdj(inventoryAdj ia)
        {
            ctx.inventoryAdjs.Add(ia);
            ctx.SaveChanges();
            return ia.voucher_id;
        }

        public string GetVouID()
        {
            var res = (from i in ctx.inventoryAdjs orderby i.voucher_id descending select i.voucher_id).ToArray();
            int a = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (a < Convert.ToInt32(res[i].Split('O')[1]))
                {
                    a = Convert.ToInt32(res[i].Split('O')[1]);
                }
            }
            string vo_id = "Adj000" + a;
            if (res != null)
                return vo_id;
            else
                return null;
        }
      
        public void AddInvAdjDetail(inventoryAdjDetail iad)
        {
            ctx.inventoryAdjDetails.Add(iad);
            ctx.SaveChanges();
        }

        public inventoryAdj getInvAdj(string id)
        {
            var res = (from ia in ctx.inventoryAdjs where ia.voucher_id == id select ia).SingleOrDefault();
            return res;
        }

        public inventoryAdj[] getInvAdjPendingList()
        {
            var res = (from ia in ctx.inventoryAdjs where ia.status == "Pending" select ia);
            return res.ToArray();
        }

        public inventoryAdj getInvAdjPending(string id)
        {
            var res = (from ia in ctx.inventoryAdjs where ia.voucher_id == id && ia.status == "Pending" select ia).SingleOrDefault();
            return res;
        }

        public InventoryAdjDetails[] getInvAdjDList(string id)
        {
            var res = (from iad in ctx.inventoryAdjDetails
                       join c in ctx.catalogues on iad.item_code equals c.item_code
                       where iad.voucher_id == id
                       select new InventoryAdjDetails { Voucher_id = iad.voucher_id, Item_code = iad.item_code, Description = c.description, Qty = (int)iad.quantity, Reason = iad.reason });
            return res.ToArray();
        }

        public void UpdateInvAdj(inventoryAdj ia)
        {
            inventoryAdj iaobj = getInvAdj(ia.voucher_id);
            if (iaobj != null)
            {
                iaobj.emp_auth_id = ia.emp_auth_id;
                iaobj.emp_supervisor_id = ia.emp_supervisor_id;
                iaobj.status = ia.status;
                ctx.SaveChanges();
            }
        }
        public List<inventoryAdj> getInvAdjList(string s)
        {
            if (s == "mgr")
                return (from ia in ctx.inventoryAdjs where ia.total >= 250 select ia).ToList();
            else if (s == "sup")
                return (from ia in ctx.inventoryAdjs where ia.total < 250 select ia).ToList();
            else
                return null;
        }

        public List<inventoryAdjDetail> getInvAdjDList1(string id)
        {
            var res = (from iad in ctx.inventoryAdjDetails where iad.voucher_id == id select iad).ToList();
            if (res != null)
                return res;
            else
                return null;
        }
    }
}