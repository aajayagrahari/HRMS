<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    CodeFile="ListJobMaster.aspx.cs" Inherits="Pages_Admin_ListJobMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lbl_heding" runat="server" Text=" List Job Master"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="3">
                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width: 1000px; overflow: scroll; padding-left: 0px; padding-bottom: 20px;">
                    <asp:GridView ID="gv_jobmaster" runat="server" AutoGenerateColumns="false" Width="976px"
                        AllowPaging="True" PageSize="22" OnPageIndexChanging="gv_jobmaster_PageIndexChanging"
                        OnRowCommand="gv_jobmaster_RowCommand" OnRowDataBound="gv_jobmaster_RowDataBound"
                        OnRowDeleting="gv_jobmaster_RowDeleting" OnRowEditing="gv_jobmaster_RowEditing">
                        <RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <a href="JobMasterDetails.aspx?JobId=<%# Eval("JobId")%>">
                                        <img style="border: 0px; vertical-align: bottom;" alt="" src="../../Images/Edit.gif">
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="...">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="delete" CssClass="">
                                        <img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" >
                                    </asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Download Job">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text=' <%# Eval("Files")%> ' CommandName="Download"
                                        CommandArgument='<%# Eval("JobId")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Title" ItemStyle-Width="250">
                                <ItemTemplate>
                                    <div style="width: 250px; word-wrap: break-word;">
                                        <asp:Label ID="lbl_Title" runat="server" Text=' <%# Eval("Title")%> '></asp:Label>
                                        <asp:Label ID="lbl_deleted" runat="server" Text='  <%# Eval("IsDeleted")%>' Visible="false"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discription" ItemStyle-Width="300">
                                <ItemTemplate>
                                    <div style="width: 300px; height: 50px; overflow: hidden; text-align: justify; word-wrap: break-word;
                                        padding: 0px 5px 0px 5px;">
                                        <%# Eval("Description")%>
                                        &nbsp;...
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Create dDate" Visible="false">
                                <ItemTemplate>
                                    <%# Eval("CreatedDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modified Date" Visible="false">
                                <ItemTemplate>
                                    <%# Eval("ModifiedDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Detials" Visible="false">
                                <ItemTemplate>
                                    <b>Created By :</b>
                                    <%# Eval("CreatedBy")%><br />
                                    <b>Created Date :</b>
                                    <%# Eval("CreatedDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modified Detials" Visible="false">
                                <ItemTemplate>
                                    <b>Modified By :</b>
                                    <%# Eval("ModifiedBy")%><br />
                                    <b>Modified Date :</b>
                                    <%# Eval("ModifiedDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Image ID="Img4Delete1" runat="server" Style="border: 0px; vertical-align: middle;
                                        width: 20px" Width="20px" Height="20px" ImageUrl="~/Images/delete_icon.png" Visible="false" />
                                    <asp:Image ID="ImgTick1" runat="server" Style="border: 0px; vertical-align: middle;"
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
