using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class UpdateStockCard_2 : System.Web.UI.Page
    {
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((ef.getStockCard(Session["item_code"].ToString())).Count > 0)
                {
                    GridView1.DataSource = ef.getStockCard(Session["item_code"].ToString());                    
                    label1.Text = ef.getStockCardDetail(Session["item_code"].ToString()).ToList()[0].C_description;
                    Label2.Text = ef.getStockCardDetail(Session["item_code"].ToString()).ToList()[0].Unit;
                    Label3.Text = ef.getStockCardDetail(Session["item_code"].ToString()).ToList()[0].Balance.ToString();

                    GridView1.DataBind();
                }
                else
                {                    
                    Response.Redirect(String.Format("UpdateStockCard_1.aspx"));                    
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("UpdateStockCard_3.aspx"));            
        }
    }
}