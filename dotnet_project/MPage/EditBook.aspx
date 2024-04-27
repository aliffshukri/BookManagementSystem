<%@ Page Title="" Language="C#" MasterPageFile="~/MPage/MPage.Master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="dotnet_project.MPage.InfoStationary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
        .auto-style2 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><strong>Edit Library Book Info</strong></h2>
    <br />

    <table class="wrapper">
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"><label for="TextBox5">ISBN:</label></td>
            <td class="auto-style2"><asp:TextBox ID="TextBox5" runat="server" Width="177px" placeholder="XXX-XXX-XXXXX-X"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get" Width="83px" />
                &nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Clear" Width="83px"/>
            &nbsp;</td>
        </tr>
      <tr>
        <td>&nbsp;</td>
        <td class="auto-style7"><label for="DropDownList1">Type of book :</label></td>
        <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="course-dropdown" Height="31px" Width="177px">
            <asp:ListItem Text="Select a Type" Value="" />
            <asp:ListItem Text="Journal" Value="Journal" />
            <asp:ListItem Text="Novel" Value="Novel" />
            <asp:ListItem Text="Comic" Value="Comic" />
            <asp:ListItem Text="Thesis" Value="Thesis" />
            <asp:ListItem Text="Fiction" Value="Fiction" />
            <asp:ListItem Text="Non-Fiction" Value="Non_Fiction" />
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style7"><label for="TextBox1">Title:</label></td>
        <td><asp:TextBox ID="TextBox1" runat="server" Width="177px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style6"></td>
        <td class="auto-style8"><label for="TextBox2">Author:</label></td>
        <td class="auto-style6"><asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style3" Width="177px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style6"></td>
        <td class="auto-style8"><label for="TextBox3">Publisher:</label></td>
        <td class="auto-style6"><asp:TextBox ID="TextBox2" runat="server" Width="177px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style7"><label for="TextBox4">Year Published:</label></td>
        <td><asp:TextBox ID="TextBox4" runat="server" Width="177px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style7"><label for="TextBox6">Quantity:</label></td>
        <td><asp:TextBox ID="TextBox6" runat="server" Width="177px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style1"></td>
        <td class="auto-style1"></td>
        <td class="auto-style1"></td>
    </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" Width="83px" />&nbsp;
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" Width="83px" />&nbsp;
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Search" Width="83px" />&nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                    <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                    <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectDBConnectionString %>" SelectCommand="SELECT * FROM [Book]"></asp:SqlDataSource>
    <br />
    <div>

    </div>

</asp:Content>
