<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ListEmployeeMaster.aspx.cs" Inherits="Pages_Admin_ListEmployeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center" style="width: 100%">
                        <table border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" style="width: 100%">
                                    <table id="Table1" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" style="width: 50%">
                                                <asp:Label ID="lblPageHeader" runat="server" Text="Employee Master" CssClass="pageHeading"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 50%">
                                                <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width: 100%">
                                    <%--<asp:Panel runat="server" ID="pUpload" Visible="false">--%>
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 100%;">
                                                    <table cellpadding="0" cellspacing="1" width="30%" border="1" align="right">
                                                        <tr>
                                                            <td align="left" style="width: 90%;">
                                                                <asp:FileUpload ID="FUploadSheet" TabIndex="4" CssClass="Text" runat="server" BorderStyle="None"
                                                                    Width="200px" Height="20px" />
                                                                <asp:Label ID="lblFileUpload" runat="server" Text="" Visible="true"></asp:Label>
                                                            </td>
                                                            <td align="right" style="width: 10%;">
                                                                <asp:Button ID="cmdUpload" Text="Upload" TabIndex="5" Width="70px" runat="server"
                                                                    CssClass="button" UseSubmitBehavior="False" OnClick="cmdUpload_Click"></asp:Button>&nbsp;
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                   <%-- </asp:Panel>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%; background-color: Gray;" valign="bottom">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" style="width: 80%; background-color: Gray;" valign="bottom">
                                                <asp:HyperLink ID="hplCreateNew" runat="server" NavigateUrl="~/Pages/Admin/frmEmployeeMaster.aspx?EmpId="
                                                    CssClass="Link">
                                                    <img style="border: 0px; vertical-align: middle;" alt="" src="../../Images/AddNewRecord.gif" /><asp:Label
                                                        ID="lblAddNewEmployee" runat="server" Text=" Add New Employee" CssClass="Label"
                                                        ForeColor="White"></asp:Label></asp:HyperLink>
                                            </td>
                                            <td style="width: 20%; background-color: Gray;" align="right">
                                                <asp:LinkButton ID="btnExport" runat="server" CssClass="" ToolTip="Export Data in Excel" OnClick="btnExportExcel_Click"><img style="border:0px;vertical-align:bottom;" alt="" src="../../Images/export.png" / ></asp:LinkButton>
                                                <asp:LinkButton ID="lbImport" runat="server" Font-Bold="true" ForeColor="White" OnClick="lbImport_onClick"
                                                                    ToolTip="Import From Sheet"><img style="border:0px;vertical-align:middle;" alt="" src="../../Images/import.png" / ></asp:LinkButton>
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
                                                <ajax:TabContainer ID="TabContainer1" runat="server" CssClass="fancy fancy-green"
                                                    Height="570px" ActiveTabIndex="0">
                                                    <ajax:TabPanel ID="tbplEmployeeDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Personal
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="EmployeeDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%;" valign="top">
                                                                            <div style="width: 1074px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdEmployeeMasterDetails" runat="server" AutoGenerateColumns="False"
                                                                                    DataKeyNames="EmployeeId" Width="1624px" OnRowCommand="grdEmployeeMasterDetails_RowCommand"
                                                                                    OnRowEditing="grdEmployeeMasterDetails_RowEditing" OnRowDeleting="grdEmployeeMasterDetails_RowDeleting"
                                                                                    OnRowDataBound="grdEmployeeMasterDetails_RowDataBound">
                                                                                    <RowStyle BorderWidth="2px" BorderColor="Salmon" />
                                                                                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                        BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                        ForeColor="Snow" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="...">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Container.DataItemIndex%>'
                                                                                                    CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:bottom;" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <ControlStyle ForeColor="#6600FF" />
                                                                                            <ItemStyle Font-Size="Medium" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="...">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeId" runat="server" Text=' <%#Eval("EmployeeId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeType" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeTypeId" runat="server" Text='<%#Eval("EmployeeTypeId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Type">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeType" runat="server" Text='<%#Eval("EmployeeType")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="PCardNo" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PCardNo" runat="server" Text=' <%#Eval("PCardNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="First Name" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_FirstName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Middle Name" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_MiddleName" runat="server" Text='<%#Eval("MiddleName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Last Name" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LastName" runat="server" Text='<%#Eval("LastName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Father Name" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_FatherName" runat="server" Text='<%#Eval("FatherName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Department" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Department" runat="server" Text=' <%#Eval("Department")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Department">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DepartmentName" runat="server" Text=' <%#Eval("DepartmentName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Designation" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Designation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Designation">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DesignationName" runat="server" Text='<%#Eval("DesignationName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Unit">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Unit" runat="server" Text='<%#Eval("Unit ")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub Unit" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_SubUnit" runat="server" Text=' <%#Eval("SubUnit")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="PF No" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PFNo" runat="server" Text='<%#Eval("PFNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ESI No" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ESINo" runat="server" Text='<%#Eval("ESINo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Alias Name" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_AliasName" runat="server" Text='<%#Eval("AliasName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Nick Name" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_NickName" runat="server" Text='<%#Eval("NickName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="LocalAddress" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LocalAddress" runat="server" Text='<%#Eval("LocalAddress")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_City" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Zip Code" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ZipCode" runat="server" Text=' <%#Eval("ZipCode")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Country" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Country" runat="server" Text=' <%#Eval("Country")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Country">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CountryName" runat="server" Text=' <%#Eval("CountryName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="State" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_State" runat="server" Text='<%#Eval("State")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="State Name" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_StateName" runat="server" Text=' <%#Eval("StateName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Contact No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ContactNo" runat="server" Text='<%#Eval("ContactNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmailId">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmailId" runat="server" Text='<%#Eval("EmailId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Paramanent Address" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ParamAddress" runat="server" Text='<%#Eval("ParamAddress")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Paramanent City" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ParamCity" runat="server" Text='<%#Eval("ParamCity")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Param ZipCode" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ParamZipCode" runat="server" Text='<%#Eval("ParamZipCode")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Paramanent Country" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ParamCountry" runat="server" Text=' <%#Eval("ParamCountry")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Paramanent State" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ParamState" runat="server" Text=' <%#Eval("ParamState")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Place Of Birth">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PlaceOfBirth" runat="server" Text='<%#Eval("PlaceOfBirth")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Ration CardNo" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_RationCardNo" runat="server" Text='<%#Eval("RationCardNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Voter Id" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_VoterId" runat="server" Text='<%#Eval("VoterId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Passport No" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PassportNo" runat="server" Text='<%#Eval("PassportNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="DL No" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DLNo" runat="server" Text='<%#Eval("DLNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ValidUpTo" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ValidUpTo" runat="server" Text='<%#Eval("ValidUpTo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Identity Marks" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_IdentityMarks" runat="server" Text=' <%#Eval("IdentityMarks")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Religion" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Religion" runat="server" Text=' <%#Eval("Religion")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Nationality" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Nationality" runat="server" Text='<%#Eval("Nationality")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Date Of Birth" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DateOfBirth" runat="server" Text='<%#Eval("DateOfBirth")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Retirement Date" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_RetirementDate" runat="server" Text='<%#Eval("RetirementDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Gender" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Gender" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Height" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Height" runat="server" Text='<%#Eval("Height")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Blood Group" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_BloodGroup" runat="server" Text='<%#Eval("BloodGroup")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="MaritalStatus" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_MaritalStatus" runat="server" Text='<%#Eval("MaritalStatus")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Date" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Date" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="LoginId">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LoginId" runat="server" Text='<%#Eval("LoginId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Password">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Password" runat="server" Text='<%#Eval("Password")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeePic" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeePic" runat="server" Text='<%#Eval("EmployeePic")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Created Date" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Modified Date" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ModifiedDate" runat="server" Text='<%#Eval("ModifiedDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Created By" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Modified By" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ModifiedBy" runat="server" Text='<%#Eval("ModifiedBy")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="IsDeleted" Visible="False">
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlJobDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Job
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="JobDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%;" valign="top">
                                                                            <div style="width: 1074px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdEmployeeJobDetails" runat="server" AutoGenerateColumns="false"
                                                                                    DataKeyNames="EmployeeId" Width="1624px" OnRowCommand="grdEmployeeJobDetails_RowCommand"
                                                                                    OnRowEditing="grdEmployeeJobDetails_RowEditing" OnRowDeleting="grdEmployeeJobDetails_RowDeleting"
                                                                                    OnRowDataBound="grdEmployeeJobDetails_RowDataBound">
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
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeJobId" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeJobId" runat="server" Text=' <%#Eval("EmployeeJobId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeId" runat="server" Text=' <%#Eval("EmployeeId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Application Date" ItemStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ApplicationDate" runat="server" Text=' <%#Eval("ApplicationDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Interview Date" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_InterviewDate" runat="server" Text='<%#Eval("InterviewDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Joining Date">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_JoiningDate" runat="server" Text='<%#Eval("JoiningDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Confirmation Date" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ConfirmationDate" runat="server" Text='<%#Eval("ConfirmationDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Salarty Stop After" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_SalartyStopAfter" runat="server" Text='<%#Eval("SalartyStopAfter")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Contract Start Date" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ContractStartDate" runat="server" Text='<%#Eval("ContractStartDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ContractEndDate" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ContractEndDate" runat="server" Text='<%#Eval("ContractEndDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Date Of Transfer" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DateOfTransfer" runat="server" Text='<%#Eval("DateOfTransfer")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="PF Start Date" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PFStartDate" runat="server" Text='<%#Eval("PFStartDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EPS Start Date" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EPSStartDate" runat="server" Text='<%#Eval("EPSStartDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ESI SStart Date" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ESISStartDate" runat="server" Text='<%#Eval("ESISStartDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Category" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Category" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="AdharCardNo" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_AdharCardNo" runat="server" Text='<%#Eval("AdharCardNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Status" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Status" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Location" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Location" runat="server" Text='<%#Eval("Location")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Lavel" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Lavel" runat="server" Text='<%#Eval("Lavel")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Grade" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Grade" runat="server" Text='<%#Eval("Grade")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Boss Report To" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_BossReportTo" runat="server" Text='<%#Eval("BossReportTo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Placement By" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PlacementBy" runat="server" Text='<%#Eval("PlacementBy")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ESI Dispensary" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ESIDispensary" runat="server" Text='<%#Eval("ESIDispensary")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="NSS No" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_NSSNo" runat="server" Text='<%#Eval("NSSNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="PS No" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PSNo" runat="server" Text='<%#Eval("PSNo")%>'></asp:Label>
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlQualification" runat="server">
                                                        <HeaderTemplate>
                                                            Qualification
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="QualificationDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr runat="server">
                                                                        <td align="center" style="width: 100%" runat="server">
                                                                            <div style="width: 1074px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdQualification" runat="server" AutoGenerateColumns="False" Width="1074px"
                                                                                    OnRowCommand="grdQualification_RowCommand" OnRowEditing="grdQualification_RowEditing"
                                                                                    OnRowDeleting="grdQualification_RowDeleting" OnRowDataBound="grdQualification_RowDataBound">
                                                                                    <RowStyle BorderWidth="2px" BorderColor="Salmon" />
                                                                                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                        BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                        ForeColor="Snow" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="...">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Container.DataItemIndex%>'
                                                                                                    CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:bottom;" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <ControlStyle ForeColor="#6600FF" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="...">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeQualificationId" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeLeaveId" runat="server" Text=' <%#Eval("EmployeeQualificationId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id" Visible="true">
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
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Item No" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ItemNo" runat="server" Text=' <%#Eval("ItemNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Class Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ClassId" runat="server" Text='<%#Eval("ClassId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Class Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ClassName" runat="server" Text='<%#Eval("ClassName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Passing Year" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PassingYear" runat="server" Text='<%#Eval("PassingYear")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="College/University Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CollegeOrUniversityName" runat="server" Text='<%#Eval("CollegeOrUniversityName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Subject" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Subject" runat="server" Text='<%#Eval("Subject")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Percentage">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Percentage" runat="server" Text='<%#Eval("Percentage")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlEarningDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Earning
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="EarningDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server" align="center">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%" valign="top">
                                                                            <div style="width: 1074px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdEmployeeEarningDetails" runat="server" AutoGenerateColumns="false"
                                                                                    DataKeyNames="EmployeeId" Width="1074px" OnRowCommand="grdEmployeeEarningDetails_RowCommand"
                                                                                    OnRowEditing="grdEmployeeEarningDetails_RowEditing" OnRowDeleting="grdEmployeeEarningDetails_RowDeleting"
                                                                                    OnRowDataBound="grdEmployeeEarningDetails_RowDataBound">
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
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeEarningId" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeEarningId" runat="server" Text=' <%#Eval("EmployeeEarningId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeId" runat="server" Text=' <%#Eval("EmployeeId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Item No" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ItemNo" runat="server" Text=' <%#Eval("ItemNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Allowances" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Allowances" runat="server" Text='<%#Eval("Allowances")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Amount">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Amount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Calc. On" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CalcOn" runat="server" Text='<%#Eval("CalcOn")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Calc. On" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CalcOnEarning" runat="server" Text='<%#Eval("CalcOnEarning")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Payment Mode" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PaymentMode" runat="server" Text='<%#Eval("PaymentMode")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Payment Mode" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_PaymentMode4Earning" runat="server" Text='<%#Eval("PaymentMode4Earning")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Bonus" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Bonus" runat="server" Text='<%#Eval("Bonus")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="O.T." Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_OT" runat="server" Text='<%#Eval("OT")%>'></asp:Label>
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlDeductionDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Deduction
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="DeductionDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server" align="center">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%" valign="top">
                                                                            <div style="width: 1074px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdEmployeeDeductionDetails" runat="server" AutoGenerateColumns="false"
                                                                                    Width="1074px" OnRowCommand="grdEmployeeDeductionDetails_RowCommand" OnRowEditing="grdEmployeeDeductionDetails_RowEditing"
                                                                                    OnRowDeleting="grdEmployeeDeductionDetails_RowDeleting" OnRowDataBound="grdEmployeeDeductionDetails_RowDataBound">
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
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeDeductionId" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeDeductionId" runat="server" Text=' <%#Eval("EmployeeDeductionId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeId" runat="server" Text=' <%#Eval("EmployeeId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Item No" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ItemNo" runat="server" Text=' <%#Eval("ItemNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Deductions" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Deductions" runat="server" Text='<%#Eval("Deductions")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Deduction (%)" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DeductionPercetage" runat="server" Text='<%#Eval("DeductionPercetage")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Amount">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DeductionAmount" runat="server" Text='<%#Eval("DeductionAmount")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Calc. On" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DeductionCalcOn" runat="server" Text='<%#Eval("DeductionCalcOn")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Calc. On" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DeductionCalcOnDesc" runat="server" Text='<%#Eval("DeductionCalcOnDesc")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Payment Mode" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DeductionPayMode" runat="server" Text='<%#Eval("DeductionPayMode")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Payment Mode" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DeductionPayModeDesc" runat="server" Text='<%#Eval("DeductionPayModeDesc")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Limit" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_DeductionLimit" runat="server" Text='<%#Eval("DeductionLimit")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Limit Amount" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LimitAmount" runat="server" Text='<%#Eval("LimitAmount")%>'></asp:Label>
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlLeave" runat="server">
                                                        <HeaderTemplate>
                                                            Leave
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="LeaveDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr runat="server">
                                                                        <td align="center" style="width: 100%" runat="server">
                                                                            <div style="width: 1074px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdEmployeeLeaveDetails" runat="server" AutoGenerateColumns="False"
                                                                                    Width="1074px" OnRowCommand="grdEmployeeLeaveDetails_RowCommand" OnRowEditing="grdEmployeeLeaveDetails_RowEditing"
                                                                                    OnRowDeleting="grdEmployeeLeaveDetails_RowDeleting" OnRowDataBound="grdEmployeeLeaveDetails_RowDataBound">
                                                                                    <RowStyle BorderWidth="2px" BorderColor="Salmon" />
                                                                                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                        BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                        ForeColor="Snow" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="...">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Container.DataItemIndex%>'
                                                                                                    CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:bottom;" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <ControlStyle ForeColor="#6600FF" />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="...">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeLeaveId" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeLeaveId" runat="server" Text=' <%#Eval("EmployeeLeaveId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id" Visible="true">
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
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Item No" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ItemNo" runat="server" Text=' <%#Eval("ItemNo")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Leave Type">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LeaveType" runat="server" Text='<%#Eval("LeaveType")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Opening">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Opening" runat="server" Text='<%#Eval("Opening")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Monthly Earned Type" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_MonthlyEarnedType" runat="server" Text='<%#Eval("MonthlyEarnedType")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Monthly Earned">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_MonthlyEarned" runat="server" Text='<%#Eval("MonthlyEarned")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EarningLeaveAllowedAfter" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EarningLeaveAllowedAfter" runat="server" Text='<%#Eval("EarningLeaveAllowedAfter")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EarningLeaveIn">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EarningLeaveIn" runat="server" Text='<%#Eval("EarningLeaveIn")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ConsumedEL">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ConsumedEL" runat="server" Text='<%#Eval("ConsumedEL")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CasulLeaveAllowedAfter" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CasulLeaveAllowedAfter" runat="server" Text='<%#Eval("CasulLeaveAllowedAfter")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Casual Leave Allowed In" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CasualLeaveAllowedIn" runat="server" Text='<%#Eval("CasualLeaveAllowedIn")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EarnedCL">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EarnedCLt" runat="server" Text='<%#Eval("EarnedCL")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlLeftDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Left
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="LeftDetails" runat="server">
                                                                <table align="center" border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%">
                                                                            <div style="width: 1076px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdEmployeeLeftDetails" runat="server" AutoGenerateColumns="false"
                                                                                    DataKeyNames="EmployeeId" Width="1074px" OnRowCommand="grdEmployeeLeftDetails_RowCommand"
                                                                                    OnRowEditing="grdEmployeeLeftDetails_RowEditing" OnRowDeleting="grdEmployeeLeftDetails_RowDeleting"
                                                                                    OnRowDataBound="grdEmployeeLeftDetails_RowDataBound">
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
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeLeftId" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeLeftId" runat="server" Text=' <%#Eval("EmployeeLeftId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id" ItemStyle-HorizontalAlign="Center" Visible="true">
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
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Left Date" ItemStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LeftDate" runat="server" Text=' <%#Eval("LeftDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Full & Final" Visible="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_FullnFinal" runat="server" Text='<%#Eval("FullnFinal")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Left Reason">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LeftReason" runat="server" Text='<%#Eval("LeftReason")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Leaving Reason 4 PF Dept." Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LeavingReason4PFDepartment" runat="server" Text='<%#Eval("LeavingReason4PFDepartment")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Leaving Reason 4 ESI Dept." Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LeavingReason4ESIDepartment" runat="server" Text='<%#Eval("LeavingReason4ESIDepartment")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CreatedDate" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ModifiedDate" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ModifiedDate" runat="server" Text='<%#Eval("ModifiedDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CreatedBy" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Modified By" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ModifiedBy" runat="server" Text='<%#Eval("ModifiedBy")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="IsDeleted" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_IsDeleted" runat="server" Text='<%#Eval("IsDeleted")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlOthers" runat="server">
                                                        <HeaderTemplate>
                                                            Other
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="OthersDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%;" valign="top">
                                                                            <div style="width: 1074px; height: 560px; overflow: auto;">
                                                                                <asp:GridView ID="grdEmployeeOtherDetails" runat="server" AutoGenerateColumns="false"
                                                                                    DataKeyNames="EmployeeId" Width="1624px" OnRowCommand="grdEmployeeOtherDetails_RowCommand"
                                                                                    OnRowEditing="grdEmployeeOtherDetails_RowEditing" OnRowDeleting="grdEmployeeOtherDetails_RowDeleting"
                                                                                    OnRowDataBound="grdEmployeeOtherDetails_RowDataBound">
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
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="EmployeeOtherId" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_EmployeeOtherId" runat="server" Text=' <%#Eval("EmployeeOtherId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Employee Id" ItemStyle-HorizontalAlign="Center" Visible="true">
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
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Salary Type" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_SalaryTypeId" runat="server" Text=' <%#Eval("SalaryType")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Salary Type" ItemStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_SalaryType" runat="server" Text=' <%#Eval("SalaryTypeId")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Skilled">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Skilled" runat="server" Text='<%#Eval("Skilled")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Category" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Category" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="OT Rate Type" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_OTRateType" runat="server" Text='<%#Eval("OTRateType")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="OT Rate" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_OTRate" runat="server" Text='<%#Eval("OTRate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Late Rate Type" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LateRateType" runat="server" Text='<%#Eval("LateRateType")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Late Penalty Rate">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_LatePenaltyRate" runat="server" Text='<%#Eval("LatePenaltyRate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="IncrementDueDate" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_IncrementDueDate" runat="server" Text='<%#Eval("IncrementDueDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Increment Month" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_IncrementMonth" runat="server" Text='<%#Eval("IncrementMonth")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="BasicPayIncrementAs" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_BasicPayIncrementAs" runat="server" Text='<%#Eval("BasicPayIncrementAs")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Identity Card Validity" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_IdentityCardValidity" runat="server" Text='<%#Eval("IdentityCardValidity")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="SalaryCalculationDays" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_SalaryCalculationDays" runat="server" Text='<%#Eval("SalaryCalculationDays")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="GeneralWorkingHours" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_GeneralWorkingHours" runat="server" Text='<%#Eval("GeneralWorkingHours")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="OTCalculationDays" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_OTCalculationDays" runat="server" Text='<%#Eval("OTCalculationDays")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="OTWorkingHours" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_OTWorkingHours" runat="server" Text='<%#Eval("OTWorkingHours")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="TotalDaysInMonth" Visible="true" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_TotalDaysInMonth" runat="server" Text='<%#Eval("TotalDaysInMonth")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CreatedDate" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ModifiedDate" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ModifiedDate" runat="server" Text='<%#Eval("ModifiedDate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CreatedBy" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_CreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ModifiedBy" Visible="false" ItemStyle-HorizontalAlign="Center"
                                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_ModifiedBy" runat="server" Text='<%#Eval("ModifiedBy")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="IsDeleted" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_IsDeleted" runat="server" Text='<%#Eval("IsDeleted")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="...">
                                                                                            <ItemTemplate>
                                                                                                <asp:Image ID="Img4Delete" runat="server" Style="border: 0px; vertical-align: middle;
                                                                                                    width: 20px" Width="20px" Height="20px" ImageUrl="~/Images/delete_icon.png" Visible="false" />
                                                                                                <asp:Image ID="ImgTick" runat="server" Style="border: 0px; vertical-align: middle;"
                                                                                                    Width="20px" Height="20px" ImageUrl="~/Images/tick_32.png" Visible="true" />
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                </ajax:TabContainer>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="cmdUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
