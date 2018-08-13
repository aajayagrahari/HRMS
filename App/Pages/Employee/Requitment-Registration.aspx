<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true"
    CodeFile="Requitment-Registration.aspx.cs" Inherits="Pages_Admin_Requitment_Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">

        function ShowHide() {

            var msg = document.getElementById('<%=lbl_msg.ClientID%>');
            if (msg.innerHtml == 'true') {
                var Div_Show = document.getElementById('<%=Div_Show.ClientID%>');
                var radio = document.getElementById('<%=rdo_categry.ClientID%>');

                var radioButtons = radio.getElementsByTagName('input');

                if (radioButtons[0].checked) {
                    Div_Show.style.display = "none";

                }
                if (radioButtons[1].checked || radioButtons[2].checked || radioButtons[3].checked || radioButtons[4].checked) {

                    Div_Show.style.display = "block";

                }
            }

        }


        function display() {

            if (document.getElementById('<%=ddl_post.ClientID%>').value == '-- Select Post --') {
                alert('Please Enter Apply Post !');
                document.getElementById('<%=ddl_post.ClientID%>').focus();
                return false;
            }
            var date = new Date();

            var d = date.getDate();
            var m = date.getMonth() + 1;
            var y = date.getFullYear();
            var postingdate = document.getElementById('<%=lbl_posting_Date.ClientID%>').value;
            var dob = document.getElementById('<%=txt_dob.ClientID%>').value;

            var OpeningDate = new Date(postingdate);

            var openingYear = OpeningDate.getFullYear();
            var openingMonth = OpeningDate.getMonth();

            date1 = new Date(dob);
            var dobmonth = date1.getMonth();
            var year = date1.getFullYear();

            var totalyear = openingYear - year;
            var totalmonth = dobmonth - openingMonth;
            var Minage = document.getElementById('<%=lbl_min_Age.ClientID%>').value;
            var Maxage = document.getElementById('<%=lbl_max_age.ClientID%>').value;

            var a = parseInt(totalyear);
            var b = parseInt(Minage);
            var msg = document.getElementById('<%=lbl_msg.ClientID%>');
            var btn_submit = document.getElementById('<%=btn_submit.ClientID%>');

            if (a < b) {
                alert("You are not eligible for this post");
                msg.innerHtml = 'false';
                btn_submit.style.display = "none";
                return;
            }
            else {
                msg.innerHtml = 'true';
                btn_submit.style.display = "block";
            }
            if (parseInt(totalyear) > parseInt(Maxage)) {
                alert("You are not eligible for this post ");
                msg.innerHtml = 'false';
                btn_submit.style.display = "none";
                return;
            }
            else {
                msg.innerHtml = 'true';
                btn_submit.style.display = "block";
            }
        }
    </script>
    <script type="text/javascript">
        function display1() {

            if (document.getElementById('<%=ddl_post.ClientID%>').value == '-- Select Post --') {
                alert('Please Enter Apply Post !');
                document.getElementById('<%=ddl_post.ClientID%>').focus();
                return false;
            }
        }
        function DateValidation() {

            var chkdate = document.getElementById('<%=txt_dob.ClientID%>').value
            if (document.getElementById('<%=txt_dob.ClientID%>').value == '') {
                alert("Please enter the Date of birth !")

                document.getElementById('<%=txt_dob.ClientID%>').focus();

                return false;
            }
            else if (!chkdate.match(/^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/)) {
                alert('Invalid Date Format !');
                document.getElementById('<%=txt_dob.ClientID%>').focus();

                return false;
            }
        }

        function Validation() {

            if (document.getElementById('<%=ddl_post.ClientID%>').value == '-- Select Post --') {
                alert('Please Enter Apply Post !');
                document.getElementById('<%=ddl_post.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_fname.ClientID%>').value == 'Enter First Name') {
                alert('Please Enter First Name !');
                document.getElementById('<%=txt_fname.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_lname.ClientID%>').value == 'Enter Last Name') {
                alert('Please Enter Last Name !');
                document.getElementById('<%=txt_lname.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_f_fname.ClientID%>').value == 'Enter First Name') {
                alert('Please Enter Father First Name !');
                document.getElementById('<%=txt_f_fname.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_f_lname.ClientID%>').value == 'Enter Last Name') {
                alert('Please Enter Father Last !');
                document.getElementById('<%=txt_f_lname.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=txt_dob.ClientID%>').value == '') {
                alert('Please Enter Date Of Birth !');
                document.getElementById('<%=txt_dob.ClientID%>').focus();
                return false;
            }
            var radio = document.getElementById('<%=rdo_categry.ClientID%>');

            var radioButtons = radio.getElementsByTagName('input');
            var is_valid;
            if (radioButtons[0].checked || radioButtons[1].checked) {
                is_valid = true;

            }
            else {

                alert('Please Enter Category !');
                document.getElementById('<%=rdo_categry.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_c_address.ClientID%>').value == '') {
                alert('Please Enter Communication Address !');
                document.getElementById('<%=txt_c_address.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=txt_C_city.ClientID%>').value == '') {
                alert('Please Enter Communication City !');
                document.getElementById('<%=txt_C_city.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_c_state.ClientID%>').value == '') {
                alert('Please Enter Communication State !');
                document.getElementById('<%=txt_c_state.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=txt_c_pin.ClientID%>').value == '') {
                alert('Please Enter Communication Pin Code !');
                document.getElementById('<%=txt_c_pin.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_c_pin.ClientID%>').value == '') {
                alert('Please Enter Communication Pin Code !');
                document.getElementById('<%=txt_c_pin.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_c_pin.ClientID%>').value == '') {
                alert('Please Enter Communication Pin Code !');
                document.getElementById('<%=txt_c_pin.ClientID%>').focus();
                return false;
            }


            if (document.getElementById('<%=txt_p_address.ClientID%>').value == '') {
                alert('Please Enter Permanent  Address !');
                document.getElementById('<%=txt_p_address.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=txt_p_city.ClientID%>').value == '') {
                alert('Please Enter Permanent  City !');
                document.getElementById('<%=txt_p_city.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_p_state.ClientID%>').value == '') {
                alert('Please Enter Permanent  State !');
                document.getElementById('<%=txt_p_state.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=txt_p_pincode.ClientID%>').value == '') {
                alert('Please Enter Permanent  Pin Code !');
                document.getElementById('<%=txt_p_pincode.ClientID%>').focus();
                return false;
            }
            var RegExEmail = /^(?:\w+\.?)*\w+@(?:\w+\.)+\w+$/;
            if (document.getElementById('<%=txt_email.ClientID%>').value == '') {
                alert('Please Enter Email ID !');
                document.getElementById('<%=txt_email.ClientID%>').focus();
                return false;
            }
            if (!RegExEmail.test(document.getElementById('<%=txt_email.ClientID%>').value)) {
                alert('Please Insert Valid Mail ID!');
                document.getElementById('<%=txt_email.ClientID%>').focus();
                return false;
            }

            if (document.getElementById('<%=txt_mobile.ClientID%>').value == '') {
                alert('Please Enter Mobile No !');
                document.getElementById('<%=txt_mobile.ClientID%>').focus();
                return false;
            }

            var y = document.getElementById('<%=txt_mobile.ClientID%>').value;
            if (isNaN(y) || y.indexOf(" ") != -1) {
                alert("Invalid Mobile No!")
                document.getElementById('<%=txt_mobile.ClientID%>').focus();
                return false;
            }
            if ((y.length > 10) || (y.length < 10)) {
                alert("Enter 10 Digits Mobile No!");
                document.getElementById('<%=txt_mobile.ClientID%>').focus();
                return false;
            }



            var grid = (document.getElementById("<%=gv_education.ClientID%>")) ? document.getElementById("<%=gv_education.ClientID%>") : null;
            if (grid) {
                if (grid.rows.length < 0 || grid.rows.length == 0) {
                    alert("Enter Education Detials!");
                    document.getElementById('<%=gv_education.ClientID%>').focus();
                    return false;
                }
            }


            var id_value = document.getElementById("<%=upl_resume.ClientID %>").value;
            if (id_value != '') {

                var valid_extensions = /(.doc|docx)$/i;

                if (valid_extensions.test(id_value)) {



                }
                else {
                    alert('Please Upload Resume In .doc Formate !.')

                    document.getElementById('<%=upl_resume.ClientID%>').focus();

                    return false;

                }
                if (validateFileSize(file, 1048576, "valid_msg", "Document size should be less than 1MB !") == false) {
                    return false;
                }
            }


            var id_value1 = document.getElementById("<%=upd_photo.ClientID %>").value;

            if (id_value1 != '') {

                var valid_extensions = /(.jpg|.png)$/i;

                if (valid_extensions.test(id_value1)) {



                }

                else {
                    alert('Please Upload Photo In .jpg or .png Formate !.')

                    document.getElementById('<%=upd_photo.ClientID%>').focus();

                    return false;


                }

            }


            var id_value2 = document.getElementById("<%=upd_sign.ClientID %>").value;

            if (id_value2 != '') {

                var valid_extensions = /(.jpg|.png)$/i;

                if (valid_extensions.test(id_value2)) {



                }

                else {
                    alert('Please Upload Signature In .jpg or .png Formate !.')

                    document.getElementById('<%=upd_sign.ClientID%>').focus();

                    return false;


                }

            }



            var id_value3 = document.getElementById("<%=upd_certificate.ClientID %>").value;

            if (id_value3 != '') {

                var valid_extensions = /(.jpg|.png)$/i;

                if (valid_extensions.test(id_value3)) {

                }

                else {
                    alert('Please Upload Certificate In .jpg or .png Formate !.')

                    document.getElementById('<%=upd_certificate.ClientID%>').focus();

                    return false;


                }

            }



        }
        onload = ShowHide;
   
    </script>
    <style type="text/css">
        .style1
        {
            width: 296px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <center>
                <table width="100%" align="center" border="1">
                    <tr>
                        <td align="center" valign="top" style="background:SaddleBrown;color:white;">
                            Registration Form
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <table width="100%" align="center"  style="padding:10px 20px 20px 100px;">
                                <tr>
                                    <td align="left" valign="top" colspan="2">
                                       <font face="Arial Narrow"> <b>(Imp: Please read the details on prescribed educational, professional as well as
                                            experience requirements for the various professionals before filling in the form,
                                            incomplete application will summarily be rejected) </b></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="2" style="border-bottom: 1px solid #000;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" colspan="2">
                                        <asp:Label ID="Label4" runat="server">All fields mark with ( <span style="color:Red; font-weight:bold; font-size:20px; padding-top:10px; vertical-align:middle;">*</span> ) are mandatory </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                      <font face="Arial Narrow">  <b>1. Application for Registration for</b></font> &nbsp;
                                         <asp:DropDownList ID="ddl_post" CssClass="TextBoxdesign" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_post_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                            *</span>
                                        <asp:HiddenField ID="lbl_min_Age" runat="server" />
                                        <asp:HiddenField ID="lbl_max_age" runat="server" />
                                        <asp:HiddenField ID="lbl_posting_Date" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                       <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                        <font face="Arial Narrow"> <b>2. Name (Applicatnt Holder's)</b></font>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="left" valign="top">
                                        <table>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txt_fname" onblur="return display1();" CssClass="TextBoxdesign" runat="server"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txt_fname"
                                                        WatermarkText="Enter First Name">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txt_mname" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txt_mname"
                                                        WatermarkText="Enter Middle Name" runat="server">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txt_lname" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txt_lname"
                                                        WatermarkText="Enter Last Name" runat="server">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                            </tr>
                                             
                                   <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                      
                                  
                               
                                            <tr>
                                                <td align="left" valign="top" colspan="3">
                                                   <font face="Arial Narrow"> <b>3. Father’s/Husband’s Name </b></font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txt_f_fname" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txt_f_fname"
                                                        WatermarkText="Enter First Name">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txt_f_mname" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" TargetControlID="txt_f_mname"
                                                        WatermarkText="Enter Middle Name" runat="server">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txt_f_lname" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" TargetControlID="txt_f_lname"
                                                        WatermarkText="Enter Last Name" runat="server">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                            </tr>
                                              <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                   <font face="Arial Narrow"> <b>4. Date of Birth </b></font>
                                                    <asp:Label ID="Label1" runat="server" Text="(mm/dd/yyyy) "></asp:Label>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="txt_dob" onblur="return DateValidation();" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:ImageButton ID="btn_calender" ImageUrl="~/Images/calc1.png" Width="30" runat="server" />
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_dob"
                                                        PopupButtonID="btn_calender">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                    <font face="Arial Narrow"><b>5. Category</b></font> <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                </td>
                                                <td align="left" valign="top" colspan="2">
                                                    <asp:RadioButtonList ID="rdo_categry" CssClass="TextBoxdesign" onclick="var a=display();ShowHide();return a;"
                                                        RepeatColumns="5" runat="server">
                                                        <asp:ListItem Value="General">General</asp:ListItem>
                                                        <asp:ListItem Value="OBC">OBC</asp:ListItem>
                                                        <asp:ListItem Value="SC">SC</asp:ListItem>
                                                        <asp:ListItem Value="ST">ST</asp:ListItem>
                                                        <asp:ListItem Value="PH">PH</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr><td colspan="3"><hr /></td></tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="3">
                                                    <div runat="server" id="Div_Show" style="display: none;">
                                                        <table>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <font face="Arial Narrow">Certificate No.</font>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txt_certificate_no" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                   <font face="Arial Narrow"> Date Of Issue</font>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txt_Date_of_issue" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="txt_Date_of_issue"
                                                                        runat="server">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                   <font face="Arial Narrow"> Issuing Authority</font>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txt_authority" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                   <font face="Arial Narrow"> Upload Certificate</font>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:FileUpload ID="upd_certificate" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="3">
                                                    <font face="Arial Narrow"><b>6. Address for Communication </b></font><span style="color: Red; font-weight: bold; font-size: 20px;
                                                        vertical-align: middle;">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="3">
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txt_c_address" Height="65" Width="200" TextMode="MultiLine" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                 &nbsp;&nbsp;&nbsp;<font face="Arial Narrow"><b> City</b></font> &nbsp;
                                                    <asp:TextBox ID="txt_C_city" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                         &nbsp;<font face="Arial Narrow"> <b>State</b></font> &nbsp;
                                                    <asp:TextBox ID="txt_c_state" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                         &nbsp;<font face="Arial Narrow"> <b>Pin Code</b></font> &nbsp;
                                                    <asp:TextBox ID="txt_c_pin" runat="server" MaxLength="6" Width="100" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_c_pin"
                                                        ValidChars="0123456789">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                   
                                                </td>
                                                <td align="left" valign="top">
                                                   
                                                </td>
                                                <td align="left" valign="top">
                                                   
                                                </td>
                                            </tr>
                                            <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="3">
                                                   <font face="Arial Narrow"> <b>7. Permanent Address</b></font> <span style="color: Red; font-weight: bold; font-size: 20px;
                                                        vertical-align: middle;">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="3">
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txt_p_address" Height="65" Width="200" TextMode="MultiLine" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                 &nbsp;&nbsp;&nbsp; <font face="Arial Narrow"><b>City</b></font> &nbsp;
                                                    <asp:TextBox ID="txt_p_city" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;" >
                                                        *</span>
                                                         &nbsp; <font face="Arial Narrow"><b>State </b></font>&nbsp;
                                                    <asp:TextBox ID="txt_p_state" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                        &nbsp; <font face="Arial Narrow"><b>Pin Code</b></font> &nbsp;
                                                    <asp:TextBox ID="txt_p_pincode" runat="server" MaxLength="6" Width="100" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_p_pincode"
                                                        ValidChars="0123456789">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                   
                                                </td>
                                                <td align="left" valign="top">
                                                   
                                                </td>
                                                <td align="left" valign="top">
                                                    
                                                </td>
                                            </tr>
                                            <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                    <font face="Arial Narrow"><b>8. E-Mail Address</b></font> <span style="color: Red; font-weight: bold; font-size: 20px;
                                                        vertical-align: middle;">*</span>
                                                </td>
                                                <td align="left" valign="top" colspan="3">
                                                    <asp:TextBox ID="txt_email" runat="server" Width="300"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                   <font face="Arial Narrow"> <b>9. Phone No.(Prefix city) Code</b></font>
                                                </td>
                                                <td align="left" valign="top" colspan="3">
                                                    <asp:TextBox ID="txt_phone" runat="server" MaxLength="11" CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                            <tr>
                                                <td align="left" valign="top" class="style1">
                                                   <font face="Arial Narrow"> <b>10. Mobile</b></font> <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                                        *</span>
                                                </td>
                                                <td align="left" valign="top" colspan="3">
                                                    <asp:TextBox ID="txt_mobile" runat="server" MaxLength="10" CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr><td colspan="3"><hr /></td></tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr > <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                <tr id="rowEduQualification1" runat="server">
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>11. Educational Qualifications</b></font> <asp:Label ID="Label2" runat="server" Text="(Most recent one first)"></asp:Label>
                                        <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                            *</span>
                                    </td>
                                </tr>
                                <tr id="rowEduQualification2" runat="server">
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px;">
                                        <table style="background-color: #000;" cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="center"  valign="top" style="background-color: #fff;" >
                                                  <font face="Arial Narrow">  Qualification</font> &nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="center"  valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Name of School/ College/University</font>
                                                </td>
                                                <td align="center"  valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Year of Passing</font>
                                                </td>
                                                <td align="center"  valign="top" style="background-color: #fff;">
                                                 <font face="Arial Narrow">Division/ Grade</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:DropDownList ID="ddd_education" runat="server"  CssClass="TextBoxdesign">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_school" runat="server" Width="200"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_passed_year" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_division" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                    &nbsp;
                                                    <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btn_add_Click"  CssClass="TextBoxdesign" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="rowEduQualification3" runat="server">
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px; padding-top: 10px;
                                        padding-bottom: 10px;">
                                        <asp:GridView ID="gv_education" runat="server" AutoGenerateColumns="false" Width="100%"
                                            ShowHeader="false" OnRowCommand="gv_education_RowCommand" OnRowDeleting="gv_education_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>.
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Qualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="170">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_University" runat="server" Text='<%# Eval("University") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="130">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_PassingYear" runat="server" Text='<%# Eval("PassingYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Grade" runat="server" Text='<%# Eval("Grade") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="16">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png"
                                                            CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="rowProQualification1" runat="server">
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>12. Professional Qualifications </b>(Most recent one first)</font>
                                    </td>
                                </tr>
                                <tr id="rowProQualification2" runat="server">
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px;">
                                        <table style="background-color: #000;" cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                  <font face="Arial Narrow"> Qualification</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Name of School/ College/University</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Year of Passing</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <font face="Arial Narrow">Division/ Grade</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:DropDownList ID="ddl_proEducation" runat="server"  CssClass="TextBoxdesign">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_pro_school" runat="server" Width="200"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_pro_passed_year" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_pro_division" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                    &nbsp;
                                                    <asp:Button ID="btn_pro_add" runat="server" Text="Add" OnClick="btn_pro_add_Click"  CssClass="TextBoxdesign" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="rowProQualification3" runat="server">
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px; padding-top: 10px;
                                        padding-bottom: 10px;">
                                        <asp:GridView ID="gv_pro_education" runat="server" AutoGenerateColumns="false" Width="100%"
                                            ShowHeader="false" OnRowCommand="gv_pro_education_RowCommand" OnRowDeleting="gv_pro_education_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>.
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="110">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Qualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="170">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_University" runat="server" Text='<%# Eval("University") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="130">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_PassingYear" runat="server" Text='<%# Eval("PassingYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Grade" runat="server" Text='<%# Eval("Grade") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="16">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png"
                                                            CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="rowWorkWxperience1" runat="server">
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>13. Work Experience</b> (From present position give Details on every employment,
                                        add separate sheet if necessary)</font>
                                    </td>
                                </tr>
                                <tr id="rowWorkWxperience2" runat="server">
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px;">
                                        <table style="background-color: #000;" cellpadding="1" cellspacing="1" width="100%">
                                        <tr id="rowWorkExp" runat="server"  Visible="false"><td colspan="5"><asp:Label ID="lblWorkExperience" runat="server" BackColor="ActiveBorder" Width="100%" Height="20"></asp:Label></td></tr>
                                            <tr>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Organization</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Designation</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Duration</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <font face="Arial Narrow">Salary Drawn</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                  <font face="Arial Narrow">  Brief Job profile</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_organization" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_designation" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_duration" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_salary" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_job_brief" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                                    &nbsp;
                                                    <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"  CssClass="TextBoxdesign" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="rowWorkWxperience3" runat="server">
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px; padding-top: 10px;
                                        padding-bottom: 10px;">
                                        <asp:GridView ID="gv_work_experience" runat="server" AutoGenerateColumns="false"
                                            Width="100%" ShowHeader="false" OnRowCommand="gv_work_experience_RowCommand" OnRowDeleting="gv_work_experience_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>.
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="120">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Organization" runat="server" Text='<%# Eval("Organization") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="140">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Designation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="145">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Duration" runat="server" Text='<%# Eval("Duration") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="145">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Salary" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Jobprofile" runat="server" Text='<%# Eval("Jobprofile") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="16">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png"
                                                            CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                       <font face="Arial Narrow"> <b>14. Total years of experience:</b></font>
                                        <asp:TextBox ID="txt_total_Experience" runat="server"  CssClass="TextBoxdesign"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                      <font face="Arial Narrow">  <b>15. References</b></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px;">
                                        <table style="background-color: #000;" cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                  <font face="Arial Narrow">  Name</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                  <font face="Arial Narrow">  Address</font>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                   <font face="Arial Narrow"> Contact Details</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_name" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_address" runat="server" Width="200" CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="center" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_contact" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                    <asp:Button ID="btn_References" runat="server" Text="Add" OnClick="btn_References_Click" CssClass="TextBoxdesign" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px; padding-top: 10px;
                                        padding-bottom: 10px;">
                                        <asp:GridView ID="gv_references" runat="server" AutoGenerateColumns="false" Width="100%"
                                            ShowHeader="false" OnRowCommand="gv_references_RowCommand" OnRowDeleting="gv_references_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>.
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="140">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Address" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Contact" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="16">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png"
                                                            CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                        <b>16. Have you applied earlier, if so please furnish details thereof: </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px; padding-top: 10px;
                                        padding-bottom: 10px;">
                                        <table width="70%" align="left">
                                        <tr>
                                        <td><font face="Arial Narrow">Name of the Organization</font></td>
                                        <td><asp:DropDownList ID="ddl_org" runat="server" CssClass="TextBoxdesign">
                                            <asp:ListItem Text="-- Select Organization --" Value="-- Select Organization --"></asp:ListItem>
                                            <asp:ListItem Text="EMMC" Value="EMMC"></asp:ListItem>
                                            <asp:ListItem Text="BECIL" Value="BECIL"></asp:ListItem>
                                        </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                        <td><font face="Arial Narrow"> Name of the Post</font></td>
                                        <td><asp:TextBox ID="txt_org_post" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                        <td> <font face="Arial Narrow"> Date of Applied</font></td>
                                        <td> <asp:TextBox ID="txt_Date_of_applied" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                         <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txt_Date_of_applied"
                                            runat="server">
                                        </asp:CalendarExtender>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>Outcome</td>
                                        <td> <asp:TextBox ID="txt_outcome" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
                                        </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>17. Languages known</b></font> <asp:Label ID="Label3" runat="server" Text="(Tick appropriate boxes)"></asp:Label>
                                        <span style="color: Red; font-weight: bold; font-size: 20px; vertical-align: middle;">
                                            *</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px;">
                                        <table style="background-color: #000;" cellpadding="1" cellspacing="1" width="60%">
                                            <tr>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                  <font face="Arial Narrow">  Language</font>
                                                </td>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                    <font face="Arial Narrow">Read</font>
                                                </td>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                    <font face="Arial Narrow">Speak</font>
                                                </td>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                    <font face="Arial Narrow">Write</font>
                                                </td>
                                                <td bgcolor="white"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                    <asp:TextBox ID="txt_language" runat="server" CssClass="TextBoxdesign"></asp:TextBox>
                                                </td>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                    <asp:CheckBox ID="chk_read" runat="server"  CssClass="TextBoxdesign" />
                                                </td>
                                                <td align="left" valign="top" style="background-color: #fff;" >
                                                    <asp:CheckBox ID="chk_speak" runat="server"  CssClass="TextBoxdesign" />
                                                </td>
                                                <td align="left" valign="top" style="background-color: #fff;">
                                                    <asp:CheckBox ID="chk_write" runat="server"  CssClass="TextBoxdesign" />
                                                    
                                                </td>
                                                <td bgcolor="white"><asp:Button ID="btn_language" runat="server" Text="Add" OnClick="btn_language_Click" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px; padding-top: 10px;
                                        padding-bottom: 10px;">
                                        <asp:GridView ID="gv_Language" runat="server" AutoGenerateColumns="false" Width="70%"
                                            ShowHeader="false" OnRowCommand="gv_Language_RowCommand" OnRowDeleting="gv_Language_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>.
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="130">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Language" runat="server" Text='<%# Eval("Language") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Read" runat="server" Text='<%# Eval("Read") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Speak" runat="server" Text='<%# Eval("Speak") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Write" runat="server" Text='<%# Eval("Write") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="16">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png"
                                                            CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                        <font face="Arial Narrow"><b>18. How did you learn about the vacancy. </b></font> <span style="color: Red; font-weight: bold;
                                            font-size: 20px; vertical-align: middle;">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px;">
                                        <asp:CheckBoxList ID="chk_about_company" RepeatColumns="4" runat="server"  CssClass="TextBoxdesign">
                                            <asp:ListItem Text="Website" Value="Website"></asp:ListItem>
                                            <asp:ListItem Text="Advertisement" Value="Advertisement"></asp:ListItem>
                                            <asp:ListItem Text="Training Institutes" Value="Training Institutes"></asp:ListItem>
                                            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr><td colspan="3"><br /></td></tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>19. Note: Please provide self attested photocopies of following documents </b></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" style="padding-left: 23px;">
                                       <font face="Arial Narrow"> a) Educational / Professional Certificates</font>
                                        <br />
                                       <font face="Arial Narrow"> b) Date of Birth Certificate</font>
                                        <br />
                                       <font face="Arial Narrow"> c) Experience Certificates</font>
                                        <br />
                                        <font face="Arial Narrow">d) Caste Certificate, if applicable</font>
                                    </td>
                                </tr>
                                <tr><td colspan="3"><br /></td></tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>20. Upload Resume</b> Max Size(2 mb)</font>
                                        <asp:FileUpload ID="upl_resume" runat="server"  CssClass="TextBoxdesign" />
                                    </td>
                                </tr>
                                  <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>21. Upload Photo</b> Dimension (Width:130px,Hieght:153px) Size (45KB)</font>
                                        <asp:FileUpload ID="upd_photo" runat="server"  CssClass="TextBoxdesign" />
                                    </td>
                                </tr>
                                  <tr> <td align="left" valign="top" colspan="3"> <br />  </td> </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                       <font face="Arial Narrow"> <b>22. Upload Signature</b> Dimension (Width:130px,Hieght:30px) Size (45KB)</font>
                                        <asp:FileUpload ID="upd_sign" runat="server"  CssClass="TextBoxdesign" />
                                    </td>
                                </tr>
                                <tr><td colspan="3"><br /></td></tr>
                                <tr>
                                    <td align="center" valign="top" colspan="3">
                                        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClientClick="return Validation();"
                                            OnClick="btn_submit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   
                </table>
            </center>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_submit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
