<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="ViewRequisitionListApprove.aspx.cs" Inherits="logicuniversity.Views.ViewRequisitionListApprove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="row text-center">
            <h2>Items Detail</h2>
    </div>
    <br />
    <br />
    <div class="container">
        <div class="col-md-3">

        </div>
        <div class="col-md-6">
            <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="161px" Width="467px">
            <Columns>
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                
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
        </div>
    </div>
    
    <br />
    <div class="row text-center">
           <a href="javascript: history.go(-1)">Go Back</a>
    </div>
</asp:Content>
