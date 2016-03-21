<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/manager.master" AutoEventWireup="true" CodeBehind="ConfirmAdjVouDbymgr.aspx.cs" Inherits="logicuniversity.Views.ConfirmAdjVouDbymgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">   
    <form id="form1" runat="server">
        <asp:Label ID="lblVouNo" runat="server" Text="Voucher No. : "></asp:Label>
        <br />
        <asp:Label ID="lblDateIssue" runat="server" Text="Date Issue : "></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvInvAdjD" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Item Code" DataField="item_code" />
                <%--<asp:BoundField HeaderText="Description" DataField="" />--%>
                <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                <asp:BoundField HeaderText="Reason" DataField="reason" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />
    </form>
</asp:Content>
