using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Entity;

namespace logicuniversity.Controllers
{
    public class InvAdjController
    {
        InvAdjFacade iaf = new InvAdjFacade();

        public string AddInvAdj(InventoryAdj ia)
        {
            inventoryAdj invadj = new inventoryAdj();

            int v_id = 0;
            var vid = iaf.GetVouID();
            if (vid != null)
            {
                int id = Convert.ToInt32(vid.Split('j')[1]);
                v_id = id + 1;
            }
            else
                v_id = 1;

            invadj.voucher_id = "Adj000" + v_id;
            invadj.date_issue = Convert.ToDateTime(ia.Date_issue);
         
            invadj.status = ia.Status;

            return iaf.AddInvAdj(invadj);
        }

        public void AddInvAdjDetail(InventoryAdjDetails iad)
        {
            inventoryAdjDetail iadobj = new inventoryAdjDetail();
            iadobj.voucher_id = iad.Voucher_id;
            iadobj.item_code = iad.Item_code;
            iadobj.quantity = iad.Qty;
            iadobj.reason = iad.Reason;
            iaf.AddInvAdjDetail(iadobj);
        }

        public inventoryAdj[] getInvAdjPendingList()
        {
            return iaf.getInvAdjPendingList();
        }

        public inventoryAdj getInvAdjPending(string id)
        {
            return iaf.getInvAdjPending(id);
        }

        public InventoryAdjDetails[] getInvAdjDList(string id)
        {
            return iaf.getInvAdjDList(id);
        }

        public void UpdateInvAdj(InventoryAdj ia)
        {
            inventoryAdj iaobj = new inventoryAdj();
            iaobj.voucher_id = ia.Voucher_id;
            if (ia.Sup_id != "")
                iaobj.emp_supervisor_id = Convert.ToInt16(ia.Sup_id);
            if (ia.Auth_id != "")
                iaobj.emp_auth_id = Convert.ToInt16(ia.Auth_id);
            iaobj.status = ia.Status;
            iaf.UpdateInvAdj(iaobj);
        }

        public void UpdateInvAdj(string vid, int supid, int mgrid, string status)
        {
            inventoryAdj iaobj = new inventoryAdj();
            iaobj.voucher_id = vid;
            if (supid != 0)
                iaobj.emp_supervisor_id = supid;
            if (mgrid != 0)
                iaobj.emp_auth_id = mgrid;
            iaobj.status = status;
            iaf.UpdateInvAdj(iaobj);
        }

        public List<inventoryAdj> getInvAdjList(string s)
        {
            return iaf.getInvAdjList(s);
        }

        public List<inventoryAdjDetail> getInvAdjDList1(string id)
        {
            return iaf.getInvAdjDList1(id);
        }
    }
}