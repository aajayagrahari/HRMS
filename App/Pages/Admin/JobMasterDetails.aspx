<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="JobMasterDetails.aspx.cs" Inherits="Pages_Admin_JobMasterDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table width="100%">
<tr>
<td align="left" style="width: 100%" colspan="3">
<asp:Label ID="lblPageHeader" runat="server" Text="Job Details Master" CssClass="pageHeading"></asp:Label>
<hr />
</td>
</tr>
<tr>
<td align="center" valign="top" colspan="3">
    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
</td>

</tr>

<tr>
<td align="left" valign="top">Job Title</td>
<td align="left" valign="top">:
</td>
<td align="left" valign="top">
    <asp:TextBox ID="txt_job_title" Width="600" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="left" valign="top">Short Discription</td>
<td align="left" valign="top">:
</td>
<td align="left" valign="top">
    <asp:TextBox ID="txt_discription" CssClass="TextBoxdesign" Width="600" Height="150" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="left" valign="top">Upload Job File</td>
<td align="left" valign="top">:
</td>
<td align="left" valign="top">
    <asp:FileUpload ID="upd_job" runat="server" />
</td>
</tr>
<tr>
<td align="left" valign="top"></td>
<td align="left" valign="top">
</td>
<td align="left" valign="top">
    <asp:Button ID="btn_submit" runat="server" Text="Submit" onclick="btn_submit_Click" 
       />
</td>
</tr>
</table>
</asp:Content>

