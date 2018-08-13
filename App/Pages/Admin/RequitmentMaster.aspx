<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true"
    CodeFile="RequitmentMaster.aspx.cs" Inherits="Pages_Admin_RequitmentMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script language="javascript" type="text/javascript">
        function validation() {

            var y = document.getElementById("<%=txt_contact_no.ClientID%>").value;
            var RegExEmail = /^(?:\w+\.?)*\w+@(?:\w+\.)+\w+$/;
            var mail = document.getElementById("<%=txt_email.ClientID%>").value;

            if (document.getElementById("<%=txt_fname.ClientID%>").value == "") {
                alert('Please Enter First Name!');
                document.getElementById("<%=txt_fname.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txt_lname.ClientID%>").value == "") {
                alert('Please Enter Last Name!');
                document.getElementById("<%=txt_lname.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txt_date_birth.ClientID%>").value == "") {
                alert('Please Enter Date Of Birth!');
                document.getElementById("<%=txt_date_birth.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txt_email.ClientID%>").value == "") {
                alert('Please Enter Mail ID!');
                document.getElementById("<%=txt_email.ClientID%>").focus();
                return false;
            }
            if (!RegExEmail.test(mail)) {
                alert('Please Insert Valid Mail ID!');
                document.getElementById("<%=txt_email.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txt_contact_no.ClientID%>").value == '') {
                alert('Please Enter Mobile Number!');
                document.getElementById("<%=txt_contact_no.ClientID%>").focus();
                return false;
            }
            if (isNaN(y) || y.indexOf(" ") != -1) {
                alert("Invalid Mobile No. !")
                document.getElementById("<%=txt_contact_no.ClientID%>").focus();
                return false;
            }
            if ((y.length > 10) || (y.length < 10)) {
                alert("Enter 10 digits mobile no!");
                document.getElementById("<%=txt_contact_no.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txt_qualifiaction.ClientID%>").value == '') {
                alert('Please Enter Qualification !');
                document.getElementById("<%=txt_qualifiaction.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_apply_for.ClientID%>").value == '') {
                alert('Please Enter Apply For !');
                document.getElementById("<%=txt_apply_for.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=ddl_exprience.ClientID%>").value == ' -- Select Exprience --') {
                alert('Please Select Experience !');
                document.getElementById("<%=ddl_exprience.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=upd_resume.ClientID%>").value == '') {
                alert('Please Choose Resume !');
                document.getElementById("<%=upd_resume.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txt_city.ClientID%>").value == '') {
                alert('Please Enter City !');
                document.getElementById("<%=txt_city.ClientID%>").focus();
                return false;
            }


            if (document.getElementById("<%=txt_pin_code.ClientID%>").value == '') {
                alert('Please Enter Pin Code !');
                document.getElementById("<%=txt_pin_code.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=ddl_country.ClientID%>").value == '-- Select --') {
                alert('Please Select Country !');
                document.getElementById("<%=ddl_country.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddl_state.ClientID%>").value == '-- Select --') {
                alert('Please Select State !');
                document.getElementById("<%=ddl_state.ClientID%>").focus();
                return false;
            }




            if (document.getElementById("<%=txt_address.ClientID%>").value == '') {
                alert('Please Enter Current Address !');
                document.getElementById("<%=txt_address.ClientID%>").focus();
                return false;
            }




        }
    
                               
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" align="center">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Requairtment Form"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" height="30">
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table width="100%" align="center">
                    <tr>
                        <td align="center" valign="top" colspan="3">
                            <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            First Name
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_fname" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            Last Name
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_lname" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Gender
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="ddl_gender" runat="server" CssClass="TextBoxdesign">
                                <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            Date Of Birth
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_date_birth" runat="server" MaxLength="12" CssClass="TextBoxdesign"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txt_date_birth" runat="server">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Email Id
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_email" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            Mobile No
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_contact_no" CssClass="TextBoxdesign" runat="server" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Last Qualification
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_qualifiaction" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            Apply For
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_apply_for" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Experience
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="ddl_exprience" runat="server" CssClass="TextBoxdesign">
                                <asp:ListItem Text=" -- Select Exprience --" Value=" -- Select Exprience --"></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="10 +" Value="10 +"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            Resume
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:FileUpload ID="upd_resume" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            City
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_city" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            Pin Code
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_pin_code" CssClass="TextBoxdesign" runat="server" MaxLength="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Country
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="ddl_country" runat="server" AutoPostBack="True" CssClass="TextBoxdesign"
                                OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            State
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="ddl_state" runat="server" CssClass="TextBoxdesign">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Current Address
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Height="60" CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                        <td align="left" valign="top" style="padding-left: 50px;">
                            Parmanent Address
                        </td>
                        <td align="left" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txt_paramanent_Address" runat="server" TextMode="MultiLine" Height="60"
                                CssClass="TextBoxdesign"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" height="50">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" valign="top">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClientClick="return validation()"
                                OnClick="btn_submit_Click" />
                        </td>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
