<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/employee.master" AutoEventWireup="true" CodeBehind="ViewRequisitionDetail.aspx.cs" Inherits="logicuniversity.Views.ViewRequisitionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="row" id="requestinfo">
            <div class="col-md-6">
                <asp:Label ID="lab_status_text" runat="server" Text="Status:"></asp:Label>  <asp:Label ID="lab_status" runat="server" Text="" CssClass="label-danger"></asp:Label>  
                 <asp:Label ID="reason" runat="server" Visible="false" Text="Reason:"></asp:Label><asp:Label ID="text_reason" runat="server" Text="" Visible="false"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lab_reqtime_text" runat="server" Text="Request Time:"></asp:Label> <asp:Label ID="lab_reqtime" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row" id="approveinfo">
            <div class="col-md-6">
                <asp:Label ID="lab_approvename_text" runat="server" Text="Approved by:"></asp:Label><asp:Label ID="lab_approvename" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lab_approvedate_text" runat="server" Text="Date:"></asp:Label><asp:Label ID="lab_approvedate" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row" id="receiveinfo">
            <div class="col-md-6">
                <asp:Label ID="lab_receivename_text" runat="server" Text="Received by:"></asp:Label><asp:Label ID="lab_receivename" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-6">
               <asp:Label ID="lab_receivedate_text" runat="server" Text="Date:"></asp:Label><asp:Label ID="lab_receivedate" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <hr />
        </div>
        <div class="row" id="grid">
            <div class="row">
                <div class="col-md-6">
                    <h2>Unfulfilleditems:</h2>
                </div>
                <div class="col-md-6">
                    <h2>Requisition form</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4  text-center">
                    <asp:GridView ID="UnfulfillitemGridView" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" AllowPaging="True" PageSize="25" OnPageIndexChanging="UnfulfillitemGridView_PageIndexChanging" DataKeyNames="Item_code" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="500px">
                        <Columns>
                            <asp:BoundField DataField="Item_code" HeaderText="Item_code" Visible="false"/>
                            <asp:BoundField DataField="Name" HeaderText="Category" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="Reason" HeaderText="Reason" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="AddItem" runat="server" OnClick="AddItem_Click" CssClass="btn btn-default">Add</asp:LinkButton>
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
                <div class="col-md-2">
                        <asp:Button ID="AddAll" runat="server" Text="AddAll" OnClick="AddAll_Click" CssClass="btn btn-primary" />
                </div>
                 <div class="col-md-6">
                        <asp:GridView ID="OriginalrequisitionGridView" AutoGenerateColumns="False" AllowPaging="True" PageSize="26" OnPageIndexChanging="OriginalrequisitionGridView_PageIndexChanging" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="367px">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Category" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
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
        <div class="row text-center navbar-fixed-middle">
                <asp:Button ID="OK" runat="server" Text="OK" OnClick="OK_Click" CssClass="btn btn-primary" Width="125px"/>           
        </div>
    </form>
</asp:Content>
