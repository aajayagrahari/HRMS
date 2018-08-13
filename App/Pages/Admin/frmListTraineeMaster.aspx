<%@ Page Title="List Trainee Master" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmListTraineeMaster.aspx.cs" Inherits="Pages_Admin_frmListTraineeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; background-color: Gray;" valign="bottom">
                <asp:HyperLink ID="hplCreateNew" runat="server" NavigateUrl="~/Pages/Admin/frmEmployeeTraining.aspx"
                    CssClass="Link">
                    <img style="border: 0px; vertical-align: middle;" alt="" src="../../Images/AddNewRecord.gif" /><asp:Label
                        ID="lblAddNewEmployee" runat="server" Text="Create New Training Details" CssClass="Label"
                        ForeColor="White"></asp:Label></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvTraineeList" runat="server" AutoGenerateColumns="false" Width="100%"
                    OnRowCommand="gdvTraineeList_RowCommand" OnRowEditing="gdvTraineeList_RowEditing"
                    OnRowDeleting="gdvTraineeList_RowDeleting">
                    <RowStyle BorderWidth="2" BorderColor="Salmon" />
                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                        BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                        ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Edit" Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Eval("TrainingId") %>'
                                    CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("TrainingId") %>'
                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Training Subject" DataField="Traning_Subject" />
                        <asp:BoundField HeaderText="Start Date" DataField="StarDate" />
                        <asp:BoundField HeaderText="End Date" DataField="EndDate" />
                        <asp:BoundField HeaderText="Duration" DataField="Duration" />
                        <asp:BoundField HeaderText="Discription" DataField="Traning_Description" />
                        <asp:TemplateField HeaderText="Click here">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("TrainingId") %>'></asp:LinkButton></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
