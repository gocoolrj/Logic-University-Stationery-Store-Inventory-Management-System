<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="Create_Employee_Profile.aspx.cs" Inherits="logicuniversity.Views.Create_Employee_Profile" %>
<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">

  
             <form id="form1" runat="server">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
    
<asp:Label ID="Employee" runat="server" align="Center" Text="Create New Employee" Font-Size="X-Large"></asp:Label>
        <br /><br /><br />
                  <div style="height: 318px">
            <table id="Table1" class="auto-style1" align="center" border="1" style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: normal; font-style: normal; font-variant: normal; text-transform: none; color: #000000; height: 186px; width: 586px;" >
                      
                <tr>
                    <td>Employee Name</td>
                    <td style="width: 360px">
                        <asp:TextBox ID="empnameid" runat="server" Height="20px" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NameField" runat="server" ControlToValidate="empnameid" ErrorMessage="*" ForeColor="Red" ValidationGroup="Create" Visible="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email Address</td>
                    <td style="width: 360px">
                        <asp:TextBox ID="empmailid" runat="server" Height="20px" TextMode="Email" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="MailField" runat="server" ControlToValidate="empmailid" ErrorMessage="*" ForeColor="Red" ValidationGroup="Create" Visible="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="CheckMail" runat="server" ControlToValidate="empmailid" ErrorMessage="Enter Valid Mail Id" ForeColor="Red"  ValidationGroup="Create" Visible="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Employee Role</td>
                    <td style="width: 360px">
                        <asp:DropDownList ID="roleid" runat="server" Height="20px" Width="150px" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </td>
                   
                </tr>
                <tr>
                    <td style="height: 25px">Department ID</td>
                    <td style="height: 25px; width: 360px;">
                        <asp:DropDownList ID="deptid" runat="server" Height="20px" Width="150px" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </td>
                

                </tr>
                <tr>
                    <td style="height: 121px">Password</td>
                    <td style="width: 360px; height: 121px">
                        <asp:TextBox ID="passwordid" runat="server" Height="20px" TextMode="Password" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordField" runat="server" ControlToValidate="passwordid" ErrorMessage="*" ForeColor="Red" ValidationGroup="Create" Visible="false"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <br />
            <br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Create" runat="server" OnClick="Create_Click" Text="Create" ValidationGroup="Create" />
            
       


          
    </div>
    </form>

</asp:Content>
