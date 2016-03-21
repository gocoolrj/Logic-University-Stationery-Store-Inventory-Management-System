using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace logicuniversity.Controllers
{
    public class RequisitionController
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        
        public List<stationery_trend_report_view> GetAll()
        {
            var res = (from o in ctx.stationery_trend_report_view
                       select o).ToList();
            return res;
        }
        public List<stationery_trend_report_view> GetbyDeptAndDate(int dept_id, int month, int year)
        {
            int day = this.getLastDayOfMonth(month, year);
            string s1 = month + "/1/" + year + " 12:00:00 AM";
            string s2 = month + "/" + day + "/" + year + " 12:00:00 AM";
           // DateTime d1 = DateTime.ParseExact(s1,"M/dd/yyyy HH:mm:ss", null);
            //DateTime d2 = DateTime.ParseExact(s2, "M/dd/yyyy HH:mm:ss", null);
            DateTime d1 = DateTime.Parse(s1);
            DateTime d2 = DateTime.Parse(s2);
            var res = (from o in ctx.stationery_trend_report_view
                       where o.dept_id == dept_id && (o.req_date >= d1 && o.req_date <= d2.Date)
                       select o).ToList();
            return res;
        }
        public List<stationery_trend_report_view> GetbyDate(int month, int year)
        {
            int day = this.getLastDayOfMonth(month, year);
            string s1 = month + "/1/" + year + " 12:00:00 AM";
            string s2 = month + "/" + day + "/" + year + " 12:00:00 AM";
            DateTime d1 = DateTime.Parse(s1);
            DateTime d2 = DateTime.Parse(s2);
            var res = (from o in ctx.stationery_trend_report_view
                       where o.req_date >= d1 && o.req_date <= d2.Date
                       select o).ToList();
            return res;
        }
        public List<stationery_trend_report_view> GetbyCatgIDAndDate(int catg_id, int month, int year)
        {
            int day = this.getLastDayOfMonth(month, year);
            string s1 = month + "/1/" + year + "12:00:00 AM";
            string s2 = month + "/" + day + "/" + year + "12:00:00 AM";
            DateTime d1 = DateTime.Parse(s1);
            DateTime d2 = DateTime.Parse(s2);
            var res = (from o in ctx.stationery_trend_report_view
                       where o.catg_id == catg_id && (o.req_date >= d1 && o.req_date <= d2.Date)
                       select o).ToList();
            return res;
        }
        public int getLastDayOfMonth(int month, int year)
        {
            int day = 1;
            if (month == 9 || month == 4 || month == 6 || month == 11)
            {
                day = 30;
            }
            else if (month == 2)
            {
                if (year % 4 == 0)
                {
                    day = 29;
                }
                else
                {
                    day = 28;
                }
            }
            else
            {
                day = 31;
            }

            return day;
        }
        public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;
            if (Linqlist == null) return dt;
            foreach (T Record in Linqlist)
            {
                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

       
    }
}