<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="ApproveRequisition.aspx.cs" Inherits="logicuniversity.Views.ApproveRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="col-md-3">

    </div>
    <div class="col-md-6">
        <div class="row text-center">
        <h1>Requisition List</h1>
            <br />
    <br />
        </div>
    <div>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="286px" Width="794px">
            <Columns>
                <asp:BoundField DataField="Emp_name" HeaderText="Staff Name" SortExpression="Emp_name" />
                <asp:BoundField DataField="Req_date" HeaderText="Submit Date" SortExpression="Req_date" DataFormatString = "{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="Req_id" SortExpression="Req_id" Visible="False" />
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CommandName="Select" CommandArgument='<%# Eval("Req_id") %>' onCommand="LinkButton1_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
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
    
</asp:Content>