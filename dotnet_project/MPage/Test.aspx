<%@ Page Title="" Language="C#" MasterPageFile="~/MPage/MPage.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="dotnet_project.MPage.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 196px;
        }
        .auto-style2 {
            width: 196px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            width: 168px;
        }
        .auto-style5 {
            width: 168px;
            height: 23px;
        }
        .auto-style6 {
            width: 219px;
        }
        .auto-style7 {
            width: 219px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Customer Feedback</h2>
    <br />
    <table class="w-100">
        <tr>
            <td class="auto-style1">Feedback ID:</td>
            <td class="auto-style4">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">Must enter feedback ID</td>
            <td>Invalid feedback ID</td>
        </tr>
        <tr>
            <td class="auto-style2">Room Type</td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                <asp:ListItem Text="Family" Value="Family"></asp:ListItem>
                <asp:ListItem Text="Luxury" Value="Luxury"></asp:ListItem>
                <asp:ListItem Text="Suite" Value="Suite"></asp:ListItem>
            </asp:DropDownList>
            </td>
            <td class="auto-style7"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style2">E-mail:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">Must enter e-mail</td>
            <td class="auto-style3">Invalid e-mail format</td>
        </tr>
        <tr>
            <td class="auto-style2">Phone Number:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">Must enter phone number</td>
            <td class="auto-style3">Invalid phone number</td>
        </tr>
        <tr>
            <td class="auto-style1">Customer Satisfaction:</td>
            <td class="auto-style4">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem Text="Excellent" Value="Excellent"></asp:ListItem>
                <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                <asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
                <asp:ListItem Text="Horrible" Value="Horrible"></asp:ListItem>
            </asp:CheckBoxList>
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
