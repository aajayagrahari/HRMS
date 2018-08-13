<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmEmployeeMaster.aspx.cs" Inherits="Pages_Admin_frmEmployeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 <script src="../../Js/top-to-bottom.js"></script>
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

        function CheckInterviewDate() {
            debugger;
            var ApplicationDate = document.getElementById("<%=txtApplicationDate.ClientID%>").value;
            var InterViewDate = document.getElementById("<%=txtInterViewDate.ClientID%>").value;
            var JoiningDate = document.getElementById("<%=txtJoiningDate.ClientID%>").value;
            if (InterViewDate < ApplicationDate) {
                alert("Please ensure that the Application Date is greater than or equal to the InterView Date.");
                InterViewDate.focus();
                return false;
            }
        }
        function CheckJoiningDate() {
            debugger;
            var ApplicationDate = document.getElementById("<%=txtApplicationDate.ClientID%>").value;
            var InterViewDate = document.getElementById("<%=txtInterViewDate.ClientID%>").value;
            var JoiningDate = document.getElementById("<%=txtJoiningDate.ClientID%>").value;
            if (JoiningDate < ApplicationDate && JoiningDate < InterViewDate) {
                alert("Please ensure that the Application/Interview Date is greater than or equal to the Joining Date.");
                JoiningDate.focus();
                return false;
            }
        }
        function DateValidation() {
            debugger;
            var InterviewDate = document.getElementById('<%=txtInterViewDate.ClientID%>');
            var InterviewDateD = new Date(InterviewDate.value.split('/')[2], InterviewDate.value.split('/')[1] - 1, InterviewDate.value.split('/')[0]);
            var JoiningDate = document.getElementById('<%=txtJoiningDate.ClientID%>');
            var JoiningDateD = new Date(JoiningDate.value.split('/')[2], JoiningDate.value.split('/')[1] - 1, JoiningDate.value.split('/')[0]);
            if (JoiningDateD < InterviewDateD) {
               // JoiningDate.style.backgroundColor = "Yellow";
                alert('Please ensure that the Interview Date is greater than or equal to the Joining Date.');
                JoiningDate.focus();
                return false;
            }
            else {
                JoiningDate.style.backgroundColor = '';
                return true;
            }
        }
        
    </script>
    <script type="text/jscript">
        jQuery(document).ready(function () {
            var offset = 220;
            var duration = 500;
            jQuery(window).scroll(function () {
                if (jQuery(this).scrollTop() > offset) {
                    jQuery('.back-to-top').fadeIn(duration);
                } else {
                    jQuery('.back-to-top').fadeOut(duration);
                }
            });

            jQuery('.back-to-top').click(function (event) {
                event.preventDefault();
                jQuery('html, body').animate({ scrollTop: 0 }, duration);
                return false;
            })
        });
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
                                    <table id="Table3" border="0" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" style="width: 50%">
                                                <asp:Label ID="lblPageHeader" runat="server" Text="Employee Master" CssClass="pageHeading"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 50%">
                                                <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
                                                <a href="#" class="back-to-top">Back to Top</a>
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
                                <td align="left" style="width: 100%">
                                    <table id="Table4" border="1" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" style="width: 40%">
                                                <table id="Table5" border="0" runat="server" cellpadding="0" cellspacing="0" width="93%" style="background-color: ActiveBorder">
                                                    <tr>
                                                        <td align="left" style="width: 100%" colspan="2">
                                                            <table id="Table6" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 35%">
                                                                        &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" CssClass="Label" Text="Employee Id"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="width: 20%">
                                                                        <asp:TextBox ID="txtEmployeeId" runat="server" Text="New" MaxLength="30" Width="70%"
                                                                            CssClass="TextBoxdesign" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" style="width: 20%">
                                                                        &nbsp;&nbsp;<asp:Label ID="lblPCardNo" runat="server" CssClass="Label" Text="P.Card No."></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="width: 25%">
                                                                        <asp:TextBox ID="txtPCardNo" runat="server" Text="New" MaxLength="30" Width="62%"
                                                                            CssClass="TextBoxdesign" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                                <table id="Table7" border="0" runat="server" cellpadding="0" cellspacing="0" width="93%" style="background-color: ActiveBorder">
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
                                                <table id="Table8" border="0" runat="server" cellpadding="0" cellspacing="0" width="97%" style="background-color: ActiveBorder">
                                                    <tr>
                                                        <td align="left" style="width: 35%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblUnit" CssClass="Label" runat="server" Text="Unit"></asp:Label>
                                                            <asp:Label ID="Label21" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 65%">
                                                            <asp:TextBox ID="txtUnit" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"
                                                                OnTextChanged="txtUnit_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtEsiNo" runat="server" MaxLength="30" Width="85%" CssClass="TextBoxdesign"
                                                                OnTextChanged="txtEsiNo_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                                    <table id="Table9" border="0" style="height: 600px;" runat="server" cellpadding="0" cellspacing="0"
                                        width="100%">
                                        <tr>
                                            <td align="left" valign="top">
                                                <ajax:TabContainer ID="TabContainer1" runat="server" CssClass="fancy fancy-green"
                                                    Height="570px" ActiveTabIndex="0" ScrollBars="Auto">
                                                    <ajax:TabPanel ID="tbplEmployeeDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Personal
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="EmployeeDetails" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="left" style="width: 50%;" valign="top">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblAliasName" runat="server" CssClass="Label" Text="Alias Name"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%">
                                                                                                                <asp:TextBox ID="txtAliasName" runat="server" MaxLength="50" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblNickName" runat="server" CssClass="Label" Text="Nick Name"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%">
                                                                                                                <asp:TextBox ID="txtNickName" runat="server" MaxLength="50" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
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
                                                                                    <td align="left" style="width: 100%;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblAddress" runat="server" CssClass="Label" Text="Local Address"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" Width="86%" TextMode="MultiLine"
                                                                                                        CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblCity" runat="server" CssClass="Label" Text="City"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="30" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblZipCode" runat="server" CssClass="Label" Text="Zip Code"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtZipCode" runat="server" MaxLength="6" Width="30%" CssClass="TextBoxdesign"
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblCountry" runat="server" CssClass="Label" Text="Country"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:DropDownList ID="DDLCountry" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                                                        AutoPostBack="True" OnSelectedIndexChanged="DDLCountry_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblState" runat="server" CssClass="Label" Text="State"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:DropDownList ID="DDLState" runat="server" CssClass="TextBoxdesign" Width="90%">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblContactNo" runat="server" CssClass="Label" Text="ContactNo"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtContactNo" runat="server" MaxLength="14" Width="30%" CssClass="TextBoxdesign"
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblEmailId" runat="server" CssClass="Label" Text="Email Id"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtEmailId" runat="server" MaxLength="40" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblParmaNentAddress" runat="server" CssClass="Label" Text="Permanent Address"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtPermanentAddress" runat="server" MaxLength="50" Width="86%" TextMode="MultiLine"
                                                                                                        CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblPrmanentCity" runat="server" CssClass="Label" Text="City"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtPermanentCity" runat="server" MaxLength="30" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblPermanentZip" runat="server" CssClass="Label" Text="Zip Code"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtPermanentZip" runat="server" MaxLength="6" Width="30%" CssClass="TextBoxdesign"
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblPermanentCountry" runat="server" CssClass="Label" Text="Country"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:DropDownList ID="DDLPermanentCountry" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DDLPermanentCountry_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblPermanentState" runat="server" CssClass="Label" Text="State"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:DropDownList ID="DDLPermanentState" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%; height: 54px;" valign="bottom">
                                                                                                    <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click">
                                                                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" />
                                                                                                    </asp:LinkButton>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%; height: 54px;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                <asp:Label ID="lblCityType" CssClass="Label" runat="server" Text="City Type"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%">
                                                                                                                <asp:RadioButtonList ID="rblCityType" CssClass="Label" runat="server" RepeatColumns="2"
                                                                                                                    RepeatDirection="Horizontal">
                                                                                                                    <asp:ListItem Selected="True" Text="Metro" Value="M"></asp:ListItem>
                                                                                                                    <asp:ListItem Text="Non Metro" Value="NM"></asp:ListItem>
                                                                                                                </asp:RadioButtonList>
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
                                                                        <td align="left" style="width: 50%;" valign="top">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblPlaceOfBirth" runat="server" CssClass="Label" Text="Place Of Birth"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtPlaceOfBirth" runat="server" MaxLength="50" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                    <asp:TextBox ID="txtPlaceOfBirth1" runat="server" MaxLength="50" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblRationCardNo" runat="server" CssClass="Label" Text="Ration Card No."></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtRationCardNo" runat="server" MaxLength="20" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblVoterId" runat="server" CssClass="Label" Text="Voter Id"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtVoterId" runat="server" MaxLength="20" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblPanNo" runat="server" CssClass="Label" Text="PAN No."></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtPANNo" runat="server" MaxLength="20" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblPasportNo" runat="server" CssClass="Label" Text="Pass Port No."></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtPassportNo" runat="server" MaxLength="20" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblDLNo" runat="server" CssClass="Label" Text="D/L No."></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtDLNo" runat="server" MaxLength="20" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblValidUpto" runat="server" CssClass="Label" Text="Valid Upto"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtValidUpto" runat="server" Width="30%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                    <ajax:CalendarExtender ID="CalendarExtender14" PopupPosition="BottomRight" Format="dd/MM/yyyy"
                                                                                                        TargetControlID="txtValidUpto" runat="server" Enabled="True">
                                                                                                    </ajax:CalendarExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblIdentityMarks" runat="server" CssClass="Label" Text="Identity Marks"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtIdentityMarks" runat="server" MaxLength="100" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblReligion" runat="server" CssClass="Label" Text="Religion"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtReligion" runat="server" MaxLength="20" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblNationality" runat="server" CssClass="Label" Text="Nationality"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtNationality" runat="server" MaxLength="20" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
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
                                                                                    <td align="left" style="width: 100%;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblDateOfBirth" runat="server" CssClass="Label" Text="Date Of Birth"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtDateOfBirth" runat="server" Width="30%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                    <ajax:CalendarExtender ID="CalendarExtender15" PopupPosition="BottomRight" Format="dd/MM/yyyy"
                                                                                                        TargetControlID="txtDateOfBirth" runat="server" Enabled="True">
                                                                                                    </ajax:CalendarExtender>
                                                                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblRetirementDate" runat="server" CssClass="Label" Text="Retirement Date"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:TextBox ID="txtRetirementDate" runat="server" Width="30%" CssClass="TextBoxdesign"
                                                                                                        Enabled="false"></asp:TextBox>
                                                                                                    <ajax:CalendarExtender ID="CalendarExtender16" PopupPosition="BottomRight" Format="dd/MM/yyyy"
                                                                                                        TargetControlID="txtRetirementDate" runat="server" Enabled="True">
                                                                                                    </ajax:CalendarExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%" colspan="2">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                                                        <tr id="Tr1" runat="server">
                                                                                                            <td id="Td1" align="left" style="width: 25%" runat="server">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblGender" runat="server" CssClass="Label" Text="Gender/Sex"></asp:Label>
                                                                                                            </td>
                                                                                                            <td id="Td2" align="left" style="width: 30%" runat="server">
                                                                                                                <asp:DropDownList ID="DDLGender" runat="server" CssClass="TextBoxdesign" Width="86%">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                            <td id="Td3" align="left" style="width: 15%" runat="server">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblHeight" runat="server" CssClass="Label" Text="Height(cms)"
                                                                                                                    onkeypress="return ValidateNumberOnly(event);"></asp:Label>
                                                                                                            </td>
                                                                                                            <td id="Td4" align="left" style="width: 30%" runat="server">
                                                                                                                <asp:TextBox ID="txtHeight" runat="server" MaxLength="20" Width="70%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 25%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblBloodGroup" runat="server" CssClass="Label" Text="Blood Group"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 75%">
                                                                                                    <asp:DropDownList ID="DDLBloodGroup" runat="server" CssClass="TextBoxdesign" Width="34%">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%" colspan="2">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                                                        <tr id="Tr2" runat="server">
                                                                                                            <td id="Td5" align="left" style="width: 26%" runat="server">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblMaritalStatus" runat="server" CssClass="Label" Text="Marital Status"></asp:Label>
                                                                                                            </td>
                                                                                                            <td id="Td6" align="left" style="width: 29%" runat="server">
                                                                                                                <asp:DropDownList ID="DDLMaritalStatus" runat="server" CssClass="TextBoxdesign" Width="90%">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                            <td id="Td7" align="left" style="width: 10%" runat="server">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblDate" runat="server" CssClass="Label" Text="Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td id="Td8" align="left" style="width: 30%" runat="server">
                                                                                                                <asp:TextBox ID="txtDate" runat="server" Width="75%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender17" PopupPosition="BottomRight" Format="dd/MM/yyyy"
                                                                                                                    TargetControlID="txtDate" runat="server" Enabled="True">
                                                                                                                </ajax:CalendarExtender>
                                                                                                                &nbsp;
                                                                                                            </td>
                                                                                                            <td id="Td9" align="left" style="width: 5%" runat="server">
                                                                                                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbtnNext_Click">
                                                                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Back.png" Width="36px" />
                                                                                                                </asp:LinkButton>
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
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlJobDetails" runat="server">
                                                        <HeaderTemplate>
                                                            Job
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="JobDetails" runat="server">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr>
                                                                        <td align="left" style="width: 100%" colspan="2">
                                                                            <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                                <tr>
                                                                                    <td align="left" style="width: 50%;" valign="top">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="98%" runat="server">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblApplicationDate" runat="server" CssClass="Label" Text="Application Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                <asp:TextBox ID="txtApplicationDate" runat="server" Width="75%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtenderDispatch_date" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtApplicationDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 20%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblInterviewDate" runat="server" CssClass="Label" Text="Interview Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 30%;">
                                                                                                                <asp:TextBox ID="txtInterViewDate" runat="server" Width="70%" CssClass="TextBoxdesign"
                                                                                                                    onchange="CheckInterviewDate();"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender1" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtInterViewDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 65%">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 38%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblJoiningDate" runat="server" CssClass="Label" Text="Joining Date"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 62%">
                                                                                                                            <asp:TextBox ID="txtJoiningDate" runat="server" Width="50%" CssClass="TextBoxdesign"
                                                                                                                                AutoPostBack="true" OnTextChanged="txtJoiningDate_TextChanged" onchange="DateValidation();"></asp:TextBox>
                                                                                                                            <ajax:CalendarExtender ID="CalendarExtender2" Animated="true" PopupPosition="BottomRight"
                                                                                                                                Format="dd/MM/yyyy" TargetControlID="txtJoiningDate" runat="server">
                                                                                                                            </ajax:CalendarExtender>
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblDaysCalculation" runat="server" CssClass="Label"></asp:Label>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 38%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblConfirmationDate" runat="server" CssClass="Label" Text="Confirmation Date"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 62%">
                                                                                                                            <asp:TextBox ID="txtConfirmationDate" runat="server" Width="50%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                            <ajax:CalendarExtender ID="CalendarExtender3" Animated="true" PopupPosition="BottomRight"
                                                                                                                                Format="dd/MM/yyyy" TargetControlID="txtConfirmationDate" runat="server">
                                                                                                                            </ajax:CalendarExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 38%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblSalaryStopAfter" runat="server" CssClass="Label" Text="Salary Stop After"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 62%">
                                                                                                                            <asp:TextBox ID="txtSalaryStopAfter" runat="server" Width="50%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                            <ajax:CalendarExtender ID="CalendarExtender4" Animated="true" PopupPosition="BottomRight"
                                                                                                                                Format="dd/MM/yyyy" TargetControlID="txtSalaryStopAfter" runat="server">
                                                                                                                            </ajax:CalendarExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 35%">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" runat="server">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 100%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblAppointMentLetterIssueDate" runat="server" CssClass="Label"
                                                                                                                                Text="Appointment Letter Issue Date"></asp:Label><br />
                                                                                                                            <asp:TextBox ID="txtAppointMentLetterIssueDate" runat="server" Width="90%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                            <ajax:CalendarExtender ID="CalendarExtender18" Animated="true" PopupPosition="BottomRight"
                                                                                                                                Format="dd/MM/yyyy" TargetControlID="txtAppointMentLetterIssueDate" runat="server">
                                                                                                                            </ajax:CalendarExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 100%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblContractPeriod" runat="server" CssClass="Label" Text="Contract Period"></asp:Label><br />
                                                                                                                            <asp:TextBox ID="txtContrctPeriod" runat="server" MaxLength="10" Width="30%" CssClass="TextBoxdesign"
                                                                                                                                onkeypress="return ValidateNumberOnly(event);" OnTextChanged="txtContrctPeriod_TextChanged"
                                                                                                                                AutoPostBack="true"></asp:TextBox>
                                                                                                                            <asp:DropDownList ID="ddlContractPeriod" runat="server" CssClass="TextBoxdesign"
                                                                                                                                OnSelectedIndexChanged="ddlContractPeriod_SelectedIndexChanged" AutoPostBack="true"
                                                                                                                                Width="50%">
                                                                                                                            </asp:DropDownList>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
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
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblContractStartDate" runat="server" CssClass="Label"
                                                                                                                    Text="Contract Start Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                <asp:TextBox ID="txtContractStartDate" runat="server" Width="80%" CssClass="TextBoxdesign"
                                                                                                                    OnTextChanged="txtContractStartDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender5" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtContractStartDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblContractEndDate" runat="server" CssClass="Label" Text="Contract End Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                <asp:TextBox ID="txtContractEndDate" runat="server" Width="70%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender6" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtContractEndDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblDateOfTransfer" runat="server" CssClass="Label" Text="Date Of Transfer"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%">
                                                                                                                <asp:TextBox ID="txtDateOfTransfer" runat="server" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender7" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtDateOfTransfer" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblPFStartDate" runat="server" CssClass="Label" Text="PF Start Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%">
                                                                                                                <asp:TextBox ID="txtPFStartDate" runat="server" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender8" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtPFStartDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblEPStartDate" runat="server" CssClass="Label" Text="EPS Start Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%">
                                                                                                                <asp:TextBox ID="txtEPSStartDate" runat="server" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender9" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtEPSStartDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblESIStartDate" runat="server" CssClass="Label" Text="ESI Start Date"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%">
                                                                                                                <asp:TextBox ID="txtESIStartDate" runat="server" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                <ajax:CalendarExtender ID="CalendarExtender10" Animated="true" PopupPosition="BottomRight"
                                                                                                                    Format="dd/MM/yyyy" TargetControlID="txtESIStartDate" runat="server">
                                                                                                                </ajax:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 100%; height: 40px" colspan="2">
                                                                                                                &nbsp;
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%;" valign="top">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="98%" runat="server">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblCategory4Job" runat="server" CssClass="Label" Text="Category"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtCategory4Job" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblGrade4Job" runat="server" CssClass="Label" Text="Grade"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtGrade" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblLevel4Job" runat="server" CssClass="Label" Text="Lavel"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtLevel4Job" runat="server" Width="35%" CssClass="TextBoxdesign"></asp:TextBox>&nbsp;
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblMsg4LevelJob" runat="server" CssClass="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblLocation4job" runat="server" CssClass="Label" Text="Location"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtLocation4Job" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblStatus4job" runat="server" CssClass="Label" Text="Status"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtStatus4Job" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblAdharCardNo" runat="server" CssClass="Label" Text="Aadhar Card No."></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtAdharCardNo" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%;">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                                                        style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblPSNo" runat="server" CssClass="Label" Text="P.S.No."></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtPSNo" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblNSSNo" runat="server" CssClass="Label" Text="NSS No."></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtNSSNo" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblESIDispensary" runat="server" CssClass="Label" Text="ESI Dispensary"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtESIDispensary" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblPlaceMentBy" runat="server" CssClass="Label" Text="Placement By"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtPlacementBy" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 25%;">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblBossReportTO" runat="server" CssClass="Label" Text="Boss(Report To)"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 75%;">
                                                                                                                <asp:TextBox ID="txtBossReportTo" runat="server" Width="87%" CssClass="TextBoxdesign"></asp:TextBox>
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
                                                                    <tr>
                                                                        <td align="left" style="width: 100%; height: 100px;" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: ActiveBorder">
                                                                        <td align="left" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4BackFromJob" runat="server" OnClick="lbtnBackFromJob_Click">
                                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                        <td align="right" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4NextFromJob" runat="server" OnClick="lbtnNextFromJob_Click">
                                                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Back.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbQualification" runat="server">
                                                        <HeaderTemplate>
                                                            Qualification
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" align="center">
                                                                    <tr>
                                                                        <td align="left" style="width: 100%" colspan="2">
                                                                            <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                                align="center">
                                                                                <tr >
                                                                                    <td id="Td10" align="left" style="width: 100%" valign="top" runat="server" colspan="2">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                                            style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td id="Td11" align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                                                    <div style="width: 100%; height: 512px; overflow: auto;">
                                                                                                        <asp:GridView ID="grdQualification" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                                            OnRowCommand="grdQualification_RowCommand" OnRowEditing="grdQualification_RowEditing"
                                                                                                            OnRowDeleting="grdQualification_RowDeleting" OnRowDataBound="grdQualification_RowDataBound">
                                                                                                            <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                                                            <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                                                BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                                            <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                                                ForeColor="Snow" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="...">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="chk_Class" runat="server" CssClass="Label" Text='<%#Eval("ClassName")%>'
                                                                                                                            AutoPostBack="true" OnCheckedChanged="chk_Class_CheckChanged" />
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="ClassId" Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lbl_ClassId" runat="server" Text='<%#Eval("ClassId")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Class Name">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_ClassName" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            Width="45%"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Passing Year">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_PassingYear" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="College/University Name">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtCollegeOrUniversityName" runat="server" CssClass="TextBoxdesign"
                                                                                                                            Enabled="false" Width="85%"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Subject">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtSubject" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            Width="85%"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Percentage (%)">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtPercentage" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            Width="35%"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
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
                                                                    <tr>
                                                                        <td align="left" style="width: 100%; height: 10px;" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: ActiveBorder">
                                                                        <td align="left" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4BackFromQualification" runat="server" OnClick="lbtnBackFromQualification_Click">
                                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                        <td align="right" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4NextFromQualification" runat="server" OnClick="lbtnNextFromQualification_Click">
                                                                                <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Back.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlEarningDetails" runat="server" >
                                                        <HeaderTemplate>
                                                            Earning
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="EarningDetails" runat="server">
                                                                <table id="Table30" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr>
                                                                        <td colspan="2" align="left" style="width: 100%;">
                                                                            <table id="Table31" border="1" cellpadding="0" cellspacing="0" width="80%" runat="server" align="center">
                                                                                <tr id="Tr3" runat="server">
                                                                                    <td align="left" style="width: 100%" valign="top" runat="server" colspan="2">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                            <tr runat="server">
                                                                                                <td align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                                                    <div style="width: 100%; height: 512px; overflow: auto;">
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
                                                                                                                <asp:TemplateField HeaderText="Amount">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_Amount" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            onkeypress="return ValidateNumberOnly(event);" Width="65%" OnTextChanged="txt_Amount_TextChanged"
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
                                                                    <tr>
                                                                        <td colspan="2" align="left" style="width: 100%; height: 10%;">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: ActiveBorder">
                                                                        <td align="left" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4BackFromEarning" runat="server" OnClick="lbtnBackFromEarning_Click">
                                                                                <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                        <td align="right" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4Next4Earning" runat="server" OnClick="lbtnNextFromEarning_Click">
                                                                                <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Back.png" Width="36px" /></asp:LinkButton>
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
                                                                <table id="Table33" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" align="center">
                                                                    <tr>
                                                                        <td align="left" style="width: 100%" colspan="2">
                                                                            <table id="Table34" border="1" cellpadding="0" cellspacing="0" width="80%" runat="server" align="center">
                                                                                <tr runat="server">
                                                                                    <td align="left" style="width: 100%" valign="top" runat="server" colspan="2">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                                            <tr >
                                                                                                <td align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                                                    <div style="width: 100%; height: 512px; overflow: auto;">
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
                                                                                                                <asp:TemplateField HeaderText="Amount">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txt_Amount4D" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                                            onkeypress="return ValidateNumberOnly(event);" Width="80px"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Calc On" Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:DropDownList ID="ddlCalcOn4D" Width="150px" Enabled="false" runat="server" CssClass="TextBoxdesign">
                                                                                                                        </asp:DropDownList>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="PayMode"  Visible="false">
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
                                                                                                                        <asp:CheckBox ID="chk_Limit" runat="server" Enabled="false" AutoPostBack="true" OnCheckedChanged="chkLimit_CheckedChanged" /><br />
                                                                                                                        <asp:TextBox ID="txt_LimitAmount" runat="server" CssClass="TextBoxdesign" Visible="false"
                                                                                                                            onkeypress="return ValidateNumberOnly(event);" OnTextChanged="txt_LimitAmount_TextChanged"
                                                                                                                            AutoPostBack="true" Width="65px"></asp:TextBox>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
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
                                                                    <tr>
                                                                        <td align="left" style="width: 100%; height: 10px" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: ActiveBorder">
                                                                        <td align="left" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4BackFromDeductions" runat="server" OnClick="lbtnBackFromDeduction_Click">
                                                                                <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                        <td align="right" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4NextFromDeduction" runat="server" OnClick="lbtnNextFromDeduction_Click">
                                                                                <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/Back.png" Width="36px" /></asp:LinkButton>
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
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="left" style="width: 100%" colspan="2">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                                <tr runat="server">
                                                                                    <td align="left" style="width: 10%" runat="server" valign="top">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td align="center" style="width: 80%" runat="server" valign="top">
                                                                                        <table align="center" border="1" cellpadding="0" cellspacing="0" width="100%"
                                                                                            runat="server">
                                                                                            <tr runat="server">
                                                                                                <td align="center" style="width: 100%" runat="server" colspan="2">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                                                        style="background-color: ActiveBorder">
                                                                                                        <tr runat="server">
                                                                                                            <td Td8align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
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
                                                                                                                            <asp:TemplateField HeaderText="Opening">
                                                                                                                                <ItemTemplate>
                                                                                                                                    <asp:TextBox ID="txt_Opening" runat="server" CssClass="TextBoxdesign" Enabled="true"
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
                                                                                                                        </Columns>
                                                                                                                    </asp:GridView>
                                                                                                                </div>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr id="Tr7" runat="server">
                                                                                                            <td align="left" style="width: 100%" runat="server">
                                                                                                                <hr style="color: Black; width: 100%;" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%" runat="server" colspan="2">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" style="width: 100%" runat="server" colspan="2">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                                                        style="background-color: ActiveBorder">
                                                                                                        <tr runat="server">
                                                                                                            <td align="left" style="width: 20%;" colspan="2" runat="server">
                                                                                                                <asp:CheckBox ID="chkLeaveValidation" runat="server" CssClass="Label" Text="Leave Validation Check Here"
                                                                                                                    AutoPostBack="True" OnCheckedChanged="chkLeaveValidation_CheckedChanged" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr id="Tr11" runat="server">
                                                                                                            <td align="left" style="width: 100%" colspan="2" runat="server">
                                                                                                                <hr style="color: Black; width: 100%;" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr >
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
                                                                                                        <tr >
                                                                                                            <td align="left" style="width: 50%;" runat="server">
                                                                                                                &nbsp;&nbsp;<asp:Label ID="lblOnlyLastYearConsumed" runat="server" Text="Only Last Year Earned EL, can Consumed in Current Year"
                                                                                                                    CssClass="Label"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 50%;" runat="server">
                                                                                                                <asp:CheckBox ID="chkOnlyLastYearConsumed" runat="server" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
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
                                                                                                        <tr>
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
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 100%" colspan="2" runat="server">
                                                                                                                <hr style="color: Black; width: 100%;" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" style="width: 10%" valign="top" runat="server">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                                            style="background-color: ActiveBorder">
                                                                                            <tr runat="server">
                                                                                                <td align="left" style="width: 10%" valign="top" runat="server">
                                                                                                    <asp:Label ID="lblCHOpening" runat="server" Text="CH Opening" CssClass="Label"></asp:Label><br />
                                                                                                    <asp:TextBox ID="txtCHOpening" runat="server" MaxLength="10" Width="75%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 100%; height: 63px;" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: ActiveBorder">
                                                                        <td align="left" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4BackFromLeave" runat="server" OnClick="lbtnBackFromLeave_Click">
                                                                                <asp:Image ID="Image17" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                        <td align="right" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4NextFromLeave" runat="server" OnClick="lbtnNextFromLeave_Click">
                                                                                <asp:Image ID="Image18" runat="server" ImageUrl="~/Images/Back.png" Width="36px" /></asp:LinkButton>
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
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="left" style="width: 100%;" colspan="2">
                                                                            <table align="center" border="1" cellpadding="0" cellspacing="0" width="50%"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td align="center" style="width: 50%" colspan="2">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                                            style="background-color: ActiveBorder">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblLeftDate" runat="server" Text="Left Date" CssClass="Label"></asp:Label><br />
                                                                                                    <asp:TextBox ID="txtLeftDate" runat="server" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                    <ajax:CalendarExtender ID="CalendarExtender11" Animated="true" PopupPosition="BottomRight"
                                                                                                        Format="dd/MM/yyyy" TargetControlID="txtLeftDate" runat="server">
                                                                                                    </ajax:CalendarExtender>
                                                                                                    &nbsp;&nbsp;&nbsp;
                                                                                                    <asp:CheckBox ID="chkFullnFinal" runat="server" Text="Full & Final" CssClass="Label" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblLeftResion" runat="server" Text="Left Reason" CssClass="Label"></asp:Label><br />
                                                                                                    <asp:DropDownList ID="DDLLeftResion" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                                                        AutoPostBack="false">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblReason4Leave4PF" runat="server" Text="Reason for Leaving for PF Department"
                                                                                                        CssClass="Label"></asp:Label><br />
                                                                                                    <asp:DropDownList ID="DDLReason4Leave4PF" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblReason4Leaving4ESI" runat="server" Text="Reason for Leaving for ESI Department"
                                                                                                        CssClass="Label"></asp:Label><br />
                                                                                                    <asp:DropDownList ID="DDlReason4Leaving4ESI" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 100%; height: 338px;" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: ActiveBorder">
                                                                        <td align="left" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4backFromLeft" runat="server" OnClick="lbtnBackFromLeft_Click">
                                                                                <asp:Image ID="Image13" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                        <td align="right" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4NextFromLeft" runat="server" OnClick="lbtnNextFromLeft_Click">
                                                                                <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/Back.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </ajax:TabPanel>
                                                    <ajax:TabPanel ID="tbpnlOthers" runat="server">
                                                        <HeaderTemplate>
                                                            Other & Bank
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <asp:Panel ID="OthersDetails" runat="server">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="left" style="width: 100%;" colspan="2">
                                                                            <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                <tr>
                                                                                    <td align="center" style="width: 100%" colspan="2">
                                                                                        <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 50%;" valign="top">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 100%;">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 25%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblSalaryType" runat="server" CssClass="Label" Text="Salary Type"></asp:Label>
                                                                                                                            <asp:Label ID="Label20" runat="server" CssClass="Required" Text="*"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 75%">
                                                                                                                            <asp:DropDownList ID="DDLSalaryType" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                                                                                AutoPostBack="false">
                                                                                                                            </asp:DropDownList>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 25%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblSkilled" runat="server" CssClass="Label" Text="Skilled"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 75%">
                                                                                                                            <asp:DropDownList ID="DDLSkilled" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                                                                                AutoPostBack="false">
                                                                                                                            </asp:DropDownList>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 25%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblCategory" runat="server" CssClass="Label" Text="Category"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 75%">
                                                                                                                            <asp:DropDownList ID="DDLCategory" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                                                                                AutoPostBack="false">
                                                                                                                            </asp:DropDownList>
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
                                                                                                            <td align="left" style="width: 100%;">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 25%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblOTRateType" runat="server" CssClass="Label" Text="O.T. Rate Type"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 75%">
                                                                                                                            <asp:DropDownList ID="DDLOTRateType" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                                                                                AutoPostBack="false">
                                                                                                                            </asp:DropDownList>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 25%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblOTRate" runat="server" CssClass="Label" Text="O.T. Rate"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 75%">
                                                                                                                            <asp:TextBox ID="txtOTRate" runat="server" MaxLength="30" Width="45%" CssClass="TextBoxdesign"
                                                                                                                                onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
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
                                                                                                            <td align="left" style="width: 100%;">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 25%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblLateRateType" runat="server" CssClass="Label" Text="Late Rate Type"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 75%">
                                                                                                                            <asp:DropDownList ID="DDLLateRateType" runat="server" CssClass="TextBoxdesign" Width="90%"
                                                                                                                                AutoPostBack="false">
                                                                                                                            </asp:DropDownList>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 25%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblLatePenaltyRate" runat="server" CssClass="Label" Text="Late Penalty Rate"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 75%">
                                                                                                                            <asp:TextBox ID="txtLatePenaltyRate" runat="server" MaxLength="30" Width="45%" CssClass="TextBoxdesign"
                                                                                                                                onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 100%; height: 32px" colspan="2">
                                                                                                                            &nbsp;
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                                <td align="left" style="width: 50%;" valign="top">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 100%;">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblIncrementDueDate" runat="server" CssClass="Label" Text="IncrementDueDate"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%">
                                                                                                                            <asp:TextBox ID="txtIncrementDueDate" runat="server" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                            <ajax:CalendarExtender ID="CalendarExtender12" Animated="true" PopupPosition="BottomRight"
                                                                                                                                Format="dd/MM/yyyy" TargetControlID="txtIncrementDueDate" runat="server">
                                                                                                                            </ajax:CalendarExtender>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblIncrementMonth" runat="server" CssClass="Label" Text="Increment Month"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%">
                                                                                                                            <asp:DropDownList ID="DDLIncrementMonth" runat="server" CssClass="TextBoxdesign"
                                                                                                                                Width="90%" AutoPostBack="false">
                                                                                                                            </asp:DropDownList>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblBasicPayIncrement" runat="server" CssClass="Label"
                                                                                                                                Text="Basic Pay Increment As"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%">
                                                                                                                            <asp:TextBox ID="txtBasicPayIncrement" runat="server" MaxLength="30" Width="40%"
                                                                                                                                CssClass="TextBoxdesign"></asp:TextBox>&nbsp;<asp:Label ID="lbladditional" Text="(Per Grade-wise Pay Scale)"
                                                                                                                                    runat="server" CssClass="Label"></asp:Label>
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
                                                                                                            <td align="left" style="width: 100%;">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblIdentityCardValidUpto" runat="server" CssClass="Label"
                                                                                                                                Text="Identity Card Valid upto"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%">
                                                                                                                            <asp:TextBox ID="txtIdentityCardValidUpto" runat="server" Width="40%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                                            <ajax:CalendarExtender ID="CalendarExtender13" Animated="true" PopupPosition="BottomRight"
                                                                                                                                Format="dd/MM/yyyy" TargetControlID="txtIdentityCardValidUpto" runat="server">
                                                                                                                            </ajax:CalendarExtender>
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
                                                                                                            <td align="left" style="width: 100%;">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%; height: 32px">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblSalaryCalculationDays" runat="server" CssClass="Label"
                                                                                                                                Text="Salary Calculation Days"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%; height: 32px" valign="top">
                                                                                                                            <asp:TextBox ID="txtSalaryCalculationDays" runat="server" Width="40%" Height="18px"
                                                                                                                                Enabled="false"></asp:TextBox>
                                                                                                                            <ajax:NumericUpDownExtender ID="NMExt4SalaryCalculation" runat="server" TargetControlID="txtSalaryCalculationDays"
                                                                                                                                Minimum="1" Maximum="31" Width="100">
                                                                                                                            </ajax:NumericUpDownExtender>
                                                                                                                            <%-- <asp:DropDownList ID="DDLSalaryCalculationDays" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>--%>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%; height: 32px">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblGeneralWorkingHours" runat="server" CssClass="Label"
                                                                                                                                Text="General Working Hours"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%; height: 32px" valign="top">
                                                                                                                            <asp:TextBox ID="txtGeneralWorkingHours" runat="server" Width="40%" Height="18px"
                                                                                                                                Enabled="false"></asp:TextBox>
                                                                                                                            <ajax:NumericUpDownExtender ID="NMExtGeneralWorkingHours" runat="server" TargetControlID="txtGeneralWorkingHours"
                                                                                                                                Minimum="1" Maximum="24" Width="100">
                                                                                                                            </ajax:NumericUpDownExtender>
                                                                                                                            <%-- <asp:DropDownList ID="DDLGeneralWorkingHours" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>--%>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%; height: 32px">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblOTCalculationDays" runat="server" CssClass="Label"
                                                                                                                                Text="O.T.Calculation Days"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%; height: 32px" valign="top">
                                                                                                                            <asp:TextBox ID="txtOTCalculationDays" runat="server" Width="40%" Height="18px" Enabled="false"></asp:TextBox>
                                                                                                                            <ajax:NumericUpDownExtender ID="NMExtOTCalculationDays" runat="server" TargetControlID="txtOTCalculationDays"
                                                                                                                                Minimum="1" Maximum="31" Width="100">
                                                                                                                            </ajax:NumericUpDownExtender>
                                                                                                                            <%--<asp:DropDownList ID="DDLOTCalculationDays" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>--%>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%; height: 32px">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblOTWorkingHours" runat="server" CssClass="Label" Text="O.T.Working Hours"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%; height: 32px" valign="top">
                                                                                                                            <asp:TextBox ID="txtOTWorkingHours" runat="server" Width="40%" Height="18px" Enabled="false"></asp:TextBox>
                                                                                                                            <ajax:NumericUpDownExtender ID="NMExtOTWorkingHours" runat="server" TargetControlID="txtOTWorkingHours"
                                                                                                                                Minimum="1" Maximum="24" Width="100">
                                                                                                                            </ajax:NumericUpDownExtender>
                                                                                                                            <%--<asp:DropDownList ID="DDLOTWorkingHours" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>--%>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 35%; height: 26px">
                                                                                                                            &nbsp;&nbsp;<asp:Label ID="lblTotalDaysInMonth" runat="server" CssClass="Label" Text="Total Days in Month"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="left" style="width: 65%; height: 26px" valign="top">
                                                                                                                            <asp:TextBox ID="txtTotalWorkingDaysInMonth" runat="server" Width="40%" Height="18px"
                                                                                                                                Enabled="false"></asp:TextBox>
                                                                                                                            <ajax:NumericUpDownExtender ID="NMExtTotalWorkingDaysInMonth" runat="server" TargetControlID="txtTotalWorkingDaysInMonth"
                                                                                                                                Minimum="1" Maximum="24" Width="100">
                                                                                                                            </ajax:NumericUpDownExtender>
                                                                                                                            <%--<asp:DropDownList ID="DDLTotalDaysInMonth" runat="server" CssClass="TextBoxdesign"
                                                                                                        Width="90%" AutoPostBack="false">
                                                                                                    </asp:DropDownList>--%>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 100%;" colspan="2">
                                                                                                                            &nbsp;
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
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%" colspan="2">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" style="width: 100%" colspan="2">
                                                                                        <table border="1" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                                                                            <tr>
                                                                                                <td align="center" style="width: 100%">
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%"
                                                                                                        style="background-color: ActiveBorder">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 15%">
                                                                                                                <asp:Label ID="lblBankName" runat="server" CssClass="Label" Text="Bank Name"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 35%">
                                                                                                                <asp:TextBox ID="txtBankName" runat="server" MaxLength="50" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 15%">
                                                                                                                <asp:Label ID="lblBranch" runat="server" CssClass="Label" Text="Branch"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 35%">
                                                                                                                <asp:TextBox ID="txtBranch" runat="server" MaxLength="50" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 15%">
                                                                                                                <asp:Label ID="lblAccountHolder" runat="server" CssClass="Label" Text="Account Holder Name"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 35%">
                                                                                                                <asp:TextBox ID="txtAccountHolder" runat="server" MaxLength="50" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 15%">
                                                                                                                <asp:Label ID="lblAccountNo" runat="server" CssClass="Label" Text="Account No"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 35%">
                                                                                                                <asp:TextBox ID="txtAccountNo" runat="server" MaxLength="50" Width="86%" CssClass="TextBoxdesign"></asp:TextBox>
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
                                                                    <tr>
                                                                        <td align="left" style="width: 100%; height: 96px;" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: ActiveBorder">
                                                                        <td align="left" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4BackFromOthers" runat="server" OnClick="lbtnBackFromOthers_Click">
                                                                                <asp:Image ID="Image15" runat="server" ImageUrl="~/Images/Next1.png" Width="36px" /></asp:LinkButton>
                                                                        </td>
                                                                        <td align="right" style="width: 50%">
                                                                            <asp:LinkButton ID="lbtn4NextFromOthers" runat="server" OnClick="lbtnNextFromOthers_Click">
                                                                                <asp:Image ID="Image16" runat="server" ImageUrl="~/Images/Back.png" Width="36px" /></asp:LinkButton>
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
        <Triggers >
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
