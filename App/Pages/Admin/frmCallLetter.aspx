<%@ Page Title="Call Letter" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmCallLetter.aspx.cs" Inherits="Pages_Admin_frmCallLetter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center" cellpadding="0" cellspacing="0" style="border: 1px solid #000000;
        font-size: 14px;">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" align="center">
                    <tr>
                        <td bgcolor="SaddleBrown">
                        <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="White"></asp:Label>
                            
                        </td>
                        <td bgcolor="SaddleBrown">
                        <asp:Label ID="lblEmailid" runat="server" Text="Email-Id" ForeColor="White"></asp:Label>
                            
                        </td>
                        <td bgcolor="SaddleBrown">
                         <asp:Label ID="lblDesignation" runat="server" Text="Designation" ForeColor="White"></asp:Label>
                            
                        </td>
                        <td bgcolor="SaddleBrown">
                         <asp:Label ID="lblVenue" runat="server" Text="Venue" ForeColor="White"></asp:Label>
                            
                        </td>
                        <td bgcolor="SaddleBrown">
                         <asp:Label ID="lblDate" runat="server" Text="Date" ForeColor="White"></asp:Label>
                            
                        </td>
                        <td bgcolor="SaddleBrown">
                        <asp:Label ID="lblFileName" runat="server" Text="File Name" ForeColor="White"></asp:Label>
                            
                        </td>
                        <td bgcolor="SaddleBrown">
                         <asp:Label ID="lblProjectSiteName" runat="server" Text="Project Site Name" ForeColor="White"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVenue" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                PopupPosition="Right" Enabled="True">
                            </ajax:CalendarExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFileName" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                            <td>
                                <asp:TextBox ID="txtProjectSiteName" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="70" OnClick="btnAdd_Click" />&nbsp;<asp:HiddenField
                                ID="hdnCallLetterId" runat="server" />
                        </td>
                    </tr>
                </table>
        </tr>
        <tr>
            <td>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gdvCallLetter" runat="server" Width="100%" AutoGenerateColumns="false"
                    AllowPaging="false" PageSize="5" OnPageIndexChanging="gdvCallLetter_PageIndexChanging"
                    OnRowCommand="gdvCallLetter_RowCommand" OnRowDeleting="gdvCallLetter_RowDeleting"
                    OnRowEditing="gdvCallLetter_RowEditing">
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
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                <asp:HiddenField ID="hdnCallLetterMasterId" runat="server" Value='<%#Eval("CallLetterMasterId")%>' />
                                <asp:HiddenField ID="hdnDate" runat="server" Value='<%#Eval("InterviewDate1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="gdvtxtName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email-Id">
                            <ItemTemplate>
                                <asp:Label ID="gdvtxtEmailID" runat="server" Text='<%#Eval("EmailId")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation">
                            <ItemTemplate>
                                <asp:Label ID="gdvtxtDesignation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Venue">
                            <ItemTemplate>
                                <asp:Label ID="gdvtxtVenue" runat="server" Text='<%#Eval("Venue")%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Interview Date">
                            <ItemTemplate>
                                <asp:Label ID="gdvtxtInterviewDate" runat="server" Text='<%#Eval("InterviewDate")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="File Name">
                            <ItemTemplate>
                                <asp:Label ID="gdvtxtFileName" runat="server" Text='<%#Eval("CFileName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project SiteName">
                            <ItemTemplate>
                                <asp:Label ID="gdvtxtProjectSiteName" runat="server" Text='<%#Eval("ProjectSiteName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enter Manager Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txtManagerName" runat="server"></asp:TextBox></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Click Here">
                            <ItemTemplate>
                                <asp:Button ID="gdvbtnCallletter" runat="server" Text="Print Call Letter" CommandArgument='<%# Container.DataItemIndex %>' /></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
