<%@ Page Title="Employee Training" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmEmployeeTraining.aspx.cs" Inherits="Pages_Admin_frmEmployeeTraining" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript">
        function SelectAllCheckboxes(chk) {
            $('#<%=gdvTrainingEmployee.ClientID %>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center" cellpadding="0" cellspacing="0" style="border: 1px solid #000000;
        font-size: 14px;">
        <tr>
            <td colspan="2" style="background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;"
                align="center">
                Training Detail
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" width="70%" align="center">
                    <tr>
                        <td>
                            <b>Subject</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSubject" runat="server" Width="250px" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <b>Start Date</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="TextBoxdesign" Width="130px"></asp:TextBox>
                            <ajax:CalendarExtender ID="AjaxCalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                PopupPosition="Right" Enabled="True">
                            </ajax:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>End Date</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="TextBoxdesign" Width="130px"></asp:TextBox>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                                PopupPosition="Right" Enabled="True">
                            </ajax:CalendarExtender>
                            &nbsp;&nbsp;<asp:TextBox ID="txtHour" runat="server" Width="40" CssClass="TextBoxdesign"></asp:TextBox>(Hour)&nbsp;<asp:TextBox
                                ID="txtMinute" runat="server" Width="40" CssClass="TextBoxdesign"></asp:TextBox>(Minute)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Description</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300"
                                CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="70" OnClick="btnSave_Click" Enabled="true" />&nbsp<asp:Button
                                ID="btnCancel" runat="server" Text="Cancel" Width="70" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <div style="width: 1074px; height: 1024px; overflow: auto;">
                    <asp:GridView ID="gdvTrainingEmployee" runat="server" AutoGenerateColumns="false"
                        Width="100%">
                        <RowStyle BorderWidth="2" BorderColor="Salmon" />
                        <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                            BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                            ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select All" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" Checked='<%#Eval("_Flag") %>' />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <input id="chkAll" type="checkbox" onclick="SelectAllCheckboxes(this,'<%=gdvTrainingEmployee.ClientID %>');">
                                </HeaderTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Empployee Id">
                                <ItemTemplate>
                                    <asp:Label ID="gdvlblId" runat="server" Text='<%#Eval("EmployeeId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <asp:Label ID="gdvEmployeeName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="gdvDesignation" runat="server" Text='<%#Eval("Designation") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:Label ID="gdvDepartment" runat="server" Text='<%#Eval("Department") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact No.">
                                <ItemTemplate>
                                    <asp:Label ID="gdvContact" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email-Id">
                                <ItemTemplate>
                                    <asp:Label ID="gdvEmailId" runat="server" Text='<%#Eval("EmailId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
