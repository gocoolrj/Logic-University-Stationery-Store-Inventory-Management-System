<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/supervisor.master" AutoEventWireup="true" CodeBehind="RequisitionTrendReportByCatg.aspx.cs" Inherits="logicuniversity.Views.RequisitionTrendReportByCatg" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
    <CR:CrystalReportViewer ID="crpt" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
        </form>
</asp:Content>
