using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class CollectionPoint
    {
        int col_id;

        public int Col_id
        {
            get { return col_id; }
            set { col_id = value; }
        }

        int clerk_emp_id;
    
        public int Clerk_emp_id
        {
          get { return clerk_emp_id; }
          set { clerk_emp_id = value; }
        }

        string col_location;

        public string Col_location
        {
            get { return col_location; }
            set { col_location = value; }
        }

        DateTime col_date;

        public DateTime Col_date
        {
            get { return col_date; }
            set { col_date = value; }
        }
    }
}