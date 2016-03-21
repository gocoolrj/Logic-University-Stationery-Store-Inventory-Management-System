<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/employee.master" AutoEventWireup="true" CodeBehind="employee_home.aspx.cs" Inherits="logicuniversity.Views.employee_home" %>
<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">
                <small> Welcome</small> <asp:Label ID="lblName" runat="server"></asp:Label>
            </h1>
            
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            
        </div>
    </div>
    </form>
</asp:Content>
