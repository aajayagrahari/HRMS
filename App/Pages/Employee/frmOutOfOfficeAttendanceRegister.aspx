<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmOutOfOfficeAttendanceRegister.aspx.cs"
    Inherits="Pages_Employee_frmOutOfOfficeAttendanceRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
            <table border="0" runat="server" cellpadding="0" cellspacing="0" width="100%" style="height : 150px">
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 100%" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                            <tr>
                                <td align="left" style="width: 100%">
                                    <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" style="width: 100%">
                                                <table border="0" cellpadding="0" style="background-color: ActiveBorder" cellspacing="0"
                                                    width="100%" runat="server">
                                                    <tr>
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblCODE" runat="server" CssClass="Label" Text="CODE"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 15%">
                                                            <asp:TextBox ID="txtCode" CssClass="TextBoxdesign" runat="server" Width="75%" OnTextChanged="txtCode_TextChanged"
                                                                AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblName" runat="server" CssClass="Label" Text="Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 15%">
                                                            <asp:TextBox ID="txtName" CssClass="TextBoxdesign" runat="server" Width="75%" Enabled="false"></asp:TextBox>
                                                            <asp:TextBox ID="txtTDSEarningId" CssClass="TextBoxdesign" runat="server" Width="75%"
                                                                Visible="false"></asp:TextBox>
                                                            <asp:TextBox ID="txtTDSDeductionId" CssClass="TextBoxdesign" runat="server" Width="75%"
                                                                Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblGender" runat="server" CssClass="Label" Text="Gender"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 15%">
                                                            <asp:DropDownList ID="DDLGender" runat="server" CssClass="TextBoxdesign" Width="86%"
                                                                Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblDOJ" runat="server" CssClass="Label" Text="DOJ"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 25%">
                                                            <asp:TextBox ID="txtDateOfJoining" runat="server" Width="75%" CssClass="TextBoxdesign"
                                                                Enabled="false"></asp:TextBox>
                                                            <ajax:CalendarExtender ID="CalendarExtender1" Animated="true" PopupPosition="BottomRight"
                                                                Format="dd/MM/yyyy" TargetControlID="txtDateOfJoining" runat="server">
                                                            </ajax:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblFHName" runat="server" CssClass="Label" Text="F/H Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 15%">
                                                            <asp:TextBox ID="txtfhName" CssClass="TextBoxdesign" runat="server" Width="75%" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblUnit" runat="server" CssClass="Label" Text="Unit"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 15%">
                                                            <asp:TextBox ID="txtUnit" runat="server" MaxLength="30" Width="75%" CssClass="TextBoxdesign"
                                                                Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblMonth" runat="server" CssClass="Label" Text="Month"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 15%">
                                                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                                                                AutoPostBack="True" Width="85%">
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
                                                        <td align="left" style="width: 10%">
                                                            <asp:Label ID="lblYear" runat="server" CssClass="Label" Text="Year"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 15%">
                                                            <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="83%"
                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlFinYear_SelectedIndexChanged">
                                                                <asp:ListItem Value="2012">2012</asp:ListItem>
                                                                <asp:ListItem Value="2013">2013</asp:ListItem>
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
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 100%" valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" style="width: 100%">
                        <table border="1" cellpadding="0" cellspacing="0" runat="server" width="50%">
                            <tr>
                                <td align="left" style="width: 100%">
                                    <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%"
                                        style="background-color: ActiveBorder; height : 100px;">
                                        <tr>
                                            <td align="left" style="width: 15%">
                                                <asp:Label ID="lblDateFrom" runat="server" Visible="true" CssClass="Label" Text="Date From :"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 35%">
                                                <asp:TextBox ID="txtDateFrom" runat="server" Width="75%" CssClass="TextBoxdesign"
                                                    Enabled="true"></asp:TextBox>
                                                <ajax:CalendarExtender ID="CalendarExtender2" Animated="true" PopupPosition="BottomRight"
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateFrom" runat="server">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td align="left" style="width: 15%">
                                                <asp:Label ID="lblDateTo" runat="server" Visible="true" CssClass="Label" Text="Date To :"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 35%">
                                                <asp:TextBox ID="txtDateTo" runat="server" Width="75%" CssClass="TextBoxdesign" Enabled="true"></asp:TextBox>
                                                <ajax:CalendarExtender ID="CalendarExtender3" Animated="true" PopupPosition="BottomRight"
                                                    Format="dd/MM/yyyy" TargetControlID="txtDateTo" runat="server">
                                                </ajax:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 100%" colspan="4">
                                                <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%" style="background-color: ActiveBorder">
                                                    <tr>
                                                        <td align="left" style="width: 15%">
                                                            <asp:Label ID="lblPurpose" runat="server" Visible="true" CssClass="Label" Text="Purpose :"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 85%">
                                                            <asp:TextBox ID="txtPurpose" runat="server" Width="90%" CssClass="TextBoxdesign"
                                                                Enabled="true" TextMode="MultiLine" Height="85px"></asp:TextBox>
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
                    <td align="center" style="width: 100%">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
