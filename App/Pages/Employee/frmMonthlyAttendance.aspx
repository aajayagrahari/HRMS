<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmMonthlyAttendance.aspx.cs" Inherits="Pages_Employee_frmMonthlyAttendance" %>

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
                    <td align="left" style="width: 100%">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                            <tr>
                                <td align="left" style="width: 100%">
                                    <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" style="width: 100%">
                                                <table id="Table6" border="0" cellpadding="0" style="background-color: ActiveBorder"
                                                    cellspacing="0" width="100%" runat="server">
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
                                                            <asp:TextBox ID="txtUnit" runat="server" MaxLength="30" Width="82%" CssClass="TextBoxdesign"
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
                                                            <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="83%" AutoPostBack="true" OnSelectedIndexChanged="ddlFinYear_SelectedIndexChanged">
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
                    <td align="left" valign="top" style="width: 100%">
                        <ajax:TabContainer ID="TabContainer1" runat="server" CssClass="fancy fancy-green"
                            Height="850px" ScrollBars="Auto" ActiveTabIndex="0" Width="100%">
                            <ajax:TabPanel ID="tbplSalaryStructure" runat="server">
                                <HeaderTemplate>
                                    Attendance Register
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:Panel ID="SalaryDetails" runat="server">
                                        <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                            <tr>
                                                <td align="left" style="width: 100%">
                                                    <table id="Table2" border="0" cellpadding="0" cellspacing="0" runat="server" width="100%"
                                                        style="background-color: ActiveBorder">
                                                        <tr>
                                                            <td align="left" style="width: 100%">
                                                                <div style="width: 100%; height: 840px; overflow: auto;">
                                                                    <asp:GridView ID="grdMonthlyAttendanceSummary" runat="server" AutoGenerateColumns="False"
                                                                        DataKeyNames="AttendanceDate" Width="100%" OnRowCommand="grdMonthlyAttendanceSummary_RowCommand"
                                                                        OnRowEditing="grdMonthlyAttendanceSummary_RowEditing" OnRowDeleting="grdMonthlyAttendanceSummary_RowDeleting"
                                                                        OnRowDataBound="grdMonthlyAttendanceSummary_RowDataBound">
                                                                        <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                            BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                            ForeColor="Snow" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Date">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chk_Date" runat="server" CssClass="Label" AutoPostBack="true" OnCheckedChanged="chk_Date_CheckChanged"
                                                                                        Text='<%#Eval("AttendanceDate")%>' />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                                                                <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="...">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Days" runat="server" Visible="true" CssClass="Label" Text='<%#Eval("Status1")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="MarkIn Time">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txt_MarkInTime" runat="server" CssClass="NumericTextBoxdesign" Enabled="false"
                                                                                        onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Updated MarkIn Time">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txt_UpdatedMarkInTime" runat="server" CssClass="NumericTextBoxdesign"
                                                                                        Enabled="false" onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="MarkOut Time">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txt_MarkOutTime" runat="server" CssClass="NumericTextBoxdesign"
                                                                                        Enabled="false" onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Updated MarkOut Time">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txt_UpdatedMarkOutTime" runat="server" CssClass="NumericTextBoxdesign"
                                                                                        Enabled="false" onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_Status" runat="server" Visible="true" CssClass="Label"></asp:Label>
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
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    Attendance
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                            <tr>
                                                <td align="left" style="width: 100%">
                                                    <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%"
                                                        style="background-color: ActiveBorder">
                                                        <tr>
                                                            <td align="left" style="width: 12%">
                                                                <asp:Label ID="lblTodayDate" runat="server" Visible="true" CssClass="Label"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 10%">
                                                                <asp:TextBox ID="txtMarkInTime" runat="server" CssClass="NumericTextBoxdesign" Enabled="false"
                                                                    onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 10%">
                                                                <asp:TextBox ID="txtUpdatedMarkInTime" runat="server" CssClass="NumericTextBoxdesign" Enabled="false"
                                                                    onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 8%">
                                                                <asp:Button ID="btnMarkIn" runat="server" Text="Mark In" OnClick="btnMarkIn_Click" />
                                                            </td>
                                                            <td align="left" style="width: 10%">
                                                                <asp:TextBox ID="txtMarkOutTime" runat="server" CssClass="NumericTextBoxdesign" Enabled="false"
                                                                    onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 10%">
                                                                <asp:TextBox ID="txtUpdatedMarkOutTime" runat="server" CssClass="NumericTextBoxdesign" Enabled="false"
                                                                    onkeypress="return ValidateNumberOnly(event);" Width="45%"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 20%">
                                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                    Width="90%"></asp:TextBox>
                                                                <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtRemarks" WatermarkText="Please Enter Remarks IF Any">
                                                                </ajax:TextBoxWatermarkExtender>
                                                            </td>
                                                            <td align="left" style="width: 10%">
                                                                <asp:Button ID="btnMarkOutTime" runat="server" Text="Mark Out" OnClick="btnMarkOutTime_Click" Enabled="false" />
                                                            </td>
                                                            <td align="left" style="width: 10%">
                                                                <asp:Label ID="lblAttendanceStatus" runat="server" Visible="true" CssClass="Label"></asp:Label>
                                                                <asp:TextBox ID="txtFullTime" runat="server" CssClass="TextBoxdesign" Enabled="false" Visible="false"
                                                                    Width="90%"></asp:TextBox>
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
