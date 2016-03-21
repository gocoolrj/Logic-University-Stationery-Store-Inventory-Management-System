using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using Entity;
namespace logicuniversity.DAO
{
    public class UpdateDepartmentEEF
    {

        StationeryDBEntities sat = new StationeryDBEntities();

        public List<collectionPoint> GetColId()
        {
            var colid = from c in sat.collectionPoints
                        select c;

            return colid.ToList();
        }


        public List<string> GetDeptName(int Dept_id)
        {

            List<string> deptname = new List<string>();

            var name = (from d in sat.departments
                        join e in sat.employees
                        on d.dept_id equals e.dept_id
                        where d.dept_id == Dept_id
                        select d).ToList();

            foreach (var dn in name)
            {
                deptname.Add(dn.dept_name);
            }

            return deptname;

        }

        public List<string> GetEmployee(int dept_Id)
        {
            List<string> ls = new List<string>();
            var employ = (from e in sat.employees
                          join d in sat.departments
                          on e.dept_id equals d.dept_id
                          where e.dept_id == dept_Id && e.role_id != null && e.emp_password != null
                          select e).ToList();

            foreach (var x in employ)
            {
                ls.Add(x.emp_name);
            }

            return ls;
        }

        public List<string> GetContact(int Dept_id)
        {
            List<string> con = new List<string>();

            var dept = (from d in sat.departments
                        join e in sat.employees
                            on d.dept_id equals e.dept_id
                        where e.dept_id == Dept_id
                        select d).ToList();

            foreach (var c in dept)
            {
                con.Add(c.dept_phone);
            }

            return con;

        }



        public string GetMail(String Emp_Name)
        {


            var mail = from e in sat.employees
                       where e.emp_name == Emp_Name
                       select e.emp_email;


            return mail.SingleOrDefault();

        }

        public String GetEmailClerk(int col_ID)
        {


            var cmail = from e in sat.employees
                        join c in sat.collectionPoints
                        on e.emp_id equals c.clerk_emp_id
                        where c.col_id == col_ID
                        select e.emp_email;



            return cmail.SingleOrDefault();
        }

        public void UpdateDept(int deptID, int ColID)
        {
            var col = sat.departments.FirstOrDefault(c => c.dept_id == deptID);

            if (col != null)
            {
                col.col_id = ColID;

                sat.SaveChanges();
            }
        }

        public void UpdateEmp(String empname)
        {
            var emp = sat.employees.FirstOrDefault(e => e.emp_name == empname);
            if (emp != null)
            {
                emp.role_id = 1004;
                sat.SaveChanges();
            }
        }

    }
}