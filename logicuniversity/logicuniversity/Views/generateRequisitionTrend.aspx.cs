using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Controllers;
using System.Data;
using System.Globalization;
using Entity;

namespace logicuniversity.Views
{
    public partial class generateRequisitionTrend : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        RequisitionController rc = new RequisitionController();
        DepartmentController dc = new DepartmentController();
        CategoryController cc = new CategoryController();
        CatalogueController catc = new CatalogueController();
        static List<stationery_trend_report_view> list1, list2, list3;
        static List<stationery_trend_report_view> listTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Supervisor")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {

                        load_ddlDepartment();
                        load_calendar();
                        listTotal = new List<stationery_trend_report_view>();
                        list1 = new List<stationery_trend_report_view>();
                        list2 = new List<stationery_trend_report_view>();
                        list3 = new List<stationery_trend_report_view>();
                        Session.Remove("finalData");
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }

        }

        public void load_calendar()
        {
            ddlmonth1.DataSource = this.load_month();
            ddlmonth1.DataBind();
            ddlmonth2.DataSource = this.load_month();
            ddlmonth2.DataBind();
            ddlmonth3.DataSource = this.load_month();
            ddlmonth3.DataBind();

            ddlyear1.DataSource = this.load_year();
            ddlyear1.DataBind();
            ddlyear2.DataSource = this.load_year();
            ddlyear2.DataBind();
            ddlyear3.DataSource = this.load_year();
            ddlyear3.DataBind();
        }

        public void load_ddlCategory()
        {

            ddl.DataSource = cc.GetAll();
            ddl.DataTextField = "name";
            ddl.DataValueField = "catg_id";
            ddl.DataBind();
            ddl.Items.Insert(0, "--- Select One ---");
        }

        public void load_ddlDepartment()
        {

            ddl.DataSource = dc.getAll();
            ddl.DataTextField = "dept_name";
            ddl.DataValueField = "dept_id";
            ddl.DataBind();
            ddl.Items.Insert(0, "--- Select All ---");

        }


        protected void btnGenerate_Click(object sender, EventArgs e)
        {

            List<stationery_trend_report_view> reportList = rc.GetAll();
            dt = rc.LINQResultToDataTable(reportList);
            Session["TrendReport"] = dt;
            Response.Redirect(string.Format("RequisitionTrendReport.aspx"));
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoCatalogue.Checked == true && ddl.SelectedIndex > 0)
            {
                ddlCatalogue.Visible = true;
                load_ddlCatalogue();
            }
            else if (rdoDept.Checked == true)
            {
                ddlCatalogue.Visible = false;
            }
        }
        public void load_ddlCatalogue()
        {
            string x = ddl.SelectedValue.ToString();
            int catg_id = int.Parse(x);

            ddlCatalogue.DataSource = catc.GetCatalogue(catg_id);
            ddlCatalogue.DataTextField = "description";
            ddlCatalogue.DataValueField = "item_code";
            ddlCatalogue.DataBind();
            ddlCatalogue.Items.Insert(0, "--- Select One ---");


        }

        protected void rdoCategory_CheckedChanged(object sender, EventArgs e)
        {
            ddlCatalogue.Visible = false;
            load_ddlCategory();
        }

        protected void rdoDept_CheckedChanged(object sender, EventArgs e)
        {
            ddlCatalogue.Visible = false;
            load_ddlDepartment();
        }

        protected void rdoCatalogue_CheckedChanged(object sender, EventArgs e)
        {
            ddlCatalogue.Visible = true;
            load_ddlCategory();

        }


        public int[] load_year()
        {
            int[] year = new int[5];// for last 5 from this year
            string x = DateTime.Now.Year.ToString();
            int y = Int32.Parse(x);
            for (int z = 0; z < 5; z++)
            {
                year[z] = y - z;
            }
            return year;
        }
        public string[] load_month()
        {
            string[] month = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return month;
        }

        protected void chk2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2.Checked == true)
            {
                Panel2.Visible = true;
                ddlmonth2.Enabled = true;
                ddlyear2.Enabled = true;
            }
            else
            {
                Panel2.Visible = false;
                ddlmonth2.Enabled = false;
                ddlyear2.Enabled = false;
            }

        }

        protected void chk3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk3.Checked == true)
            {
                Panel3.Visible = true;
                ddlmonth3.Enabled = true;
                ddlyear3.Enabled = true;
            }
            else
            {
                Panel3.Visible = false;
                ddlmonth3.Enabled = false;
                ddlyear3.Enabled = false;
            }
        }



        protected void btnRetrieve_Click(object sender, EventArgs e)
        {

            if (list1 != null)
            {
                list1.Clear();// to prevent data duplication when retrieve button is clicked several time
            }
            if (list2 != null)
            {
                list2.Clear();
            }
            if (list3 != null)
            {
                list3.Clear();
            }
            if (listTotal != null)
            {
                listTotal.Clear();
            }





            if (rdoDept.Checked == true && ddl.SelectedIndex != 0)
            {
                int dept_id = Int32.Parse(ddl.SelectedValue);



                if (chk2.Checked == true && chk3.Checked == false)// t t f
                {
                    /***for GridView 1***/
                    bindGridView1(dept_id);
                    /***for GridView 1***/

                    /***for GridView 2***/
                    bindGridView2(dept_id);
                    /***for GridView 2***/
                }
                else if (chk2.Checked == true && chk3.Checked == true)// t t t
                {
                    /***for GridView 1***/
                    bindGridView1(dept_id);
                    /***for GridView 1***/

                    /***for GridView 2***/
                    bindGridView2(dept_id);
                    /***for GridView 2***/

                    /***for GridView 3***/
                    bindGridView3(dept_id);
                    /***for GridView 3***/
                }
                else if (chk3.Checked == true && chk2.Checked == false)// t f t
                {
                    /***for GridView 1***/
                    bindGridView1(dept_id);
                    /***for GridView 1***/

                    /***for GridView 3***/
                    bindGridView3(dept_id);
                    /***for GridView 3***/
                }
                else if (chk2.Checked == false && chk3.Checked == false)// t f f
                {
                    /***for GridView 1***/
                    bindGridView1(dept_id);
                    /***for GridView 1***/
                }

            }
            else if (rdoDept.Checked = true && ddl.SelectedIndex == 0) // Select All Dept
            {
                if (chk2.Checked == true && chk3.Checked == false)// t t f
                {
                    /***for GridView 1 by Date***/
                    bindGridView1byDate();
                    /***for GridView 1 by Date***/

                    /***for GridView 2 by Date***/
                    bindGridView2byDate();
                    /***for GridView 2 by Date***/

                }
                else if (chk2.Checked == true && chk3.Checked == true)// t t t
                {
                    /***for GridView 1 by Date***/
                    bindGridView1byDate();
                    /***for GridView 1 by Date***/

                    /***for GridView 2 by Date***/
                    bindGridView2byDate();
                    /***for GridView 2 by Date***/

                    /***for GridView 3 by Date***/
                    bindGridView3byDate();
                    /***for GridView 3 by Date***/
                }
                else if (chk3.Checked == true && chk2.Checked == false)// t f t
                {
                    /***for GridView 1 by Date***/
                    bindGridView1byDate();
                    /***for GridView 1 by Date***/

                    /***for GridView 3 by Date***/
                    bindGridView3byDate();
                    /***for GridView 3 by Date***/
                }
                else if (chk2.Checked == false && chk3.Checked == false)// t f f
                {
                    /***for GridView 1 by Date***/
                    bindGridView1byDate();
                    /***for GridView 1 by Date***/
                }
            }
            else if (rdoCategory.Checked == true)
            {
                int catg_id = Int32.Parse(ddl.SelectedValue);
                if (chk2.Checked == true && chk3.Checked == false)// t t f
                {
                    /***for GridView 1 by CatgID***/
                    bindGridView1byCatgID(catg_id);
                    /***for GridView 1 by CatgID***/

                    /***for GridView 2 by CatgID***/
                    bindGridView2byCatgID(catg_id);
                    /***for GridView 2 by CatgID***/
                }
                else if (chk2.Checked == true && chk3.Checked == true)// t t t
                {
                    /***for GridView 1 by CatgID***/
                    bindGridView1byCatgID(catg_id);
                    /***for GridView 1 by CatgID***/

                    /***for GridView 2 by CatgID***/
                    bindGridView2byCatgID(catg_id);
                    /***for GridView 2 by CatgID***/

                    /***for GridView 3 by CatgID***/
                    bindGridView3byCatgID(catg_id);
                    /***for GridView 3 by CatgID***/
                }
                else if (chk3.Checked == true && chk2.Checked == false)// t f t
                {
                    /***for GridView 1 by CatgID***/
                    bindGridView1byCatgID(catg_id);
                    /***for GridView 1 by CatgID***/

                    /***for GridView 3 by CatgID***/
                    bindGridView3byCatgID(catg_id);
                    /***for GridView 3 by CatgID***/
                }
                else if (chk2.Checked == false && chk3.Checked == false)// t f f
                {
                    /***for GridView 1 by CatgID***/
                    bindGridView1byCatgID(catg_id);
                    /***for GridView 1 by CatgID***/
                }
            }
            else if (rdoCatalogue.Checked == true)
            {
                //
            }
        }

        private void bindGridView1byCatgID(int catg_id)
        {
            int month1 = ddlmonth1.SelectedIndex + 1;
            int year1 = Int32.Parse(ddlyear1.SelectedValue);
            list1 = rc.GetbyCatgIDAndDate(catg_id, month1, year1);
            gv1.DataSource = list1;
            gv1.DataBind();
            //listTotal.AddRange(list1);
            Label1.Text = ddlmonth1.SelectedValue + ", " + year1;
        }

        private void bindGridView2byCatgID(int catg_id)
        {
            int month2 = ddlmonth2.SelectedIndex + 1;
            int year2 = Int32.Parse(ddlyear2.SelectedValue);
            list2 = rc.GetbyCatgIDAndDate(catg_id, month2, year2);
            gv2.DataSource = list2;
            gv2.DataBind();
            //listTotal.AddRange(list2);
            Label2.Text = ddlmonth2.SelectedValue + ", " + year2;
        }

        private void bindGridView3byCatgID(int catg_id)
        {
            int month3 = ddlmonth3.SelectedIndex + 1;
            int year3 = Int32.Parse(ddlyear1.SelectedValue);
            list3 = rc.GetbyCatgIDAndDate(catg_id, month3, year3);
            gv3.DataSource = list3;
            gv3.DataBind();
            //listTotal.AddRange(list3);
            Label3.Text = ddlmonth3.SelectedValue + ", " + year3;
        }

        //*****************************Select All Department*************************//
        private void bindGridView1byDate()
        {
            int month1 = ddlmonth1.SelectedIndex + 1;
            int year1 = Int32.Parse(ddlyear1.SelectedValue);
            list1 = rc.GetbyDate(month1, year1);
            gv1.DataSource = list1;
            gv1.DataBind();
            //listTotal.AddRange(list1);
            Label1.Text = ddlmonth1.SelectedValue + ", " + year1;
        }

        private void bindGridView2byDate()
        {
            int month2 = ddlmonth2.SelectedIndex + 1;
            int year2 = Int32.Parse(ddlyear1.SelectedValue);
            list2 = rc.GetbyDate(month2, year2);
            gv2.DataSource = list2;
            gv2.DataBind();
            //listTotal.AddRange(list2);
            Label2.Text = ddlmonth2.SelectedValue + ", " + year2;
        }
        private void bindGridView3byDate()
        {
            int month3 = ddlmonth3.SelectedIndex + 1;
            int year3 = Int32.Parse(ddlyear1.SelectedValue);
            list3 = rc.GetbyDate(month3, year3);
            gv3.DataSource = list3;
            gv3.DataBind();
            //listTotal.AddRange(list3);
            Label3.Text = ddlmonth3.SelectedValue + ", " + year3;
        }
        ////*************************Select By Department*****************************//
        //public void bindGridView1(int dept_id)
        //{
        //    int month1 = ddlmonth1.SelectedIndex + 1;
        //    int year1 = Int32.Parse(ddlyear1.SelectedValue);
        //    if (Session["list1"] == null)
        //    {
        //        list1 = rc.GetbyDeptAndDate(dept_id, month1, year1);
        //        Session["list1"] = list1;
        //    }
        //    else
        //    {
        //        list1Old = Session["list1"] as List<stationery_trend_report_view>;
        //        list1 = rc.GetbyDeptAndDate(dept_id, month1, year1);
        //        int count = 0;
        //        for (int x = 0; x < list1.Count; x++)
        //        {
        //            for (int y = 0; y < list1Old.Count; y ++)
        //            {
        //                if (list1[x].item_code == list1Old[y].item_code)
        //                {
        //                    count++;
        //                }
        //            }
        //            if (count == 0)
        //            {
        //                list1.AddRange(list1Old);
        //            }
        //            else
        //            {
        //                //error duplicate items
        //            }

        //        }
        //        Session["list1"] = list1;

        //    }
        //    gv1.DataSource = list1;
        //    gv1.DataBind();
        //    Label1.Text = ddlmonth1.SelectedValue +", "+ year1 ;
        //}

        private void bindGridView1(int dept_id)
        {
            int month1 = ddlmonth1.SelectedIndex + 1;
            int year1 = Int32.Parse(ddlyear1.SelectedValue);
            list1 = rc.GetbyDeptAndDate(dept_id, month1, year1);
            gv1.DataSource = list1;
            gv1.DataBind();
            //listTotal.AddRange(list1);
            Label1.Text = ddlmonth1.SelectedValue + ", " + year1;
        }

        private void bindGridView2(int dept_id)
        {
            int month2 = ddlmonth2.SelectedIndex + 1;
            int year2 = Int32.Parse(ddlyear2.SelectedValue);
            list2 = rc.GetbyDeptAndDate(dept_id, month2, year2);
            gv2.DataSource = list2;
            gv2.DataBind();
            //listTotal.AddRange(list2);
            Label2.Text = ddlmonth2.SelectedValue + ", " + year2;
        }

        private void bindGridView3(int dept_id)
        {
            int month3 = ddlmonth3.SelectedIndex + 1;
            int year3 = Int32.Parse(ddlyear3.SelectedValue);
            list3 = rc.GetbyDeptAndDate(dept_id, month3, year3);
            gv3.DataSource = list3;
            gv3.DataBind();
            //listTotal.AddRange(list3);
            Label3.Text = ddlmonth3.SelectedValue + ", " + year3;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            if (list2.Count > 0 && list3.Count > 0)
            {
                list2.AddRange(list3);
                list1.AddRange(list2);
                listTotal.AddRange(list1);
            }
            else if (list2.Count > 0)
            {
                list1.AddRange(list2);
                listTotal.AddRange(list1);
            }
            else
            {
                listTotal.AddRange(list1);
            }

            dt = rc.LINQResultToDataTable(listTotal);
            Session["finalData"] = dt;
            if (rdoDept.Checked == true && listTotal.Count > 0)
            {
                Response.Redirect(string.Format("RequisitionTrendReportByDept.aspx"));
            }
            else if (rdoCategory.Checked == true && listTotal.Count > 0)
            {
                Response.Redirect(string.Format("RequisitionTrendReportByCatg.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Please Retrieve Data first!!')", true);
            }
        }

    }
}