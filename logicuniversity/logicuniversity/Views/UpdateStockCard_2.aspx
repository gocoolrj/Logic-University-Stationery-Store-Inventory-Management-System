<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/clerk.master" AutoEventWireup="true" CodeBehind="UpdateStockCard_2.aspx.cs" Inherits="logicuniversity.Views.UpdateStockCard_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <h1>Stock Card Details</h1>
    <form ID="form1" runat="server">
        Item Description: 
        <asp:label id="label1" runat="server" Text="Item Description: "/>
        <br>
        UOM: 
        <asp:Label ID="Label2" runat="server" Text="UOM: "></asp:Label>
        <br>
        Stock Level: 
        <asp:label ID="Label3" runat="server" Text="Stock Level: "></asp:label>
        <br>
        <h2>Stock Card</h2>
        <br>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="false">
            <Columns>
                <asp:BoundField datafield="date" HeaderText ="Date" DataFormatString = "{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="s_description" HeaderText="Dept/Supplier" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            </Columns>
        </asp:GridView>
        <br>
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
        <br />
    </form>
    
</asp:Content>
