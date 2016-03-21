<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="ApproveRequisitionDetail.aspx.cs" Inherits="logicuniversity.Views.ApproveRequisitionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div class ="row text-center">
        <h1>Requisition Detail</h1>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-md-3">

        </div>
        <div class="col-md-6">
            
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="266px" Width="825px">
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
        <div class="col-md-3">

        </div>
    </div> 
        <div class="row">
            <div class="col-md-3">

        </div>
        <div class="col-md-6 ">
        
            
                <asp:Label ID="Label1" runat="server" Text="Reason:  "></asp:Label><asp:TextBox ID="TextBox1" runat="server" Width="188px" CssClass="form-control" Text=""></asp:TextBox>
        <br />
        <br />
                    
        <asp:Button ID="ApproveBtn" runat="server" Text="Approve" CssClass="btn btn-default" OnClick="ApproveBtn_Click" />         <asp:Button ID="RejectBtn" runat="server" CssClass="btn btn-default" Text="Reject" OnClick="RejectBtn_Click" Width="102px" />
        
        
        </div>
        <div class="col-md-3">

        </div>
        </div>
        </form>
</asp:Content>
