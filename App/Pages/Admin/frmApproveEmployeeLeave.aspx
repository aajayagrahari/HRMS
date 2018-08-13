<%@ Page Title="Approve Employee Leave" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="frmApproveEmployeeLeave.aspx.cs" Inherits="Pages_Admin_frmApproveEmployeeLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table align="center" width="100%" bgcolor="#A9A9A9">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="gdvApproveLeave" runat="server" 
        AutoGenerateColumns="false" Width="100%"
Caption="<table width='100%' align='center' align='center' bgcolor='SaddleBrown'
                            cellpadding='0' cellspacing='0' style='border: 1px solid #000000; font-size: 14px;' >
                            <tr><td align='left' style='background: SaddleBrown; color: #fff; 
border-bottom: 1px solid #000000;'><b>Pending Leave Request</b></td></tr></table>" onrowcommand="gdvApproveLeave_RowCommand">

<Columns>
                                            <asp:BoundField HeaderText="Employee Id" DataField="EmployeeId">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="From Date" DataField="FromDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                          
                                            <asp:BoundField HeaderText="To Date" DataField="ToDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:BoundField HeaderText="Nature of Leave" DataField="LeaveNature" />
                                            <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                            <asp:BoundField HeaderText="Submitted Date" DataField="SubmittedDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           <asp:TemplateField HeaderText="Approve/Disapprove">
                                           <ItemTemplate>
                                           <asp:RadioButtonList ID="rblApproceDisApprove" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="2">Disapprove</asp:ListItem>
                                           <asp:ListItem Value="1">Approve</asp:ListItem>
                                           </asp:RadioButtonList>
                                           </ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Remark">
                                           <ItemTemplate><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine">
                                           </asp:TextBox></ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Submit">
                                           <ItemTemplate>
                                           <asp:HiddenField ID="hdnLeaveId" runat="server" Value='<%#Eval("LeaveId") %>'  />
                                           <asp:Button ID="btnSubmit" runat="server" Text="Submit" CommandName="Submit" CommandArgument=  '<%# Container.DataItemIndex %>' />
                                           </ItemTemplate>
                                           </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            There is no record...</EmptyDataTemplate>

</asp:GridView></td></tr>

        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
            <div style="width: 976px; height: 520px; overflow: auto;">
    <asp:GridView ID="gdvApproveDisApprove" runat="server" 
        AutoGenerateColumns="false" Width="100%"
Caption="<table width='100%' align='center'align='center' bgcolor='SaddleBrown'
                            cellpadding='0' cellspacing='0' style='border: 1px solid #000000; font-size: 14px;' >
                            <tr><td align='left' style='background: SaddleBrown; color: #fff; 
border-bottom: 1px solid #000000;'><b>Approve/DisApprove Leave Request</b></td></tr></table>" onrowcommand="gdvApproveLeave_RowCommand" 
        >

        <Columns>
            <asp:BoundField HeaderText="Employee Id" DataField="EmployeeId">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="From Date" DataField="FromDate">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="From Period" DataField="FromPeriod">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="To Date" DataField="ToDate">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="To Period" DataField="ToPeriod">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Nature of Leave" DataField="LeaveNature" />
            <asp:BoundField HeaderText="Reason" DataField="Reason" />
            <asp:BoundField HeaderText="Submitted Date" DataField="SubmittedDate">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Status" DataField="IsApproved" />
            <asp:BoundField HeaderText="Remark" DataField="Remark" />
            <asp:BoundField HeaderText="Approved Date" DataField="ApprovedDate" />
        </Columns>
                                        <EmptyDataTemplate>
                                            There is no record...</EmptyDataTemplate>

</asp:GridView>
</div></td></tr>
</table>
</asp:Content>

