<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/supervisor.master" AutoEventWireup="true" CodeBehind="generateStationeryOrder.aspx.cs" Inherits="logicuniversity.Views.generate_stationeryOrderReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    
    <form runat="server">
     
  

        <div class="row">
            <div class="col-lg-12">
                    <h2 class="page-header">Stationery Order Report</h2>
            </div>
        </div>
        <br />



        <div class ="row">
            <div class="col-lg-12">               
                <div class="col-lg-4">
                    <asp:Label ID="Label1" runat="server" Text="From :"></asp:Label>
                    <asp:TextBox ID="txtFromDate" runat="server" type="Date" CssClass="form-control" placeholder="DD/MM/YYYY" required="true"></asp:TextBox>
                </div>
                
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="To :"></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server" type="Date" CssClass="form-control" placeholder="DD/MM/YYYY" required="true"></asp:TextBox>
                </div>
            </div>
        </div>
        <br/>
         <div class ="row">
             <div class="col-lg-4">
                 <asp:RadioButton ID="rdoCategory" runat="server" GroupName="rdoGroup" Text="Compare by Category" class="radio" AutoPostBack="True" OnCheckedChanged="rdoCategory_CheckedChanged" Checked="True"/>
                 <asp:RadioButton ID="rdoCatalogue" runat="server" GroupName="rdoGroup" Text="Compare by Each Item" class="radio" AutoPostBack="True" OnCheckedChanged="rdoCatalogue_CheckedChanged" />
                </div>
        </div>
        <br/>
        <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-4">
                    <asp:DropDownList ID="ddlcategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" class="btn btn-default dropdown-toggle" data-toggle="dropdown" Width="200px"></asp:DropDownList>
                </div>
                
                <div class="col-lg-4">
                    <asp:DropDownList ID="ddlcatalogue" runat="server" class="btn btn-default dropdown-toggle" Width="200px" AutoPostBack="True" Visible="False" ></asp:DropDownList>
                </div>
            </div>
        </div>
        <br/>


        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-4">
               <asp:Button ID="btnAddtolist" runat="server" Text="Add to List" class="btn btn-primary" OnClick="btnAddtolist_Click" />
            </div>
                </div>
        </div>
        <br/>
        
        <br/>
        <br/>
        <div class ="row">
            <div class="col-lg-12">
                <div class="col-lg-6">
                     <asp:GridView ID="gvPOReport" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="po_id" HeaderText="PO Number" ItemStyle-Width="100px"/>
                                        <asp:BoundField DataField="item_code" HeaderText="Item Code" ItemStyle-Width="70px"/>
                                        <asp:BoundField DataField="name" HeaderText="Category" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="250px"/>
                                        <asp:BoundField DataField="quantity" HeaderText="Quantity" /> 
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                        <asp:BoundField DataField="total" HeaderText="Total" />
                                        </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Width="0px" />
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
        </div>
        <br/>
         <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-4">
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" class="btn btn-primary" />
</div>
                </div>
        </div>
    </form>
    
</asp:Content>

