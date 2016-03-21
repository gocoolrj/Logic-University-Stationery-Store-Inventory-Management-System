<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/representative.master" AutoEventWireup="true" CodeBehind="ViewReceiveList.aspx.cs" Inherits="logicuniversity.Views.ViewReceiveList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="col-lg-12">

          <div class="row">
                <div class="col-lg-12">
                        <h2 class="page-header">Requisition List</h2>
                </div>
           </div>


            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                        <asp:GridView ID="gvReceiveStationeriesList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="256px" Width="531px">
          
            <Columns>
                <asp:BoundField DataField="Req_Dept_Id" HeaderText="Reqisition ID" />
                <asp:BoundField DataField="Emp_name" HeaderText="Employee Name" />
                <asp:BoundField DataField="Date" HeaderText="Request Date" />
                <asp:TemplateField HeaderText="Detail">
                    <ItemTemplate>

                            <asp:LinkButton Id="LinkButtonDetail" runat="server" OnCommand="commandLinkView" CommandArgument='<%#Eval("Req_Dept_Id")%>' OnClick="LinkButtonDetail_Click">ViewDetail</asp:LinkButton>
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


        </div>
       
    </form>
</asp:Content>
