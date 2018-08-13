<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmEmployeePromotion.aspx.cs" Inherits="Pages_Admin_frmEmployeePromotion" %>

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
    <script type="text/javascript" language="javascript">
        function ValidateNumberOnly() {
            if ((event.keyCode < 48 || event.keyCode > 57)) {
                event.returnValue = false;
            }
        }

    </script>
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
                                    <asp:Label ID="lblPageHeader" runat="server" Text="Employee Promotion" CssClass="pageHeading"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100%">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%">
                                    <hr style="color: Black; width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%">
                                    <table border="1" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" style="width: 40%">
                                                <table border="0" runat="server" cellpadding="0" cellspacing="0" width="93%" style="background-color: ActiveBorder">
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" CssClass="Label" Text="Employee Id"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:DropDownList ID="DDLEmployeeId" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                AutoPostBack="true" OnSelectedIndexChanged="DDLEmployeeId_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblEmployeeType" runat="server" CssClass="Label" Text="Employee Type"></asp:Label>
                                                            <asp:Label ID="Label24" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:DropDownList ID="DDlEmployeeType" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                AutoPostBack="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblFirstName" CssClass="Label" runat="server" Text="First Name"></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                            <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator2" runat="server"
                                                                ErrorMessage="*" ToolTip="Please Enter the First Name" SetFocusOnError="true"
                                                                ControlToValidate="txtFirstName" ValidationGroup="Req_Blank" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblMiddleName" CssClass="Label" runat="server" Text="Middle Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" style="width: 33%">
                                                <table border="0" runat="server" cellpadding="0" cellspacing="0" width="93%" style="background-color: ActiveBorder">
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblLastName" CssClass="Label" runat="server" Text="Last Name"></asp:Label>
                                                            <asp:Label ID="Label16" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                            <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator12" runat="server"
                                                                ErrorMessage="*" ToolTip="Please Enter the Last Name" SetFocusOnError="true"
                                                                ControlToValidate="txtLastName" ValidationGroup="Req_Blank" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblFatherName" runat="server" CssClass="Label" Text="Father Name"></asp:Label>
                                                            <asp:Label ID="Label22" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtFatherName" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                            <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator13" runat="server"
                                                                ErrorMessage="*" ToolTip="Please Enter Father Name" SetFocusOnError="true" ControlToValidate="txtFatherName"
                                                                ValidationGroup="Req_Blank" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblDept" runat="server" CssClass="Label" Text="Department"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:DropDownList ID="DDLDepartment" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                AutoPostBack="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" CssClass="Label" Text="Designation"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:DropDownList ID="DDLDesignation" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                AutoPostBack="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" style="width: 27%">
                                                <table border="0" runat="server" cellpadding="0" cellspacing="0" width="97%" style="background-color: ActiveBorder">
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblUnit" CssClass="Label" runat="server" Text="Unit"></asp:Label>
                                                            <asp:Label ID="Label21" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtUnit" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                            <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator1" runat="server"
                                                                ErrorMessage="*" ToolTip="Please Enter Unit Name" SetFocusOnError="true" ControlToValidate="txtUnit"
                                                                ValidationGroup="Req_Blank" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblSubUnit" runat="server" CssClass="Label" Text="Sub-Unit"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtSubUnit" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblPFNo" CssClass="Label" runat="server" Text="PF No."></asp:Label>
                                                            <asp:Label ID="Label23" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtPFNo" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                            <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator14" runat="server"
                                                                ErrorMessage="*" ToolTip="Please Enter PF No." SetFocusOnError="true" ControlToValidate="txtPFNo"
                                                                ValidationGroup="Req_Blank" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblEsiNo" runat="server" CssClass="Label" Text="Esi No."></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtEsiNo" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width: 100%;">
                                    <table border="0" style="height: 600px;" runat="server" cellpadding="0" cellspacing="0"
                                        width="100%">
                                        <tr>
                                            <td align="left" valign="top">
                                                <ajax:TabContainer ID="TabContainer1" runat="server" CssClass="fancy fancy-green"
                                                    Height="530px" ActiveTabIndex="0" ScrollBars="Auto">
                                                    <ajax:TabPanel ID="tbplPromotionDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Promotion Details
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="EmployeeDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="60%" align="center">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%;" valign="top">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td align="center" style="width: 100%;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%" colspan="2">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblPramotionDate" runat="server" CssClass="Label" Text="Promotion Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 50%">
                                                                                                                <asp:TextBox ID="txtPromotionDate" runat="server" Width="30%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender11" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtPromotionDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                <asp:TextBox ID="txtJoningDate" runat="server" Width="30%" CssClass="TextBoxdesign"
                                                                                                                    Visible="false" Enabled="false"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblNewPostion" runat="server" CssClass="Label" Text="New Department"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:DropDownList ID="DDLNewDept" runat="server" CssClass="TextBoxdesign" Width="33%"
                                                                                                        AutoPostBack="false">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblNewDesignation" runat="server" CssClass="Label" Text="New Designation"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:DropDownList ID="DDlNewDesignation" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="33%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                                                                <table border="1" cellpadding="0" cellspacing="0" width="90%" runat="server" align="center">
                                                                    <tr runat="server">
                                                                        <td align="left" style="width: 100%" valign="top" runat="server">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                <tr runat="server">
                                                                                    <td align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                                        <div style="width: 100%; height: 510px; overflow: auto;">
                                                                                            <asp:GridView ID="grdEmployeeMasterDetails" runat="server" AutoGenerateColumns="False"
                                                                                                DataKeyNames="Allowances" Width="100%" OnRowCommand="grdEmployeeMasterDetails_RowCommand"
                                                                                                OnRowEditing="grdEmployeeMasterDetails_RowEditing" OnRowDeleting="grdEmployeeMasterDetails_RowDeleting"
                                                                                                OnRowDataBound="grdEmployeeMasterDetails_RowDataBound">
                                                                                                <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                                                <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                                    BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                                <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                                    ForeColor="Snow" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Allowances">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chk_Allowance" runat="server" CssClass="Label" Text='<%#Eval("Allowances")%>'
                                                                                                                AutoPostBack="true" OnCheckedChanged="chk_Allowance_CheckChanged" />
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Amount" Visible="true">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txt_Amount" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="85%"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="New Amount">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txt_NewAmount" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="85%" OnTextChanged="txt_NewAmount_TextChanged"
                                                                                                                AutoPostBack="true"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Calc On">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlCalcOn" Width="150px" Enabled="false" runat="server" CssClass="TextBoxdesign">
                                                                                                            </asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="PayMode">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlPayMode" Width="150px" Enabled="false" runat="server" CssClass="TextBoxdesign"
                                                                                                                OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged" AutoPostBack="true">
                                                                                                            </asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Bonus">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chk_Bonus" runat="server" Enabled="false" />
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="OT">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chk_OT" runat="server" Enabled="false" />
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="ItemNo" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txt_ItemNo" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="25%"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlDeductionDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Deduction
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="DeductionDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="90%" runat="server" align="center">
                                                                    <tr runat="server">
                                                                        <td align="left" style="width: 100%" valign="top" runat="server">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                <tr id="Tr1" runat="server">
                                                                                    <td id="Td1" align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                                        <div style="width: 100%; height: 510px; overflow: auto;">
                                                                                            <asp:GridView ID="grdDeduction" runat="server" AutoGenerateColumns="False" DataKeyNames="Deductions"
                                                                                                Width="100%" OnRowCommand="grdDeduction_RowCommand" OnRowEditing="grdDeduction_RowEditing"
                                                                                                OnRowDeleting="grdDeduction_RowDeleting" OnRowDataBound="grdDeduction_RowDataBound">
                                                                                                <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                                                <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                                    BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                                <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                                    ForeColor="Snow" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Deductions">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chk_Deductions" runat="server" CssClass="Label" Text='<%#Eval("Deductions")%>'
                                                                                                                AutoPostBack="true" OnCheckedChanged="chk_Deductions_CheckChanged" />
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Percentage">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txt_Percentage" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="70px" Text='<%#Eval("DeductionPercentage")%>'></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Amount" Visible="true">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txt_Amount4D" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="80px"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="New Amount">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txt_NewAmount4D" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="80px"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Calc On">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlCalcOn4D" Width="150px" Enabled="false" runat="server" CssClass="TextBoxdesign">
                                                                                                            </asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="PayMode">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlPayMode4D" Width="150px" Enabled="false" runat="server"
                                                                                                                OnSelectedIndexChanged="ddlPayMode4D_SelectedIndexChanged" AutoPostBack="true"
                                                                                                                CssClass="TextBoxdesign">
                                                                                                            </asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Limit">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chk_NewLimit" runat="server" Enabled="false" AutoPostBack="true"
                                                                                                                OnCheckedChanged="chkLimit_CheckedChanged" /><br />
                                                                                                            <asp:TextBox ID="txt_NewLimitAmount" runat="server" CssClass="TextBoxdesign" Visible="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" OnTextChanged="txt_LimitAmount_TextChanged"
                                                                                                                AutoPostBack="true" Width="65px"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Old Limit" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chk_OldLimit" runat="server" Enabled="false" /><br />
                                                                                                            <asp:TextBox ID="txt_OldLimitAmount" runat="server" CssClass="TextBoxdesign" onkeypress="return ValidateNumberOnly(event);"
                                                                                                                Width="65px"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="ItemNo" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="txt_ItemNo" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="25%"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlLeave" runat="server">
                                                        <HeaderTemplate>
                                                            Leave
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="LeaveDetails" runat="server">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr runat="server">
                                                                        <td align="center" style="width: 100%" runat="server" valign="top">
                                                                            <table align="center" border="1" cellpadding="0" cellspacing="0" width="90%" runat="server">
                                                                                <tr runat="server">
                                                                                    <td align="center" style="width: 100%" runat="server">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                            <tr id="Tr2" runat="server">
                                                                                                <td align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                                                    <div style="width: 100%; height: 270px; overflow: auto;">
                                                                                                        <asp:GridView ID="grdLeave" runat="server" AutoGenerateColumns="False" DataKeyNames="LeaveTypeId"
                                                                                                            Width="100%" OnRowCommand="grdLeave_RowCommand" OnRowEditing="grdLeave_RowEditing"
                                                                                                            OnRowDeleting="grdLeave_RowDeleting" OnRowDataBound="grdLeave_RowDataBound">
                                                                                                            <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                                                            <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                                                BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                                            <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                                                ForeColor="Snow" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Leave">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="chk_LeaveTypeId" runat="server" CssClass="Label" Text='<%#Eval("LeaveTypeId")%>'
                                                                                                                            AutoPostBack="true" OnCheckedChanged="chk_LeaveTypeId_CheckChanged" />
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Opening" Visible="true">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_Opening" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            Width="70px" Text='<%#Eval("LeaveAllowed")%>'></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Opening">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_NewOpening" runat="server" CssClass="TextBoxdesign" Enabled="true"
                                                                                                                            Width="70px" Text='<%#Eval("LeaveAllowed")%>'></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Monthly Earned Type">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:RadioButtonList ID="rbtn_MonthlyEarnedType" runat="server" RepeatDirection="Horizontal"
                                                                                                                            CssClass="Label" BorderWidth="1px" RepeatColumns="3">
                                                                                                                            <asp:ListItem Value="1" Text="Automatic" Selected="True"></asp:ListItem>
                                                                                                                            <asp:ListItem Value="2" Text="Specified"></asp:ListItem>
                                                                                                                            <asp:ListItem Value="3" Text="Not Required"></asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Monthly Earned">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_MonthlyEarned" runat="server" CssClass="TextBoxdesign" Visible="false"
                                                                                                                            Width="45px"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="ItemNo" Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_ItemNo" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            onkeypress="return ValidateNumberOnly(event);" Width="25%"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 100%" runat="server">
                                                                                                    <hr style="color: Black; width: 100%;" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr runat="server">
                                                                                    <td align="left" style="width: 100%" runat="server">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr runat="server">
                                                                                    <td align="center" style="width: 100%" runat="server">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 20%;" colspan="2" runat="server">
                                                                                                    <asp:CheckBox ID="chkLeaveValidation" runat="server" CssClass="Label" Text="Leave Validation Check Here"
                                                                                                        AutoPostBack="True" OnCheckedChanged="chkLeaveValidation_CheckedChanged" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 100%" colspan="2" runat="server">
                                                                                                    <hr style="color: Black; width: 100%;" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblfromTheDateOfjoiningEarningLeaveAllowedAfter" runat="server"
                                                                                                        Text="From The Date of Joining, Earning Leave Allowed After" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    <asp:TextBox ID="txtEarningLeaveAllowdAfter" runat="server" MaxLength="10" Width="35%"
                                                                                                        CssClass="TextBoxdesign" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                    <asp:DropDownList ID="DDLEarningLeaveAllowed" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="30%">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblOnlyLastYearConsumed" runat="server" Text="Only Last Year Earned EL, can Consumed in Current Year"
                                                                                                        CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    <asp:CheckBox ID="chkOnlyLastYearConsumed" runat="server" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblCasualLeaveAllowedAfter" runat="server" Text="From The Date of Joining, Casual Leave Allowed After"
                                                                                                        CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    <asp:TextBox ID="txtCasualLeaveAllowedAfter" runat="server" MaxLength="10" Width="35%"
                                                                                                        CssClass="TextBoxdesign" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                    <asp:DropDownList ID="DDLCasualLeaveAllowedAfter" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="30%">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblCLConsumedinCurrentYear" runat="server" Text="Only Last Year Earned CL, can Consumed in Current Year"
                                                                                                        CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 50%;" runat="server">
                                                                                                    <asp:CheckBox ID="chkCLConsumedinCurrentYear" runat="server" />
                                                                                                    <asp:TextBox ID="txtItemNo4Leave" runat="server" MaxLength="10" Width="35%" Visible="False"
                                                                                                        CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 100%" colspan="2" runat="server">
                                                                                                    <hr style="color: Black; width: 100%;" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                </ajax:TabContainer>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="bottom">
                                                &nbsp;<asp:Button ID="btnSubmit" runat="server" ValidationGroup="Req_Blank" Text="Submit"
                                                    Width="7%" OnClick="btnSubmit_Click" />
                                                &nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="7%" OnClick="btnCancel_Click" />
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
