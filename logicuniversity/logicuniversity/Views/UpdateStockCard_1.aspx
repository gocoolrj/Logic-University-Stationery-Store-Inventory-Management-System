<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="UpdateStockCard_1.aspx.cs" Inherits="logicuniversity.Views.UpdateStockCard_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form3" runat="server">
        <div class="row text-right">
            Category:<asp:DropDownList ID="ddlCategory" runat="server" Height="22px" Width="200px" OnSelectedIndexChanged="ddlCategory_SelectedIndexChange" AutoPostBack="true"  >
                        <asp:ListItem Selected="True">ALL</asp:ListItem>
                     </asp:DropDownList>
        </div>
        <div class="row text-center">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" PageSize="24" PageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="215px" Width="595px" > 
                <Columns>
                    <asp:BoundField DataField="item_code" HeaderText="Item Code" />
                    <asp:BoundField DataField="name" HeaderText="Category" />
                    <asp:BoundField DataField="description" HeaderText ="Description"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="View" CommandArgument ='<%# Eval("item_code") %>' OnCommand="LinkButton1_Command" />
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCatalogueList" TypeName="logicuniversity.DBBroker.EfFacade"></asp:ObjectDataSource>
    </form>
</asp:Content>
