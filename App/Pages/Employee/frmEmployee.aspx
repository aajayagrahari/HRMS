<%@ Page Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    CodeFile="frmEmployee.aspx.cs" Inherits="Pages_Employee_frmEmployee" %>

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
            <br />
            <br />
            <div>
                <asp:Label ID="lblPageHeader" runat="server" Text="Employee Detail" CssClass="pageHeading"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblMsg" runat="server" CssClass="Required"></asp:Label>
            </div>
            <div style="clear: both">
            </div>
            <div style="width: 100%;">
                <ajax:TabContainer ID="TabContainer1" CssClass="fancy fancy-green" Width="100%" runat="server"
                    ActiveTabIndex="1" ViewStateMode="Enabled">
                    <ajax:TabPanel ID="tbpnlEmpProfile" runat="server">

                        <HeaderTemplate>
                            Employee Profile</HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel5" runat="server">
                                <asp:FormView ID="FormEmpDetail" runat="server" DataKeyNames="EmployeeId" AllowPaging="True"
                                    CellPadding="4" BackColor="White" BorderColor="#4B6C9E" BorderStyle="None" BorderWidth="1px"
                                    GridLines="Both" ForeColor="#006699" HeaderText="Employee Profile" Font-Size="Small"
                                    Width="100%">
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="SaddleBrown" ForeColor="White" Font-Bold="True" Height="30px"
                                        HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <EditRowStyle BackColor="White" Font-Bold="True" ForeColor="#006699" />
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" runat="server" width="100%">
                                            <tr>
                                                <td align="left" style="width: 85%">
                                                    <table width="100%" align="center">
                                                        <tr>
                                                            <td width="12%" align="left">
                                                                <b>Employee Id :</b>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Bind("EmployeeId") %>'></asp:Label>
                                                            </td>
                                                            <td width="18%" align="left">
                                                                <b>Employee Name :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <b>Father Name :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblFatherName" runat="server" Text='<%#Bind("FatherName") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="12%" align="left">
                                                                <b>Department :</b>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lblDepartment" runat="server" Text='<%#Bind("DepartmentName") %>'></asp:Label>
                                                            </td>
                                                            <td width="18%" align="left">
                                                                <b>Designation :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("DesignationName") %>'></asp:Label>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <b>Email-Id :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblEmailId" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="12%" align="left">
                                                                <b>Contact No :</b>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lblContactNo" runat="server" Text='<%#Bind("ContactNo") %>'></asp:Label>
                                                            </td>
                                                            <td width="18%" align="left">
                                                                <b>Permanet Address :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblPermanetAddress" runat="server" Text='<%#Bind("ParamAddress") %>'></asp:Label>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <b>Local Address :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblLocalAddress" runat="server" Text='<%#Bind("LocalAddress") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="12%" align="left">
                                                                <b>Date of Birth :</b>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Bind("DateOfBirth") %>'></asp:Label>
                                                            </td>
                                                            <td width="18%" align="left">
                                                                <b>Nationality :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblNationality" runat="server" Text='<%#Bind("Nationality") %>'></asp:Label>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <b>Religion :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblReligion" runat="server" Text='<%#Bind("Religion") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="12%" align="left">
                                                                <b>Gender :</b>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lblGender" runat="server" Text='<%#Bind("GendarFullName") %>'></asp:Label>
                                                            </td>
                                                            <td width="18%" align="left">
                                                                <b>Blood Group :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblBloodGroup" runat="server" Text='<%#Bind("BloodGroup") %>'></asp:Label>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <b>Place of Birth :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblPlaceOfBirth" runat="server" Text='<%#Bind("PlaceOfBirth") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="12%" align="left">
                                                                <b>PassportNo :</b>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lbl" runat="server" Text='<%#Bind("PassportNo") %>'></asp:Label>
                                                            </td>
                                                            <td width="18%" align="left">
                                                                <b>ESI No :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblESINo" runat="server" Text='<%#Bind("ESINo") %>'></asp:Label>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <b>Voter Id :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblVoterId" runat="server" Text='<%#Bind("VoterId") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="12%" align="left">
                                                                <b>Marital Status :</b>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lblMaritalStatus" runat="server" Text='<%#Bind("MaritalStatusFullName") %>'></asp:Label>
                                                            </td>
                                                            <td width="18%" align="left">
                                                                <b>Retirement Date :</b>
                                                            </td>
                                                            <td width="20%" align="left">
                                                                <asp:Label ID="lblRetirementDate" runat="server" Text='<%#Bind("RetirementDate") %>'></asp:Label>
                                                            </td>
                                                            <td width="15%" align="left">
                                                                &nbsp;
                                                            </td>
                                                            <td width="20%" align="left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left" style="width: 15%" valign="top">
                                                   <img src='../../EmpPhotos/<%#Eval("EmployeePic")%>'  width="100" height="150" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:FormView>
                            </asp:Panel>
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="tbpnlAttendance" runat="server" TabIndex="1">
                        <HeaderTemplate>
                            Attendance</HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server">
                                <table border="0" cellpadding="0" cellspacing="0" runat="server" width="70%" align="center">
                                    <tr>
                                        <td align="center" style="width: 100%">
                                            <table width="100%" align="center" cellpadding="0" cellspacing="0" style="border: 2px solid #000000;
                                                font-size: 14px;">
                                                <tr>
                                                    <td colspan="2" style="background: SaddleBrown; color: #fff; border-bottom: 1px solid #000000;"
                                                        align="center">
                                                        <b>Employee Attendance</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 40%">
                                                        Employee Id:
                                                    </td>
                                                    <td align="left" style="width: 60%">
                                                        <asp:Label ID="lblEmpId" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 40%">
                                                        Attendance Date and TIme:
                                                    </td>
                                                    <td align="left" style="width: 60%">
                                                        <asp:TextBox ID="txtDate" runat="server" CssClass="TextBoxdesign"></asp:TextBox>&nbsp;
                                                        <asp:TextBox ID="txtTime" runat="server" Width="60px" CssClass="TextBoxdesign"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 40%">
                                                        Remarks:
                                                    </td>
                                                    <td align="left" style="width: 60%">
                                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="40%" Style="height: 36px"
                                                            CssClass="TextBoxdesign"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="rowAlertMsg" runat="server">
                                                    <td align="left" style="width: 100%" colspan="2">
                                                        <marquee> <asp:Label ID="lblAlertMsg" runat="server" BackColor="Bisque"  ></asp:Label></marquee>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnMarkin" runat="server" Text="MarkIn" OnClick="btnMarkin_Click"
                                                            CssClass="bold" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </ajax:TabPanel>
                 
                    <ajax:TabPanel ID="tbpnlLeaveRequest" runat="server" TabIndex="3">
                        <HeaderTemplate>
                            Leave Request</HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel3" runat="server">
                                <table border="0" cellpadding="0" cellspacing="0" width="50%" runat="server" align="center">
                                    <tr runat="server">
                                        <td align="center" style="width: 100%" runat="server">
                                            <table width="100%" align="center" align="center" cellpadding="0" cellspacing="0"
                                                style="border: 1px solid #000000; font-size: 14px;">
                                                <tr>
                                                    <td colspan="2" style="background: SaddleBrown; color: #fff; border-bottom: 1px solid #000000;"
                                                        align="center">
                                                        Leave Request
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblLeaveMsg" runat="server"></asp:Label><asp:HiddenField ID="hdnLeaveId"
                                                            runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%">
                                                        Employee Id
                                                    </td>
                                                    <td align="left" style="width: 70%">
                                                        <asp:Label ID="lblLeaveEmployeeId" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%">
                                                        From
                                                    </td>
                                                    <td align="left" style="width: 70%">
                                                        <table align="left">
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                                    <ajax:CalendarExtender ID="AjaxCalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                                                        PopupPosition="Right" Enabled="True">
                                                                    </ajax:CalendarExtender>
                                                                    <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator2" runat="server"
                                                                        ErrorMessage="*" ToolTip="Please Enter the From Date" SetFocusOnError="True"
                                                                        ControlToValidate="txtFromDate" ValidationGroup="Req_Blank" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%">
                                                        To
                                                    </td>
                                                    <td>
                                                        <table align="left" style="width: 70%">
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server" onblur="return abc();" CssClass="TextBoxdesign"></asp:TextBox><ajax:CalendarExtender
                                                                        ID="AjaxCalendarExtender2" runat="server" TargetControlID="txtToDate" PopupPosition="Right"
                                                                        Enabled="True">
                                                                    </ajax:CalendarExtender>
                                                                    <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator1" runat="server"
                                                                        ErrorMessage="*" ToolTip="Please Enter the To Date" SetFocusOnError="True" ControlToValidate="txtToDate"
                                                                        ValidationGroup="Req_Blank" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%">
                                                        Nature of Leave
                                                    </td>
                                                    <td align="left" style="width: 70%">
                                                        <asp:DropDownList ID="ddlLeaveNature" runat="server" CssClass="TextBoxdesign" Width="45%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%">
                                                        Reason
                                                    </td>
                                                    <td align="left" style="width: 70%">
                                                        <asp:TextBox ID="txtReason" runat="server" Width="300px" Height="45px" TextMode="MultiLine"
                                                            CssClass="TextBoxdesign"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bold" ValidationGroup="Req_Blank"
                                                            OnClick="btnSave_Click" />
                                                    </td>
                                                </tr>
                                                <tr id="row1" runat="server" visible="False">
                                                    <td id="Td1" runat="server" colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr id="gdvrow1" runat="server" visible="False">
                                                    <td id="Td2" colspan="2" bgcolor="#4b6c9e" runat="server">
                                                        <font color="#FFFFFF"><b>Saved Leave Request</b></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="width: 100%; overflow: auto;">
                                                            <asp:GridView ID="gdvSavedLeaveDetail" runat="server" AutoGenerateColumns="False"
                                                                Width="100%" OnRowCommand="gdvSavedLeaveDetail_RowCommand" OnRowDeleting="gdvSavedLeaveDetail_RowDeleting"
                                                                OnRowEditing="gdvSavedLeaveDetail_RowEditing">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("LeaveId") %>'
                                                                                CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/24533-32-delete-icon.png" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Eval("LeaveId") %>'
                                                                                CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Employee Id" DataField="EmployeeId">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="From Date" DataField="FromDate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="To Date" DataField="ToDate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Nature of Leave" DataField="LeaveNature" />
                                                                    <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                                                    <asp:TemplateField HeaderText="Click Here to Submit">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CommandName="Submit" CommandArgument='<%#Eval("LeaveId") %>' /></ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="row2" runat="server" visible="False">
                                                    <td id="Td3" runat="server" colspan="2">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr id="gdvrow2" runat="server" visible="False">
                                                    <td id="Td4" colspan="2" bgcolor="#4b6c9e" runat="server">
                                                        <font color="#ffffff"><b>Submitted Leave Request</b></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="width: 786px; overflow: auto;">
                                                            <asp:GridView ID="gdvSubmittedLeaveDetail" runat="server" AutoGenerateColumns="False"
                                                                Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="Employee Id" DataField="EmployeeId">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="From Date" DataField="FromDate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="To Date" DataField="ToDate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Reason" DataField="Reason" Visible="False" />
                                                                    <asp:BoundField HeaderText="Approved By" DataField="ApprovedBy" />
                                                                    <asp:BoundField HeaderText="Submitted Date" DataField="SubmittedDate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Approved Date" DataField="ApprovedDate">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Status" DataField="IsApproved">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
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
                    <ajax:TabPanel ID="TabSallarySetup" runat="server" TabIndex="4">
                        <HeaderTemplate>
                            Holidays</HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel4" runat="server">
                                <table width="100%" align="center" bgcolor="#A9A9A9" cellpadding="0" cellspacing="0"
                                    style="border: 1px solid #000000; font-size: 14px;">
                                    <tr>
                        <td align='left' style='background: SaddleBrown; color: #fff; border-bottom: 1px solid #000000;'>
                            <b>List of Holidays for administrative officer of central Goverment located for Delhi/New
                                Delhi</b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gdvHolidayList" runat="server" AllowPaging="True" PageSize="5"
                    Width="100%" AutoGenerateColumns="False"
                    >
                    <RowStyle BorderWidth="2px" BorderColor="Salmon" />
                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                        BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                        ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                <asp:HiddenField ID="hdnHoliDayId" runat="server" Value='<%#Eval("HolidaysId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Holiday" DataField="HoliDays" />
                        <asp:BoundField HeaderText="Date" DataField="EnglishMD" />
                        <asp:BoundField HeaderText="Saka Date" DataField="SakaMD" />
                        <asp:BoundField HeaderText="Day" DataField="HoliDays_Day" />
                        <asp:BoundField HeaderText="Nature of HoliDay" DataField="Holidays_Type" />
                    </Columns>
                    <EmptyDataTemplate>
                        There is no record.....</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </ajax:TabPanel>
                </ajax:TabContainer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
