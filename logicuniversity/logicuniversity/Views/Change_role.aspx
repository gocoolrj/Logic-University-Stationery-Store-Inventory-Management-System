<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/representative.master" AutoEventWireup="true" CodeBehind="Change_role.aspx.cs" Inherits="logicuniversity.Views.Change_role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">


    <form id="form1" runat="server">


    <table class="nav-justified">
        <tr>
            <td>Employee ID</td>
             <td>
                <asp:Label ID="IDLbl" runat="server"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>Employee Name</td>
            <td>
                <asp:Label ID="NameLbl" runat="server"></asp:Label>
            </td>
    
        </tr>
        <tr>
            <td>Role</td>
            <td>
                <asp:DropDownList ID="roleid" runat="server" Height="20px" Width="150px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
        <br />
        <br />



      
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
       



      
        <asp:Button ID="Button1" runat="server" Text="Change" OnClick="Button1_Click" />
    
       



      
    </form>


</asp:Content>
