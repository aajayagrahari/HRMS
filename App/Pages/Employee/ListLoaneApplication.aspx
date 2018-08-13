<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    CodeFile="ListLoaneApplication.aspx.cs" Inherits="Pages_Admin_ListLoaneApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lbl_heding" runat="server" Text="Loan Apllication List" CssClass="pageHeading"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" >
                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="background-color: Gray;" valign="bottom">
                <asp:HyperLink ID="hplCreateNew" runat="server" NavigateUrl="~/Pages/Employee/frmLoaneApplication.aspx"><img style="border:0px;vertical-align:middle;" alt="" src="../../Images/AddNewRecord.gif" / ></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <div style="width: 1000px; overflow: auto; padding-left: 0px; padding-bottom: 20px;">
                    <asp:GridView ID="grdLoaneApplication" runat="server" AutoGenerateColumns="false" Width="976px"
                        AllowPaging="True" PageSize="22" OnPageIndexChanging="grdLoaneApplication_PageIndexChanging"
                        OnRowCommand="grdLoaneApplication_RowCommand" OnRowDataBound="grdLoaneApplication_RowDataBound"
                        OnRowDeleting="grdLoaneApplication_RowDeleting" OnRowEditing="grdLoaneApplication_RowEditing">
                        <RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Bottom">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Container.DataItemIndex%>'
                                        CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:bottom;" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                                <ControlStyle ForeColor="#6600FF" />
                                <ItemStyle Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                        CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Id" ItemStyle-HorizontalAlign="Center" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmployeeId" runat="server" Text=' <%#Eval("EmployeeId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_SubjectLine" runat="server" Text=' <%#Eval("ApplicationHeading")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Body" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Body" runat="server" Text='<%#Eval("ApplicationBody")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Document" ItemStyle-HorizontalAlign="Center"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text=' <%# Eval("EmpDocument")%> ' CommandName="Download"
                                        CommandArgument='<%# Eval("EmployeeId")%>'></asp:LinkButton>
                                    <%-- <asp:Label ID="lbl_EmpDocument" runat="server" Text=' <%#Eval("EmpDocument")%>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Remarks" runat="server" Text=' <%#Eval("Remarks")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Status" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IsDeleted" Visible="false">
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
</asp:Content>
