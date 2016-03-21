<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="MakeDisbursement.aspx.cs" Inherits="logicuniversity.Views.MakeDisbursement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
      

        <div class="col-lg-12">

            <div class="row">
                <div class ="col-lg-12">
                <h1 class="page-header">Disbursement List</h1>
                    </div>
            </div>

            
            <br/>
            <div class="row">
                 <div class ="col-lg-3">
                     Department:<br/><asp:DropDownList ID="DropDownList1" runat="server" Width="250px" AutoPostBack="false" CssClass="btn btn-default dropdown-toggle"> </asp:DropDownList>
                 </div>
            </div>
            <br/>
            <div class="row">
                <div class ="col-lg-3">
                    <asp:Button ID="Button1" runat="server" Text="Retrieve" OnClick="Button1_Click" class="btn btn-primary" />
                 </div>
            </div>
            <br />

            <div class="row">
                 <div class ="col-lg-7">
                     <asp:GridView ID="GridView1" runat="server" style="width:80%" AutoGenerateColumns="False" DataKeyNames="item_code" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField ="item_code" HeaderText="Item code"/>
                    <asp:BoundField DataField ="description" HeaderText ="Stationery Description"/>
                    <asp:BoundField DataField="req_amount" HeaderText="Needed Amount" Visible="false"/>
                    <asp:BoundField DataField="actual_amount" HeaderText="Actual Amount"/>
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
            <br/>
            <div class="row">
                <div class ="col-lg-3">
                   <asp:Button ID="Button2" runat="server" Text="Confirm" Visible="false" OnClick="Button2_Click" class="btn btn-primary"/>
                 </div>
            </div>


      </div>
    </form>
</asp:Content>
