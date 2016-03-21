<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/employee.master" AutoEventWireup="true" CodeBehind="AddItems.aspx.cs" Inherits="logicuniversity.Views.AddItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="addItems" runat="server">
        <div class="row text-right">
            <asp:Label ID="Label1" runat="server" Text="Category:" CssClass=""></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="200px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  AutoPostBack="true">
                <asp:ListItem Selected="True">All</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="row text-center">
            <div class="col-md-3">

            </div>
            <div class="col-md-9">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="896px" PageSize="26" OnPageIndexChanging="pageChanging" DataKeyNames="Item_code" CellPadding="4" GridLines="None" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TextBox1" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Item_code" HeaderText="Item_Code" Visible="false" HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Category" HeaderStyle-HorizontalAlign="Justify">
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Quantity(0~99)" HeaderStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" Text=""></asp:TextBox>                                
                            </ItemTemplate>
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true" ControlToValidate="txtQty" ValidationExpression="^\d{0,2}$" ForeColor="Red"
                                     runat="server" ErrorMessage="Please enter right number" SetFocusOnError="False"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
             </div>
        </div>
        <div class="row text-center navbar-fixed-middle">
            <asp:Button ID="Add" runat="server" Text="Add" CssClass="btn btn-default" Height="35px" Width="100px" OnClick="Add_Click"/><asp:Button ID="Return" runat="server" Text="Return" CssClass="btn btn-default" Height="35px" Width="100px" OnClick="Return_Click"/>
        </div>
    </form>
</asp:Content>
