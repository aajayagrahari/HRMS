<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmForgot.aspx.cs" Inherits="Pages_Universal_frmForgot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <table id="Table1" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%">
                        <table id="Table2" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" style="width: 100%">
                                    <table id="Table3" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" >
                                                <asp:Label ID="lblPageHeader" runat="server" Text="Change Password" CssClass="pageHeading"></asp:Label>
                                            <hr />
                                            </td>
                                           
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            
       <tr>
               <td align="center" valign="top" >
               <table width="100%">
                           
                           <tr>
                           <td align="center" ></td> <td align="center" ></td>
               <td align="left" >
                     <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                                            
                                            </td>
                                        </tr>
                            <tr>
                                <td align="left" valign="top">
                                  Enter Email Id
                                </td>
                                 <td align="left" valign="top">
                                  :
                                </td>
                                 <td align="left" valign="top">
                                     <asp:TextBox ID="txtEmailId" runat="server" ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ValidationGroup="ChangePassword" ControlToValidate="txtEmailId" ErrorMessage="*"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"  ValidationGroup="ChangePassword" ControlToValidate="txtEmailId" 
                                         ErrorMessage="Enter Valid Email Id !." 
                                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="left" valign="top">
                            
                                </td>
                                 <td align="left" valign="top">
                                  
                                </td>
                                 <td align="left" valign="top">
                                     <asp:Button ID="btn_submit" runat="server" ValidationGroup="ChangePassword" 
                                         Text="Submit" onclick="btn_submit_Click" />
                                </td>
                            </tr>
                            </table>
                            </td>
                            </tr>
                            </table>
                            </td>
                            </tr>
                            </table>
    </form>
</body>
</html>
