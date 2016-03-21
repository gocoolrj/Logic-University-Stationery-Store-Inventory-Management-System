<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="AddNewDiscrepancy.aspx.cs" Inherits="logicuniversity.Views.AddNewDiscrepancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    

    <div class="col-lg-12">

        <div class="row">
            <div class="col-lg-12">
                    <h2 class="page-header">Add new discrepancy</h2>
            </div>
        </div>
        <br />

        <div class ="row">
            <div class="col-lg-1">
                Item :
             </div>  
            <div class ="col-lg-4">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" CssClass="btn btn-default dropdown-toggle" Width="300px"></asp:DropDownList>
            </div>
        </div>
        <br/>
       <%-- <div class ="row">
            <div class="col-lg-1">
                Department :
             </div>  
            <div class ="col-lg-4">
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" CssClass="btn btn-default dropdown-toggle" Width="300px"></asp:DropDownList>
            </div>
        </div--%>
        <br/>
        <div class ="row">
            <div class="col-lg-1">
                Quantity :
             </div>  
            <div class ="col-lg-4">
                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
            </div>
        </div>
        <br/>
        <div class ="row">
            <div class="col-lg-1">
                Remark :
             </div>  
            <div class ="col-lg-4">
                 <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </div>
        </div>
        <br/>

        <div class="row">            
            <div class="col-lg-1">
                <asp:Button ID="Button2" runat="server" Text="Add to list" OnClick="Button2_Click" class="btn btn-primary" />
             </div> 
            </div>

        <br />

        <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
        <br />
        <br />

        <div class="row">            
            <div class="col-lg-1">
                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" class="btn btn-primary" Visible="false" />
             </div> 
            </div>
       
        
    </div>
    
    </form>
</asp:Content>
