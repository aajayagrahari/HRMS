<%@ Page Title="Advertisement Master" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="frmAdvertisement.aspx.cs" Inherits="Pages_Admin_frmAdvertisement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table width="100%" align="center"  cellpadding="0"
        cellspacing="0" style="border: 1px solid #000000; font-size: 14px;">
<tr><td colspan="2"><asp:Label ID="lblmsg" runat="server"></asp:Label></td></tr>
<tr><td bgcolor="SaddleBrown" colspan="2"><b><asp:Label ID="lblCreateAdv" runat="server" Text="Create Advertisement" ForeColor="White"></asp:Label> </b></td></tr>
<tr><td width="20%">Advertisement</td>
<td><asp:TextBox ID="txtAdvertisement" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
</tr>
<tr>
<td>Description</td>
<td><asp:TextBox ID="txtDiscription" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
</tr>
<tr>
<td>Opening Date</td>
<td><asp:TextBox ID="txtOpeningDate" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
<ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtOpeningDate"
                                PopupPosition="Right" Enabled="True">
                            </ajax:CalendarExtender>
</td>
</tr>
<tr>
<td>Closing Date</td>
<td><asp:TextBox ID="txtClosingDate" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
<ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtClosingDate"
                                PopupPosition="Right" Enabled="True">
                            </ajax:CalendarExtender>
<asp:HiddenField ID="hdnAdvertisementId1" runat="server" /></td>
</tr>
<tr>
<td align="left" valign="top">Upload Job File</td>
<td align="left" valign="top">: <asp:FileUpload ID="upd_job" runat="server" />
</td>

</tr>
<tr>
<td colspan="2" align="center"><asp:Button ID="btnSave" runat="server" Text="Save" 
        onclick="btnSave_Click"  /></td>
</tr>
<tr><td colspan="2"><br /></td></tr>
<tr><td colspan="2" align="center"><asp:GridView ID="gdvAdvertisementDetail" 
        runat="server" AutoGenerateColumns="false" Width="100%" 
        onrowcommand="gdvAdvertisementDetail_RowCommand" 
        onrowdeleting="gdvAdvertisementDetail_RowDeleting" 
        onrowediting="gdvAdvertisementDetail_RowEditing">
<RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
<Columns>
 <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                    CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
<asp:TemplateField HeaderText="S.No">
<ItemTemplate><%# Container.DataItemIndex+1 %>
<asp:HiddenField ID="hdnAdvertisementId" runat="server" Value='<%#Eval("AdvertisementId") %>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Advertisement">
<ItemTemplate><asp:Label ID="lblAdvertisement" runat="server" Text='<%#Eval("AdvertisementName") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description">
<ItemTemplate>
  <div style="width: 250px; text-align:justify; padding:2px 5px 2px 5px; word-wrap: break-word;">
<asp:Label ID="lblDescription" runat="server" Text='<%#Eval("AdverDescription") %>'></asp:Label>
</div>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Opening Date">
<ItemTemplate><asp:Label ID="lblOpeningDate" runat="server" Text='<%#Eval("OpeningDate1") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Closing Date">
<ItemTemplate><asp:Label ID="lblClosingDate" runat="server" Text='<%#Eval("ClosingDate1") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="View Attached File">
<ItemTemplate><asp:LinkButton ID="lnkFileName" runat="server" Text='<%#Eval("PDFFileName") %>' CommandArgument='<%# Container.DataItemIndex %>'
CommandName="Download"></asp:LinkButton></ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView></td></tr>
</table>
</asp:Content>

