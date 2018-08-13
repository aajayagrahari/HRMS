<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    CodeFile="RequitmentRegistration.aspx.cs" Inherits="Pages_Admin_RequitmentRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                Requitment Registration Master
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width: 985px; overflow: scroll; padding-bottom: 20px;">
                    <asp:GridView ID="gv_requitmentMaster" runat="server" AutoGenerateColumns="false"
                        AllowPaging="True" Width="2000" OnPageIndexChanging="gv_requitmentMaster_PageIndexChanging"
                        PageSize="20" OnRowCommand="gv_requitmentMaster_RowCommand">
                        <PagerStyle CssClass="pagerlink" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Post" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70">
                                <ItemTemplate>
                                    <a href="RequitmentRegistrationDetails.aspx?rid=<%# Eval("RRId") %>" target="_blank">
                                        View Details</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="170">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_fname" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MName") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Father Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="170">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Fatherfname" runat="server" Text='<%# Eval("FatherFName") %>'></asp:Label>
                                    <asp:Label ID="lbl_FatherMName" runat="server" Text='<%# Eval("FatherMName") %>'></asp:Label>
                                    <asp:Label ID="lbl_FatherLName" runat="server" Text='<%# Eval("FatherLName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Post" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="170">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Post" runat="server" Text='<%# Eval("PostName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Category" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Download Resume" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("Resume")%> ' CommandName="Download"
                                        CommandArgument='<%# Eval("RRId")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download Certificate" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="170">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_Certificate" runat="server" Text='<%# Eval("Certificate")%> '
                                        CommandName="Certificate" CommandArgument='<%# Eval("RRId")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Card No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CardNo" runat="server" Text='<%# Eval("CardNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Of Issue" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="70">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_DateOfIssue" runat="server" Text='<%# Eval("DateOfIssue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issuing Authority" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="170">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_IssueingAuthority" runat="server" Text='<%# Eval("IssueingAuthority") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Applied Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="170">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
