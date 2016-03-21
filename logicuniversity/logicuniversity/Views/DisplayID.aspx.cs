using Entity;
using logicuniversity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class DisplayID : System.Web.UI.Page
    {
        StationeryDBEntities sat = new StationeryDBEntities();
        CreateEmpController cec = new CreateEmpController();
        protected void Page_Load(object sender, EventArgs e)
        {

            //   int ID = Convert.ToInt32(EmpID.Text);
            //employee emp = new employee();

            //var id = sat.employees.Last(z => z.emp_id == ID);

            //id.emp_id = int.Parse(EmpID.Text);

            EmpID.Text = cec.GetEmpId().ToString();

        }
    }
}