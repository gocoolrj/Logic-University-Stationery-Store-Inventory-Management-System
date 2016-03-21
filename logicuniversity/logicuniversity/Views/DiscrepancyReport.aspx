<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="DiscrepancyReport.aspx.cs" Inherits="logicuniversity.Views.DiscrepancyReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="discrepancyReportForm" runat="server">
    <div class="col-lg-12">

            <div class="row">
                <div class ="col-lg-12">
                <h1 class="page-header">Discrepancy Report</h1>
                    </div>
            </div>
        <br/>
            <div class="row">
                <div class ="col-lg-6">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="156px" Width="390px">
                        <Columns>
                            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="Voucher_id" HeaderText="Voucher#" />
                            <asp:BoundField DataField="Emp_name" HeaderText="Supervisor" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("Voucher_id") %>' OnCommand="LinkButton2_OnCommand" Text="View"/>
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
                <div class="col-lg-3">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Add new discrepancy</asp:LinkButton></div>
                </div>
            </div>
    
        
    </form>

    
</asp:Content>
