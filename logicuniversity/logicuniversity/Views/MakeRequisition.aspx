<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/employee.master" AutoEventWireup="true" CodeBehind="MakeRequisition.aspx.cs" Inherits="logicuniversity.Views.MakeRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class="row container-fluid text-center">
        <div class="col-md-3">    
        </div>
        <div class="col-md-8">
            <asp:GridView ID="reqGridView" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" Width="666px"  OnRowDeleting="reqGridView_RowDeleting"  DataKeyNames="Item_code" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="Item_code" HeaderText="Item_code" Visible="false"/>
                    <asp:BoundField DataField="Name" HeaderText="Category" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </div>
    </div>
    <div class="row text-center navbar-fixed-middle">
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" Height="40px" Width="120px" OnClick="btnSave_Click"/>
    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" Height="40px" Width="120px" OnClick="btnAdd_Click"/>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" Height="40px" Width="120px" OnClick="btnSubmit_Click"/>
    </div>
    </form>
</asp:Content>