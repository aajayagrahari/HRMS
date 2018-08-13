<%@ Page Title="AllowanceMaster Master Form" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmAllowanceMaster.aspx.cs" Inherits="Pages_Admin_frmAllowanceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="70%" align="center" cellpadding="0" cellspacing="0" style="background-color: ActiveBorder;
        border: 1px solid #000000; font-size: 14px;">
        <tr>
            <td colspan="2" style="background: SaddleBrown; color: #fff; border-bottom: 1px solid #000000;"
                align="center">
                <asp:Label ID="lblPageHeading" runat="server" Text="Allowance Master" CssClass="pageHeading"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Allowance</b>
            </td>
            <td>
                <asp:TextBox ID="txtAllowance" runat="server" CssClass="TextBoxdesign" Width="250"></asp:TextBox>&nbsp;<asp:Button
                    ID="btnSave" runat="server" Text="Save" Width="70" OnClick="btnSave_Click" />&nbsp;<asp:Button
                        ID="btnCancel" runat="server" Text="Cancel" Width="70" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="gdvAllowance" runat="server" AutoGenerateColumns="false" Width="50%"
                    AutoGenerateEditButton="True" OnRowCancelingEdit="gdvAllowance_RowCancelingEdit"
                    OnRowEditing="gdvAllowance_RowEditing" OnRowUpdating="gdvAllowance_RowUpdating"
                    Caption="<table align='left' width='100%'><tr><td align='left'>Allowance Detail</td></tr></table>"
                    OnRowCommand="gdvAllowance_RowCommand" OnRowDeleting="gdvAllowance_RowDeleting">
                     <RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('are you sure to delete this record?');"
                                    CommandName="Delete" CommandArgument='<%#Eval("AllowanceId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Allowance">
                            <ItemTemplate>
                                <asp:Label ID="lblAllowance" runat="server" Text='<%#Eval("Allowances") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hdnAllowanceId" runat="server" Value='<%#Eval("AllowanceId") %>' />
                                <asp:TextBox ID="gdvtxtAllowance" runat="server" Text='<%#Eval("Allowances") %>'></asp:TextBox></EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        There is no record......</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
