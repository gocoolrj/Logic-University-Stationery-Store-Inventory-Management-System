using Entity;
using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Controllers
{
    public class DelegateController
    {
        DelegateFacade df = new DelegateFacade();

        public void AddDelegate(Delegation d)
        {
            delegation del = new delegation();
            del.emp_id = d.Emp_id;
            del.start_date = Convert.ToDateTime(d.Start_date);
            del.end_date = Convert.ToDateTime(d.End_date);
            del.head_id = d.Head_id;
            del.reason = d.Reason;
            del.status = d.Status;
            df.AddDelegate(del);
        }
    }
}