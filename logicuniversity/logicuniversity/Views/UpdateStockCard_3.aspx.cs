using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class UpdateStockCard_3 : System.Web.UI.Page
    {
        EFFacade facade = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(TextBox1.Text);
            //DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);
            string des = TextBox2.Text;
            string qty = TextBox3.Text;
            facade.updateStockCard(Session["item_code"].ToString(), dt, des, qty);
            facade.updateStocklevel(Session["item_code"].ToString(), qty);

            Response.Redirect(String.Format("UpdateStockCard_2.aspx"));

        }


    }
}