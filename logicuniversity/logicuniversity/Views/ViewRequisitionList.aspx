<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/employee.master" AutoEventWireup="true" CodeBehind="ViewRequisitionList.aspx.cs" Inherits="logicuniversity.Views.ViewRequisitionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
   <form id="listform1" runat="server">
       <div class="row container-fluid">
           <div class="col-md-3"></div>
           <div class="row">
           <div class="col-md-6" style="background-color:lightgray">
               <div class="col-md-5">
                   <asp:Label ID="Label1" runat="server" Text="Start time:  "></asp:Label><asp:TextBox ID="startdate" runat="server" type="date" Text=""></asp:TextBox>
               </div>
               <div class="col-md-5">
                   <asp:Label ID="Label2" runat="server" Text="End time:  "></asp:Label><asp:TextBox ID="enddate" runat="server" type="date" Text=""></asp:TextBox>
               </div>
               <div class="col-md-2">
                   <asp:LinkButton ID="reqSearch" runat="server" OnClick="reqSearch_Click" Font-Size="XX-Large"><span class="glyphicon glyphicon-search"></span></asp:LinkButton> 
               </div>                                                                                                     
           </div>
           </div>
           <div class="row text-center">
               <asp:Label ID="errmessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
           </div>
           <div class="col-md-3"></div>            
       </div>
       <div class="row container-fluid">
           <div class="col-md-3">
               
            </div>
           <div class="col-md-6">
               <asp:ListView ID="reqlistview" runat="server" OnSelectedIndexChanging="reqlistview_SelectedIndexChanging">
                   <LayoutTemplate>
                       <table runat="server" id="reqlist" class="table table-hover">
                           <tr runat="server" id="itemPlaceholder"></tr>
                       </table>
                   </LayoutTemplate>
                   <ItemTemplate>
                       <tr runat="server" id="basicinfo">
                           <td class="text-left col-md-6">
                               <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">
                                   <div class="col-md-6">
                                       <asp:Label ID="reqDate_text" runat="server" Text="Request Time: "></asp:Label> <asp:Label ID="reqId" runat="server" Visible="false" Text='<%#Eval("Req_id") %>'>"></asp:Label>
                                       <br />
                                       <asp:Label ID="reqDate" runat="server" Text='<%#Eval("Req_date") %>'>'></asp:Label>
                                   </div>
                                   <div class="col-md-6">
                                        <asp:Label ID="status_text" runat="server" Text="Status"></asp:Label>
                                   <br />
                                   <asp:Label ID="status" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                   </div>
                               </asp:LinkButton>                             
                           </td>
                       </tr>
                   </ItemTemplate>
                   <SelectedItemTemplate>
                       <tr runat="server" id="basicinfo">
                           <td class="text-left col-md-4">
                               <asp:Label ID="reqDate_text" runat="server" Text="Request Time: "></asp:Label> <asp:Label ID="reqId" runat="server" Visible="false" Text='<%#Eval("Req_id") %>'>"></asp:Label>
                               <br />
                               <asp:Label ID="reqDate" runat="server" Text='<%#Eval("Req_date") %>'>'></asp:Label>
                           </td>
                           <td class="text-left col-md-2">
                               <asp:Label ID="status_text" runat="server" Text="Status"></asp:Label>
                               <br />
                               <asp:Label ID="status" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                           </td>
                       </tr>
                   </SelectedItemTemplate>
               </asp:ListView>
           </div>
           <div class="col-md-3">
               
           </div>
       </div>
   </form>
</asp:Content>
