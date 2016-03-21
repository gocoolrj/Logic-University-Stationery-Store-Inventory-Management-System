using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.WebService
{
    public class EmployeeBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public bool checkUserNamePassword(string email, string pw)
        {
            var query = (from x in ctx.employees
                         where x.emp_email == email
                         && x.emp_password == pw
                         select x).FirstOrDefault();
            if (query == null)
                return false;
            else
                return true;
        }
        public string getUserRole(string email)
        {
            var query = (from x in ctx.employees
                         join y in ctx.roles on x.role_id equals y.role_id
                         where x.emp_email == email
                         select y.role1).FirstOrDefault();

            return query;
        }

        public employee[] getAll()
        {


            var res = (from o in ctx.employees
                       select o);
            return res.ToArray();
        }



        public employee getEmployee(string emp_email)
        {


            var res = (from o in ctx.employees
                       where o.emp_email == emp_email
                       select o).SingleOrDefault();
            return res;
        }

        public employee getEmployeeByID(string id)
        {
            int x = Int16.Parse(id);
            var res = (from o in ctx.employees
                       where o.emp_id == x
                       select o).SingleOrDefault();
            return res;
        }
    }
}