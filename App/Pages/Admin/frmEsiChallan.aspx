<%@ Page Title="Challan Report" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmEsiChallan.aspx.cs" Inherits="Pages_Admin_frmEsiChallan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function ValidateNumberOnly() {
            if ((event.keyCode < 48 || event.keyCode > 57)) {
                event.returnValue = false;
            }
        }
        function print() {

            var prtContent = document.getElementById("printDiv");
            var WinPrint = window.open('', '', 'left=0,top=0,width=900,height=700,status=0,scrollbars=yes');
            WinPrint.document.write("<html><head><link href=\"../App_Themes/CSS/VMC.css\" rel=\"stylesheet\" type=\"text/css\" /></head><br><body>" + prtContent.innerHTML + "<br><\/body><br><\/html>");
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
        function btnPrint_onclick() {
            print();
        }
        function Clickheretoprint() {
            var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
            disp_setting += "scrollbars=yes,width=650, height=600, left=100, top=25";
            var content_vlue = document.getElementById("printDiv").innerHTML;

            var docprint = window.open("", "", disp_setting);
            docprint.document.open();
            docprint.document.write('<html><head><title>E.S.I. Challan</title>');
            docprint.document.write('</head><body onLoad="self.print()"><center>');
            docprint.document.write(content_vlue);
            docprint.document.write('</center></body></html>');
            docprint.document.close();
            docprint.focus();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center" style="border: 1px solid #000000;">
        <tr>
            <td align="left" style="width: 100%">
                <table width="100%" align="center" style="border: 1px solid #000000; background-color: ActiveBorder;">
                    <tr>
                        <td align="left" style="width: 100%">
                            <table width="100%" align="center" style="border: 1px solid #000000;">
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width : 15%">
                                        <asp:Label ID="lblCompanyName" runat="server" Text="Organisation Name" CssClass="Label"></asp:Label>
                                    </td>
                                    <td align="left" style="width : 15%">
                                        <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="Label"></asp:Label>
                                    </td>
                                    <td align="left" style="width : 15%">
                                        <asp:Label ID="lblBankName" runat="server" Text="Bank Name" CssClass="Label"></asp:Label>
                                    </td>
                                    <td align="left" style="width : 15%">
                                        <asp:Label ID="lblChequeNo" runat="server" Text="Cheque No." CssClass="Label"></asp:Label>
                                    </td>
                                    <td align="left" style="width : 15%">
                                        <asp:Label ID="lblDate" runat="server" Text="Date" CssClass="Label"></asp:Label>
                                    </td>
                                    <td align="left" style="width : 15%">
                                        <asp:Label ID="lblFinancialYear" runat="server" Text="Financial Year" CssClass="Label"></asp:Label>
                                    </td>
                                    <td align="left" style="width : 10%">
                                        <asp:Label ID="lblMonth" runat="server" Text="Select Month" CssClass="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtOrgName" runat="server" CssClass="TextBoxdesign" Width="170px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" CssClass="TextBoxdesign" runat="server"
                                            Width="165px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBankName" runat="server" CssClass="TextBoxdesign" Width="195px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtChequeNo" CssClass="TextBoxdesign" runat="server" onkeypress="return ValidateNumberOnly();"
                                            Width="130px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" CssClass="TextBoxdesign" runat="server" Width="110px"></asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                            PopupPosition="Right" Enabled="True">
                                        </ajax:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                                            AutoPostBack="True" Width="100px">
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
                                </tr>
                                <tr>
                                    <td width="49%" align="left" colspan="5">
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="Clickheretoprint();" Enabled="false"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="5" id="printDiv">
                <asp:Literal ID="litReport" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
