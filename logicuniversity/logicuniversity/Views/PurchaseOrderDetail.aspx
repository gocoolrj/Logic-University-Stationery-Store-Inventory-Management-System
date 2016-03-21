<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/supervisor.master" AutoEventWireup="true" CodeBehind="PurchaseOrderDetail.aspx.cs" Inherits="logicuniversity.Views.PurchaseOrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        
    <div class="row">
        <div class="col-lg-6">  
            <asp:GridView ID="gvPOD" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="po_id" HeaderText="Item No." />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                    <asp:BoundField DataField="net_amount" HeaderText="Amount" />
                    <asp:BoundField DataField="total" HeaderText="Total" />
                </Columns>
               
            </asp:GridView>
             <asp:Button ID="btnApv" BackColor="SkyBlue" runat="server" Text="Approve" OnClick="btnApv_Click"  />&nbsp &nbsp &nbsp &nbsp
             <asp:Button ID="btnRej" BackColor="SkyBlue" runat="server" Text="Reject" OnClick="btnRej_Click" />
        </div>
     </div>
    </form>
</asp:Content>
