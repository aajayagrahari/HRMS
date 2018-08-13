<%@ Page Title="Approve Updated Attencance" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmApproveUpdatedAttendance.aspx.cs" Inherits="Pages_Admin_frmApproveUpdatedAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript">
        function SelectAllCheckboxes(chk) {
            $('#<%=gdvPendingAttendanse.ClientID %>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center" style="background-color: ActiveBorder">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="width: 15%;background-color: ActiveBorder">
                <asp:Label ID="Employee" runat="server" CssClass="Label" Text="Employee"></asp:Label>
            </td>
            <td  style="width: 15%;background-color: ActiveBorder">
                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="TextBoxdesign" 
                    AutoPostBack="True" onselectedindexchanged="ddlEmployee_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td  style="width: 15%;background-color: ActiveBorder">
                <asp:Label ID="lblMonth" runat="server" CssClass="Label" Text="Month"></asp:Label>
            </td>
            <td  align="left" style="width: 15%;background-color: ActiveBorder">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" Width="155px"
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlMonth_SelectedIndexChanged" >
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">January</asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">August</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td   style="width: 15%;background-color: ActiveBorder">
                <asp:Label ID="lblYear" runat="server" CssClass="Label" Text="Year"></asp:Label>
            </td>
            <td  align="left" style="width: 25%;background-color: ActiveBorder">
                <asp:DropDownList ID="DDLYear" runat="server" CssClass="TextBoxdesign" 
                
                    AutoPostBack="True" onselectedindexchanged="DDLYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td colspan="6"><br /></td></tr>
        <tr>
            <td colspan="6"  style="background-color: ActiveBorder">
                <asp:GridView ID="gdvPendingAttendanse" runat="server" AutoGenerateColumns="false" Width="100%">

                <Columns>
                <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:HiddenField ID="hdnAttendanceId" runat="server" Value='<%#Eval("AttendanceId")%>' />
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select All" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <input id="chkAll" type="checkbox" onclick="SelectAllCheckboxes(this,'<%=gdvPendingAttendanse.ClientID %>');">
                                </HeaderTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approve/DisApprove">
                            <ItemTemplate><asp:RadioButtonList ID="rblApproveDisApprove" runat="server" RepeatDirection="Horizontal"
                            CssClass="TextBoxdesign"
                             AutoPostBack="true" OnSelectedIndexChanged="rblApproveDisApprove_OnSelectedIndexChanged">
                            <asp:ListItem Value="Approve">Approve</asp:ListItem>
                            <asp:ListItem Value="DisApprove">Reject</asp:ListItem>
                            </asp:RadioButtonList></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Attendance Date">
                            <ItemTemplate><asp:TextBox ID="txtAttendanceDate" runat="server" CssClass="TextBoxdesign" Text='<%#Eval("AttendanceDate")%>'></asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MarkIn Time">
                            <ItemTemplate>
                            <asp:TextBox ID="txtMarkinTime" runat="server" Width="60" CssClass="TextBoxdesign" Text='<%#Eval("MarkInTime")%>'></asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Updated MarkIn Time">
                            <ItemTemplate>
                            <asp:TextBox ID="txtUpdatedMarkinTime" runat="server" CssClass="TextBoxdesign" Width="60" Text='<%#Eval("UpdatedMarkInTime")%>'></asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="MarkOut Time">
                            <ItemTemplate>
                            <asp:TextBox ID="txtMarkOutTime" runat="server" Width="60" CssClass="TextBoxdesign" Text='<%#Eval("MarkoutTime")%>'></asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Updated MarkOut Time">
                            <ItemTemplate>
                            <asp:TextBox ID="txtUpdatedMarkOutTime" runat="server" CssClass="TextBoxdesign" Width="60" Text='<%#Eval("UpdatedMarkOutTime")%>'></asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate><asp:TextBox ID="txtRemark" runat="server" CssClass="TextBoxdesign" TextMode="MultiLine"></asp:TextBox></ItemTemplate>
                            </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>There is no record....</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr><td colspan="6"><br /></td></tr>
         <tr id="rowSubmit" runat="server" visible="false"><td colspan="6" align="center" style="background-color: ActiveBorder">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="70" 
                onclick="btnSubmit_Click" /></td></tr>
        <tr><td colspan="6"><br /></td></tr>
        <tr><td colspan="6" style="background-color: ActiveBorder">
        <asp:GridView ID="gdvApproved" runat="server" AutoGenerateColumns="false" Width="100%">
        <Columns>
        <asp:BoundField HeaderText="Employee Name" DataField="Name" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField HeaderText="Attendance Date" DataField="AttendanceDate" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField HeaderText="MarkIn Time" DataField="MarkInTime" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField HeaderText="MarkOut Time" DataField="MarkoutTime" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField HeaderText="Status" DataField="Status1" ItemStyle-HorizontalAlign="Center" />
        </Columns>
        <EmptyDataTemplate>There is no record...</EmptyDataTemplate>
        </asp:GridView>
        </td></tr>
       
    </table>
</asp:Content>
