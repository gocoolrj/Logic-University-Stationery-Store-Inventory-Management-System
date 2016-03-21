using Entity;
using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Controllers
{
    public class UpdateDeptController
    {
        SendMail sm = new SendMail();
        StationeryDBEntities sat = new StationeryDBEntities();

        UpdateDepartmentEEF udeef = new UpdateDepartmentEEF();



        public string GetClerkMail(int COL_ID)
        {
            return udeef.GetEmailClerk(COL_ID);
        }

        public string GetEmEmail(String EMP_NAME)
        {
            return udeef.GetMail(EMP_NAME);
        }

        public List<string> GetDeptPhone(int DEPTID)
        {
            return udeef.GetContact(DEPTID);
        }

        public List<string> GetAllEmployee(int Deptid)
        {
            return udeef.GetEmployee(Deptid);
        }

        public List<collectionPoint> GetColID()
        {
            return udeef.GetColId();
        }

        public List<string> GetDeptName(int deptID)
        {
            return udeef.GetDeptName(deptID);
        }

        public void SendEmail(String from, string strTo
                              , string strSubject
                              , string strBody)
        {

            sm.sendEmail(from, strTo, strSubject, strBody);
        }

        public void updateDept(int DeptID, int ColID)
        {
            udeef.UpdateDept(DeptID, ColID);
        }

        public void updateEmp(String name)
        {
            udeef.UpdateEmp(name);
        }
    }
}