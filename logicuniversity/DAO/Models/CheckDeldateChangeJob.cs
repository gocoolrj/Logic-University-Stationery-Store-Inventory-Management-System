using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using logicuniversity.Models;
using Entity;
namespace logicuniversity.Models
{
    public class CheckDeldateChangeJob : IJob
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        int employeeid;
        DateTime to;
        int roles;
        public void Execute(IJobExecutionContext context)
        {

            var query = from emp in ctx.employees
                        join r in ctx.delegations on emp.emp_id equals r.emp_id
                        where r.status == "active"
                        select new delegation { Emp_id1 = (int)emp.emp_id, ToDate1 = (DateTime)(r.end_date), Role1 = (int)(emp.role_id) };

            foreach (delegation query1 in query)
            {
                employeeid = query1.Emp_id1;
                to = query1.ToDate1;
                roles = query1.Role1;
            }
            // Execute the query, and change the column values  
            // you want to change. 
            foreach (delegation emp1 in query)
            {


                try
                {
                    if (emp1.ToDate1.Date == System.DateTime.Now.Date)
                    {
                        emp1.Role1 = 3;
                        emp1.Status = "Inactive";
                        ctx.SaveChanges();
                    }
                }


                  



                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.

                }
            }

        }

    }
}

