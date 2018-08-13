<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    CodeFile="ListOfVacancy.aspx.cs" Inherits="Pages_Universal_ListOfVacancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lbl_heding" runat="server" CssClass="pageHeading" Text=" List Of Vacancy"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
             
                <asp:Repeater ID="rpt_vacancy" runat="server" >
                    <ItemTemplate>
                        <table width="980" align="center">
                            <tr>
                                <td valign="top" align="left">
                                    <div style="width: 730px;  text-align:justify; word-wrap: break-word;">
                                        <b>
                                            <%# Eval("AdvertisementName")%></b>
                                    </div>
                                </td>
                                <td valign="top" align="left">
                                    <b>Posted Date</b> &nbsp;
                                    <%# Eval("OpeningDate1")%>
                                    <br />
                                     <b>Last Date</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <%# Eval("ClosingDate1")%>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" colspan="2" style="border-bottom: 1px solid #ddd;">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" style="width: 730px; padding-right:10px; ">
                                    <div style="width: 740px;  text-align:justify; word-wrap: break-word;">
                                        <%# Eval("AdverDescription")%>
                                </td>
                                </div>
                                <td valign="middle" align="left">
                                    <a href="ListOfVacancy.aspx?JobId=<%# Eval("AdvertisementId") %>" >View Details</a>
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
