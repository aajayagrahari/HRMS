<%@ Page Title="Post Master" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="frmPostMaster.aspx.cs" Inherits="Pages_Admin_frmPostMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    function ValidateNumberOnly() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
            event.returnValue = false;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="80%" align="center"  cellpadding="0" 
        cellspacing="0" style="border: 1px solid #000000; font-size: 14px;padding:0px 10px 0px 10px;">
        <tr><td bgcolor="SaddleBrown" colspan="2" align="center"><asp:Label ID="lblCreatePost" runat="server" Text="Create Post" ForeColor="White"></asp:Label></td></tr>
<tr><td colspan="2"><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr>
<tr>
<td width="20%">Advertisement</td>
<td><asp:DropDownList ID="ddlAdvertisement" runat="server" CssClass="TextBoxdesign"></asp:DropDownList></td>
</tr>
<tr>
<td>Post</td>
<td><asp:TextBox ID="txtPost" runat="server" CssClass="TextBoxdesign" Width="200"></asp:TextBox>&nbsp;
Min Age&nbsp;<asp:TextBox ID="txtMinAge" runat="server" Width="30" onkeypress="return ValidateNumberOnly();"></asp:TextBox>
&nbsp;
Max Age&nbsp;<asp:TextBox ID="txtMaxAge" runat="server" Width="30" onkeypress="return ValidateNumberOnly();"></asp:TextBox>
</td>
</tr>
<tr><td>Post Detail</td>
<td><asp:TextBox ID="txtPostDetail" runat="server" TextMode="MultiLine" Width="400" CssClass="TextBoxdesign" Height="150"></asp:TextBox></td>
</tr>
<tr><td colspan="2"><asp:Button ID="btnSave" runat="server" Text="Save" Width="70" 
        onclick="btnSave_Click" /><asp:HiddenField ID="hdnPostId1" runat="server" /></td></tr>

<tr><td colspan="2">
<br />
</td></tr>
<tr><td colspan="2"><asp:GridView ID="gdvPostDetail" runat="server" 
        AutoGenerateColumns="false" Width="100%" 
        onrowcommand="gdvPostDetail_RowCommand" 
        onrowdeleting="gdvPostDetail_RowDeleting" 
        onrowediting="gdvPostDetail_RowEditing" AllowPaging="True" 
        onpageindexchanging="gdvPostDetail_PageIndexChanging" PageSize="20">
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
<asp:TemplateField HeaderText="S.No.">
<ItemTemplate><%# Container.DataItemIndex+1 %>
<asp:HiddenField ID="hdnPostId" runat="server" Value='<%#Eval("PostId")%>'  />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post Name">
<ItemTemplate><asp:Label ID="lblPostName" runat="server" Text='<%#Eval("PostName")%>' ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post Description">
<ItemTemplate><asp:Label ID="lblPostDetail" runat="server" Text='<%#Eval("PostDescription")%>' ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Min Age">
<ItemTemplate><asp:Label ID="lblMinAge" runat="server" Text='<%#Eval("MinAge")%>' ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Max Age">
<ItemTemplate><asp:Label ID="lblMaxge" runat="server" Text='<%#Eval("MaxAge")%>' ></asp:Label></ItemTemplate>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>There is no record...</EmptyDataTemplate>
</asp:GridView></td></tr>
</table>
</asp:Content>

