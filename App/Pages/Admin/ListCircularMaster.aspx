<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    CodeFile="ListCircularMaster.aspx.cs" Inherits="Pages_Admin_ListCircularMaster" %>

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
            <td align="left" style="width: 100%; background-color: Gray;" valign="bottom">
                <asp:HyperLink ID="hplCreateNew" runat="server" NavigateUrl="~/Pages/Admin/frmCircularMaster.aspx"
                    CssClass="Link">
                    <img style="border: 0px; vertical-align: middle;" alt="" src="../../Images/AddNewRecord.gif" /><asp:Label
                        ID="lblAddNewEmployee" runat="server" Text="Create New Circular" CssClass="Label"
                        ForeColor="White"></asp:Label></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="70%" align="center">
                    <tr>
                        <td align="center" valign="top">
                            <div style="overflow: auto; width: 1000px;">
                                <asp:GridView ID="gv_list_circular_master" runat="server" DataKeyNames="CId" AutoGenerateColumns="false"
                                    AllowPaging="True" OnPageIndexChanging="gv_list_circular_master_PageIndexChanging"
                                    Width="976px" OnRowDataBound="gv_list_circular_master_RowDataBound" OnRowDeleting="gv_list_circular_master_RowDeleting">
                                    <RowStyle BorderWidth="2" BorderColor="Salmon" />
                                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                                        BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                                        ForeColor="Snow" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="...">
                                            <ItemTemplate>
                                                <a href="frmCircularMaster.aspx?Cid=<%# Eval("CId")%>">
                                                    <img style="border: 0px; vertical-align: bottom;" alt="" src="../../Images/Edit.gif">
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="...">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="delete" CssClass="">
                                            <img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" >
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Title">
                                            <ItemTemplate>
                                                <%# Eval("Title")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <%# Eval("Description")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Created By" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_CreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Created Date" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ModifiedBy" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IsDeleted" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_IsDeleted" runat="server" Text='<%#Eval("IsDeleted")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="...">
                                            <ItemTemplate>
                                                <asp:Image ID="Img4Delete" runat="server" Style="border: 0px; vertical-align: middle;
                                                    width: 20px" Width="20px" Height="20px" ImageUrl="~/Images/delete_icon.png" Visible="false" />
                                                <asp:Image ID="ImgTick" runat="server" Style="border: 0px; vertical-align: middle;"
                                                    Width="20px" Height="20px" ImageUrl="~/Images/tick_32.png" Visible="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
