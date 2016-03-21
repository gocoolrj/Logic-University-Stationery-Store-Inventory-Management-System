using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logicuniversity.WebService;

namespace logicuniversity.Views
{
    public partial class AddNewDiscrepancy : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        public static List<DiscrepancyDetail> list = new List<DiscrepancyDetail>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_role"] != null)
            {
                string x = Session["user_role"].ToString();
                if (Session["user_role"].ToString() == "Store Clerk") 
                {
                    if (!IsPostBack)
                    {
                        DropDownList1.DataSource = ef.getCatalogueList();
                        DropDownList1.DataTextField = "Description";
                        DropDownList1.DataValueField = "Item_code";
                        DropDownList1.DataBind();
                    }
                }
                else
                {
                    Response.Redirect(string.Format("~/login.aspx"));
                }
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string item_code = DropDownList1.SelectedItem.Value;
            string description = DropDownList1.SelectedItem.Text;
            int quantity = Convert.ToInt32(TextBox1.Text);
            string remark = TextBox2.Text;

            makeDiscrepancyDetail(item_code, description, quantity, remark);

            GridView1.DataSource = list;
            GridView1.DataBind();

            Button1.Visible = true;

            DropDownList1.Text = null;
            TextBox1.Text = null;
            TextBox2.Text = null;

        }

        protected void makeDiscrepancyDetail(string item_code, string description, int quantity, string remark)
        {
            DiscrepancyDetail d = new DiscrepancyDetail();
            d.Item_code = item_code;
            d.Description = description;
            d.Quantity = quantity;
            d.Reason = remark;
            list.Add(d);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ef.createDiscrepancy(list);
            Server.Transfer("DiscrepancyReport.aspx", true);
            list = null;

        }


    }
}