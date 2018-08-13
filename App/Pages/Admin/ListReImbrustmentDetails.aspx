<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    CodeFile="ListReImbrustmentDetails.aspx.cs" Inherits="Pages_Admin_ListReImbrustmentDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .fancy-green .ajax__tab_header
        {
            background: url(../../green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
        {
            background: url(../../green_left_Tab.gif) no-repeat left top;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
        {
            background: url(../../green_right_Tab.gif) no-repeat right top;
        }
        .fancy .ajax__tab_header
        {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }
        .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer
        {
            height: 38px;
        }
        .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
        {
            height: 38px;
            margin-left: 16px; /* offset the width of the left image */
        }
        .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
        {
            margin: 16px 16px 0px 0px;
        }
        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
        {
            color: #fff;
        }
        .fancy .ajax__tab_body
        {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left">
                <table id="Table3" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPageHeader" runat="server" Text="List ReImburstment" CssClass="pageHeading"></asp:Label>
                            <hr />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="top">
                            <asp:TabContainer ID="TabContainer1" runat="server" Height="570" ActiveTabIndex="0"
                                CssClass="fancy fancy-green">
                                <asp:TabPanel runat="server" ID="panal1">
                                    <HeaderTemplate>
                                        Pending ReImbursement List</HeaderTemplate>
                                    <ContentTemplate>
                                        <div style="width: 1076px; overflow: auto; padding-bottom: 20px;">
                                            <table>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" valign="top">
                                                        <asp:GridView ID="gv_ReImbrustment" runat="server" AutoGenerateColumns="False" Width="2000px"
                                                            AllowPaging="True" OnPageIndexChanging="gv_ReImbrustment_PageIndexChanging" OnSelectedIndexChanged="gv_ReImbrustment_SelectedIndexChanged"
                                                            PageSize="25" EmptyDataText="No Record Found !">
                                                            <RowStyle BorderWidth="2px" BorderColor="Salmon" />
                                                            <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                ForeColor="Snow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Action">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButtonList ID="rdo_approved" runat="server" RepeatColumns="2">
                                                                            <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
                                                                            <asp:ListItem Value="0" Text="DisApproved"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Employee Id">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmployeeId") %>
                                                                        <asp:HiddenField ID="hdn_ReimbursementId" runat="server" Value='<%# Eval("ReimbursementDetailId")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Employee Name">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmployeeName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ManagerName">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ManagerName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Department") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FromDate">
                                                                    <ItemTemplate>
                                                                        <%# Eval("FromDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ToDate">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ToDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Business Purpose">
                                                                    <ItemTemplate>
                                                                        <%# Eval("BusinessPurpose") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Applied Date">
                                                                    <ItemTemplate>
                                                                        <%# Eval("CreatedDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reimbursement Date">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ReimbursementDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reimbursement Description">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ReimbursementDescription") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Category">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Category") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cost">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Cost") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" ID="panal2">
                                    <HeaderTemplate>
                                        Approved/DisApprove List</HeaderTemplate>
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <div style="width: 1076px; overflow: auto; padding-bottom: 20px;">
                                                        <asp:GridView ID="gv_Verified" runat="server" AutoGenerateColumns="false" Width="2000"
                                                            AllowPaging="True" OnPageIndexChanging="gv_Verified_PageIndexChanging" OnRowDataBound="gv_Verified_RowDataBound"
                                                            PageSize="25" EmptyDataText="No Record Found !">
                                                            <RowStyle BorderWidth="2px" BorderColor="Salmon" />
                                                            <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                ForeColor="Snow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_approved" runat="server" Text='<%# Eval("IsApprove") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lbl_isApprove" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Employee Id">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmployeeId") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Employee Name">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmployeeName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ManagerName">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ManagerName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Department") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FromDate">
                                                                    <ItemTemplate>
                                                                        <%# Eval("FromDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ToDate">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ToDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Business Purpose">
                                                                    <ItemTemplate>
                                                                        <%# Eval("BusinessPurpose") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Applied Date">
                                                                    <ItemTemplate>
                                                                        <%# Eval("CreatedDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reimbursement Date">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ReimbursementDate") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reimbursement Description">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ReimbursementDescription") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Category">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Category") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cost">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Cost") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
