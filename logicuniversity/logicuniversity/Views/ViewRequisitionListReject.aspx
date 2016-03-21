<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="ViewRequisitionListReject.aspx.cs" Inherits="logicuniversity.Views.ViewRequisitionListReject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="row text-center">
        <h2>Item Detail</h2>
    </div>
    <br />
    <br />
    <div class="row container">
        <div class="col-md-6">

        </div>
        <div class="col-md-6">
            <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="154px" Width="419px">
            <Columns>
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Reason" />
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
            Reason:<asp:Label ID="Label1" runat="server" CssClass="label" Text="Label"></asp:Label>
        </div>
    </div>
    
    <br />
    

    <div class="row text-center">
        

    <br />
         <a href="javascript: history.go(-1)">Go Back</a>
    </div>  
</asp:Content>
