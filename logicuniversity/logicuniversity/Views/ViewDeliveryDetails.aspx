<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="ViewDeliveryDetails.aspx.cs" Inherits="logicuniversity.Views.ViewDeliveryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server">
        <asp:Label ID="lblvdod" runat="server" Font-Bold="True" Text="Delivery Order Details"></asp:Label>
        <br />
        <asp:GridView ID="gvdod" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvdod_RowDatabound">
            <Columns>
                <asp:BoundField HeaderText="Purchase Order No." DataField="po_id" />
                <asp:BoundField HeaderText="Supplier" DataField="sup_name" />
                <asp:BoundField HeaderText="Item Code" DataField="item_code" />
                <asp:BoundField HeaderText="Item Name" DataField="item_name" />
                <asp:BoundField HeaderText="Quantity" DataField="qty" />
                <asp:BoundField HeaderText="Price" DataField="price" />
                <asp:BoundField HeaderText="Status" DataField="status" />
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </form>

</asp:Content>
