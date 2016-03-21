<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/manager.master" AutoEventWireup="true" CodeBehind="ConfirmAdjVoubymgr.aspx.cs" Inherits="logicuniversity.Views.ConfirmAdjVoubymgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Larger" Text="Confirm Adjustment Voucher"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvAdjVou" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAdjVou_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Voucher No." DataField="voucher_id" />
                <asp:BoundField HeaderText="Date Issue" DataField="date_issue" />
                <asp:BoundField HeaderText="Amount" DataField="total" />
                <asp:BoundField HeaderText="Status" DataField="status" />
                <asp:ButtonField HeaderText="Details" CommandName="select" Text="Details" />
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
