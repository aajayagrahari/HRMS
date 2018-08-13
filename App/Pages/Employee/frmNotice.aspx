<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true" CodeFile="frmNotice.aspx.cs" Inherits="Pages_Employee_frmNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table width="100%">
        <tr>
            <td align="left" valign="top">
                Notice Form
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table>
                    <tr>
                   
                        <td align="left" valign="top">
                            <asp:GridView ID="gv_list_circular_master" runat="server" 
                                AutoGenerateColumns="false"  PageSize="15" GridLines="None" AllowPaging="True" ShowHeader="false" >
                                <Columns>
                                    
                                    <asp:TemplateField  >
                                        <ItemTemplate>
                                        <table>
                                        <tr>
                                       <td align="left" valign="top"><b> Subject</b></td>  <td align="left" valign="top"><b> :</b></td><td align="left" valign="top"> <b><%# Eval("Title")%></b></td>
                                        </tr>
                                          <tr>
                                        <td align="left" valign="top"><b> Description </b></td> <td align="left" valign="top"><b> :</b></td>  <td align="left" valign="top">  <%# Eval("Description")%></td>
                                        </tr>
                                        <tr>
                                        <td align="left" valign="top" colspan="3"><hr /></td>
                                        </tr>
                                        </table>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

