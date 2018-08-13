<%@ Page Title="Deduction Master Form" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmDeductionMaster.aspx.cs" Inherits="Pages_Admin_frmDeductionMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="70%" align="center" cellpadding="0" cellspacing="0"
        style="background-color:ActiveBorder; border: 1px solid #000000; font-size: 14px;">
        <tr>
            <td colspan="2" style="background: SaddleBrown; color: #fff; border-bottom: 1px solid #000000;"
                align="center">
                <asp:Label ID="lblPageHeading" runat="server" Text="Deduction Master" CssClass="pageHeading"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Deduction</b>
            </td>
            <td>
                <asp:TextBox ID="txtDeduction" runat="server" CssClass="TextBoxdesign" Width="250"></asp:TextBox>
                &nbsp;<asp:TextBox ID="txtPercentage" CssClass="TextBoxdesign" runat="server" Width="40"></asp:TextBox>(%)
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="70" OnClick="btnSave_Click" />&nbsp;<asp:Button
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
                <asp:GridView ID="gdvDeduction" runat="server" AutoGenerateColumns="false" Width="50%"
                    AutoGenerateEditButton="True" OnRowCancelingEdit="gdvDeduction_RowCancelingEdit"
                    OnRowEditing="gdvDeduction_RowEditing" Caption="<table align='left' width='100%'><tr><td align='left'>Allowance Detail</td></tr></table>"
                    OnRowCommand="gdvDeduction_RowCommand" OnRowDeleting="gdvDeduction_RowDeleting"
                    OnRowUpdating="gdvDeduction_RowUpdating">
                     <RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('are you sure to delete this record?');"
                                    CommandName="Delete" CommandArgument='<%#Eval("DesuctionId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Deduction">
                            <ItemTemplate>
                                <asp:Label ID="lblDeduction" runat="server" Text='<%#Eval("Deductions") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hdnDeductionId" runat="server" Value='<%#Eval("DesuctionId") %>' />
                                <asp:TextBox ID="gdvtxtDeduction" runat="server" Text='<%#Eval("Deductions") %>'></asp:TextBox></EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="%">
                            <ItemTemplate>
                                <asp:Label ID="lblDeductionPercentage" runat="server" Text='<%#Eval("DeductionPercentage") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDeductionPercentage" runat="server" Text='<%#Eval("DeductionPercentage") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        There is no record......</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
