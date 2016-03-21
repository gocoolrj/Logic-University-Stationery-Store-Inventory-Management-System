<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="delegatesucc.aspx.cs" Inherits="logicuniversity.Views.delegatesucc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="deleg" runat="server">
  <div>
        <asp:Label ID="Label1" runat="server" Text="You have delegated your authority succesfully to"></asp:Label><asp:Label ID="LblEmplname" runat="server" Text=""></asp:Label>


    </div>
<div>
     <asp:Label ID="LblFromDatetext" runat="server" Text=" From:"></asp:Label> <asp:Label ID="LblFrmDate" runat="server" Text=""></asp:Label>
     
</div>
        <div>
            <asp:Label ID="LblToDateText" runat="server" Text="To:"></asp:Label> <asp:Label ID="LblToDate" runat="server" Text=""></asp:Label>


        </div>

<div>
    <asp:Button ID="BtnUndelegate" runat="server" Text="Undelegate" OnClick="BtnUndelegate_Click" />  <asp:Button ID="BtnOk" runat="server" Text="Ok" OnClick="BtnOk_Click" />
</div>
    </form>
</asp:Content>
