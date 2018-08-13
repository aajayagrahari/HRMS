<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="OutOfOfficeAttendanceList4Employee.aspx.cs"
    Inherits="Pages_Employee_OutOfOfficeAttendanceList4Employee" %>

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
                                    <asp:Label ID="lblPageHeader" runat="server" Text="Out Of Office Attendance List"
                                        CssClass="pageHeading"></asp:Label>
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
                                                <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="20%"
                                                    OnSelectedIndexChanged="ddlFinYear_SelectedIndexChanged" AutoPostBack="true">
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
                                                                <asp:GridView ID="grdOutOfOffice" runat="server" AutoGenerateColumns="false" DataKeyNames="EmployeeId"
                                                                    Width="1076px" OnRowCommand="grdOutOfOffice_RowCommand" OnRowEditing="grdOutOfOffice_RowEditing"
                                                                    OnRowDeleting="grdOutOfOffice_RowDeleting" OnRowDataBound="grdOutOfOffice_RowDataBound">
                                                                    <RowStyle BorderWidth="2" BorderColor="Salmon" />
                                                                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                                                                        BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                                                                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                                                                        ForeColor="Snow" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Employee Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_EmployeeId" runat="server" Text=' <%#Eval("EmployeeId")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Month">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Month" runat="server" Text=' <%#Eval("Month")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Month">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_MonthName" runat="server" Text=' <%#Eval("Month")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Year" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Year" runat="server" Text='<%#Eval("Year")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date From">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_OutOfOfficeDateFrom" runat="server" Text=' <%#Eval("DateFrom")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date To">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_OutOfOfficeDateTo" runat="server" Text=' <%#Eval("DateTo")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IsApprove">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_IsApprove" runat="server" Text=' <%#Eval("IsApprove")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Status" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Approved By" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_ApprovedBy" runat="server" Text='<%#Eval("ApprovedBy")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Approved By" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_ApprovedByName" runat="server" Text='<%#Eval("Name1")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Designation" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Designation1" runat="server" Text='<%#Eval("Designation1")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Department" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_Department1" runat="server" Text='<%#Eval("Department1")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
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
                                                                        <asp:TemplateField HeaderText="..." Visible="false">
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
