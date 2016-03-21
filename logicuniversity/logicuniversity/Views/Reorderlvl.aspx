<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="Reorderlvl.aspx.cs" Inherits="logicuniversity.Views.Reorderlvl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div style="margin-left:auto; margin-right:auto; text-align:center;">
            <asp:Label ID="lblTitle" runat="server" BorderStyle="Ridge" Text="Notify Reorder"></asp:Label><br /><br />

         </div>
        <br />
        <br />
        <div class ="row">
            <div class="col-lg-12"?>
                <asp:GridView ID="gvReoderLvl" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Category Name" DataField="catg_id" />
                        <asp:BoundField HeaderText="Item Code" DataField="item_code" />
                        <asp:BoundField HeaderText="Description" DataField="description" />
                        <asp:BoundField HeaderText="Reorder_level" DataField="reorder_level" />
                        <asp:BoundField HeaderText="Unit" DataField="uom" />
                        <asp:BoundField HeaderText="Balance" DataField="balance" />

                        <%--<asp:HyperLinkField NavigateUrl="~/Views/PurchaseOrder.aspx" Text="ReOrder" />--%>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="btnro" runat="server" Text="Reorder" OnClick="btnro_Click" />
            </div>
        </div>

    </form>
</asp:Content>
