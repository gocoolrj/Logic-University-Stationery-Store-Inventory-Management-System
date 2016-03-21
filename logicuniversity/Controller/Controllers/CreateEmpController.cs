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
    public class CreateEmpController
    {
        getListEEF get = new getListEEF();

        public List<department> getDeptID()
        {
            return get.GetList();
        }

        public List<role> getRoleID()
        {
            return get.GetRoles();
        }
        public List<role> gethodroles()
        {
            return get.Gethodroles();
        }

        public int GetEmpId()
        {
            return get.getLastID();
        }

        public void createEmployee(String name, String email, int roleid, int deptid, String pw)
        {
            get.createNewEmployee(name, email, roleid, deptid, pw);
        }

        public void modiyEmp(int empid, String name, String email, int roleid, int deptid, String pw)
        {
            get.modifyEmployee(empid, name, email, roleid, deptid, pw);
        }
        public List<Employee> getEmployeeByRole(int RoleID)
        {
            return get.GetEmployeeByRole(RoleID);
        }

        public List<Employee> getEmployeeByID(int EmpID)
        {
            return get.GetEmployeebyID(EmpID);
        }
        public void DeleteEmp(int empid)
        {
            get.deleteEmployee(empid);
        }

        public void ChangeRole(int empid, int roleid)
        {
            get.ChangeRole(empid, roleid);
        }




    }
}