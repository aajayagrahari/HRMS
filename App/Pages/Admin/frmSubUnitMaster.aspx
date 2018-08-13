<%@ Page Title="Unit Master Page" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmSubUnitMaster.aspx.cs" Inherits="Pages_Admin_frmSubUnitMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        <table width="80%" align="center" cellpadding="0" cellspacing="0" style="border: 1px solid #4b6c9e">
            <tr>
                <td colspan="3">
                    <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid #4b6c9e;
                        font-size: 14px;">
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblPageHeading" runat="server" Text="Sub Unit Master" CssClass="pageHeading"></asp:Label>
                                <hr />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <b>Unit</b>
                </td>
                <td>
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlUnit" Width="170px" runat="server" class="TextBoxdesign">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <b>Sub Unit Code</b>
                </td>
                <td>
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtSubUnitCode" runat="server" class="TextBoxdesign" onfocus="return Select(event,this,'AD',10);"
                        onblur="return UnSelect(event,this,'AD',10);" onkeypress="return ValdTextBox(event,this,'AD',10);" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <b>Sub Unit Name</b>
                </td>
                <td>
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtSubUnitName" runat="server" class="TextBoxdesign" onfocus="return Select(event,this,'AD',30);"
                        onblur="return UnSelect(event,this,'AD',30);" onkeypress="return ValdTextBox(event,this,'AD',30);" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn_style" OnClick="btnSave_Click" />
                    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn_style"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label><asp:Literal ID="litReport1" runat="server"
                        Visible="false"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gdvSubUnit" runat="server" AutoGenerateColumns="false" CssClass="grid_style"
                        Width="100%" OnRowCommand="gdvSubUnit_RowCommand" OnRowDeleting="gdvSubUnit_RowDeleting"
                        OnRowEditing="gdvSubUnit_RowEditing" OnRowDataBound="gdvSubUnit_RowDataBound"
                        AllowPaging="True" OnPageIndexChanging="gdvSubUnit_PageIndexChanging">
                        <RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField HeaderText="...">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Eval("SubUnitCode") %>'
                                        CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:bottom;" alt="" src="../../Images/Edit.gif" / ></asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                                <ControlStyle ForeColor="#6600FF" />
                                <ItemStyle Font-Size="Medium" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="...">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("SubUnitCode") %>'
                                        CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="UnitName" DataField="UnitName" />
                            <asp:BoundField HeaderText="Sub Unit Code" DataField="UnitCode" />
                            <asp:BoundField HeaderText="Sub Unit Name" DataField="UnitName" />
                            <asp:TemplateField HeaderText="Creation Detail">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBy" runat="server" Text='<%#Bind ("CreatedBy")%>'></asp:Label>
                                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Bind ("CreatedDate")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modification Detail">
                                <ItemTemplate>
                                    <asp:Label ID="lblModifiedBy" runat="server" Text='<%#Bind ("ModifiedBy")%>'></asp:Label>
                                    <asp:Label ID="lblModifiedDate" runat="server" Text='<%#Bind ("ModifiedDate")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Deleted" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsDeleted" runat="server" Text='<%#Eval("IsDeleted") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Image ID="Img4Delete" runat="server" Style="border: 0px; vertical-align: middle;
                                        width: 20px" Width="20px" Height="20px" ImageUrl="~/Images/delete_icon.png" Visible="false" />
                                    <asp:Image ID="ImgTick" runat="server" Style="border: 0px; vertical-align: middle;"
                                        Width="20px" Height="20px" ImageUrl="~/Images/tick_32.png" Visible="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            There is no record.....</EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
