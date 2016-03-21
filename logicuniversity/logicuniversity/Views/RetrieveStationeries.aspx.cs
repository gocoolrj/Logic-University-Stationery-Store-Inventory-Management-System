using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{

    public partial class RetrieveStstioneries : System.Web.UI.Page
    {
        static List<Stationery1> list;
        EFFacade ef = new EFFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView2.DataSource = list;
            //GridView2.DataBind();
            Button1.Visible = false;
            list = ef.getStationeryByItemName();
            GridView2.DataSource = list;
            GridView2.DataBind();
            if (list == null)
            {
                Button2.Visible = false;
            }
            else
            {
                Button2.Visible = true;
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //list = ef.getStationeryByItemName();
            //GridView2.DataSource = list;
            //GridView2.DataBind();
            //Button2.Visible = true;
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

            Session["item_code"] = e.CommandArgument.ToString();
            //Server.Transfer("RetrieveStationeriesDetail.aspx", true);
            Response.Redirect(string.Format("RetrieveStationeriesDetail.aspx"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("MakeDisbursement.aspx", true);
        }

    }
}