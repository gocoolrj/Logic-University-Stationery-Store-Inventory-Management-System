using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using logicuniversity.Models;
namespace logicuniversity.Controllers
{
    public class DelegateAuthorityControl
    {

        DelegateAuthorityFacade daf = new DelegateAuthorityFacade();
        public List<Rolename> getEmployeeListORef(int dept_id)
        {

            return daf.getEmployeeList(dept_id);


        }
        public Rolename getEmployeeInfoORef(int emp_id)
        {

            return daf.getEmployeeInfo(emp_id);
        }

        public void updateEmployeeORef(int emp_id)
        {


            daf.changeEmployeeRole(emp_id);
        }

        public void storeDelegationORef(int emp_id, DateTime startdate, DateTime todate)
        {

            daf.storeDelegationDetails(emp_id, startdate, todate);
        }
        public void storeDelegationORef(int emp_id, String datestring, String datestring1, int depthead_id)
        {


            daf.storeDelegationDetails(emp_id, datestring, datestring1, depthead_id);

        }

        public void unDelegateAuthority(int dept_id)
        {

            daf.unDelegateEmployee(dept_id);
        }


        public customDelegation getdelegatedEmployee(int dept_id)
        {

            return daf.getDelegateEmployeeInfo(dept_id);
        }

        public void unDelegateEmployee(int p)
        {
            daf.unDelegate(p);
        }
    }
}