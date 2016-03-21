<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/employee.master" AutoEventWireup="true"  CodeBehind="DisplayID.aspx.cs" Inherits="logicuniversity.Views.DisplayID"  %>
<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>

       <form id="form1" runat="server">
    <div class="auto-style1">
    <asp:Label ID="Message" runat="server" Text="Sucessfully Created New Employee" Font-Size="XX-Large"> </asp:Label>
        <br />
        <br />
        <asp:Label ID="Display" runat="server" Text="Employee ID Is :" Font-Size="X-Large"></asp:Label>   
   
    &nbsp;&nbsp;&nbsp;   
        <asp:Label ID="EmpID" runat="server"  Font-Size="X-Large"></asp:Label>
   
    </div>
    </form>
</asp:Content>
