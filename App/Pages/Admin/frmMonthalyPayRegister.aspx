<%@ Page Title="Monthaly Pay Register" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="frmMonthalyPayRegister.aspx.cs" Inherits="Pages_Admin_frmMonthalyPayRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    function Clickheretoprint() {
        var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
        disp_setting += "scrollbars=yes,width=650, height=600, left=100, top=25";
        var content_vlue = document.getElementById("printDiv").innerHTML;

        var docprint = window.open("", "", disp_setting);
        docprint.document.open();
        docprint.document.write('<html><head><title>Challan Report</title>');
        docprint.document.write('</head><body onLoad="self.print()"><center>');
        docprint.document.write(content_vlue);
        docprint.document.write('</center></body></html>');
        docprint.document.close();
        docprint.focus();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%"  align="center" >
<tr><td colspan="2"><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr>
<tr>
<td width="20%"  align="right" 
CssClass="TextBoxdesign" >Select Month</td>
<td ><asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" CssClass="TextBoxdesign" 
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
</asp:DropDownList>
&nbsp;
<asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="Clickheretoprint();" Enabled="false"/>
</td>
</tr>
<tr><td colspan="2" id="printDiv"><asp:Literal ID="litPayRegisterReport" runat="server"></asp:Literal></td></tr>
</table>
</asp:Content>

