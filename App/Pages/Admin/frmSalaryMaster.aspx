<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmSalaryMaster.aspx.cs" Inherits="Pages_Admin_frmSalaryMaster" %>

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
                            Height="800px" ScrollBars="Vertical" ActiveTabIndex="1" Width="100%">
                            <ajax:TabPanel ID="tbplSalaryStructure" runat="server">
                                <HeaderTemplate>
                                    Salary Structure
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:Panel ID="SalaryDetails" runat="server">
                                        <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="center" style="width: 100%;" valign="top">
                                                    <div style="width: 100%; height: 730px; overflow: auto;">
                                                        <asp:GridView ID="grdEmployeeMasterDetails" runat="server" AutoGenerateColumns="False"
                                                            DataKeyNames="EmployeeId" Width="1024px" OnRowCommand="grdEmployeeMasterDetails_RowCommand"
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
                                                                <asp:TemplateField HeaderText="..." Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                                                            CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Employee Code">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_EmployeeId" runat="server" Text=' <%#Eval("EmployeeId")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PCardNo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_PCardNo" runat="server" Text=' <%#Eval("PCardNo")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_EmployeeName" runat="server" Text='<%#Eval("EmployeeName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Father Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_FatherName" runat="server" Text='<%#Eval("FatherName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Unit" runat="server" Text='<%#Eval("Unit")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Department" runat="server" Text=' <%#Eval("Department")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Designation">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_Designation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PF No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_PFNo" runat="server" Text='<%#Eval("PFNo")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ESI No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_ESINo" runat="server" Text='<%#Eval("ESINo")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Joining Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_JoiningDate" runat="server" Text='<%#Eval("JoiningDate")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Created By" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_CreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Modified By" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_ModifiedBy" runat="server" Text='<%#Eval("ModifiedBy")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IsDeleted" Visible="False">
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
                            <ajax:TabPanel ID="tbplAttendance" runat="server">
                                <HeaderTemplate>
                                    Attendance
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:Panel ID="Attendance" runat="server">
                                        <table id="Table4" border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                            <tr id="Tr4" runat="server">
                                                <td id="Td6" align="left" style="width: 100%;" valign="top" runat="server">
                                                    <table id="Table5" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                        <tr runat="server">
                                                            <td align="left" style="width: 100%" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="50%" align="center">
                                                                                <tr>
                                                                                    <td align="left" style="width: 10%">
                                                                                        <asp:Label ID="lblMonth" runat="server" CssClass="Label" Text="Month"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" style="width: 90%">
                                                                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                                                                                            AutoPostBack="True" Width="155px">
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
                                                                                        <asp:DropDownList ID="DDLYear" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="DDLYear_SelectedIndexChanged"
                                                                                            AutoPostBack="True" Width="155px">
                                                                                            <asp:ListItem Value="2013">2013</asp:ListItem>
                                                                                            <asp:ListItem Value="2014">2014</asp:ListItem>
                                                                                            <asp:ListItem Value="2015">2015</asp:ListItem>
                                                                                            <asp:ListItem Value="2016">2016</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                                                        <tr id="Tr5" runat="server">
                                                            <td align="left" style="width: 100%" runat="server">
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="left" style="width: 100%">
                                                                            <table id="Table6" border="0" cellpadding="0" style="background-color: ActiveBorder"
                                                                                cellspacing="0" width="100%" runat="server">
                                                                                <tr id="Tr6" runat="server">
                                                                                    <td id="Td8" runat="server">
                                                                                        <asp:Label ID="lblCODE" runat="server" CssClass="Label" Text="CODE"></asp:Label>
                                                                                    </td>
                                                                                    <td id="Td9" runat="server">
                                                                                        <asp:TextBox ID="txtCode" CssClass="TextBoxdesign" runat="server" Width="75%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td id="Td10" runat="server">
                                                                                        <asp:Label ID="lblName" runat="server" CssClass="Label" Text="Name"></asp:Label>
                                                                                    </td>
                                                                                    <td id="Td11" runat="server">
                                                                                        <asp:TextBox ID="txtName" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td id="Td12" runat="server">
                                                                                        <asp:Label ID="lblLoanBalance" runat="server" CssClass="Label" Text="Loan Balance"></asp:Label>
                                                                                    </td>
                                                                                    <td id="Td13" runat="server">
                                                                                        <asp:TextBox ID="txtLoanBalance" CssClass="TextBoxdesign" runat="server" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                    </td>
                                                                                    <td id="Td14" runat="server">
                                                                                        <asp:Label ID="lblSalaryProcessDate" runat="server" CssClass="Label" Text="Salary Process Date"></asp:Label><br />
                                                                                        <asp:TextBox ID="txtSalaryProcessDate" runat="server" Width="75%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                        <ajax:CalendarExtender ID="CalendarExtender14" PopupPosition="BottomRight"
                                                                                            Format="dd/MM/yyyy" TargetControlID="txtSalaryProcessDate" runat="server" 
                                                                                            Enabled="True">
                                                                                        </ajax:CalendarExtender>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr7" runat="server">
                                                                                    <td id="Td16" runat="server">
                                                                                        <asp:Label ID="lblDOJ" runat="server" CssClass="Label" Text="DOJ"></asp:Label>
                                                                                    </td>
                                                                                    <td id="Td17" runat="server">
                                                                                        <asp:TextBox ID="txtDateOfJoining" runat="server" Width="75%" CssClass="TextBoxdesign"></asp:TextBox>
                                                                                        <ajax:CalendarExtender ID="CalendarExtender1" PopupPosition="BottomRight"
                                                                                            Format="dd/MM/yyyy" TargetControlID="txtDateOfJoining" runat="server" 
                                                                                            Enabled="True">
                                                                                        </ajax:CalendarExtender>
                                                                                        
                                                                                    </td>
                                                                                    <td id="Td18" runat="server">
                                                                                        <asp:Label ID="lblFHName" runat="server" CssClass="Label" Text="F/H Name"></asp:Label>
                                                                                    </td>
                                                                                    <td id="Td19" runat="server">
                                                                                        <asp:TextBox ID="txtfhName" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td id="Td20" runat="server">
                                                                                    </td>
                                                                                    <td id="Td21" runat="server">
                                                                                        <asp:TextBox ID="txtDaysInMonthAfterJoining" runat="server" Width="25%" 
                                                                                            CssClass="TextBoxdesign" Enabled="False" Visible="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td id="Td7" runat="server">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr8" style="background-color: White" runat="server">
                                                            <td align="left" style="width: 100%" runat="server">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr9" runat="server">
                                                            <td align="left" style="width: 100%" runat="server">
                                                                <table id="Table2" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                                    <tr runat="server">
                                                                        <td id="Td23" style="width: 49%" align="left" runat="server" valign="top">
                                                                            <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%">
                                                                                        <table style="background-color: ActiveBorder" border="0" cellpadding="0" cellspacing="0"
                                                                                            width="100%">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblOpening" runat="server" CssClass="Label" Text="Opening"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblDays" runat="server" CssClass="Label" Text="Days"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblEarnedActual" runat="server" CssClass="Label" Text="Earned/Actual"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblExtraEarned" runat="server" CssClass="Label" Text="Extra Earned"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%" colspan="5">
                                                                                                    <hr style="color: Black; width: 100%;" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblTotalDays" runat="server" Text="Total Days" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtTotalDays" CssClass="TextBoxdesign" runat="server" Width="50%" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblOnDuty" runat="server" Text="On Duty" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtOnDuty" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"
                                                                                                        OnTextChanged="txtOnDuty_TextChanged" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblAbsent" runat="server" Text="Absent" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtAbsent" CssClass="TextBoxdesign" runat="server" Width="50%" OnTextChanged="txtAbsent_TextChanged"
                                                                                                        AutoPostBack="True" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblExtraDays" runat="server" Text="Over Time" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblOverTimeIndays" runat="server" Text="(in Days)" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtOverTime" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" AutoPostBack="True" OnTextChanged="txtOverTime_TextChanged" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblHolidays" runat="server" Text="Holidays" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtHolidays" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        AutoPostBack="True" OnTextChanged="txtHolidays_TextChanged" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblWeeklyOff" runat="server" Text="Weekly Off" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtWeeklyOff1" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" OnTextChanged="txtWeeklyOff1_TextChanged" AutoPostBack="True" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblEL" runat="server" Text="EL" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtEL4Opening" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtEL4Days" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        AutoPostBack="True" OnTextChanged="txtEL4Days_TextChanged" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtEL4EarningActual" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtEL4ExtraEarning" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblCL" runat="server" Text="CL" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtCL4Opening" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtCL4Days" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        AutoPostBack="True" OnTextChanged="txtCL4Days_TextChanged" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtCL4EarningActual" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtCL4EarningExtra" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblSL" runat="server" Text="SL" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtSL4Opening" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtSL4Days" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        AutoPostBack="True" OnTextChanged="txtSL4Days_TextChanged"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtSL4EarningActual" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtSL4EarningExtra" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblL1" runat="server" Text="L1" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL14Opening" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL14Days" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        AutoPostBack="True" OnTextChanged="txtL14Days_TextChanged"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL14EarningActual" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL14EarningExtra" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblL2" runat="server" Text="L2" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL24Opening" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL24Days" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        AutoPostBack="True" OnTextChanged="txtL24Days_TextChanged"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL24EarningActual" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL24EarningExtra" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblL3" runat="server" Text="L3" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL34Opening" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL34Days" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        AutoPostBack="True" OnTextChanged="txtL34Days_TextChanged"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL34EarningActual" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" onkeypress="return ValidateNumberOnly(event);"
                                                                                                        Enabled="False"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtL34EarningExtra" CssClass="TextBoxdesign" runat="server" 
                                                                                                        Width="50%" Enabled="False" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblRestrictedholidays" runat="server" Text="Rst. Holidays" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtRestrictedHolidyas" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        AutoPostBack="True" OnTextChanged="txtRestrictedHolidyas_TextChanged" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblMaternity" runat="server" Text="Maternity" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtMaternity" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                        AutoPostBack="True" OnTextChanged="txtMaternity_TextChanged" 
                                                                                                        onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblDayWork" runat="server" Text="Day Work" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtDayWork" CssClass="TextBoxdesign" runat="server" Width="50%" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:Label ID="lblPaidDays" runat="server" Text="Paid Days" CssClass="Label"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    <asp:TextBox ID="txtPaidDays" CssClass="TextBoxdesign" runat="server" Width="50%" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td align="left" style="width: 20%">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td id="Td24" runat="server" style="background-color: White">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td id="Td25" style="width: 49%" valign="top" align="right" runat="server">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%">
                                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    <table border="1" cellpadding="0" cellspacing="0" width="50%" style="background-color: ActiveBorder;"
                                                                                                        align="left">
                                                                                                        <tr>
                                                                                                            <td align="left" style="width: 100%" valign="top">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="vertical-align: top">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 40%">
                                                                                                                            <asp:Label ID="lblArrPaidDays" runat="server" Text="Arr.Paid Days" CssClass="Label"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="right" style="width: 60%">
                                                                                                                            <asp:TextBox ID="txtArrPaidDays" CssClass="TextBoxdesign" runat="server" Width="70%" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 40%">
                                                                                                                            <asp:Label ID="lblPfPaidDays" runat="server" Text="PF Paid Days" CssClass="Label"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="right" style="width: 60%">
                                                                                                                            <asp:TextBox ID="txtPfPaidDays" CssClass="TextBoxdesign" runat="server" Width="70%" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 40%">
                                                                                                                            <asp:Label ID="lblEsiPaidDays" runat="server" CssClass="Label" 
                                                                                                                                Text="ESI Paid Days"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="right" style="width: 60%">
                                                                                                                            <asp:TextBox ID="txtEsiPaidDays" runat="server" CssClass="TextBoxdesign" 
                                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="70%"></asp:TextBox>
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
                                                                                                            <td align="left" style="width: 100%; height: 48px">
                                                                                                                &nbsp;
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
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 100%">
                                                                                        <table border="1" cellpadding="0" cellspacing="0" 
                                                                                            style="background-color: ActiveBorder" width="100%">
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="lblRemarks" runat="server" CssClass="Label" Text="Remarks"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left" style="width: 100%">
                                                                                                    <asp:TextBox ID="txtRemark" runat="server" Columns="55" Rows="10" 
                                                                                                        TextMode="MultiLine"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:Button ID="btnCalculateSalary" runat="server" 
                                                                                            OnClick="btnCalculateSalary_Click" Text="Process Salary" />
                                                                                        <asp:Button ID="btnNextAtTab2" runat="server" Text="Next" />
                                                                                        <asp:Button ID="btnBackAtTab2" runat="server" Text="Back" />
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
                                        </td>
                                        </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    Err & Ded
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                            <tr>
                                                <td align="left" style="width: 100%">
                                                    <table id="Table7" border="1" cellpadding="0" cellspacing="0" width="80%" runat="server"
                                                        align="center">
                                                        <tr id="Tr1" runat="server">
                                                            <td id="Td1" align="left" style="width: 100%" valign="top" runat="server">
                                                                <table id="Table8" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                                    style="background-color: ActiveBorder">
                                                                    <tr id="Tr2" runat="server">
                                                                        <td id="Td2" align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                            <div style="width: 100%; height: 510px; overflow: auto;">
                                                                                <asp:GridView ID="grdAllowances" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                    OnRowCommand="grdAllowances_RowCommand" OnRowEditing="grdAllowances_RowEditing"
                                                                                    OnRowDeleting="grdAllowances_RowDeleting" OnRowDataBound="grdAllowances_RowDataBound">
                                                                                    <RowStyle BorderWidth="0px" BorderColor="Salmon" />
                                                                                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                                                                                        BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                                                                                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                                                                                        ForeColor="Snow" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Allowances">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbl_Allowance" runat="server" CssClass="Label" Text=' <%#Eval("Allowances")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="170px" />
                                                                                            <ItemStyle HorizontalAlign="Left" Width="170px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Amount">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txt_Amount" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                    onkeypress="return ValidateNumberOnly(event);" Width="65%" Text='<%#Eval("Amount")%>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Ear. Amount">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txt_EarnedAmount" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                    onkeypress="return ValidateNumberOnly(event);" Width="65%" Text='<%#Eval("AllowanesAmount")%>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Deductions">
                                                                                            <ItemTemplate>
                                                                                                <%--<asp:Label ID="lbl_Deductions" runat="server" Text=' <%#Eval("Deductions")%>' CssClass="Label"></asp:Label>--%>
                                                                                                <asp:CheckBox ID="chk_Deductions" runat="server" CssClass="Label" Text='<%#Eval("Deductions")%>'
                                                                                                                AutoPostBack="true" OnCheckedChanged="chk_Deductions_CheckChanged" />
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="170px" />
                                                                                            <ItemStyle HorizontalAlign="Left" Width="170px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Percentage (%)">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txt_Percentage" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                    onkeypress="return ValidateNumberOnly(event);" Width="70px" Text='<%#Eval("DedPercentage")%>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Amount" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txt_Amount4D" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                    onkeypress="return ValidateNumberOnly(event);" Width="70px" Text='<%#Eval("DeductionAmount")%>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Deduct Amount">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txt_DeductAmount" runat="server" CssClass="TextBoxdesign" Enabled="false"
                                                                                                    onkeypress="return ValidateNumberOnly(event);" Width="85%" Text='<%#Eval("DedAmount")%>' OnTextChanged="txt_DeductAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="120px" />
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
