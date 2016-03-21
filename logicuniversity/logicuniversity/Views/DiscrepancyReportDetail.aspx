<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="DiscrepancyReportDetail.aspx.cs" Inherits="logicuniversity.Views.DiscrepancyReportDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div>
            <h2>Discrepancy Detail</h2>
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="reason" HeaderText="Reason" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <a href="javascript: history.go(-1)">Go Back</a>
    </form>
</asp:Content>
