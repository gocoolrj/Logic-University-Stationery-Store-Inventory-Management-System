using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Department
    {
        int dept_id;

        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }
        string dept_code;

        public string Dept_code
        {
            get { return dept_code; }
            set { dept_code = value; }
        }
        string dept_name;

        public string Dept_name
        {
            get { return dept_name; }
            set { dept_name = value; }
        }
        string dept_phone;

        public string Dept_phone
        {
            get { return dept_phone; }
            set { dept_phone = value; }
        }
        string dept_fax;

        public string Dept_fax
        {
            get { return dept_fax; }
            set { dept_fax = value; }
        }
        int col_id;

        public int Col_id
        {
            get { return col_id; }
            set { col_id = value; }
        }
    }
}