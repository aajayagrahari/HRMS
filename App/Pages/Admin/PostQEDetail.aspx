<%@ Page Title="Qualification Experience Detail" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="PostQEDetail.aspx.cs" Inherits="Pages_Admin_PostQEDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="80%" align="center"  cellpadding="0" 
        cellspacing="0" style="border: 1px solid #000000; font-size: 14px;padding:0px 10px 0px 10px;">
        <tr><td bgcolor="SaddleBrown" colspan="2" align="center">
        <asp:Label ID="lblQualificationExperience" runat="server" Text="Qualification Experience Entry Form" ForeColor="White"></asp:Label>
        </td></tr>
<tr><td colspan="2" align="center"><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr>
<tr>
<td width="20%">Post</td>
<td><asp:DropDownList ID="ddlPost" runat="server" CssClass="TextBoxdesign"></asp:DropDownList></td>
</tr>
<tr>
<td align="left" valign="top">Qualification Detail</td>
<td align="left" valign="top"><asp:TextBox ID="txtQualificationDetail" runat="server" CssClass="TextBoxdesign" Width="200"></asp:TextBox>&nbsp;

<asp:RadioButtonList ID="rdo_education_type" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Value="General">General Education</asp:ListItem>
<asp:ListItem Value="Pro">Professional Education</asp:ListItem>
</asp:RadioButtonList>
</td>
</tr>
<tr>
<td></td>
<td>
<asp:RadioButtonList ID="rblEssentialandDesirable" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Value="E">Essential</asp:ListItem>
<asp:ListItem Value="D">Desirable</asp:ListItem>
</asp:RadioButtonList>

</td>
</tr>
<tr><td>Experience Detail</td>
<td><asp:TextBox ID="txtExperienceDetail" runat="server" TextMode="MultiLine" Width="300" CssClass="TextBoxdesign" Height="50"></asp:TextBox></td>
</tr>
<tr><td colspan="2"><asp:Button ID="btnSave" runat="server" Text="Save" Width="70" 
        onclick="btnSave_Click" /><asp:HiddenField ID="hdnPostQEIdId1" runat="server" /></td></tr>

<tr><td colspan="2">
<br />
</td></tr>
<tr><td colspan="2"><asp:GridView ID="gdvPostQEDetail" runat="server" 
        AutoGenerateColumns="false" Width="100%" 
        onrowcommand="gdvPostQEDetail_RowCommand" 
        onrowdeleting="gdvPostQEDetail_RowDeleting" 
        onrowediting="gdvPostQEDetail_RowEditing" AllowPaging="True" 
        onpageindexchanging="gdvPostQEDetail_PageIndexChanging" PageSize="20" 
       >
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
<asp:HiddenField ID="hdnPostQEIdId" runat="server" Value='<%#Eval("PostQEDetailId") %>'   />
<asp:HiddenField ID="hdnPostId" runat="server" Value='<%#Eval("PostId") %>' />
<asp:HiddenField ID="hdnType" runat="server" Value='<%#Eval("QualificationType1") %>' />
<asp:HiddenField ID="hdnEType" runat="server" Value='<%#Eval("EType") %>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Post Name">
<ItemTemplate><asp:Label ID="lblPostName" runat="server" Text='<%#Eval("PostName") %>'  ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Qualification">
<ItemTemplate><asp:Label ID="lblQualification" runat="server" Text='<%#Eval("QualificationDetail") %>'  ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Qualification Type">
<ItemTemplate><asp:Label ID="lblQualificationType" runat="server" Text='<%#Eval("QualificationType") %>'  ></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Experience">
<ItemTemplate><asp:Label ID="lblExperience" runat="server" Text='<%#Eval("ExperienceDetail") %>'  ></asp:Label></ItemTemplate>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>There is no record...</EmptyDataTemplate>
</asp:GridView></td></tr>
</table>
</asp:Content>

