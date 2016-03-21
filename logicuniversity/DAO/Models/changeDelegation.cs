using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using logicuniversity.DAO;
using Entity;
namespace logicuniversity.Models
{
    public class changeDelegation : IJob
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public employee e; public delegation d;
        public void Execute(IJobExecutionContext context)
        {

            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.JobDetail.JobDataMap;


            int emp_id = (Int32)dataMap.GetInt("emp_id");

            // Query the database for the row to be updated. 
            



            try
            {
                //var query1 = (from emp in ctx.employees
                //              join r in ctx.delegations on emp.emp_id equals r.emp_id
                //              where emp.emp_id == Convert.ToInt32(emp_id)
                //              where r.status == "Active"
                //              select new customDelegation
                //              {
                //                  Status = r.status,
                //                  Role1 = (int)emp.role_id


                //              }).ToList();


                //var query1 = from emp in ctx.employees
                //             join r in ctx.delegations on emp.emp_id equals r.emp_id
                //             where emp.emp_id == emp_id
                //             where r.status == "Active"
                //             select new
                //              {
                //                  r.status,
                //                  emp.role_id


                //              };
                //query1.ToList().Select(c => new customDelegation()
                //    {
                //        Status = c.status,
                //        Role1 = (int)c.role_id

                //    });
                var query1 = (from emp in ctx.employees
                              join r in ctx.delegations on emp.emp_id equals r.emp_id
                              where emp.emp_id == emp_id
                              where r.status == "active"
                              select new customDelegation
                              {

                                  Status = r.status,
                                  Role1 = (int)emp.role_id

                              }).ToList();






                
                //  }
                // Submit the changes to the database. 


                foreach (customDelegation m in query1)
                {
                    try
                    {


                        m.Status = "inactive";
                        m.Role1 = 3;
                        ctx.SaveChanges();
                    }
                    catch (Exception c) { }
                }




            }
            catch (Exception e4) { }

        }
    }
}