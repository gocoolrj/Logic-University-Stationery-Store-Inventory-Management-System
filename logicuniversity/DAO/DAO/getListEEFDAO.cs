using logicuniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class getListEEF
    {
        StationeryDBEntities sat = new StationeryDBEntities();


        public void createNewEmployee(String name, String email, int roleid, int deptid, String pw)
        {
            employee emp = new employee();

            emp.emp_name = name;
            emp.emp_email = email;
            emp.role_id = roleid;
            emp.dept_id = deptid;
            emp.emp_password = pw;

            sat.employees.Add(emp);
            sat.SaveChanges();


        }


        public void modifyEmployee(int empid, String name, String email, int roleid, int deptid, String pw)
        {
            employee emp = new employee();

            var modi = sat.employees.FirstOrDefault(em => em.emp_id == empid);

            modi.emp_name = name;
            modi.emp_email = email;
            modi.role_id = roleid;
            modi.dept_id = deptid;
            modi.emp_password = pw;

          
            sat.SaveChanges();


        }

        public void deleteEmployee(int empid)
        {
            employee emp = new employee();
            var modi = sat.employees.FirstOrDefault(em => em.emp_id == empid);
            modi.role_id = null;
            modi.emp_password = null;
            sat.SaveChanges();
        }




        public List<department> GetList()
        {
            var dept = (from d in sat.departments
                        select d);

            return dept.ToList();
        }

        public List<Employee> GetEmployeeByRole(int Role_ID)
        {
            var em = from e in sat.employees
                     join r in sat.roles
                     on e.role_id equals r.role_id
                     where e.role_id == Role_ID && e.emp_password != null
                     select new Employee { Emp_id = (int)e.emp_id, Emp_name = e.emp_name, Emp_email = e.emp_email, Emp_password = e.emp_password, Role_id = (int)e.role_id, Dept_id = (int)e.dept_id };


            return em.ToList();
        }

        public List<Employee> GetEmployeebyID(int empid)
        {
            var id = (from e in sat.employees
                      where e.emp_id == empid && e.emp_password != null
                      select new Employee { Emp_id = (int)e.emp_id, Emp_name = e.emp_name, Emp_email = e.emp_email, Emp_password = e.emp_password, Role_id = (int)e.role_id, Dept_id = (int)e.dept_id });

            return id.ToList();
        }
        public List<role> GetRoles()
        {
            var rol = (from r in sat.roles
                       select r);

            return rol.ToList();
        }
        public List<role> Gethodroles()
        {
            var hrol = (from r in sat.roles
                        where r.role_id == 1 && r.role_id == 1004 && r.role_id == 2004
                        select r);
            return hrol.ToList();
        }
        public int getLastID()
        {

            var id = (from e in sat.employees
                      select e.emp_id).ToList();

            return id.Last();

        }

        public void ChangeRole(int emp_id, int roleid)
        {
            employee emp = new employee();

            var modi = sat.employees.FirstOrDefault(em => em.emp_id == emp_id);


            modi.role_id = roleid;
            sat.SaveChanges();

        }


    }
}