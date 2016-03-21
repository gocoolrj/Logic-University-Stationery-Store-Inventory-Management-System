<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="view_stocklevel.aspx.cs" Inherits="logicuniversity.Views.view_stocklevel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div style="margin-left: auto; margin-right:auto; text-align: center;">
            <asp:Label ID="lblTitle" runat="server" BorderStyle="Ridge" Text="Inventory Status Report"></asp:Label><br /><br />
        <br />
        <br />
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">

               <asp:GridView ID="gvStockLvl" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="157px" Width="731px" OnSelectedIndexChanged="gvStockLvl_SelectedIndexChanged">
        
            <Columns>    
                <asp:BoundField HeaderText="Item Code" DataField="item_code" />
                <asp:BoundField HeaderText="Decription" DataField="description" />
                <asp:BoundField HeaderText="Location" DataField="location" />
                <asp:BoundField HeaderText="Unit of Measurement" DataField="uom" /> 
                <asp:BoundField HeaderText="Quality on hand" DataField="qoh" />
                <asp:BoundField HeaderText="Reorder Level" DataField="reorderlvl" /> 
                <asp:BoundField HeaderText="Reorder Qty" DataField="reorderqty" />
                    
                <asp:HyperLinkField NavigateUrl="~/Views/UpdateStockCard_1.aspx" Text="View" />
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
                <br />
                <asp:Button ID="btnMPO" BackColor="SkyBlue" runat="server" Text="Make Purchase Order" OnClick="btnMPO_Click" />

            </div>
            
        
            </div>           
     
        <br />
</form>
</asp:Content>
