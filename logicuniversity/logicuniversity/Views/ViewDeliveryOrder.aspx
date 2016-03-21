<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="ViewDeliveryOrder.aspx.cs" Inherits="logicuniversity.Views.ViewDeliveryOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server">
        <asp:Label ID="lblDeliveryOrder" runat="server" Font-Bold="True" Text="View Delivery Order"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblmsg" runat="server" Text="There is no data." Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="gvdo" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvdo_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="254px" Width="586px">
            <Columns>
                <asp:BoundField HeaderText="PO Number" DataField="po_id" />
                <asp:BoundField HeaderText="Supplier Name" DataField="supplier.sup_name" />
                <asp:BoundField HeaderText="PO Date" DataField="po_date" />
                <asp:BoundField HeaderText="Status" DataField="status" />
                <asp:ButtonField HeaderText="Details" CommandName="select" Text="Details" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </form>

</asp:Content>
