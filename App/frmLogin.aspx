<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="frmLogin" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRMS</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        javascript: window.history.forward(-1);
    </script>

    <script language="JavaScript" type="text/javascript" >
        function OpenNewWP() {
            debugger;
            newWin = window.open('frmForgot.aspx', 'form1', 'toolbar=no,status=no,menubar=no,location=center,scrollbars=no,resizable=no,height=500,width=450');
            newWin.opener = top;
            newWin.moveTo(900, 500);
            //Minimize();

        }
      
</script>
</head>
<body class="body">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM1" runat="server">
    </asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="left" style="width: 100%">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="left" style="width: 100%;" valign="bottom">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100%;" valign="bottom">
                            <%--<asp:Image ID="imgPage" runat="server" ImageUrl="~/Images/logo.jpg" Width="80" />
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Hrms.png" />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 180px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" style="width: 100%">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="right" valign="bottom" style="width: 60%">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/members-login-right.jpg" />
                        </td>
                        <td align="left" valign="top" style="width: 40%">
                            <table cellpadding="3" cellspacing="0" border="0" width="100%" class="login_area">
                                <tr>
                                    <td align="left" valign="middle" style="width: 100%" colspan="2">
                                        <asp:Label ID="Label1" runat="server" Text="Login" CssClass="pageHeading"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100%" colspan="2">
                                        <hr style="color: #C0C0C0;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 50%">
                                        <asp:Label ID="lblUsername" runat="server" Text="Login Id : "></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtUsername" runat="server" Width="230px" TabIndex="1" MaxLength="20"
                                            CssClass="input_inn"></asp:TextBox>
                                    </td>
                                    <td align="left" valign="bottom" style="width: 50%">
                                        <asp:RequiredFieldValidator CssClass="Required" ValidationGroup="Req_Login" ID="RequiredFieldValidator2"
                                            runat="server" ErrorMessage="*" ToolTip="Please Enter Your Login Id" SetFocusOnError="true"
                                            ControlToValidate="txtUsername" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 50%">
                                        <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtPassword" runat="server" Width="230px" TabIndex="2" MaxLength="20"
                                            TextMode="Password" CssClass="input_inn"></asp:TextBox>
                                    </td>
                                    <td align="left" valign="bottom" style="width: 50%">
                                        <asp:RequiredFieldValidator CssClass="Required" ValidationGroup="Req_Login" ID="RequiredFieldValidator3"
                                            runat="server" ErrorMessage="*" ToolTip="Please Enter your password." SetFocusOnError="true"
                                            ControlToValidate="txtPassword" Display="Dynamic"> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100%" colspan="2">
                                        <hr style="color: #C0C0C0;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100%" colspan="2">
                                        <asp:Label ID="lblMsg" runat="server" Text="" CssClass="Required"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100%" colspan="2">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td style="width: 20%" align="left">
                                                    <asp:TextBox ID="txtId" runat="server" CssClass="Text" Visible="false"></asp:TextBox>
                                                    <asp:Button ID="cmdLogin" ValidationGroup="Req_Login" runat="server" Text="Login"
                                                        CssClass="button" TabIndex="4" Width="50px" OnClick="cmdLogin_Click" />&nbsp;
                                                </td>
                                                <td style="width: 80%" align="left" valign="middle">
                                                    <asp:LinkButton ID="lbForgotPassword" CssClass="Label" runat="server" OnClientClick="return OpenNewWP();" Text="Forgot Password?"
                                                        TabIndex="5"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 200px; padding-left: 5px; padding-right: 5px; width: 100%" valign="bottom">
                <hr style="color: #C0C0C0;" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 10px">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td align="right" style="width: 100%;" valign="middle">
                            <asp:Label ID="lblFooter" runat="server" CssClass="Label" Text="© BECIL-Broadcast Engineering Consultants India Ltd."></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text=" Designed & Developed by"></asp:Label>&nbsp;<a href="http://www.vision360.co.in" style="text-decoration :None;"><asp:Label ID="Label3" runat="server" CssClass="Label" Text="Vision360 IT Consulting" ForeColor="Orange"></asp:Label></a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
