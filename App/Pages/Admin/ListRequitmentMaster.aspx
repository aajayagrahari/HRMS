<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    CodeFile="ListRequitmentMaster.aspx.cs" Inherits="ListRequitmentMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
        <tr>
            <td align="center" valign="top" colspan="3">
                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; background-color: Gray;" valign="bottom" colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" style="width: 100%; background-color: Gray;" valign="bottom">
                            <asp:HyperLink ID="hplCreateNew" runat="server" NavigateUrl="~/Pages/Admin/RequitmentMaster.aspx"><img style="border:0px;vertical-align:middle;" alt="" src="../../Images/AddNewRecord.gif" / ></asp:HyperLink>
                        </td>
                        <td style="width: 50%; background-color: Gray;" align="right">
                            <asp:LinkButton ID="btnExport" runat="server" CssClass="" ToolTip="Export Data in Excel"><img style="border:0px;vertical-align:bottom;" alt="" src="../../Images/export.png" / ></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%" colspan="3">
                <hr style="color: Black; width: 100%;" />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width: 1074px; height: 500px; overflow: auto; border: 1px solid #000;">
                    <asp:GridView ID="gv_requitmentmaster" runat="server" AutoGenerateColumns="false"
                        Width="2024px" AllowPaging="True" OnPageIndexChanging="gv_requitmentmaster_PageIndexChanging"
                        OnRowCommand="gv_requitmentmaster_RowCommand" PageSize="22">
                        <RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField HeaderText=" Download Resume">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text=' <%# Eval("Resume")%> ' CommandName="Download"
                                        CommandArgument='<%# Eval("RId")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_FNAME" runat="server" Text=' <%# Eval("FName")%> '></asp:Label>&nbsp;
                                    <asp:Label ID="lbl_lname" runat="server" Text='  <%# Eval("LName")%>'></asp:Label>
                                    <asp:Label ID="lbl_deleted" runat="server" Text='  <%# Eval("IsDeleted")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <%# Eval("Gender")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Of Birth">
                                <ItemTemplate>
                                    <%# Eval("DOB")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id ">
                                <ItemTemplate>
                                    <%# Eval("EmailId")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile No">
                                <ItemTemplate>
                                    <%# Eval("MobileNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qualification">
                                <ItemTemplate>
                                    <%# Eval("Qualification")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exprience">
                                <ItemTemplate>
                                    <%# Eval("Exprience")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <%# Eval("Designation")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country Name">
                                <ItemTemplate>
                                    <%# Eval("CountryName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State Name">
                                <ItemTemplate>
                                    <%# Eval("StateName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <%# Eval("City")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pin Code">
                                <ItemTemplate>
                                    <%# Eval("PinCode")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Current Address">
                                <ItemTemplate>
                                    <%# Eval("CAddress")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parmanent Address">
                                <ItemTemplate>
                                    <%# Eval("PAddress")%>
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
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
