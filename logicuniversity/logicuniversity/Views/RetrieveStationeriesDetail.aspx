<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="RetrieveStationeriesDetail.aspx.cs" Inherits="logicuniversity.Views.RetrieveStationeries1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">

         <div class="col-lg-12">

                <div class="row">
                    <div class="col-lg-12">
                            <h2 class="page-header">Breakdown by department</h2>
                    </div>
                </div>
        <br />
             <!--<div class="row">
                    <div class="col-lg-1">
                            From Date :
                    </div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>

                </div>
             <br/>
             <div class="row">
                    <div class="col-lg-1">
                            To Date :
                    </div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                    </div>

                </div>
             <br/>-->
             <div class="row">
                    <div class="col-lg-1">
                            Description :
                    </div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>

             <br/>
             <div class="row">
                    <div class="col-lg-1">
                            Total Quantity :
                    </div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </div>

                </div>
              <br/>
             <div class="row">
                    <div class="col-lg-1">
                            Available Quantity:
                    </div>
                    <div class="col-lg-8">                      
                       <input id="input1" type="number" class="form-control" runat="server"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="input1" runat="server" ForeColor="Red" ErrorMessage="Please enter Acutal Amount"></asp:RequiredFieldValidator>
                    </div>

                </div>

             <br/>
             <div class="row">
                    <div class="col-lg-3">
                            <asp:Button ID="Button2" runat="server" Text="dispatch" OnClick="Button2_Click" CssClass="btn btn-primary" />
                    </div>
                <br />
                 <br />
                 <br />     

                </div>

             <div class="row">
                 <div class="col-lg-6">
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="description" HeaderText="Description" visible="false"/>
                    <asp:BoundField DataField="dept_name" HeaderText="Department" />
                    <asp:BoundField DataField="dept_id" HeaderText="DEPT_ID"/>
                    <asp:BoundField DataField="quantity" HeaderText="Needed" />
                    <asp:TemplateField HeaderText="Actual">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>                  
                    <asp:BoundField DataField="unfulfilled" HeaderText="Unfulfilled" />
                </Columns>
            </asp:GridView> 
                 </div>
             </div>
             <br/>
             
        <div class="row">
            <div class="col-lg-3">
                 <a href="RetrieveStationeries.aspx">Back</a>
            </div>
        </div>
        <br/>
         <div class="row">
                    <div class="col-lg-3">
                            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click1" CssClass="btn btn-primary" />
                    </div>
                  

                </div>


</div>
   
    </form>
</asp:Content>
