<%@ Page Title="System genrated Attendance" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="frmSystemGenratedAttendanceNew.aspx.cs" Inherits="Pages_Admin_frmSystemGenratedAttendanceNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    function FillDatainOvertime() {

        var PaidDay = document.getElementById('<%=txtPaidDays.ClientID%>');
        var oldPaidDay = PaidDay.value;
        var OverTime = document.getElementById('<%=txtOverTime.ClientID%>');
        if (OverTime.value != 0) {
            var TotalPaidday = parseFloat(PaidDay.value) + parseFloat(OverTime.value);
            PaidDay.value = TotalPaidday;
        }
        else {
            var PaidDay1 = document.getElementById('<%=hdnPaidDays.ClientID%>');
            OverTime.value = "0";
            PaidDay.value = PaidDay1.value;
            
        }
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table id="Table4" border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                    <tr id="Tr4" runat="server">
                                        <td id="Td6" align="left" style="width: 100%;" valign="top" runat="server">
                                            <table id="Table5" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                <tr id="Tr1" runat="server">
                                                    <td id="Td1" align="left" style="width: 100%" runat="server">
                                                        <table border="1" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                                            <tr>
                                                                <td align="center" style="width: 100%">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="50%" align="center">
                                                                        <tr><td><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr>
                                                                        <tr>
                                                                       
                                                                       <td style="width: 15%"><asp:Label ID="Employee" runat="server" CssClass="Label" Text="Employee"></asp:Label></td>
                                                                        <td  style="width: 15%">
                                                                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="TextBoxdesign" >
                                                                        </asp:DropDownList></td>
                                                                        <td style="width: 15%"><asp:Label ID="lblMonth" runat="server" CssClass="Label" Text="Month" ></asp:Label></td>
                                                                            <td align="left" style="width: 15%">
                                                                                
                                                                           
                                                                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" 
                                                                                    Width="155px" AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlMonth_SelectedIndexChanged">
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
                                                                                </asp:DropDownList></td>
                                                                                <td style="width: 15%"><asp:Label ID="lblYear" runat="server" CssClass="Label" Text="Year" ></asp:Label></td>
                                                                                  <td align="left" style="width: 25%">
                                                                                <asp:DropDownList ID="DDLYear" runat="server" CssClass="TextBoxdesign" 
                                                                                    
                                                                                    onselectedindexchanged="DDLYear_SelectedIndexChanged" AutoPostBack="True">
                                                                                    
                                                                                    
                                                                                </asp:DropDownList></td>
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
                                                <tr id="Tr2" runat="server">
                                                    <td id="Td2" align="left" style="width: 100%" runat="server">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="Tr5" runat="server">
                                                    <td id="Td3" align="left" style="width: 100%" runat="server">
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
                                                                                <asp:TextBox ID="txtCode" CssClass="TextBoxdesign" runat="server" Width="75%" 
                                                                                    ></asp:TextBox>
                                                                            </td>
                                                                            <td id="Td10" runat="server">
                                                                                <asp:Label ID="lblName" runat="server" CssClass="Label" Text="Name"></asp:Label>
                                                                            </td>
                                                                            <td id="Td11" runat="server">
                                                                                <asp:TextBox ID="txtName" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td id="Td12" runat="server">
                                                                                <asp:Label ID="lblContactNo" runat="server" CssClass="Label" Text="Contact No."></asp:Label>
                                                                            </td>
                                                                            <td id="Td13" runat="server">
                                                                                <asp:TextBox ID="txtContactNo" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr id="Tr7" runat="server">
                                                                            <td id="Td16" runat="server">
                                                                                <asp:Label ID="lblDOJ" runat="server" CssClass="Label" Text="DOJ"></asp:Label>
                                                                            </td>
                                                                            <td id="Td17" runat="server">
                                                                                <asp:TextBox ID="txtDateOfJoining" runat="server" Width="175" CssClass="TextBoxdesign"></asp:TextBox>
                                                                               
                                                                            </td>
                                                                            <td id="Td18" runat="server">
                                                                                <asp:Label ID="lblFHName" runat="server" CssClass="Label" Text="F/H Name"></asp:Label>
                                                                            </td>
                                                                            <td id="Td19" runat="server">
                                                                                <asp:TextBox ID="txtfhName" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td id="Td20" runat="server">
                                                                            <asp:Label ID="lblEmailId" runat="server" CssClass="Label" Text="E-mail Id"></asp:Label>
                                                                            </td>
                                                                            <td id="Td21" runat="server">
                                                                                <asp:TextBox ID="txtEmail" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                                                                                &nbsp;</td>
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
                                                    <td id="Td4" align="left" style="width: 100%" runat="server">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="Tr9" runat="server">
                                                    <td id="Td5" align="left" style="width: 100%" runat="server">
                                                        <table id="Table2" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                            <tr id="Tr3" runat="server">
                                                                <td id="Td23" style="width: 49%" align="left" runat="server" valign="top">
                                                                    <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 100%">
                                                                                <table style="background-color: ActiveBorder" border="0" cellpadding="0" cellspacing="0"
                                                                                    width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 40%">
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
                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 100%" colspan="4">
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
                                                                                            <asp:TextBox ID="txtTotalDays" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                    
                                                                                   <!-- <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblOnDuty" runat="server" Text="On Duty" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtOnDuty" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        
                                                                                    </tr>!-->
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblPresent" runat="server" Text="Present" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtPresent" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
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
                                                                                            <asp:TextBox ID="txtAbsent" CssClass="TextBoxdesign" runat="server" Width="50%" 
                                                                                                Height="28px"></asp:TextBox>
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
                                                                                                AutoPostBack="True" ></asp:TextBox>
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
                                                                                            <asp:TextBox ID="txtWeeklyOff1" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                       
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblHalfday" runat="server" Text="Half Day" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtlHalfday" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                       
                                                                                    </tr>
                                                                                    <!-- <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lbllateComingDay" runat="server" Text="Late Coming Day" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtlateComingDay" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                       
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblNotMarkoutDay" runat="server" Text="Not Mark Out Day" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtNotMarkoutDay" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                       
                                                                                    </tr>!-->
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblCEL" runat="server" Text="CEL" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtCEL1" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtCEL2" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtCEL3" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                       
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblNCEL" runat="server" Text="NCEL" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtNCEL1" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtNCEL2" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtNCEL3" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                               ></asp:TextBox>
                                                                                        </td>
                                                                                       
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblCL" runat="server" Text="CL" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtCL1" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtCL2" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtCL3" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblHPL" runat="server" Text="HPL" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtHPL1" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtHPL2" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtHPL3" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                       
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblL1" runat="server" Text="L1" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL11" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL12" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL13" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblL2" runat="server" Text="L2" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL21" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL22" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL23" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblL3" runat="server" Text="L3" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL31" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL32" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtL33" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblRestrictedholidays" runat="server" Text="Rst. Holidays" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                        <asp:TextBox ID="txtRestrictedHolidyas1" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtRestrictedHolidyas2" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                 ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                          <asp:TextBox ID="txtRestrictedHolidyas3" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                AutoPostBack="True" ></asp:TextBox>
                                                                                        </td>
                                                                                       
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblMaternity" runat="server" Text="Maternity" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                           <asp:TextBox ID="txtMaternity1" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtMaternity2" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                 ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                           <asp:TextBox ID="txtMaternity3" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                 ></asp:TextBox>
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblPaternity" runat="server" Text="Paternity" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                           <asp:TextBox ID="txtPaternity1" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                 ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtPaternity2" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                 ></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                          <asp:TextBox ID="txtPaternity3" CssClass="TextBoxdesign" runat="server" Width="50%"
                                                                                                 ></asp:TextBox>
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                   <!-- <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblDayWork" runat="server" Text="Day Work" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtDayWork" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                       
                                                                                    </tr>!-->
                                                                                     <tr>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:Label ID="lblOverTime" runat="server" Text="Over Time" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtOverTime" CssClass="TextBoxdesign" Text="0" runat="server" Width="50%" onblur="return FillDatainOvertime();"></asp:TextBox>
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
                                                                                            <asp:TextBox ID="txtPaidDays" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
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
                                                                                            <asp:Label ID="lblEarnSalary" runat="server" Text="Earn Salary" CssClass="Label"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="left" style="width: 20%">
                                                                                            <asp:TextBox ID="txtEarnSalary" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
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
                                                                 
                                                                 <table width="100%">
                                                                 <tr>
                                                                 <td valign="top">
                                                                 <asp:GridView ID="gdvAllowane" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                 
                                                                         
                                                                         caption="<table width='100%'><tr><td style='background: ActiveBorder; color: #fff; border-bottom: 1px solid #000000;'align='center' align='left'>Allowance Detail</td></tr></table>" onrowdatabound="gdvAllowane_RowDataBound" 
                                                                 >
                                                                 <Columns>
                                                                 <asp:TemplateField HeaderText="S.No">
                                                                 <ItemTemplate>
                                                                 <%#Container.DataItemIndex+1 %>
                                                                 </ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Allowance">
                                                                 <ItemTemplate><asp:Label ID="lblAllowance" runat="server" Text='<%#Eval("Allowances")%>'></asp:Label></ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Amount">
                                                                 <ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label></ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Earning Allowance">
                                                                 <ItemTemplate><asp:TextBox ID="txtEarningAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:TextBox></ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 </Columns>
                                                                 </asp:GridView>
                                                                 </td>
                                                                 </tr>
                                                                 <tr><td><br /><br /><br /></td></tr>
                                                                 <tr>
                                                                 <td valign="bottom">
                                                                 <asp:GridView ID="gdvDeduction" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                 
                                                                         caption="<table width='100%'><tr><td style='background: ActiveBorder; color: #fff; border-bottom: 1px solid #000000;'align='center' align='left'>Desuction Detail</td></tr></table>" onrowdatabound="gdvDeduction_RowDataBound"
                                                                 >
                                                                 <Columns>
                                                                 <asp:TemplateField HeaderText="S.No">
                                                                 <ItemTemplate>
                                                                 <%#Container.DataItemIndex+1 %>
                                                                 </ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Deduction">
                                                                 <ItemTemplate><asp:Label ID="lblDeduction" runat="server" Text='<%#Eval("Deductions")%>'></asp:Label></ItemTemplate>
                                                                 </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Limit Amount">
                                                                 <ItemTemplate><asp:Label ID="lblLimit" runat="server" Text='<%#Eval("LimitAmount")%>'></asp:Label></ItemTemplate>
                                                                 </asp:TemplateField>


                                                                 <asp:TemplateField HeaderText="(%)">
                                                                 <ItemTemplate><asp:Label ID="lblDeductionPercentage" runat="server" Text='<%#Eval("DeductionPercetage")%>'></asp:Label></ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Amount">
                                                                 <ItemTemplate><asp:Label ID="lblDeductionAmt" runat="server" Text='<%#Eval("DeductionAmount")%>'></asp:Label></ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Earning Deduction">
                                                                 <ItemTemplate><asp:TextBox ID="txtEarningDeduction" runat="server"></asp:TextBox></ItemTemplate>
                                                                 </asp:TemplateField>
                                                                 </Columns>
                                                                 </asp:GridView>
                                                                 </td>
                                                                 </tr>
                                                                 <tr><td><asp:HiddenField ID="hdnPaidDays" runat="server" /><asp:Button ID="btnProceed" runat="server" Text="Proceed" />
                                                                 <asp:HiddenField ID="hdnWorkingSalary" runat="server" />
                                                                 <asp:HiddenField ID="hdnTotalEarning" runat="server" />
                                                                 </td></tr>
                                                                 
                                                                 </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                       
</asp:Content>

