<%@ Page Title="Post Detail" Language="C#" MasterPageFile="~/Master/Admin.master"
    AutoEventWireup="true" CodeFile="frmPostDetail.aspx.cs" Inherits="Pages_Admin_frmPostDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table align="center" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" bgcolor="SaddleBrown">
                <asp:Label ID="postDetailEntry" runat="server" Text="Post Detail Entry" ForeColor="White"
                    Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gdvPostDetail" runat="server" AutoGenerateColumns="false" Width="100%"
                    AllowPaging="True" OnPageIndexChanging="gdvPostDetail_PageIndexChanging" PageSize="7">
                    <RowStyle BorderWidth="2" BorderColor="Salmon" />
                    <PagerStyle BackColor="DarkSalmon" ForeColor="Snow" Font-Bold="true" Font-Size="Large"
                        BorderColor="Salmon" Height="35" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="SaddleBrown" Font-Italic="false" BorderColor="Brown" Height="35"
                        ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                                <asp:HiddenField ID="hdnPostId" runat="server" Value='<%#Eval("PostId") %>' />
                                <asp:HiddenField ID="hdnPostDetailID" runat="server" Value='<%#Eval("PostIdDetailId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Post Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPost" runat="server" Text='<%#Eval("PostName") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGenral" runat="server" Text="Genral" Checked='<%#Eval("IsGenral") %>' />
                                <asp:CheckBox ID="chkST" runat="server" Text="ST" Checked='<%#Eval("IsST") %>' />
                                <asp:CheckBox ID="chkSC" runat="server" Text="SC" Checked='<%#Eval("IsSC") %>' />
                                <asp:CheckBox ID="chkOBC" runat="server" Text="OBC" Checked='<%#Eval("IsOBC") %>' />
                                <asp:CheckBox ID="chkPH" runat="server" Text="PH" Checked='<%#Eval("IsPH") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fee Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGNFee" runat="server" Width="30" Text='<%#Eval("GenralAmt","{0:0}") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtSTFee" runat="server" Width="40" Text='<%#Eval("STAmt","{0:0}") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtSCFee" runat="server" Width="40" Text='<%#Eval("SCAmt","{0:0}") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtOBCFee" runat="server" Width="40" Text='<%#Eval("OBCAmt","{0:0}") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtPHFee" runat="server" Width="40" Text='<%#Eval("PHAmt","{0:0}") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vacancy">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGNVac" runat="server" Width="30" Text='<%#Eval("GenralSeat") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtSTVac" runat="server" Width="30" Text='<%#Eval("STSeat") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtSCVac" runat="server" Width="30" Text='<%#Eval("SCSeat") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtOBCVac" runat="server" Width="30" Text='<%#Eval("OBCSeat") %>'></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtPHVac" runat="server" Width="30" Text='<%#Eval("PHSeat") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        There is no record...</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save/Update" Width="90" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
