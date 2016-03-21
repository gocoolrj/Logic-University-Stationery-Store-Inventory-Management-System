<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="MakePurchaseOrder.aspx.cs" Inherits="logicuniversity.Views.MakePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div style="margin-left: auto; margin-right: auto; text-align: center;">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Stationery Add Purchase Order"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblSupplier" runat="server" Text="Supplier : "></asp:Label>
                    <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged" CssClass="btn btn-default dropdown-toggle">
                        <asp:ListItem Text="--- Select ---" Value="select"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="lblCat" runat="server" Text="Category : "></asp:Label>
                    <asp:DropDownList ID="ddlCat" runat="server" OnSelectedIndexChanged="ddlCat_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True" CssClass="btn btn-default dropdown-toggle">
                        <asp:ListItem Text="--- Select ---" Value="select"></asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDueDate" runat="server" Text="Due Date : "></asp:Label>
                    <asp:TextBox ID="txtDueDate" runat="server" type="Date" Height="24px" required="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:GridView ID="gvAddPO" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Item No." DataField="itemcode" />
                            <asp:BoundField HeaderText="Description" DataField="desc" />
                            <asp:BoundField HeaderText="Tender Price" DataField="price" />
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtqty" runat="server" placeholder="0" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-primary"/>
                    <br />
                </div>
                <div class="col-lg-6">
                    <div style="margin-left: auto; margin-right: auto; text-align: center;">
                        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Text="Stationery Purchase Order"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-lg-12">
                             <asp:Label ID="lblSupplier1" runat="server" CssClass="col-lg-6"></asp:Label>
                             <asp:Label ID="lblDate" runat="server" CssClass="col-lg-6">Date : </asp:Label>
                             <br />
                             &nbsp;&nbsp;&nbsp;
                             <asp:Label ID="lblSupCode" runat="server" Visible="False"></asp:Label>
                             <br />
                             <br />
                             <br />
                             <div>
                                 <asp:GridView ID="gvPO" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="OnSelectedIndexChanged">
                                     <Columns>
                                         <asp:BoundField HeaderText="Item No." DataField="itemcode" />
                                         <asp:BoundField HeaderText="Description" DataField="desc" />
                                         <asp:BoundField HeaderText="Tender Price" DataField="price" />
                                         <asp:BoundField HeaderText="Quantity" DataField="qty" />
                                         <asp:BoundField HeaderText="Amount" DataField="amount" />
                                         <asp:ButtonField HeaderText="Remove" CommandName="select" Text="remove" />
                                     </Columns>
                                 </asp:GridView>
                                <br />
                                <p style="text-align:left;margin-left:200px;"><asp:Label ID="lbltotal" runat="server" /></p>
                                <br />
                             </div>
                             <br />
                             <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        
    </form>
</asp:Content>
