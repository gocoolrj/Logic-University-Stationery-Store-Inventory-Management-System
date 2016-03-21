using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace logicuniversity.Controllers
{
    public class loginController
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
            string role ="";

            var query = (from x in ctx.employees
                         join y in ctx.roles on x.role_id equals y.role_id
                         where x.emp_email == email
                         select y.role1).FirstOrDefault();

            return query;
        }
        public int getUserID(string email)
        {
            var query = (from x in ctx.employees
                         where x.emp_email == email
                         select x.emp_id).FirstOrDefault();

            return query;
        }
        public int getDeptID(string email, string pw)
        {

            var query = (from x in ctx.employees
                         where x.emp_email == email
                             && x.emp_password == pw
                         select x
                      ).FirstOrDefault();

            return Convert.ToInt16(query.dept_id);
        }

        public int checkHead(int emp_id)
        {


            var query = (from x in ctx.employees join r in ctx.delegations on x.emp_id equals r.emp_id where r.head_id == emp_id && r.status == "active" select x).FirstOrDefault();
            if (query == null)
            {
                return 0;

            }
            else { return 1; }



        }

        public int getEmpID(string email, string pw)
        {
            var query = (from x in ctx.employees
                         where x.emp_email == email
                             && x.emp_password == pw
                         select x
                         ).FirstOrDefault();
            return Convert.ToInt16(query.emp_id);
        }
        public string getUserName(string email, string pw)
        {
            var name = (from e in ctx.employees
                        where e.emp_email == email
                        && e.emp_password == pw
                        select e).FirstOrDefault();

            return name.emp_name;
        }
        public string getDeptPhone(string email, string pw)
        {
            var phone = (from d in ctx.departments
                         join e in ctx.employees
                         on d.dept_id equals e.dept_id
                         where e.emp_email == email
                         && e.emp_password == pw
                         select d).FirstOrDefault();

            return phone.dept_phone;

        }
    }
}
