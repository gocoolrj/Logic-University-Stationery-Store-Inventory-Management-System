using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using logicuniversity.Models;
using Quartz;
using Entity;
namespace logicuniversity.DAO
{
    public class DelegateAuthorityFacade
    {
        changeDelegationTrigger ts = new changeDelegationTrigger();
        StationeryDBEntities ctx = new StationeryDBEntities();
        public List<Rolename> getEmployeeList(int dept_id)
        {
            var res = from emp in ctx.employees join r in ctx.roles on emp.role_id equals r.role_id where emp.dept_id == dept_id where emp.role_id != 1 && emp.role_id != 3 && emp.role_id != 4 select new Rolename { Emp_id = (int)emp.emp_id, Emp_name = emp.emp_name, Role1 = r.role1 };

         
            return (res.ToList());
        }



        public Rolename getEmployeeInfo(int emp_id)
        {

            var res = (from emp in ctx.employees join r in ctx.roles on emp.role_id equals r.role_id where emp.emp_id == emp_id select new Rolename { Emp_id = (int)emp.emp_id, Emp_name = emp.emp_name, Role1 = r.role1, Email = emp.emp_email }).SingleOrDefault();
            return res;
        }


        public void changeEmployeeRole(int emp_id)
        {

       
            var query =
                from ord in ctx.employees
                where ord.emp_id == emp_id
                select ord;
 
            foreach (employee ord in query)
            {
                ord.role_id = 1;

         
            }

     
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            
            }
        }

        public void storeDelegationDetails(int emp_id, DateTime startdate, DateTime todate)
        {


        Entity.delegation del = new Entity.delegation();
            del.emp_id = emp_id;
            del.start_date = startdate;
            del.end_date = todate;
           

        
         
            ctx.delegations.Add(del);

         
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                
                ctx.SaveChanges();
            }


        }

        public void storeDelegationDetails(int emp_id, String datestring, String datestring1, int depthead_id)
        {

            Entity.delegation del = new Entity.delegation();
            del.emp_id = emp_id;
            del.start_date = Convert.ToDateTime(datestring);
            del.end_date = Convert.ToDateTime(datestring1);
            del.status = "active";
            del.head_id = depthead_id;
            del.reason = "";
            ctx.delegations.Add(del);

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
       
            }

        }


        public void unDelegateEmployee(int dept_id)
        {

            var query = from emp in ctx.employees
                        join r in ctx.delegations on emp.emp_id equals r.emp_id
                        where emp.dept_id == dept_id
                        where r.status == "Active"
                        select emp;





            // var res = from emp in ctx.employees join r in ctx.delegations  on emp.role_id equals r.role_id where emp.dept_id == dept_id where emp.emp_id != 1 select new Rolename { Emp_id = (int)emp.emp_id, Emp_name = emp.emp_name, Role1 = r.role1 };


        }




        public customDelegation getDelegateEmployeeInfo(int dept_id)
        {
            // try
            // {
            var res = (from emp in ctx.employees
                       join r in ctx.delegations on emp.emp_id equals r.emp_id
                       where emp.dept_id == dept_id && r.status == "active"
                       select new customDelegation
                       {
                           StartDate1 = (DateTime)r.start_date,
                           ToDate1 = (DateTime)r.end_date,
                           Empname1 = emp.emp_name,
                           Emp_id1 = emp.emp_id
                       }).SingleOrDefault();
            return res;
            //   }
            // catch (Exception e) { return null; }



        }
        public void unDelegate(int p)
        {

            //  JobDataMap data = context.getJobDetail().getJobDataMap();
            // String favoriteColor = data.getString(FAVORITE_COLOR);
            ts.triggerNow(p);

        }

    }

    public class customDelegation
    {

        int Emp_id; DateTime StartDate; DateTime ToDate; String status; int role1;
        String Empname;

        public String Empname1
        {
            get { return Empname; }
            set { Empname = value; }
        }

        public Int32 Role1
        {
            get { return role1; }
            set { role1 = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime ToDate1
        {
            get { return ToDate; }
            set { ToDate = value; }
        }


        public DateTime StartDate1
        {
            get { return StartDate; }
            set { StartDate = value; }
        }

        public int Emp_id1
        {
            get { return Emp_id; }
            set { Emp_id = value; }
        }


    }


}
