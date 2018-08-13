<%@ Page Title="HoliDay Master" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmHolidayMaster.aspx.cs" Inherits="Pages_Admin_frmHolidayMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center" height="300" cellpadding="0" cellspacing="0" style="border: 1px solid #000000;
        font-size: 14px;">
        <tr>
            <td colspan="4" style="background: SaddleBrown; border-bottom: 1px solid #000000;" align="center">
            <asp:Label ID="lblHolidayEntry" runat="server" Text="HoliDay Entry Form" ForeColor="White"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="20%" style="font-size: 14px;">
                Financial Year
            </td>
            <td>
                <asp:DropDownList ID="ddlFinYear" runat="server" CssClass="TextBoxdesign" Width="110px">
                </asp:DropDownList>
            </td>
            <td style="font-size: 14px;">
                Natur of HoliDay
            </td>
            <td>
                <asp:DropDownList ID="ddlHoliDayNature" runat="server" CssClass="TextBoxdesign" Width="110px">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="NH">NH</asp:ListItem>
                    <asp:ListItem Value="FH">FH</asp:ListItem>
                    <asp:ListItem Value="RH">RH</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="font-size: 14px;">
                Month
            </td>
            <td width="20%">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="TextBoxdesign" Width="110px">
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
            <td style="font-size: 14px;">
                Date
            </td>
            <td>
                <asp:DropDownList ID="ddlDate" runat="server" CssClass="TextBoxdesign" Width="110px">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">16</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="26">26</asp:ListItem>
                    <asp:ListItem Value="27">27</asp:ListItem>
                    <asp:ListItem Value="28">28</asp:ListItem>
                    <asp:ListItem Value="29">29</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="31">31</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="font-size: 14px;">
                Saka Month
            </td>
            <td>
                <asp:DropDownList ID="ddlSakaMonth" runat="server" CssClass="TextBoxdesign" Width="110px">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="Chaitra">Chaitra</asp:ListItem>
                    <asp:ListItem Value="Vaishākh">Vaishākh</asp:ListItem>
                    <asp:ListItem Value="Jyaishtha">Jyaishtha</asp:ListItem>
                    <asp:ListItem Value="Āshādha">Āshādha</asp:ListItem>
                    <asp:ListItem Value="Shrāvana">Shrāvana</asp:ListItem>
                    <asp:ListItem Value="Bhādrapad"> Bhādrapad</asp:ListItem>
                    <asp:ListItem Value="Āshwin">Āshwin</asp:ListItem>
                    <asp:ListItem Value="Kārtik">Kārtik</asp:ListItem>
                    <asp:ListItem Value="Agrahayana">Agrahayana</asp:ListItem>
                    <asp:ListItem Value="Paush">Paush</asp:ListItem>
                    <asp:ListItem Value="Māgh">Māgh</asp:ListItem>
                    <asp:ListItem Value="Phālgun">Phālgun</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="font-size: 14px;">
                Saka Date
            </td>
            <td>
                <asp:DropDownList ID="ddlSakaDate" runat="server" CssClass="TextBoxdesign" Width="110px">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">16</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="26">26</asp:ListItem>
                    <asp:ListItem Value="27">27</asp:ListItem>
                    <asp:ListItem Value="28">28</asp:ListItem>
                    <asp:ListItem Value="29">29</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="31">31</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="font-size: 14px;">
                Day
            </td>
            <td>
                <asp:DropDownList ID="ddlWeekDay" runat="server" CssClass="TextBoxdesign" Width="110px">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="Monday">Monday</asp:ListItem>
                    <asp:ListItem Value="TuesDay">TuesDay</asp:ListItem>
                    <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                    <asp:ListItem Value="ThursDay">ThursSay</asp:ListItem>
                    <asp:ListItem Value="FriDay">FriDay</asp:ListItem>
                    <asp:ListItem Value="SaturDay">SaturDay</asp:ListItem>
                    <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="font-size: 14px;">
                HoliDay
            </td>
            <td>
                <asp:TextBox ID="txtHoliday" runat="server" CssClass="TextBoxdesign" Width="110px"></asp:TextBox>&nbsp;<asp:Button
                    ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /><asp:HiddenField
                    ID="hdnHolyDayId" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left">
                <table width='100%' align='center' bgcolor='#A9A9A9' cellpadding='0' cellspacing='0'
                    style='border: 1px solid #000000; font-size: 14px;'>
                    <tr>
                        <td align='left' style='background: SaddleBrown; color: #fff; border-bottom: 1px solid #000000;'>

                        <asp:Label ID="lblHeading" runat="server" Text="List of Holidays for administrative officer of central Goverment located for Delhi/New Delhi" ForeColor="White" Width="100%"></asp:Label>
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gdvHolidayList" runat="server" AllowPaging="true" PageSize="5"
                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="gdvHolidayList_PageIndexChanging"
                    OnRowCommand="gdvHolidayList_RowCommand" OnRowEditing="gdvHolidayList_RowEditing"
                    OnRowDeleting="gdvHolidayList_RowDeleting">
                    <RowStyle BorderWidth="2px" BorderColor="Salmon" />
                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="True" Font-Size="Large"
                        BorderColor="Salmon" Height="35px" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="False" BorderColor="Brown" Height="35px"
                        ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("HolidaysId") %>'
                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Eval("HolidaysId") %>'
                                    CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                <asp:HiddenField ID="hdnHoliDayId" runat="server" Value='<%#Eval("HolidaysId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Holiday" DataField="HoliDays" />
                        <asp:BoundField HeaderText="Date" DataField="EnglishMD" />
                        <asp:BoundField HeaderText="Saka Date" DataField="SakaMD" />
                        <asp:BoundField HeaderText="Day" DataField="HoliDays_Day" />
                        <asp:BoundField HeaderText="Nature of HoliDay" DataField="Holidays_Type" />
                    </Columns>
                    <EmptyDataTemplate>
                        There is no record.....</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
