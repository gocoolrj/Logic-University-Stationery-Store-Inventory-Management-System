<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="UpdateStockCard_3.aspx.cs" Inherits="logicuniversity.Views.UpdateStockCard_3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
       
         <div class="col-lg-12">

        <div class="row">
            <div class="col-lg-12">
                    <h2 class="page-header">Update Stock Card</h2>
            </div>
        </div>
        <br />

        <div class ="row">
            <div class="col-lg-1">
                Date :
             </div>  
            <div class ="col-lg-4">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" type="Date" Width="250px"></asp:TextBox>
            </div>
        </div>
        <br/>


             <div class ="row">
            <div class="col-lg-1">
                Dept/Supplier :
             </div>  
            <div class ="col-lg-4">
              <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
            </div>
        </div>
             <br/>
             <div class ="row">
            <div class="col-lg-1">
                Quantity :
             </div>  
            <div class ="col-lg-4">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Width="100px" type="text"></asp:TextBox>
            </div>
        </div>
             <br/>
             <div class ="row">
            
            <div class ="col-lg-4">
                 <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" CssClass="btn btn-primary"/>
            </div>
        </div>
             </div>

        
    </form>
</asp:Content>
