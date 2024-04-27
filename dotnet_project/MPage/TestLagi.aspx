<%@ Page Title="" Language="C#" MasterPageFile="~/MPage/MPage.Master" AutoEventWireup="true" CodeBehind="TestLagi.aspx.cs" Inherits="dotnet_project.MPage.TestLagi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Enter number of elements:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Generate Fibonacci" OnClick="Button1_Click" />
    </p>
</asp:Content>

