<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="ListOfVacancy.aspx.cs" Inherits="Pages_Universal_ListOfVacancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lbl_heding" runat="server" CssClass="pageHeading" Text=" List Of Vacancy"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label>
                <asp:Repeater ID="rpt_vacancy" runat="server">
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td valign="top" align="left">
                                    <div style="width: 730px; word-wrap: break-word;">
                                        <b>
                                            <%# Eval("Title") %></b>
                                    </div>
                                </td>
                                <td valign="top" align="left">
                                    <b>Posted Date</b> &nbsp;
                                    <%# Eval("CreatedDate") %>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" colspan="2" style="border-bottom: 1px solid #ddd;">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left">
                                    <div style="width: 730px; word-wrap: break-word;">
                                        <%# Eval("Description") %>
                                </td>
                                </div>
                                <td valign="bottom" align="left">
                                    <a href="ListOfVacancy.aspx?JobId=<%# Eval("JobId") %>">View Details</a>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" colspan="2" height="50">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</asp:Content>
