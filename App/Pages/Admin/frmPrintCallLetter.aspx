<%@ Page Title="Call Letter" Language="C#" MasterPageFile="~/Master/BlankMaster.master"
    AutoEventWireup="true" CodeFile="frmPrintCallLetter.aspx.cs" Inherits="Pages_Admin_frmPrintCallLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function Clickheretoprint() {
            var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
            disp_setting += "scrollbars=yes,width=650, height=600, left=100, top=25";
            var content_vlue = document.getElementById("printDiv").innerHTML;

            var docprint = window.open("", "", disp_setting);
            docprint.document.open();
            docprint.document.write('<html><head><title>BECIL</title>');
            docprint.document.write('</head><body onLoad="self.print()"><center>');
            docprint.document.write(content_vlue);
            docprint.document.write('</center></body></html>');
            docprint.document.close();
            docprint.focus();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="center">
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="Clickheretoprint();" />&nbsp;
                <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" OnClick="btnSendMail_Click" />
            </td>
        </tr>
        <tr>
            <td id="printDiv">
                <asp:Literal ID="litReport" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
