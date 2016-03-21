<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/representative.master" AutoEventWireup="true" CodeBehind="receive_stationeries.aspx.cs" Inherits="logicuniversity.Views.receive_stationeries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server" style="height: 599px">
      <div class="col-lg-12">

          <div class="row">
                <div class="col-lg-12">
                        <h2 class="page-header">Requisition List</h2>
                </div>
           </div>
        <br />

                <!--<div class ="row">
                <div class="col-lg-2">
                    Department Name:  
                 </div>  
                <div class ="col-lg-3">
                    <asp:TextBox ID="tbDeptName" runat="server" CssClass="form-control" Width="250px" Enabled="False"></asp:TextBox>
                </div>
                </div>-->
            <br/>
          <div class ="row">
                <div class="col-lg-2">
                   Collection Point:
                 </div>  
                <div class ="col-lg-3">
                   <asp:TextBox ID="tbCollPoint" runat="server" CssClass="form-control" Width="250px" Enabled="False"></asp:TextBox>
                </div>
                </div>
          <br/>
          <div class ="row">
                <div class="col-lg-2">
                   Delivered by:
                 </div>  
                <div class ="col-lg-3">
                   <asp:TextBox ID="tbDeliBy" runat="server" CssClass="form-control" Width="250px" Enabled="False"></asp:TextBox>
                </div>
                </div>


          <div class ="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <asp:GridView ID="gvReceiveStationeries" runat="server" AutoGenerateColumns="False" DataKeyNames="Item_code" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="217px" Width="583px">
          
            <Columns>
                <asp:BoundField DataField="Item_code"  Visible="false" HeaderText="ItemCode" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
         
                   <asp:TemplateField HeaderText="Problem Items">
                    <ItemTemplate>
                        <asp:TextBox ID="tbProblemItems" runat="server"></asp:TextBox>
                    </ItemTemplate> 
                </asp:TemplateField>
          
                <asp:TemplateField HeaderText="Reason">
                    <ItemTemplate>
                        <asp:TextBox ID="tbReason" runat="server" ></asp:TextBox>
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
                </div>
                </div>
                </div>
                    

          <div class ="row">
                <div class="col-lg-3">
                  
                    <asp:Button ID="btnConfirm" runat="server" OnClick="Button1_Click" Text="Confirm" CssClass="btn btn-primary" />
                </div>
                </div>


          </div>


       

       
       
      
       

    </form>
</asp:Content>
