<%@ Page Title="Register of Payment of Wages" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master"
    AutoEventWireup="true" CodeFile="frmEmployeePaymentofWages.aspx.cs" Inherits="Pages_Admin_frmEmployeePaymentofWages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
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
            docprint.document.write('<html><head><title>Inel Power System</title>');
            docprint.document.write('</head><body onLoad="self.print()"><center>');
            docprint.document.write(content_vlue);
            docprint.document.write('</center></body></html>');
            docprint.document.close();
            docprint.focus();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" align="center">
                <tr>
                    <td colspan="2" align="right">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="49%" align="right">
                        <asp:Label ID="lblFiscalYear" runat="server" Text="Financial Year" CssClass="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                        <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="20%">
                        </asp:DropDownList>
                    </td>
                    <td width="49%" align="left">
                        &nbsp;&nbsp;<asp:Label ID="lblMonth" runat="server" Text="Month" CssClass="Label"></asp:Label><br />
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                            AutoPostBack="True">
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
                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="Clickheretoprint();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" id="printDiv" align="center">
                        <asp:Literal ID="litReport" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
