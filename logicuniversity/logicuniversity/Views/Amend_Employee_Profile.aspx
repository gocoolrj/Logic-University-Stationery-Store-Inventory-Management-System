<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="Amend_Employee_Profile.aspx.cs" Inherits="logicuniversity.Views.Amend_Employee_Profile" %>
<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>

    <form id="form1" runat="server">
    <div>
          &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Role : <asp:DropDownList ID="getrole" runat="server"  align="center"  Height="20px" Width="150px" AppendDataBoundItems="true" OnSelectedIndexChanged="getrole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        Employee ID:  <asp:TextBox ID="SearchBox" runat="server"  align="center" Height="20px" Width="150px"></asp:TextBox>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />

         <asp:Panel ID="ViewList" runat="server" Visible="false">

             
        <br />
        <br />
        <br />
        <br />
             <div class="auto-style1">
                 <asp:GridView ID="GridView1" runat="server"  align="center" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="true"
                     border="1" style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: lighter; font-style: normal" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         <asp:BoundField DataField="emp_id" HeaderText="Emp ID" />
                         <asp:BoundField DataField="emp_name" HeaderText="Employee Name" />
                         <asp:BoundField DataField="emp_email" HeaderText="Employee Mail" />
                         <asp:BoundField DataField="role_id" HeaderText="Employee Role" />
                         <asp:BoundField DataField="dept_id" HeaderText="Depatment ID" />
                         <asp:BoundField DataField="emp_password" HeaderText="Employee Password" />
                         <asp:ButtonField CommandName="Select" ItemStyle-Width="30" Text="Select">
                         <ItemStyle Width="30px" />
                         </asp:ButtonField>
                     </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                 </asp:GridView>
             </div>
        </asp:Panel>

         <br />
        <br />
        <br />
        <asp:Panel ID="AmendEmp" runat="server" Visible="false">

            <table class="auto-style1"  align="center" border="1" style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: lighter; font-style: normal">
            <tr>
                <td>Employee ID</td>
                <td>
                    <asp:Label ID="EmpID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Employee Name</td>
                <td>
                    <asp:TextBox ID="EmpName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Employee Email</td>
                <td>
                    <asp:TextBox ID="EmpEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Role ID</td>
                <td>
                    <asp:DropDownList ID="EmpRole" runat="server" Height="20px" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                
            </tr>
            <tr>
                <td>Department ID</td>
                <td>
                     <asp:DropDownList ID="Dept" runat="server"  Height="20px" Width="150px">
                     </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Employee Password</td>
                <td>
                    <asp:TextBox ID="EmpPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
         
        </table>
        
        
        <br />
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="UpdateEmployee" runat="server" align="center" Text="Update" OnClick="UpdateEmployee_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DeleteEmployee" runat="server" align="center" Text="Delete" OnClick="DeleteEmployee_Click" />
        <br />
        </asp:Panel>
    
    
    </div>
    </form>
</asp:Content>
