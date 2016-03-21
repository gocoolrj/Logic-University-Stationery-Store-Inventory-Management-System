using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Models
{
    public class Quotation
    {
        int quo_id;

        public int Quo_id
        {
            get { return quo_id; }
            set { quo_id = value; }
        }
        string sup_code;

        public string Sup_code
        {
            get { return sup_code; }
            set { sup_code = value; }
        }
        int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}