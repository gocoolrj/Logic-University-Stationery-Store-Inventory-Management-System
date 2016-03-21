<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/supervisor.master" AutoEventWireup="true" CodeBehind="generateRequisitionTrend.aspx.cs" Inherits="logicuniversity.Views.generateRequisitionTrend" %>


<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
         <div class="row">
            <div class="col-lg-12">
                    <h2 class="page-header"> Requisiton Trend Report</h2>
            </div>
        </div>
        <br />
    <div class="row">
        <div class="col-lg-12">
            <div class="col-lg-2">
                <asp:RadioButton ID="rdoDept" runat="server" GroupName="rdoGroup" Text="Compare by Department" class="radio" AutoPostBack="True" Checked="True" OnCheckedChanged="rdoDept_CheckedChanged"/>
                 <asp:RadioButton ID="rdoCategory" runat="server" GroupName="rdoGroup" Text="Compare by Item Category" class="radio" AutoPostBack="True" OnCheckedChanged="rdoCategory_CheckedChanged"  />
                 <asp:RadioButton ID="rdoCatalogue" runat="server" GroupName="rdoGroup" Text="Compare by Each Item" class="radio" AutoPostBack="True" OnCheckedChanged="rdoCatalogue_CheckedChanged" Visible="False"  />
            </div>
        </div>
    </div>

    <br/>
    <br/>

    <div class="row">
        <div class="col-lg-12">
          

             <div class="col-lg-2">
                     <asp:DropDownList ID="ddl" Width="200px" runat="server" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>

            
              
                
            <div class="col-lg-2">
                     <asp:DropDownList ID="ddlCatalogue" runat="server" Visible="False"  Width="200px" CssClass="btn btn-default dropdown-toggle" ></asp:DropDownList>
                </div>
        </div>
     </div>
        <br/>
        <br/>
        <div class ="row"> 
            <div class="col-lg-12">         
                <div class="col-lg-2">
                    
                        
                        <asp:DropDownList ID="ddlmonth1" runat="server" AutoPostBack="True" CssClass="btn btn-default dropdown-toggle">
                        </asp:DropDownList>
                        
                   
                        <asp:DropDownList ID="ddlyear1" runat="server" CssClass="btn btn-default dropdown-toggle">
                        </asp:DropDownList>
                        
                </div>
                <div class="col-lg-2">
                    <asp:CheckBox ID="chk2" runat="server" AutoPostBack="True" OnCheckedChanged="chk2_CheckedChanged" />
                        <asp:DropDownList ID="ddlmonth2" runat="server" AutoPostBack="True" CssClass="btn btn-default dropdown-toggle" Enabled="False">
                        </asp:DropDownList>
                        
                   
                        <asp:DropDownList ID="ddlyear2" runat="server" CssClass="btn btn-default dropdown-toggle" Enabled="False">
                          
                        </asp:DropDownList>
                        
                </div>
                <div class="col-lg-2">
                    <asp:CheckBox ID="chk3" runat="server" AutoPostBack="True" OnCheckedChanged="chk3_CheckedChanged" />
                        <asp:DropDownList ID="ddlmonth3" runat="server" AutoPostBack="True" CssClass="btn btn-default dropdown-toggle" Enabled="False">
                        </asp:DropDownList>
                        
                   
                        <asp:DropDownList ID="ddlyear3" runat="server" CssClass="btn btn-default dropdown-toggle" Enabled="False">
                        </asp:DropDownList>
                        
                </div>

           </div>



        </div>
        <br/>
        <br/>

        <div class ="row">
            <div class="col-lg-12">
                <div class="col-lg-2">
                <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" class="btn btn-primary" OnClick="btnRetrieve_Click" />
                   </div>
             </div>
        </div>
        <br/>
        <br/>

         <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-6">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>  
                            </div>
                            <div class="panel-body">
                                <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="dept_name" HeaderText="Department" ItemStyle-Width="150px"/>
                                        <asp:BoundField DataField="name" HeaderText="Category" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="item_code" HeaderText="Item Code" ItemStyle-Width="100px"/>
                                        <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="200px"/>
                                        <asp:BoundField DataField="req_quantity" HeaderText="Quantity" /> 
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                        </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Width="0px" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>                
                </div>
            </div>

        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-6">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                 <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="panel-body">
                                <asp:GridView ID="gv2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="dept_name" HeaderText="Department" ItemStyle-Width="150px"/>
                                        <asp:BoundField DataField="name" HeaderText="Category" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="item_code" HeaderText="Item Code" ItemStyle-Width="100px"/>
                                        <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="200px"/>
                                        <asp:BoundField DataField="req_quantity" HeaderText="Quantity" /> 
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                        </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Width="0px" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>                
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-6">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="panel-body">
                                <asp:GridView ID="gv3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="dept_name" HeaderText="Department" ItemStyle-Width="150px"/>
                                        <asp:BoundField DataField="name" HeaderText="Category" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="item_code" HeaderText="Item Code" ItemStyle-Width="100px"/>
                                        <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="200px"/>
                                        <asp:BoundField DataField="req_quantity" HeaderText="Quantity" /> 
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                        </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Width="0px" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>                
                </div>
            </div>
        </asp:Panel>
        

    <div class ="row">
            <div class="col-lg-12">
                <div class="col-lg-2">
                    <asp:Button ID="btnPrint" runat="server" Text="Generate" OnClick="btnPrint_Click" class="btn btn-primary"/>
                   </div>
             </div>
        </div>
        </form>
</asp:Content>
