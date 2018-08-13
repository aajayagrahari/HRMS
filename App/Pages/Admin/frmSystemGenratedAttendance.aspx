<%@ Page Title="System genrated Attendance" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmSystemGenratedAttendance.aspx.cs" Inherits="Pages_Admin_frmSystemGenratedAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function FillDatainOvertime() {

            var Hour = document.getElementById('<%=txtOverTimeHour.ClientID%>');
            var Amtperhour = document.getElementById('<%=txtOverTimeAmount.ClientID%>');
            var Total = document.getElementById('<%=txtTotalOvertimeAmt.ClientID%>');
            var hdnTotalEarning = document.getElementById('<%=hdnTotalEarning.ClientID%>');
            var TotalEarning = document.getElementById('<%=txtEarnSalary.ClientID%>');
            if (Hour.value != "" && Amtperhour.value != "") {
                Total.value = (parseInt(Hour.value)) * (parseInt(Amtperhour.value));
            }
            else {
                Total.value = "0";
            }
            if (parseFloat(Total.value) > 0) {
                TotalEarning.value = parseFloat(TotalEarning.value) + parseFloat(Total.value)
            }
            else {
                TotalEarning.value = hdnTotalEarning.value;
            }

        }
        function hideOnCheck() {
            var chk = document.getElementById('<%=chkDetails.ClientID%>');
            var btn = document.getElementById('<%=btnProceed.ClientID%>');
            if (chk && btn) {
                if (chk.checked == true) {
                    btn.disabled = false;
                }
                else {
                    btn.disabled = true;
                }
            }
        }
        function ValidateNumberOnly() {
            if ((event.keyCode < 48 || event.keyCode > 57)) {
                event.returnValue = false;
            }
        }
        function GetGridvewInput() {
            var grid = document.getElementById("<%=grdAllowances.ClientID%>");
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                alert('dsfds');
                if (inputs[i].type == "text") {
                    if (inputs[i].name.indexOf("txt_DeductAmount").value != "") {
                        alert(inputs.length);
                        amnt = parseInt(inputs[i].name.indexOf("txt_DeductAmount").value);
                        alert(amnt.toString()); // Getting Nan here
                        
                    }
                }
            }
        }
        function GetGridvewInput() {
            var hdnTotalEarning = document.getElementById('<%=hdnTotalEarning.ClientID%>');
            var TotalEarning = document.getElementById('<%=txtEarnSalary.ClientID%>');
            var grid = document.getElementById('<%=grdAllowances.ClientID %>');
            var inputlength = grid.getElementsByTagName('input');
            var DeductiuonAmount, Percentage,DeductiuonAmountFin = 0,Oldvalue=0;
            var ExtraDeduction;
            for (i = 14; i < inputlength.length; i += 5) {
                Percentage = inputlength[i - 1].value;
                DeductiuonAmount = inputlength[i].value;
               // alert(parseFloat(Percentage));
                // alert(DeductiuonAmount);
                if (parseFloat(Percentage)==parseFloat(0)) {
                    //alert(TotalEarning.value);
                    //alert(DeductiuonAmount);
                    DeductiuonAmountFin = parseFloat(DeductiuonAmountFin) + parseFloat(DeductiuonAmount)
                   // TotalEarning.value = (parseFloat(TotalEarning.value)) - (parseFloat(DeductiuonAmount));
                    //alert(TotalEarning.value);
                }
                else {
                    DeductiuonAmountFin = parseFloat(DeductiuonAmountFin) + parseFloat(0)
                    //TotalEarning.value = parseFloat(TotalEarning.value) - parseFloat(0);
                    //alert(TotalEarning.value);
                }
            }
            //alert(parseFloat(hdnTotalEarning.value) - (parseFloat(DeductiuonAmountFin)));
            TotalEarning.value = parseFloat(hdnTotalEarning.value) - (parseFloat(DeductiuonAmountFin));
            
        }
        window.onload = hideOnCheck;
    </script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<style type="text/css">
