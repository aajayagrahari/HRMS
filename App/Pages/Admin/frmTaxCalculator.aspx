<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmTaxCalculator.aspx.cs" Inherits="Pages_Admin_frmTaxCalculator" %>

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
            font-size: 12px;
            font-weight: bold;
            color: #000;
            font-family: Times New Roaman;
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
        
        #loginform
        {
            min-width: 250px;
            height: 300px;
            background-color: #ffffff;
            border: 1px solid;
            border-color: #555555;
            padding: 16px 16px;
            border-radius: 4px;
            -webkit-box-shadow: 0px 1px 6px rgba(75, 31, 57, 0.8);
            -moz-box-shadow: 0px 1px 6px rgba(75, 31, 57, 0.8);
            box-shadow: 0px 1px 6px rgba(223, 88, 13, 0.8);
        }
        .modalBackground
        {
            background-color: #333333;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .txt
        {
            color: #505050;
        }
        .redstar
        {
            color: #FF0000;
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
            <table id="Table1" border="0" style="height: 600px;" runat="server" cellpadding="0"
                cellspacing="0" width="100%">
                <tr>
                    <td align="right">
                        <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width: 100%">
                        <ajax:TabContainer ID="TabContainer1" runat="server" CssClass="fancy fancy-green"
                            Height="870px" ScrollBars="Auto" ActiveTabIndex="0" Width="100%">
                            <ajax:TabPanel ID="tbplSalaryStructure" runat="server">
                                <HeaderTemplate>
                                    Tax Calculator
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:Panel ID="SalaryDetails" runat="server">
                                        <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                            <tr>
                                                <td align="left" style="width: 100%">
                                                    <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="left" style="width: 100%">
                                                                <table id="Table6" border="0" cellpadding="0" style="background-color: ActiveBorder"
                                                                    cellspacing="0" width="100%" runat="server">
                                                                    <tr>
                                                                        <td width="100%" align="center" colspan="6">
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="19%" OnSelectedIndexChanged="ddlFinYear_SelectedIndexChanged" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 10%">
                                                                            <asp:Label ID="lblCODE" runat="server" CssClass="Label" Text="CODE"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 23%">
                                                                            <asp:TextBox ID="txtCode" CssClass="TextBoxdesign" runat="server" Width="75%" OnTextChanged="txtCode_TextChanged"
                                                                                AutoPostBack="true"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="width: 10%">
                                                                            <asp:Label ID="lblName" runat="server" CssClass="Label" Text="Name"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 23%">
                                                                            <asp:TextBox ID="txtName" CssClass="TextBoxdesign" runat="server" Width="75%" Enabled="false"></asp:TextBox>
                                                                            <asp:TextBox ID="txtTDSEarningId" CssClass="TextBoxdesign" runat="server" Width="75%" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="txtTDSDeductionId" CssClass="TextBoxdesign" runat="server" Width="75%" Visible="false"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="width: 10%">
                                                                            <asp:Label ID="lblGender" runat="server" CssClass="Label" Text="Gender"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 23%">
                                                                            <asp:DropDownList ID="DDLGender" runat="server" CssClass="TextBoxdesign" Width="86%"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 10%">
                                                                            <asp:Label ID="lblDOJ" runat="server" CssClass="Label" Text="DOJ"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 23%">
                                                                            <asp:TextBox ID="txtDateOfJoining" runat="server" Width="75%" CssClass="TextBoxdesign"
                                                                                Enabled="false"></asp:TextBox>
                                                                            <ajax:CalendarExtender ID="CalendarExtender1" Animated="true" PopupPosition="BottomRight"
                                                                                Format="dd/MM/yyyy" TargetControlID="txtDateOfJoining" runat="server">
                                                                            </ajax:CalendarExtender>
                                                                        </td>
                                                                        <td align="left" style="width: 10%">
                                                                            <asp:Label ID="lblFHName" runat="server" CssClass="Label" Text="F/H Name"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 23%">
                                                                            <asp:TextBox ID="txtfhName" CssClass="TextBoxdesign" runat="server" Width="75%" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="width: 10%">
                                                                            <asp:Label ID="lblUnit" runat="server" CssClass="Label" Text="Unit"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 23%">
                                                                            <asp:TextBox ID="txtUnit" runat="server" MaxLength="30" Width="82%" CssClass="TextBoxdesign"
                                                                                Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 100%">
                                                    <table id="Table2" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                        <tr>
                                                            <td align="left" style="width: 100%">
                                                                <table id="Table3" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                    <tr style="background-color: Orange;">
                                                                        <td align="right" style="width: 100%">
                                                                            <table id="Table4" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">
                                                                                <tr>
                                                                                    <td width="100%" align="right" valign="middle">
                                                                                        <asp:HyperLink ID="btnCalc" runat="server" NavigateUrl="#">
                                                                                             <img style="border: 0px; vertical-align: middle;" alt="" src="../../Images/clc.png" width="25px" /></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <ajax:ModalPopupExtender ID="ModalPopupExtender2" TargetControlID="btnCalc" PopupControlID="popUpPanel"
                                                                                CancelControlID="btnclose" BackgroundCssClass="modalBackground" DropShadow="true"
                                                                                runat="server">
                                                                            </ajax:ModalPopupExtender>
                                                                            <asp:Panel ID="popUpPanel" runat="server">
                                                                                <div id="loginform">
                                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td align="center" style="width: 100%">
                                                                                                        <b>
                                                                                                            <asp:Label ID="lblCalcuLateHRAExemptionsHeading" runat="server" Text="HRA EXEMPTION COMP"
                                                                                                                CssClass="Label"></asp:Label></b>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="background-color: Orange;">
                                                                                                    <td align="center" style="width: 100%">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="background-color: Teal;">
                                                                                                    <td align="center" style="width: 100%">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 100%">
                                                                                                        <table id="Table5" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                                            <tr>
                                                                                                                <td colspan="2" align="left" style="width: 100%">
                                                                                                                    <asp:Label ID="lblHRAPaidToEmployee" runat="server" CssClass="Label" Text="HRA PAID TO THE EMPLOYEE"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 100%" colspan="2">
                                                                                                                    <hr style="color: Black; width: 100%;" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 70%">
                                                                                                                    <asp:Label ID="lblRentPaidByEmployee" runat="server" CssClass="Label" Text="RENT PAID BY EMPLOYEE"></asp:Label>
                                                                                                                </td>
                                                                                                                <td align="left" style="width: 30%">
                                                                                                                    <asp:TextBox ID="txtRentPaidByEmployee" runat="server" Enabled="true" onkeypress="return ValidateNumberOnly(event);"
                                                                                                                        Width="85%" OnTextChanged="txtRentPaidByEmployee_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 70%">
                                                                                                                    <asp:Label ID="lbl10PercentOfBasic" runat="server" CssClass="Label" Text="10% Of BASIC"></asp:Label>
                                                                                                                </td>
                                                                                                                <td align="left" style="width: 30%">
                                                                                                                    <asp:TextBox ID="txt10PercentOfBasic" runat="server" Enabled="false" onkeypress="return ValidateNumberOnly(event);"
                                                                                                                        Width="85%"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 70%">
                                                                                                                    <asp:Label ID="lblRentCalculation" runat="server" CssClass="Label" Text="RENT PAID - 10% Of BASIC"></asp:Label>
                                                                                                                </td>
                                                                                                                <td align="left" style="width: 30%">
                                                                                                                    <asp:TextBox ID="txtRentCalculation" runat="server" Enabled="false" onkeypress="return ValidateNumberOnly(event);"
                                                                                                                        Width="85%"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 70%">
                                                                                                                    <asp:Label ID="lbl4050PercentOfBasic" runat="server" CssClass="Label" Text="40%/50% OF BASIC"></asp:Label>
                                                                                                                </td>
                                                                                                                <td align="left" style="width: 30%">
                                                                                                                    <asp:TextBox ID="txt4050PercentOfBasic" runat="server" Enabled="false" onkeypress="return ValidateNumberOnly(event);"
                                                                                                                        Width="85%"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 70%">
                                                                                                                    <asp:Label ID="lblHRAExemption" runat="server" CssClass="Label" Text="HRA EXEMPTION"></asp:Label>
                                                                                                                </td>
                                                                                                                <td align="left" style="width: 30%">
                                                                                                                    <asp:TextBox ID="txtHRAEXEMPTION" runat="server" Enabled="false" onkeypress="return ValidateNumberOnly(event);"
                                                                                                                        Width="85%"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 100%" colspan="2">
                                                                                                                    <hr style="color: Black; width: 100%;" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="2" align="left" style="width: 100%">
                                                                                                                    <asp:Button ID="btnClick" runat="server" Text="Calc" OnClick="btnClick_Click" /><asp:Button
                                                                                                                        ID="btnOk" runat="server" Text="Fix" OnClick="btnOk_Click" /><asp:Button ID="btnclose"
                                                                                                                            runat="server" Text="Close" CausesValidation="false" OnClick="btnclose_Click" /><asp:Button
                                                                                                                                ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="btnOk" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                            </asp:Panel>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 100%">
                                                                            <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 100%">
                                                                                                                <div style="width: 100%; height: 680px; overflow: auto;">
                                                                                                                    <table id="Table9" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%" style="background-color: ActiveBorder">
                                                                                                                        <tr>
                                                                                                                            <td align="left" style="width: 50%" valign="top">
                                                                                                                                <table id="Table10" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td align="left" style="width: 100%">
                                                                                                                                            <table id="Table11" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%"
                                                                                                                                                style="background-color: ActiveBorder">
                                                                                                                                                <tr>
                                                                                                                                                    <td align="left" style="width: 100%">
                                                                                                                                                        <asp:GridView ID="grdTaxableEarning" runat="server" AutoGenerateColumns="False" DataKeyNames="Particulars4Earning"
                                                                                                                                                            Width="100%" OnRowCommand="grdTaxableEarning_RowCommand" OnRowEditing="grdTaxableEarning_RowEditing"
                                                                                                                                                            OnRowDeleting="grdTaxableEarning_RowDeleting" OnRowDataBound="grdTaxableEarning_RowDataBound">
                                                                                                                                                            <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                                                                                                            <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                                                                                                BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                                                                                            <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                                                                                                ForeColor="Snow" />
                                                                                                                                                            <Columns>
                                                                                                                                                                <asp:TemplateField HeaderText="PARTICULARS">
                                                                                                                                                                    <ItemTemplate>
                                                                                                                                                                        <asp:CheckBox ID="chk_TaxableEarning" runat="server" CssClass="Label"
                                                                                                                                                                            AutoPostBack="true" OnCheckedChanged="chk_TaxableEarning_CheckChanged" />
                                                                                                                                                                        <asp:Label ID="lbl_TaxableEarning" runat="server" Text='<%#Eval("Particulars4Earning")%>' Visible="true"
                                                                                                                                                                            CssClass="Label"></asp:Label>
                                                                                                                                                                    </ItemTemplate>
                                                                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                                                                                                </asp:TemplateField>
                                                                                                                                                                <asp:TemplateField HeaderText="TAXABLE AMOUNT">
                                                                                                                                                                    <ItemTemplate>
                                                                                                                                                                        <asp:TextBox ID="txt_TaxableEarning" runat="server" CssClass="NumericTextBoxdesign"
                                                                                                                                                                            Enabled="false" onkeypress="return ValidateNumberOnly(event);" Width="65%" OnTextChanged="txt_TaxableEarning_TextChanged"
                                                                                                                                                                            AutoPostBack="true"></asp:TextBox>
                                                                                                                                                                    </ItemTemplate>
                                                                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                                                                </asp:TemplateField>
                                                                                                                                                            </Columns>
                                                                                                                                                        </asp:GridView>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </td>
                                                                                                                            <td align="left" style="width: 50%" valign="top">
                                                                                                                                <table id="Table12" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td align="left" style="width: 100%">
                                                                                                                                            <table id="Table13" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%"
                                                                                                                                                style="background-color: ActiveBorder">
                                                                                                                                                <tr>
                                                                                                                                                    <td align="left" style="width: 100%">
                                                                                                                                                        <asp:GridView ID="grdTaxableDeduction" runat="server" AutoGenerateColumns="False"
                                                                                                                                                            DataKeyNames="Particulars4Deduction" Width="100%" OnRowCommand="grdTaxableDeduction_RowCommand"
                                                                                                                                                            OnRowEditing="grdTaxableDeduction_RowEditing" OnRowDeleting="grdTaxableDeduction_RowDeleting"
                                                                                                                                                            OnRowDataBound="grdTaxableDeduction_RowDataBound">
                                                                                                                                                            <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                                                                                                            <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                                                                                                BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                                                                                            <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                                                                                                ForeColor="Snow" />
                                                                                                                                                            <Columns>
                                                                                                                                                                <asp:TemplateField HeaderText="PARTICULARS">
                                                                                                                                                                    <ItemTemplate>
                                                                                                                                                                        <asp:CheckBox ID="chk_TaxableDeduction" runat="server" CssClass="Label"
                                                                                                                                                                            AutoPostBack="true" OnCheckedChanged="chk_TaxableDeduction_CheckChanged" />
                                                                                                                                                                        <asp:Label ID="lbl_TaxableDeduction" runat="server" Text='<%#Eval("Particulars4Deduction")%>' Visible="true"
                                                                                                                                                                            CssClass="Label"></asp:Label>
                                                                                                                                                                    </ItemTemplate>
                                                                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                                                                                                </asp:TemplateField>
                                                                                                                                                                <asp:TemplateField HeaderText="TAXABLE AMOUNT">
                                                                                                                                                                    <ItemTemplate>
                                                                                                                                                                        <asp:TextBox ID="txt_TaxableDeduction" runat="server" CssClass="NumericTextBoxdesign"
                                                                                                                                                                            Enabled="false" onkeypress="return ValidateNumberOnly(event);" Width="65%" OnTextChanged="txt_TaxableDeduction_TextChanged"
                                                                                                                                                                            AutoPostBack="true"></asp:TextBox>
                                                                                                                                                                    </ItemTemplate>
                                                                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                                                                                                </asp:TemplateField>
                                                                                                                                                            </Columns>
                                                                                                                                                        </asp:GridView>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
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
                                                                    <tr style="background-color: Orange;">
                                                                        <td align="center" style="width: 100%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: Teal;">
                                                                        <td align="center" style="width: 100%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" style="width: 100%">
                                                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
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
                    <td align="center" style="width: 100%">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
