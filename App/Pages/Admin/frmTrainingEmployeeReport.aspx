<%@ Page Title="Training Employee Detail" Language="C#" MasterPageFile="~/Master/BlankMaster.master" AutoEventWireup="true" CodeFile="frmTrainingEmployeeReport.aspx.cs" Inherits="Pages_Admin_frmTrainingEmployeeReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="center">
<tr><td><asp:Label ID="lblmsg" runat="server"></asp:Label></td></tr>
<tr><td><asp:Literal ID="litReport" runat="server"></asp:Literal></td></tr>
</table>
</asp:Content>

