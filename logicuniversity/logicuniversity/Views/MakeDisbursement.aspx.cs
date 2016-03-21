using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class MakeDisbursement : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DateTime d1 = Convert.ToDateTime(Session["date1"]);
                //DateTime d2 = Convert.ToDateTime(Session["date2"]);
                //TextBox1.Text = d1.ToString("MMMM dd, yyyy");
                //TextBox2.Text = d2.ToString("MMMM dd, yyyy");

                DropDownList1.DataSource = ef.getDepartmentList();
                DropDownList1.DataTextField = "dept_name";
                DropDownList1.DataValueField = "dept_id";
                DropDownList1.DataBind();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            Console.WriteLine("selectedItem"+i);
            GridView1.DataSource = ef.getDisbursementListByDept(i);
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;
            if (GridView1.Rows.Count != 0)
            {
                Button2.Visible = true;
            }
            else
            {
                Button2.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int dept_id = Convert.ToInt32(DropDownList1.SelectedItem.Value);

            List<Disbursement> list = new List<Disbursement>();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Disbursement d = new Disbursement();
                d.Item_code = GridView1.Rows[i].Cells[0].Text;
                d.Actual_amount = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                list.Add(d);
            }
            ef.createDeliverOrder(dept_id, list);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Successfully!');</script>");
        }
    }
}