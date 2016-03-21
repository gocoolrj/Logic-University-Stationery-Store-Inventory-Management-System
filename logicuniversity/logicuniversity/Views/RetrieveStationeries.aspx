<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="RetrieveStationeries.aspx.cs" Inherits="logicuniversity.Views.RetrieveStstioneries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
   
    <form id="form1" runat="server">

        <div class="col-lg-12">

            <div class="row">
                <div class="col-lg-12">
                        <h2 class="page-header">Retrieval Form</h2>
                </div>
            </div>
            <br/>
            <br/>
            <div class="row">
                
                <div class ="col-lg-3">
                         <asp:Button ID="Button1" runat="server" Text="Retrieve" Width="85px" OnClick="Button1_Click" CssClass="btn btn-primary"/>
                </div>
                
            </div>
            <br/>
            <div class="row">
                <div class="col-lg-6">
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="167px" Width="445px">
                <Columns>
                    <asp:BoundField DataField ="item_code" HeaderText="Item code"/>
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="req_quantity" HeaderText="Amount" />                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CommandName="Select" CommandArgument='<%# Eval("item_code") %>' onCommand="LinkButton1_Command"  />
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
            <br/>
            <div class="row">
                
                <div class ="col-lg-3">
                        <asp:Button ID="Button2" runat="server" Text="Disburse" Visible="false" OnClick="Button2_Click" CssClass="btn btn-primary" />
                </div>
                
            </div>
        </div>
    </form>
</asp:Content>
