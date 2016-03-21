using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class RetrieveStationeries1 : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        static 
        string s = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                s = Session["item_code"].ToString();
            }catch(Exception e1)
            {
                Response.Redirect("RetrieveStationeries.aspx", true);
            }  
            if (!IsPostBack)
            {
                Label3.Text = ef.getItemDescription(s);
                Label4.Text = ef.getNeededAmount(s).ToString();
                GridView1.DataSource = ef.getStationeryByItemCode(s);
                GridView1.DataBind();

                if (ef.ifitemshavebeenadded(s))
                {
                    Dictionary<int, int> di = ef.getalreadydispachedItem(s);
                    int actual = 0;
                    foreach (GridViewRow gvr in GridView1.Rows)
                    {
                        int dep_id = Convert.ToInt32(gvr.Cells[2].Text.ToString());
                        TextBox tb = (TextBox)gvr.Cells[4].FindControl("TextBox1");
                        tb.Text = di[dep_id].ToString();
                        actual = actual + di[dep_id];
                    }
                }
                else
                {

                }
                //DateTime d1 = Convert.ToDateTime(Session["date1"]);
                //DateTime d2 = Convert.ToDateTime(Session["date2"]);
                //Label1.Text = d1.ToString("MMMM dd, yyyy");
                //Label2.Text = d2.ToString("MMMM dd, yyyy");
                
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //string s = Session["item_code"].ToString();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                /*get actual quantity*/
                TextBox t = (TextBox)GridView1.Rows[i].Cells[4].FindControl("TextBox1");
               
                if (t.Text != "")
                {
                    int amt = Convert.ToInt32(t.Text.ToString());
                    int dept_id = Convert.ToInt16(GridView1.Rows[i].Cells[2].Text.Trim());
                    int needquantity = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text.ToString());
                    /*give deptid and actual amount*/
                    ef.updateRequisitionByDepartment(s, dept_id, amt,needquantity);
                }
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Successfully!');</script>");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /*get the actual and needed number*/
                int actualAmount = Convert.ToInt16(input1.Value);
                int neededAmount = Convert.ToInt16(Label4.Text);

                /*if amount no unfill*/
                if (actualAmount == neededAmount)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        //                    GridView1.Rows[i].Cells[4].Text = GridView1.Rows[i].Cells[3].Text.ToString();
                        TextBox txtType = (TextBox)GridView1.Rows[i].Cells[4].FindControl("TextBox1");
                        txtType.Text = GridView1.Rows[i].Cells[3].Text.ToString();
                        txtType.Enabled = true;
                    }
                }
                else if (actualAmount < neededAmount)
                {
                    Dictionary<int, int> di = ef.dispatchItem(actualAmount, Session["item_code"].ToString());
                    foreach (GridViewRow gvr in GridView1.Rows)
                    {
                        int dep_id = Convert.ToInt32(gvr.Cells[2].Text.ToString());
                        int depneedquantity = Convert.ToInt32(gvr.Cells[3].Text.ToString());
                        int actualquantity = 0;
                        TextBox tb = (TextBox)gvr.Cells[4].FindControl("TextBox1");
                        if (di[dep_id] != 0)
                        {
                            actualquantity = depneedquantity - di[dep_id];
                        }
                        else
                        {
                            actualquantity = depneedquantity;
                        }
                        tb.Text = actualquantity.ToString();
                        tb.Enabled = true;
                    }
                }
                else { }
            }
            

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}