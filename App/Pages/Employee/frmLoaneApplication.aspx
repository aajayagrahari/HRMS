<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    CodeFile="frmLoaneApplication.aspx.cs" Inherits="Pages_Admin_frmLoaneApplication" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table id="Table1" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" style="width: 100%">
                <table id="Table2" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100%">
                            <asp:Label ID="lblPageHeader" runat="server" Text="Loan Application" CssClass="pageHeading"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 100%">
                            <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100%">
                            <hr style="color: Black; width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 100%;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" Align="center">
                                <tr>
                                    <td align="left" valign="top" style="width: 100%;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="left" valign="top" style="width: 100%;">
                                                    <asp:Label ID="lblSubjectLine" CssClass="Label" runat="server" Text="Subject"></asp:Label><br />
                                                    <asp:TextBox ID="txtSubjectLine" runat="server" MaxLength="30" Width="98%" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator2" runat="server"
                                                        ErrorMessage="*" ToolTip="Please Enter the Subject Line" SetFocusOnError="true"
                                                        ControlToValidate="txtSubjectLine" ValidationGroup="Req_Blank" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="width: 100%;">
                                                    <asp:Label ID="lblUploadDocument" CssClass="Label" runat="server" Text="Upload Document"></asp:Label><br />
                                                    <asp:FileUpload ID="upd_Document" runat="server" CssClass="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="width: 100%;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="width: 100%;">
                                                    <cc1:Editor ID="txtEditor" runat="server" Height="510px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="bottom" style="width: 100%;">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
