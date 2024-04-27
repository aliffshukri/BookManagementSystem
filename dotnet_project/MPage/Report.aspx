<%@ Page Title="" Language="C#" MasterPageFile="~/MPage/MPage.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="dotnet_project.MPage.Report" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ValidateRequestMode="Disabled">
    <asp:Button ID="Button1" runat="server" Text="View Library Book Report" OnClick="Button1_Click" />
    <asp:ScriptManager ID ="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1100"></rsweb:ReportViewer>
</asp:Content>
