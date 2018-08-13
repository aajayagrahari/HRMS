<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    CodeFile="frmCircularMaster.aspx.cs" Inherits="Pages_Admin_frmCircularMaster1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lblPageHeading" runat="server" Text="Circular Master" CssClass="pageHeading"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" align="center">
                    <tr>
                        <td align="left" valign="top" style="width :15%">
                            <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="Label"></asp:Label>
                        </td>
                        <td align="left" valign="top" style="width :85%">
                            <asp:TextBox ID="txt_title" runat="server" Width="600"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width :15%">
                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="Label"></asp:Label>
                        </td>
                        <td align="left" valign="top" style="width :85%">
                            <cc1:Editor ID="edt_descripion" Height="300" Width="600" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" colspan="2">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
