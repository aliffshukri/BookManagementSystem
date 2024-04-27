<%@ Page Title="" Language="C#" MasterPageFile="~/MPage/MPage.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="dotnet_project.MPage.info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            margin-left: 0px;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            width: 199px;
        }
        .auto-style8 {
            width: 199px;
            height: 26px;
        }
        .auto-style9 {
            width: 325px;
        }
        .auto-style10 {
            height: 26px;
            width: 325px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center;">Add Library Item</h2>
    <br />

    <table class="wrapper">
        <tr>
            <td class="auto-style9">&nbsp;</td>
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
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7"><label for="TextBox1">Title:</label></td>
            <td><asp:TextBox ID="TextBox1" runat="server" Width="177px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style8"><label for="TextBox2">Author:</label></td>
            <td class="auto-style6"><asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style3" Width="177px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style8"><label for="TextBox3">Publisher:</label></td>
            <td class="auto-style6"><asp:TextBox ID="TextBox2" runat="server" Width="177px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7"><label for="TextBox4">Year Published:</label></td>
            <td><asp:TextBox ID="TextBox4" runat="server" Width="177px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7"><label for="TextBox5">ISBN:</label></td>
            <td><asp:TextBox ID="TextBox5" runat="server" Width="177px" placeholder="e.g., XXX-XXX-XXXXX-X"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7"><label for="TextBox6">Quantity:</label></td>
            <td><asp:TextBox ID="TextBox6" runat="server" Width="177px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">
                <asp:Button ID="Button1" runat="server" Text="SAVE" OnClick="Button1_Click" Width="174px" /></td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="CLEAR" OnClick="Button2_Click" Width="174px" /></td>
        </tr>
    </table>
</asp:Content>

