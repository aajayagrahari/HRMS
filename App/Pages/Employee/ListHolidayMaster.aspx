<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ListHolidayMaster.aspx.cs" Inherits="Pages_Employee_ListHolidayMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%">
                        <table border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" style="width: 100%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%">
                                    <asp:Label ID="lblPageHeader" runat="server" Text="Holidays Calender" CssClass="pageHeading"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100%">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100%">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="49%" align="right">
                                                <asp:Label ID="lblFiscalYear" runat="server" Text="Financial Year" CssClass="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="20%">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="49%" align="left">
                                                &nbsp;&nbsp;<asp:Label ID="lblMonth" runat="server" Text="Month" CssClass="Label"></asp:Label><br />
                                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">January</asp:ListItem>
                                                    <asp:ListItem Value="2">February</asp:ListItem>
                                                    <asp:ListItem Value="3">March</asp:ListItem>
                                                    <asp:ListItem Value="4">April</asp:ListItem>
                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                    <asp:ListItem Value="8">August</asp:ListItem>
                                                    <asp:ListItem Value="9">September</asp:ListItem>
                                                    <asp:ListItem Value="10">October</asp:ListItem>
                                                    <asp:ListItem Value="11">November</asp:ListItem>
                                                    <asp:ListItem Value="12">December</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%">
                                    <hr style="color: Black; width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width: 100%;">
                                    <table border="0" style="height: 600px;" runat="server" cellpadding="0" cellspacing="0"
                                        width="100%">
                                        <tr>
                                            <td align="left" valign="top">
                                                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="width: 100%;" valign="top">
                                                            <div style="width: 1074px; height: 520px; overflow: auto;">
                                                                <asp:GridView ID="grdHolidayDetails" runat="server" AutoGenerateColumns="false"
                                                                    DataKeyNames="HolidaysId" Width="1624px" OnRowCommand="grdHolidayDetails_RowCommand"
                                                                    OnRowEditing="grdHolidayDetails_RowEditing" OnRowDeleting="grdHolidayDetails_RowDeleting"
                                                                    OnRowDataBound="grdHolidayDetails_RowDataBound">
                                                                    <RowStyle BorderWidth="2" BorderColor="Salmon" />
                                                                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                                                                        BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                                                                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                                                                        ForeColor="Snow" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Bottom" Visible="false">
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
                                                                        <asp:TemplateField HeaderText="Holidays Id" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_HolidaysId" runat="server" Text=' <%#Eval("HolidaysId")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="HoliDays" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_HoliDays" runat="server" Text='<%#Eval("HoliDays")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_FinancialYear" runat="server" Text=' <%#Eval("FinancialYear")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Month" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_EnglishMonth" runat="server" Text=' <%#Eval("EnglishMonth")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="English Date" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_EnglishDate" runat="server" Text='<%#Eval("EnglishDate")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Saka Month" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_SakaMonth" runat="server" Text='<%#Eval("SakaMonth")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Saka Date" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_SakaDate" runat="server" Text='<%#Eval("SakaDate")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="HoliDays_Day" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_HoliDays_Day" runat="server" Text='<%#Eval("HoliDays_Day")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Holidays_Type" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Holidays_Type" runat="server" Text=' <%#Eval("Holidays_Type")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Created Date" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Modified Date" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_ModifiedDate" runat="server" Text='<%#Eval("ModifiedDate")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Created By" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_CreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Modified By" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_ModifiedBy" runat="server" Text='<%#Eval("ModifiedBy")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IsDeleted" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_IsDeleted" runat="server" Text='<%#Eval("IsDeleted")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