#overlay {
position: fixed;
top: 0;
left: 0;
width: 100%;
height: 100%;
background-color: #000;
filter:alpha(opacity=70);
-moz-opacity:0.7;
-khtml-opacity: 0.7;
opacity: 0.7;
z-index: 100;
display: none;
}
.cnt223 a{
text-decoration: none;
}
.popup{
width: 100%;
margin: 0 auto;
display: none;
position: fixed;
z-index: 101;
}
.cnt223{
min-width: 600px;
width: 600px;
min-height: 150px;
margin: 100px auto;
background: #f3f3f3;
position: relative;
z-index: 103;
padding: 10px;
border-radius: 5px;
box-shadow: 0 2px 5px #000;
}
.cnt223 p{
clear: both;
color: #555555;
text-align: justify;
}
.cnt223 p a{
color: #d91900;
font-weight: bold;
}
.cnt223 .x{
float: right;
height: 35px;
left: 22px;
position: relative;
top: -25px;
width: 34px;
}
.cnt223 .x:hover{
cursor: pointer;
}
</style>
<script type='text/javascript'>
    $(function () {
    var overlay = $('#<%= btnProceed.ClientID %>');
        overlay.show();
        overlay.appendTo(document.body);
        $('.popup').show();
        $('.close').click(function () {
            $('.popup').hide();
            overlay.appendTo(document.body).remove();
            return false;
        });
        $('.x').click(function () {
            $('.popup').hide();
            overlay.appendTo(document.body).remove();
            return false;
        });
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table id="Table4" border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
     <tr>
                                                <td>
                                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                                     <asp:HiddenField ID="hdnWorkingSalary" runat="server" />
                                        <asp:HiddenField ID="hdnTotalEarning" runat="server" />
                                        <asp:HiddenField ID="hdnPaidDays" runat="server" />
                                                </td>
                                            </tr>
        <tr id="Tr4" runat="server">
            <td id="Td6" align="left" style="width: 100%;" valign="top" runat="server">
                <table id="Table5" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" align="left" style="width: 100%" runat="server">
                            <table border="1" cellpadding="0" cellspacing="0" width="100%" style="background-color: ActiveBorder">
                                <tr>
                                    <td align="center" style="width: 100%">
                                        <table border="0" cellpadding="0" cellspacing="0" width="50%" align="center">
                                           
                                            <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Employee" runat="server" CssClass="Label" Text="Employee"></asp:Label>
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:Label ID="lblMonth" runat="server" CssClass="Label" Text="Month"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 15%">
                                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" Width="155px"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                                                <td style="width: 15%">
                                                    <asp:Label ID="lblYear" runat="server" CssClass="Label" Text="Year"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 25%">
                                                    <asp:DropDownList ID="DDLYear" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="DDLYear_SelectedIndexChanged"
                                                        AutoPostBack="True">
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
                                        <asp:TextBox ID="txtCode" CssClass="TextBoxdesign" runat="server" Width="75%"></asp:TextBox>
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
                                        &nbsp;
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
                                                    <asp:TextBox ID="txtAbsent" CssClass="TextBoxdesign" runat="server" Width="50%" Height="28px"></asp:TextBox>
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
                                                        AutoPostBack="True"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtCEL1" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtCEL2" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtCEL3" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblNCEL" runat="server" Text="NCEL" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtNCEL1" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtNCEL2" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtNCEL3" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblCL" runat="server" Text="CL" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtCL1" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtCL2" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtCL3" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblHPL" runat="server" Text="HPL" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtHPL1" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtHPL2" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtHPL3" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblL1" runat="server" Text="L1" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL11" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL12" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL13" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblL2" runat="server" Text="L2" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL21" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL22" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL23" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblL3" runat="server" Text="L3" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL31" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL32" CssClass="TextBoxdesign" runat="server" Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtL33" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblRestrictedholidays" runat="server" Text="Rst. Holidays" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtRestrictedHolidyas1" CssClass="TextBoxdesign" runat="server"
                                                        Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtRestrictedHolidyas2" CssClass="TextBoxdesign" runat="server"
                                                        Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtRestrictedHolidyas3" CssClass="TextBoxdesign" runat="server"
                                                        Width="50%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblMaternity" runat="server" Text="Maternity" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtMaternity1" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtMaternity2" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtMaternity3" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblPaternity" runat="server" Text="Paternity" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtPaternity1" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtPaternity2" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtPaternity3" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
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
                                                <td align="left" colspan="3" style="width: 40%">
                                                    Hour
                                                    <asp:TextBox ID="txtOverTimeHour" CssClass="TextBoxdesign" Text="0" runat="server"
                                                        Width="20" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>Amount
                                                    <asp:TextBox ID="txtOverTimeAmount" Width="30" CssClass="TextBoxdesign" Text="0"
                                                        runat="server" onblur="return FillDatainOvertime();" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                    Total
                                                    <asp:TextBox ID="txtTotalOvertimeAmt" Width="30" CssClass="TextBoxdesign" Text="0"
                                                        runat="server" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblPaidDays" runat="server" Text="Paid Days" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    &nbsp;
                                                </td>
                                                <td colspan="2" align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtPaidDays" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%">
                                                    <asp:Label ID="lblEarnSalary" runat="server" Text="Earn Salary" CssClass="Label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%">
                                                    &nbsp;
                                                </td>
                                                <td colspan="2" align="left" style="width: 20%">
                                                    <asp:TextBox ID="txtEarnSalary" CssClass="TextBoxdesign" runat="server" Width="50%"></asp:TextBox>
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
                                        <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                            <tr>
                                                <td align="left" style="width: 100%">
                                                    <table border="1" cellpadding="0" cellspacing="0" width="100%" runat="server" align="center">
                                                        <tr>
                                                            <td align="left" style="width: 100%" valign="top" runat="server">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" style="background-color: ActiveBorder">
                                                                    <tr>
                                                                        <td align="center" style="width: 100%;" valign="top" colspan="6" runat="server">
                                                                            <div style="width: 100%; height: 300px; overflow: auto;">
                                                                                <asp:GridView ID="grdAllowances" runat="server" AutoGenerateColumns="False" Width="580px"
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
                                                                                                    onkeypress="return ValidateNumberOnly(event);" Width="85%" Text='<%#Eval("DedAmount")%>'
                                                                                                    OnTextChanged="txt_DeductAmount_TextChanged" AutoPostBack="true" onblur="return GetGridvewInput();"></asp:TextBox>
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
                                                        <tr><td><br /></td></tr>
                                                        <tr>
                                                        <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="vertical-align: top;background-color: ActiveBorder">
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 40%">
                                                                                                                            <asp:Label ID="lblArrPaidDays" runat="server" Text="Arr.Paid Days" CssClass="Label"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="center" style="width: 60%">
                                                                                                                            <asp:TextBox ID="txtArrPaidDays" CssClass="TextBoxdesign" runat="server" Width="40" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 40%">
                                                                                                                            <asp:Label ID="lblPfPaidDays" runat="server" Text="PF Paid Days" CssClass="Label"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="center" style="width: 60%">
                                                                                                                            <asp:TextBox ID="txtPfPaidDays" CssClass="TextBoxdesign" runat="server" Width="40" onkeypress="return ValidateNumberOnly(event);"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" style="width: 40%">
                                                                                                                            <asp:Label ID="lblEsiPaidDays" runat="server" CssClass="Label" 
                                                                                                                                Text="ESI Paid Days"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="center" style="width: 60%">
                                                                                                                            <asp:TextBox ID="txtEsiPaidDays" runat="server" CssClass="TextBoxdesign" 
                                                                                                                                onkeypress="return ValidateNumberOnly(event);" Width="40"></asp:TextBox>
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
                                 <tr id="rowChk" runat="server" visible="false"><td class="tblTDText">
                <asp:CheckBox ID="chkDetails"  runat="server" 
                        Text="All the above selected items are correct & verified." onclick="return hideOnCheck();"/>
                </td></tr>
                                <tr id="rowSubmit" runat="server" visible="false" >
                                    <td>
                                        
                                        <asp:Button ID="btnProceed" runat="server" Text="Submit" 
                                            onclick="btnProceed_Click" />
                                       
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
