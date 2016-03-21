<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/supervisor.master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="logicuniversity.Views.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
  
    <div class="row">
        <div class="col-lg-6">  
                     
            <asp:GridView ID="gvPO" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvPO_SelectedIndexChanged" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    
                      
                    
                    <asp:BoundField DataField="po_id" HeaderText="Order No." />
                    <asp:BoundField DataField="sup_code" HeaderText="Supplier No." />
                    <asp:BoundField DataField="po_date" HeaderText="PurchaseOrder Date" />
                    <asp:BoundField DataField="po_duedate" HeaderText="PurchaseOrder DueDate" />
                    <asp:BoundField DataField="po_approvedate" HeaderText="PurchaseOrder ApproveDate" /> 
                    <asp:BoundField DataField="net_amount" HeaderText="Net Amount" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:BoundField DataField="remark" HeaderText="Remark" />
                    <asp:BoundField DataField="deliver_status" HeaderText="Deliver Status" />
                    <%--<asp:HyperLinkField Text="View" NavigateUrl="~/Views/PurchaseOrderDetail.aspx" />--%>
                    <asp:ButtonField HeaderText="Details" CommandName="select" Text="Details" />
                      
                </Columns>
                  
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                  
            </asp:GridView>
      
         </div>
        </div>
</form>

</asp:Content>
