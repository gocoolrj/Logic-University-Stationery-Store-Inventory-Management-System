using Entity;
using logicuniversity.Controllers;
using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class ViewDeliveryDetails : System.Web.UI.Page
    {
        DeliveryOrderController doc = new DeliveryOrderController();
        UnfulfillController uffc = new UnfulfillController();
        POController poc = new POController();
        List<deliverOrderDetail> dodlist = new List<deliverOrderDetail>();
        List<SelectedDODList> sdodlist = new List<SelectedDODList>();
        List<unfulfill> ufflist = new List<unfulfill>();

        string poid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                poid = Request.QueryString["poid"];
                if (doc.Check(poid) != null)
                    gvdod.DataSource = doc.getDODList(poid);
                else
                    gvdod.DataSource = doc.getDODPendingList(poid);
                gvdod.DataBind();
            }
        }

        protected void gvdod_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < gvdod.Rows.Count; i++)
            {
                if (gvdod.Rows[i].Cells[6].Text == "Delivered")
                {
                    CheckBox chk = (CheckBox)gvdod.Rows[i].FindControl("chkSelect");
                    chk.Checked = true;
                    chk.Enabled = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string poid = null;
            string sup_name = null;
            string doid = null;
            string sdoid = null;
            Boolean flag = false;

            if(gvdod.Rows.Count>0)
            {
                poid=gvdod.Rows[0].Cells[0].Text;
                sup_name=gvdod.Rows[0].Cells[1].Text;
            }

            for (int i = 0; i < gvdod.Rows.Count; i++)
            {
                if (gvdod.Rows[i].Cells[6].Text == "Delivered")
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                if (poid != null && sup_name != null)
                {
                    doid = doc.AddDO(poid, sup_name);

                    if (doid != null)
                    {

                        for (int i = 0; i < gvdod.Rows.Count; i++)
                        {
                            deliverOrderDetail dod = new deliverOrderDetail();
                            SelectedDODList sdod = new SelectedDODList();

                            CheckBox chk = (CheckBox)gvdod.Rows[i].FindControl("chkSelect");
                            if (chk.Checked && chk.Enabled == true)
                            {
                                dod.do_id = doid;
                                dod.item_code = gvdod.Rows[i].Cells[2].Text;
                                dod.quantity = Convert.ToInt16(gvdod.Rows[i].Cells[4].Text);
                                dodlist.Add(dod);
                            }
                            else if (chk.Checked == false && chk.Enabled == true)
                            {
                                sdod.Item_code = gvdod.Rows[i].Cells[2].Text;
                                sdod.Qty = Convert.ToInt16(gvdod.Rows[i].Cells[4].Text);
                                sdod.Po_id = poid;
                                sdodlist.Add(sdod);
                            }
                        }
                        int sid = doc.AddDOD(dodlist);
                        if (sdodlist.Count > 0)
                        {
                            uffc.AddUnfulfill(sdodlist);
                            if (!uffc.AddUnfulfill(sdodlist))
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('At least you need to select one!')", true);
                        }
                        if (sid != 0)
                        {
                            if (doc.CheckforDeliver(poid) == 1)
                                poc.UpdatePO(poid);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Make deliver order successfully')", true);
                            Response.Redirect("ViewDeliveryOrder.aspx");
                        }
                    }
                }
            }
            else
            {
                sdoid = doc.getDO(poid).do_id;
                for(int i=0;i<gvdod.Rows.Count;i++)
                {
                    deliverOrderDetail dod = new deliverOrderDetail();
                    SelectedDODList sdod = new SelectedDODList();
                    unfulfill uff = new unfulfill();

                    CheckBox chk = (CheckBox)gvdod.Rows[i].FindControl("chkSelect");
                    if (chk.Checked && chk.Enabled == true)
                    {
                        dod.do_id = sdoid;
                        dod.item_code = gvdod.Rows[i].Cells[2].Text;
                        dod.quantity = Convert.ToInt16(gvdod.Rows[i].Cells[4].Text);
                        dodlist.Add(dod);

                        uff.item_code = gvdod.Rows[i].Cells[2].Text;
                        uff.@ref = poid;
                        ufflist.Add(uff);
                    }
                    else if (chk.Checked == false && chk.Enabled == true)
                    {
                        sdod.Item_code = gvdod.Rows[i].Cells[2].Text;
                        sdod.Qty = Convert.ToInt16(gvdod.Rows[i].Cells[4].Text);
                        sdod.Po_id = poid;
                        sdodlist.Add(sdod);
                    }
                }
                int sid = 0;
                if (dodlist.Count > 0)
                    sid = doc.AddDOD(dodlist);

                if (ufflist.Count > 0)
                    uffc.DeleteUnfulfill(ufflist);

                if (sdodlist.Count > 0)
                {
                    uffc.AddUnfulfill(sdodlist);
                    if (!uffc.AddUnfulfill(sdodlist))
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('At least you need to select one!')", true);
                }
                if (sid != 0)
                {
                    if (doc.CheckforDeliver(poid) == 1)
                        poc.UpdatePO(poid);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Make deliver order successfully')", true);
                    Response.Redirect("ViewDeliveryOrder.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewDeliveryOrder.aspx"); 
        }
    }
}