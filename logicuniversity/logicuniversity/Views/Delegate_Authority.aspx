<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/head.master" AutoEventWireup="true" CodeBehind="Delegate_Authority.aspx.cs" Inherits="logicuniversity.Views.Delegate_Authority" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server" >
        <div>
     <label>Start date</label>
             <asp:TextBox ID="TextBox1" runat="server" type="Date" required="true"></asp:TextBox>
            <%-- <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calender.jpg" Height="30px" Width="30px" OnClick="ImageButton1_Click" ></asp:ImageButton>
             <asp:Calendar ID="Calendar1" runat="server" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged" ></asp:Calendar>--%>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*RequiredField" ForeColor="Red" ControlToValidate="TextBox1" Visible="False"></asp:RequiredFieldValidator>
    </div> 
        
        &nbsp&nbsp&nbsp&nbsp
    <div> 
  
   <label>End date</label>     
        <asp:TextBox ID="TextBox2" runat="server" type="Date" required="true"></asp:TextBox> 
        <%--<asp:ImageButton runat="server" ImageUrl="~/Images/calender.jpg" Height="30px" Width="30px" OnClick="Unnamed1_Click" ></asp:ImageButton>  
        <asp:Calendar ID="Calendar2" runat="server" Visible="False" OnSelectionChanged="Calendar2_SelectionChanged" ></asp:Calendar>--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*RequiredField" ForeColor="Red" ControlToValidate="TextBox2" Visible="False"></asp:RequiredFieldValidator>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button"  Visible="false"/>
        </div>
     &nbsp&nbsp&nbsp&nbsp
     <div style="height: 318px">
        
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged">
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /> 
            <Columns>
                <asp:BoundField HeaderText="Emp ID" DataField="emp_id" />
                <asp:BoundField HeaderText="Employee Name" DataField="emp_name" />
                <asp:BoundField HeaderText="EmployeePosition" DataField="role1" />
                <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30"  />
            </Columns>
        </asp:GridView>
          <asp:Label ID="Label1" CssClass="h3" runat="server" Text="Do you want to delegate your authority to this employee?" Visible="false"></asp:Label>
 
        <div><asp:Label ID="label2" runat="server" Text="Employee Id:" Visible="false"></asp:Label> <asp:Label ID="labelEmployeeID" runat="server" Visible="true"></asp:Label></div>
    <div><asp:Label ID="Label4" runat="server" Text="Employee Name:" Visible="false"></asp:Label> <asp:Label ID="labelEmployeeName" runat="server" Visible="true"></asp:Label></div>
   <div><asp:Label ID="Label5" runat="server" Text="Email Address:" Visible="false"></asp:Label> <asp:Label ID="labelEmailAddress" runat="server" Visible="true"></asp:Label></div>
     
    <div> <asp:Button ID="BtnYes" runat="server" Text="Yes" Visible="false" OnClick="BtnYes_Click" OnClientClick="" />  <asp:Button ID="BtnNo" runat="server" Text="No" Visible="false" OnClick="BtnNo_Click" /></div>      
       </div>
      <div>




      </div>  
 </form>

</asp:Content>