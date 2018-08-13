<%@ Page Title="Employee Pay Slip" Language="C#" MasterPageFile="~/Master/BlankMaster.master"
    AutoEventWireup="true" CodeFile="frmPaySlip.aspx.cs" Inherits="Pages_Admin_frmPaySlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="center">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="litReport" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
