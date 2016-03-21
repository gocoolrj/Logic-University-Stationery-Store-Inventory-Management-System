<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="ViewRejectItems.aspx.cs" Inherits="logicuniversity.Views.ViewRejectItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="row text-center"><h2>View Reject Items</h2></div>
    <br />
    <br />
    <div>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="275px" Width="742px">
            <Columns>
                <asp:BoundField datafield="date" HeaderText ="Date" DataFormatString = "{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="category" HeaderText="Category" />
                <asp:BoundField DataField="desc" HeaderText="Description" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="remark" HeaderText="Remark" />
                <asp:BoundField DataField="dept_name" HeaderText="Department" />
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
            </div>
         
        </div>
           
    </form>
    </div>
</asp:Content>
