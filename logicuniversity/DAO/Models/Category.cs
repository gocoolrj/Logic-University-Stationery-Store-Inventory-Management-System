using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Category
    {
        int catg_id;

        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    


    }
}