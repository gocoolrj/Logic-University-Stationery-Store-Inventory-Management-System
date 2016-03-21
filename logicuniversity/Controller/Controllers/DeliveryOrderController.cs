using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace logicuniversity.Controllers
{
    public class DeliveryOrderController
    {
        DeliveryOrderFacade dof = new DeliveryOrderFacade();
        SupplierFacade sf = new SupplierFacade();

        public deliverOrder getDO(string poid)
        {
            return dof.getDO(poid);
        }

        public List<purchaseOrder> getDOList()
        {
            return dof.getDOList();
        }

        public List<SelectedDODList> getDODPendingList(string poid)
        {
            return dof.getDODPendingList(poid);
        }

        public List<SelectedDODList> getDODList(string poid)
        {
            return dof.getDODList(poid);
        }

        public string Check(string poid)
        {
            return dof.Check(poid);
        }

        public int CheckforDeliver(string poid)
        {
            return dof.CheckforDeliver(poid);
        }

        public string AddDO(string poid, string sup_name)
        {
            deliverOrder d = new deliverOrder();
            d.po_id = poid;
            d.sup_code = sf.GetSupplier(sup_name).sup_code;
            d.do_date = System.DateTime.Now.Date;
            int do_id = 0;

            var doid = dof.GetDODID();
            if (doid != null)
            {
                int id = Convert.ToInt32(doid.Split('O')[1]);
                do_id = id + 1;
            }
            else
                do_id = 1;
            d.do_id = "DO000" + do_id;
            return dof.AddDO(d);
        }

        public int AddDOD(List<deliverOrderDetail> dodlist)
        {
            int i = 0;

            foreach(deliverOrderDetail dod in dodlist)
            {
                i= dof.AddDOD(dod);
            }
            return i;
        }
    }
}