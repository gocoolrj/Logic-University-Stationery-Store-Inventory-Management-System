using logicuniversity.Controllers;
using logicuniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logicuniversity.Views
{
    public partial class MakePurchaseOrder : System.Web.UI.Page
    {
        SupplierController sc = new SupplierController();
        CategoryController cc = new CategoryController();
        POController pc = new POController();
        PODetailController podc = new PODetailController();
        List<AddPurchaseOrder> apolist = new List<AddPurchaseOrder>();
        //List<AddPurchaseOrder> apos = new List<AddPurchaseOrder>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlSupplier.DataSource = sc.GetSuppliers();
                ddlSupplier.DataValueField = "sup_code";
                ddlSupplier.DataTextField = "sup_name";
                ddlSupplier.DataBind();

                ddlCat.DataSource = cc.GetCategories();
                ddlCat.DataValueField = "catg_id";
                ddlCat.DataTextField = "name";
                ddlCat.DataBind();

                if(checkgvPO())
                {
                    lblTitle.Visible = false;
                    lblSupplier1.Visible = false;
                    lblSupCode.Visible = false;
                    btnSubmit.Visible = false;
                    lblDate.Visible = false;
                    lbltotal.Visible = false;
                }
                else
                {
                    lblTitle.Visible = true;
                    lblSupplier1.Visible = true;
                    lblSupCode.Visible = true;
                    btnSubmit.Visible = true;
                    lblDate.Visible = true;
                    lbltotal.Visible = false;
                }
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            apolist = HttpContext.Current.Session["apolist"] as List<AddPurchaseOrder>;
            string item_code = gvPO.SelectedRow.Cells[0].Text;
            for (int i = 0; i < apolist.Count; i++)
            {
                if (apolist[i].Itemcode == item_code)
                {
                    apolist.RemoveAt(i);
                }
            }
            Session["apolist"] = apolist;
            gvPO.DataSource = Session["apolist"];
            gvPO.DataBind();
            decimal total_amount = 0;
            for (int i = 0; i < gvPO.Rows.Count; i++)
            {
                total_amount += Convert.ToDecimal(gvPO.Rows[i].Cells[4].Text);
            }
            lbltotal.Text = "Total amount : " + total_amount.ToString();

            if (checkgvPO())
            {
                lblTitle.Visible = false;
                lblSupplier1.Visible = false;
                lblSupCode.Visible = false;
                btnSubmit.Visible = false;
                lblDate.Visible = false;
                lbltotal.Visible = false;
            }
            else
            {
                lblTitle.Visible = true;
                lblSupplier1.Visible = true;
                lblSupCode.Visible = true;
                btnSubmit.Visible = true;
                lblDate.Visible = true;
                lbltotal.Visible = false;
            }
        }

        protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCat.SelectedItem.Value != "select")
            {
                string supcode = ddlSupplier.SelectedItem.Value;
                int catid = Convert.ToInt32(ddlCat.SelectedItem.Value);
                gvAddPO.DataSource = pc.GetItemPrices(catid, supcode);
                gvAddPO.DataBind();
            }
            else
            {
                gvAddPO.DataSource = null;
                gvAddPO.DataBind();
            }
        }

        protected bool checkgvPO()
        {
            Boolean flag = false;
            if (gvPO.Rows.Count <= 0)
                flag = true;
            return flag;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblSupplier1.Text = "Supplier : " + ddlSupplier.SelectedItem.Text;
            lblSupCode.Text = ddlSupplier.SelectedItem.Value;
            for (int i = 0; i < gvAddPO.Rows.Count; i++)
            {
                AddPurchaseOrder apo = new AddPurchaseOrder();
                GridViewRow row = gvAddPO.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                if (isChecked)
                {
                    
                    apo.Itemcode = gvAddPO.Rows[i].Cells[0].Text;
                    apo.Desc = gvAddPO.Rows[i].Cells[1].Text;
                    apo.Price = Convert.ToDecimal(gvAddPO.Rows[i].Cells[2].Text);
                    TextBox txtqty = (TextBox)gvAddPO.Rows[i].Cells[3].FindControl("txtqty");
                    if (txtqty.Text != "")
                        apo.Qty = Convert.ToInt16(txtqty.Text);
                    else
                        apo.Qty = 0;
                    apo.Amount = apo.Price * apo.Qty;
                    apolist.Add(apo);
                }
            }

            if (Session["apolist"] != null)
            {
                List<AddPurchaseOrder> tmp = HttpContext.Current.Session["apolist"] as List<AddPurchaseOrder>;//history

                foreach (AddPurchaseOrder t in tmp.ToList())
                {
                    foreach (AddPurchaseOrder a in apolist.ToList())//selected now
                    {
                        if(a.Itemcode == t.Itemcode)
                        {
                            //apolist.Remove(a);
                            tmp.Remove(t);
                        }                       
                    }
                }
                foreach (AddPurchaseOrder a in apolist.ToList())
                {
                    tmp.Add(a);
                }

                Session["apolist"] = tmp;
            }
            else
            {
                Session["apolist"] = apolist;
            }

            gvPO.DataSource = Session["apolist"];
            gvPO.DataBind();

            decimal total_amount = 0;
            for (int i = 0; i < gvPO.Rows.Count; i++)
            {
                total_amount += Convert.ToDecimal(gvPO.Rows[i].Cells[4].Text);
            }

            lblDate.Text = "Due Date : "+ txtDueDate.Text;
            lbltotal.Text = "Total amount : " + total_amount.ToString();

            if (checkgvPO())
            {
                lblTitle.Visible = false;
                lblSupplier1.Visible = false;
                lblSupCode.Visible = false;
                btnSubmit.Visible = false;
                lblDate.Visible = false;
                lbltotal.Visible = false;
            }
            else
            {
                lblTitle.Visible = true;
                lblSupplier1.Visible = true;
                lblSupCode.Visible = true;
                btnSubmit.Visible = true;
                lblDate.Visible = true;
                lbltotal.Visible = false;
            }
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCat.SelectedItem.Value != "select")
            {
                string supcode = ddlSupplier.SelectedItem.Value;
                int catid = Convert.ToInt32(ddlCat.SelectedItem.Value);
                gvAddPO.DataSource = pc.GetItemPrices(catid, supcode);
                gvAddPO.DataBind();
            }
            else
            {
                gvAddPO.DataSource = null;
                gvAddPO.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal net = Convert.ToDecimal((lbltotal.Text.Split(new string[] { ": " }, StringSplitOptions.None)[1]));
            string poid = pc.AddPurchaseOrder(lblSupCode.Text,net,txtDueDate.Text);

            if(poid!=null)
            {
                int i = podc.AddPOD(poid);
                if(i!=0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Make purchase successfully')", true);
                    gvAddPO.DataSource = null;
                    gvPO.DataSource = null;
                    gvAddPO.DataBind();
                    gvPO.DataBind();
                    lbltotal.Text = "";
                    Session.Remove("apolist");
                    if (checkgvPO())
                    {
                        lblTitle.Visible = false;
                        lblSupplier1.Visible = false;
                        lblSupCode.Visible = false;
                        btnSubmit.Visible = false;
                        lblDate.Visible = false;
                        lbltotal.Visible = false;
                    }
                    else
                    {
                        lblTitle.Visible = true;
                        lblSupplier1.Visible = true;
                        lblSupCode.Visible = true;
                        btnSubmit.Visible = true;
                        lblDate.Visible = true;
                        lbltotal.Visible = false;
                    }
                }
            }

        }
    }
}