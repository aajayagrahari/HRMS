<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true" CodeFile="frmChangePassword.aspx.cs" Inherits="Pages_Admin_frmChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
               <table width="60%">
                           
                           <tr>
                           <td align="center" ></td> <td align="center" ></td>
               <td align="left" >
                     <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                                            
                                            </td>
                                        </tr>
                            <tr>
                                <td align="left" valign="top">
                                  Old Password
                                </td>
                                 <td align="left" valign="top">
                                  :
                                </td>
                                 <td align="left" valign="top">
                                     <asp:TextBox ID="txt_old_password" runat="server" TextMode="Password"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ValidationGroup="ChangePassword" ControlToValidate="txt_old_password" ErrorMessage="*"></asp:RequiredFieldValidator>
                               
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                  New Password
                                </td>
                                 <td align="left" valign="top">
                                  :
                                </td>
                                 <td align="left" valign="top">
                                     <asp:TextBox ID="txt_new_password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ValidationGroup="ChangePassword" ControlToValidate="txt_new_password" ErrorMessage="*"></asp:RequiredFieldValidator>
                               
                               
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                  Confirm Password
                                </td>
                                 <td align="left" valign="top">
                                  :
                                </td>
                                 <td align="left" valign="top">
                                     <asp:TextBox ID="txt_confirm_password" runat="server" TextMode="Password"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ValidationGroup="ChangePassword" ControlToValidate="txt_confirm_password" ErrorMessage="*"></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ErrorMessage="Confirm password does not matched !." ValidationGroup="ChangePassword" ControlToCompare="txt_new_password" ControlToValidate="txt_confirm_password"></asp:CompareValidator>
                               
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
</asp:Content>

