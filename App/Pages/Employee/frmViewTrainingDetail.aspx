<%@ Page Title="View Training Detail" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true" CodeFile="frmViewTrainingDetail.aspx.cs" Inherits="Pages_Employee_frmViewTrainingDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" align="center" cellpadding="0" cellspacing="0" style="border: 1px solid #000000;
        font-size: 14px;">

<tr><td><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr>
<tr><td>
<asp:GridView ID="gdvTrainingDetail" runat="server" AutoGenerateColumns="false" Width="100%">
<RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
<Columns>
<asp:BoundField HeaderText="Subject" DataField="Traning_Subject" />
<asp:BoundField HeaderText="Start Date" DataField="StarDate" />
<asp:BoundField HeaderText="End Date" DataField="EndDate" />
<asp:BoundField HeaderText="Duration" DataField="Duration" />
<asp:BoundField HeaderText="Description" DataField="Traning_Description" />
</Columns>
</asp:GridView>
</td></tr>
</table>
</asp:Content>

