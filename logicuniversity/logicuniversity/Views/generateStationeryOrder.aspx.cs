using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.Controllers;
using System.Globalization;
using Entity;

namespace logicuniversity.Views
{
    public partial class generate_stationeryOrderReport : System.Web.UI.Page
    {
        DataTable dt = new DataTable();

        POController po = new POController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_role"] != null)
            {
                if (Session["user_role"].ToString() == "Supervisor")// in entity we will check with employee's role
                {
                    if (!IsPostBack)
                    {

                        load_ddlcategory();
                        Session.Remove("TotalPoRecord");
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }



        }
        public void load_ddlcategory()
        {
            ddlcategory.DataSource = po.GetCategory();
            ddlcategory.DataTextField = "name";
            ddlcategory.DataValueField = "catg_id";
            ddlcategory.DataBind();
            ddlcategory.Items.Insert(0, "--- Select ---");
        }


        public void load_ddlcatalogue()
        {
            if (ddlcategory.SelectedIndex != 0)
            {
                ddlcatalogue.Visible = true;
                string x = ddlcategory.SelectedValue;
                int id = Int32.Parse(x);
                ddlcatalogue.DataSource = po.GetCatalogue(id);
                ddlcatalogue.DataTextField = "description";
                ddlcatalogue.DataValueField = "item_code";
                ddlcatalogue.DataBind();
                ddlcatalogue.Items.Insert(0, "--- Select One ---");
            }

        }


        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoCatalogue.Checked == true && ddlcategory.SelectedIndex > 0)
            {
                load_ddlcatalogue();
            }
            else
            {
                ddlcatalogue.Visible = false;
            }
        }

        protected void btnAddtolist_Click(object sender, EventArgs e)
        {

            List<stationery_po_report_view> list;
            //var fromDate = DateTime.ParseExact(txtFromDate.Text, "M/d/yyyy", CultureInfo.InvariantCulture);
            DateTime fromDate = DateTime.Parse(txtFromDate.Text);
            DateTime toDate = DateTime.Parse(txtToDate.Text);
            //var toDate = DateTime.ParseExact(txtToDate.Text, "M/d/yyyy", CultureInfo.InvariantCulture);
            List<stationery_po_report_view> oldRecord = Session["TotalPoRecord"] as List<stationery_po_report_view>;
            if (rdoCategory.Checked == true)
            {
                if (ddlcategory.SelectedIndex > 0)
                {
                    string temp_catgID = ddlcategory.SelectedValue;
                    int catg_id = Int32.Parse(temp_catgID);
                    list = po.SearchReportByCategory(catg_id, fromDate, toDate);

                    if (oldRecord != null)
                    {
                        int count = 0;
                        var catgIDArray = (from x in oldRecord group x.catg_id by x.catg_id into grp orderby grp.Key select grp).ToArray();
                        for (int x = 0; x < catgIDArray.Length; x++)
                        {
                            if (catg_id == catgIDArray[x].Key)
                            {
                                count = count + 1;
                            }
                        }
                        if (count == 0)
                        {
                            list.AddRange(oldRecord);
                            Session["TotalPoRecord"] = list;
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Already exist in list')", true);
                            list = oldRecord;
                            Session["TotalPoRecord"] = oldRecord;
                        }
                    }
                    else
                    {
                        Session["TotalPoRecord"] = list;
                    }
                    gvPOReport.DataSource = list;
                    gvPOReport.DataBind();
                }
            }
            else if (rdoCatalogue.Checked == true)
            {
                if (ddlcatalogue.SelectedIndex > 0)
                {
                    string item_code = ddlcatalogue.SelectedValue.ToString();
                    list = po.SearchReportByItemCode(item_code, fromDate, toDate);
                    if (oldRecord != null)
                    {
                        int count = 0;
                        for (int x = 0; x < oldRecord.Count; x++)
                        {
                            if (item_code == oldRecord[x].item_code)
                            {
                                count = count + 1;
                            }
                        }
                        if (count == 0)
                        {
                            list.AddRange(oldRecord);
                            Session["TotalPoRecord"] = list;
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Already exist in list')", true);
                            list = oldRecord;
                            Session["TotalPoRecord"] = oldRecord;
                        }
                    }
                    else
                    {
                        Session["TotalPoRecord"] = list;
                    }
                    gvPOReport.DataSource = list;
                    gvPOReport.DataBind();
                }
            }
        }

        protected void rdoCategory_CheckedChanged(object sender, EventArgs e)
        {
            ddlcatalogue.Visible = false;
            gvPOReport.DataSource = null;
            gvPOReport.DataBind();
            Session["TotalPoRecord"] = null;
        }

        protected void rdoCatalogue_CheckedChanged(object sender, EventArgs e)
        {
            ddlcatalogue.Visible = true;
            gvPOReport.DataSource = null;
            gvPOReport.DataBind();
            load_ddlcatalogue();
            Session["TotalPoRecord"] = null;
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            List<stationery_po_report_view> reportList = Session["TotalPoRecord"] as List<stationery_po_report_view>;
            DataTable rptDt = po.LINQResultToDataTable(reportList);
            Session["rptDt"] = rptDt;
            Response.Redirect(string.Format("~/Views/POReport.aspx"));
        }

    }
}