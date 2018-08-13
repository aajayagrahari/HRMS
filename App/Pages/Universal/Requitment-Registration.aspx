<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="Requitment-Registration.aspx.cs" Inherits="Pages_Admin_Requitment_Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
        else
        
         {
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


   


    

        if (document.getElementById('<%=ddl_post.ClientID%>').value == '-- Select Post --')
         {
            alert('Please Enter Apply Post !');
            document.getElementById('<%=ddl_post.ClientID%>').focus();
            return false;
        }

        if (document.getElementById('<%=txt_fname.ClientID%>').value == 'Enter First Name') 
        {
            alert('Please Enter First Name !');
            document.getElementById('<%=txt_fname.ClientID%>').focus();
            return false;
        }

        if (document.getElementById('<%=txt_lname.ClientID%>').value == 'Enter Last Name')
         {
            alert('Please Enter Last Name !');
            document.getElementById('<%=txt_lname.ClientID%>').focus();
            return false;
        }

        if (document.getElementById('<%=txt_f_fname.ClientID%>').value == 'Enter First Name')
         {
            alert('Please Enter Father First Name !');
            document.getElementById('<%=txt_f_fname.ClientID%>').focus();
            return false;
        }

        if (document.getElementById('<%=txt_f_lname.ClientID%>').value == 'Enter Last Name') 
        {
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

       

      var grid=(document.getElementById("<%=gv_education.ClientID%>"))?document.getElementById("<%=gv_education.ClientID%>"):null;
if (grid)
 {
     if (grid.rows.length < 0 || grid.rows.length == 0)
   {
       alert("Enter Education Detials!");
       document.getElementById('<%=gv_education.ClientID%>').focus();
       return false;
   }
 }

var id_value = document.getElementById("<%=upl_resume.ClientID %>").value;
if (id_value != '') 
{
    var valid_extensions = /(.doc|docx)$/i;
    if (valid_extensions.test(id_value)) {


    }
    else
     {
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
      
   
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%">
<tr>


<td align="left" valign="top">Registration Form <hr /></td>
</tr>

<tr>
<td align="center" valign="top">
    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<table>

<tr>
<td align="left" valign="top" colspan="2" >
<b> (Imp: Please read the details on prescribed educational, professional as well as experience requirements 
for the various professionals before filling in the form, incomplete application will summarily be rejected) </b>
</td>

</tr>

<tr>
<td align="left" valign="top" colspan="2" style=" border-bottom:1px solid #000; " >

</td>

</tr>
<tr>
<td align="left" valign="top" colspan="3"><b>1. Application for Registration for</b></td>


</tr>
<tr>

<td align="left" valign="top" colspan="3">
    &nbsp;&nbsp;&nbsp; <!--<asp:TextBox ID="txt_Position" runat="server" Width="200"></asp:TextBox><!-->
    <asp:DropDownList ID="ddl_post" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddl_post_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:HiddenField ID="lbl_min_Age" runat="server" />
    <asp:HiddenField ID="lbl_max_age" runat="server" />
   <asp:HiddenField ID="lbl_posting_Date" runat="server" />
    
</td>

</tr>
<tr>
<td align="left" valign="top" colspan="3"><b>2.  Name (Applicatnt Holder's)</b> </td>

</tr>
<tr>
<td align="left" valign="top" >
<table>
<tr>
 <td align="left" valign="top">   &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_fname"  runat="server"></asp:TextBox>
     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txt_fname" WatermarkText="Enter First Name">
     </asp:TextBoxWatermarkExtender>
 </td>
<td align="left" valign="top">    <asp:TextBox ID="txt_mname" runat="server"></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txt_mname" WatermarkText="Enter Middle Name" runat="server">
    </asp:TextBoxWatermarkExtender>
</td>
<td align="left" valign="top">
    <asp:TextBox ID="txt_lname" runat="server" ></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txt_lname" WatermarkText="Enter Last Name" runat="server">
    </asp:TextBoxWatermarkExtender>
</td>
    

</tr>
<tr>
<td align="left" valign="top" colspan="3"><b>3. Father’s/Husband’s Name </b>
 </td>

</tr>
<tr>
 <td align="left" valign="top">   &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_f_fname" runat="server"></asp:TextBox>
  <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txt_f_fname" WatermarkText="Enter First Name">
     </asp:TextBoxWatermarkExtender>
 </td>
<td align="left" valign="top">    <asp:TextBox ID="txt_f_mname" runat="server"></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" TargetControlID="txt_f_mname" WatermarkText="Enter Middle Name" runat="server">
    </asp:TextBoxWatermarkExtender>

</td>
<td align="left" valign="top">
    <asp:TextBox ID="txt_f_lname" runat="server"></asp:TextBox>
     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" TargetControlID="txt_f_lname" WatermarkText="Enter Last Name" runat="server">
    </asp:TextBoxWatermarkExtender>
</td>

</tr>
<tr>
 <td align="left" valign="top"><b>4.    Date of Birth</b></td>
<td align="left" valign="top">    <asp:TextBox ID="txt_dob"   runat="server"></asp:TextBox></td>
<td align="left" valign="top">
    <asp:ImageButton ID="btn_calender" ImageUrl="~/Images/calc1.png" Width="30" runat="server" />
    <asp:CalendarExtender ID="CalendarExtender2" runat="server"   TargetControlID="txt_dob" PopupButtonID="btn_calender">
    </asp:CalendarExtender>
</td>

</tr>
<tr>
 <td align="left" valign="top"><b>5.   Category</b> </td>
<td align="left" valign="top" colspan="2">  
    <asp:RadioButtonList ID="rdo_categry" onclick="var a=display();ShowHide();return a;"  RepeatColumns="5" runat="server">
    <asp:ListItem Value="General">General</asp:ListItem>
    <asp:ListItem Value="OBC">OBC</asp:ListItem>
    <asp:ListItem Value="SC">SC</asp:ListItem>
    <asp:ListItem Value="ST">ST</asp:ListItem>
    <asp:ListItem Value="PH">PH</asp:ListItem>
    </asp:RadioButtonList>


    
    </td>


</tr>

<tr>
<td align="left" valign="top" colspan="3">
<div runat="server" id="Div_Show" style="display:none;">
<table>
<tr>
<td align="left" valign="top" >Certificate No.</td>
<td align="left" valign="top" >
    <asp:TextBox ID="txt_certificate_no" runat="server"></asp:TextBox></td>
    <td align="left" valign="top" >Date Of Issue</td>
<td align="left" valign="top" >
    <asp:TextBox ID="txt_Date_of_issue" runat="server"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="txt_Date_of_issue" runat="server">
    </asp:CalendarExtender>
    </td>
</tr>

<tr>
<td align="left" valign="top" >Issuing Authority</td>
<td align="left" valign="top" >
    <asp:TextBox ID="txt_authority" runat="server"></asp:TextBox></td>
    <td align="left" valign="top" >Upload Certificate</td>
<td align="left" valign="top" >
    <asp:FileUpload ID="upd_certificate" runat="server" /></td>
</tr>

</table>

</div>


 </td>

</tr>

<tr>
<td align="left" valign="top" colspan="3"><b>6. Address for Communication </b>

 </td>

</tr>
<tr>
 <td align="left" valign="top" colspan="3">   &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_c_address" Height="65" Width="200" TextMode="MultiLine" runat="server"></asp:TextBox></td>
</tr>

<tr>
 <td align="left" valign="top">   &nbsp;&nbsp;&nbsp;<b> City</b> &nbsp; <asp:TextBox ID="txt_C_city" runat="server"></asp:TextBox></td>
<td align="left" valign="top"> &nbsp;  <b>State</b> &nbsp; <asp:TextBox ID="txt_c_state" runat="server"></asp:TextBox></td>
<td align="left" valign="top">
   &nbsp; <b>Pin Code</b> &nbsp; <asp:TextBox ID="txt_c_pin" runat="server" MaxLength="6" Width="100"></asp:TextBox>
      <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_c_pin" ValidChars="0123456789">
    </asp:FilteredTextBoxExtender>
</td>

</tr>
<tr>
<td align="left" valign="top" colspan="3"><b>7. Permanent Address</b>

 </td>

</tr>
<tr>
 <td align="left" valign="top" colspan="3">   &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_p_address" Height="65" Width="200" TextMode="MultiLine" runat="server"></asp:TextBox></td>
</tr>

<tr>
 <td align="left" valign="top">   &nbsp;&nbsp;&nbsp; <b>City</b> &nbsp; <asp:TextBox ID="txt_p_city" runat="server"></asp:TextBox></td>
<td align="left" valign="top"> &nbsp;  <b>State </b>&nbsp; <asp:TextBox ID="txt_p_state" runat="server"></asp:TextBox></td>
<td align="left" valign="top">
   &nbsp; <b>Pin Code</b> &nbsp; <asp:TextBox ID="txt_p_pincode" runat="server" MaxLength="6" Width="100"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_p_pincode" ValidChars="0123456789">
    </asp:FilteredTextBoxExtender>
</td>

</tr>

<tr  >
<td align="left" valign="top" ><b>8. E-Mail Address</b>
 </td>
<td align="left" valign="top" colspan="3">

    <asp:TextBox ID="txt_email" runat="server" Width="300"></asp:TextBox>
 </td>

</tr>
<tr>
<td align="left" valign="top" ><b>9. Phone No.(Prefix city) Code</b>
 </td>
<td align="left" valign="top" colspan="3">
<asp:TextBox ID="txt_phone" runat="server" MaxLength="11"></asp:TextBox>
 </td>
 
</tr>
<tr>
<td align="left" valign="top" ><b>10. Mobile</b>
 </td>
<td align="left" valign="top" colspan="3">

    <asp:TextBox ID="txt_mobile" runat="server" MaxLength="10"></asp:TextBox>
 </td>

</tr>
</table>
</td>
</tr>





<tr>
<td align="left" valign="top" colspan="3" ><b>11. Educational Qualifications</b> (Most recent one first) 

 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px;">

<table  style=" background-color:#000;" cellpadding="1" cellspacing="1">
<tr>
<td align="center" valign="top" style=" background-color:#fff;">
Qualification
 </td>
 <td align="center" valign="top" style=" background-color:#fff;">
 Name of School/ 
College/University
 </td>
 
<td align="center" valign="top" style=" background-color:#fff;">
Year of Passing
 </td>
 <td align="center" valign="top" style=" background-color:#fff;">
 Division/ 
Grade
 </td>
 
</tr>


<tr>
<td align="left" valign="top" style=" background-color:#fff;">

    <asp:TextBox ID="txt_qualification" runat="server"></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
   <asp:TextBox ID="txt_school" runat="server" Width="200"></asp:TextBox>
 </td>
 
<td align="left" valign="top" style=" background-color:#fff;">
  <asp:TextBox ID="txt_passed_year" runat="server"></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
   <asp:TextBox ID="txt_division" runat="server"></asp:TextBox>

   &nbsp; <asp:Button ID="btn_add" runat="server" Text="Add" 
         onclick="btn_add_Click" />
 </td>
  
</tr>


</table>
 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px; padding-top:10px; padding-bottom:10px; ">



    <asp:GridView ID="gv_education" runat="server" AutoGenerateColumns="false" 
        Width="80%" ShowHeader="false" onrowcommand="gv_education_RowCommand" 
        onrowdeleting="gv_education_RowDeleting">
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
    
    <asp:TemplateField  ItemStyle-Width="170">
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
        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png" CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
 </td>
</tr>


<tr>
<td align="left" valign="top" colspan="3" ><b>12. Professional Qualifications </b>(Most recent one first) 


 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px;">

<table  style=" background-color:#000;" cellpadding="1" cellspacing="1">
<tr>
<td align="center" valign="top" style=" background-color:#fff;">
Qualification
 </td>
 <td align="center" valign="top" style=" background-color:#fff;">
 Name of School/ 
College/University
 </td>
 
<td align="center" valign="top" style=" background-color:#fff;">
Year of Passing
 </td>
 <td align="center" valign="top" style=" background-color:#fff;">
 Division/ 
Grade
 </td>
 
</tr>
<tr>
<td align="left" valign="top" style=" background-color:#fff;">

    <asp:TextBox ID="txt_pro_qualication" runat="server"></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
   <asp:TextBox ID="txt_pro_school" runat="server" Width="200"></asp:TextBox>
 </td>
 
<td align="left" valign="top" style=" background-color:#fff;">
  <asp:TextBox ID="txt_pro_passed_year" runat="server" ></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
   <asp:TextBox ID="txt_pro_division" runat="server"></asp:TextBox>

   &nbsp; <asp:Button ID="btn_pro_add" runat="server" Text="Add" 
         onclick="btn_pro_add_Click" />
 </td>
  
</tr>
</table>
 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px; padding-top:10px; padding-bottom:10px; ">



    <asp:GridView ID="gv_pro_education" runat="server" AutoGenerateColumns="false" 
        Width="80%" ShowHeader="false" 
        onrowcommand="gv_pro_education_RowCommand" 
        onrowdeleting="gv_pro_education_RowDeleting" >
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
    
    <asp:TemplateField  ItemStyle-Width="170">
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
        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png" CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" ><b>13. Work Experience</b> (From present position give Details on every employment, add separate sheet if 
necessary) 
 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px;">

<table  style=" background-color:#000;" cellpadding="1" cellspacing="1">
<tr>
<td align="center" valign="top" style=" background-color:#fff;">
Organization
 </td>
 <td align="center" valign="top" style=" background-color:#fff;">
 Designation
 </td>
 
<td align="center" valign="top" style=" background-color:#fff;">
Duration 

 </td>
 <td align="center" valign="top" style=" background-color:#fff;">
Salary Drawn 

 </td>
 <td align="center" valign="top" style=" background-color:#fff;">
Brief Job profile
 </td>
</tr>
<tr>
<td align="left" valign="top" style=" background-color:#fff;">

    <asp:TextBox ID="txt_organization" runat="server"></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
   <asp:TextBox ID="txt_designation" runat="server" ></asp:TextBox>
 </td>
 
<td align="left" valign="top" style=" background-color:#fff;">
  <asp:TextBox ID="txt_duration" runat="server" ></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
  <asp:TextBox ID="txt_salary" runat="server" ></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
   <asp:TextBox ID="txt_job_brief" runat="server"></asp:TextBox>

   &nbsp; <asp:Button ID="Button1" runat="server" Text="Add" 
         onclick="Button1_Click" />
 </td>
  
</tr>
</table>
 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px; padding-top:10px; padding-bottom:10px; ">



    <asp:GridView ID="gv_work_experience" runat="server" AutoGenerateColumns="false" 
        Width="90%" ShowHeader="false" 
        onrowcommand="gv_work_experience_RowCommand" 
        onrowdeleting="gv_work_experience_RowDeleting"  >
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
    
    <asp:TemplateField  ItemStyle-Width="140">
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
        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png" CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
 </td>
</tr>
<tr>
<td align="left" valign="top" ><b>14. Total years of experience:</b>
   <asp:TextBox ID="txt_total_Experience"  runat="server" MaxLength="2"></asp:TextBox>
 </td>


</tr>


<tr>
<td align="left" valign="top" colspan="3" ><b>15. References</b>
 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px;">

<table  style=" background-color:#000;" cellpadding="1" cellspacing="1">
<tr>
<td align="left" valign="top" style=" background-color:#fff;">
Name
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
 Address
 </td>
 
<td align="left" valign="top" style=" background-color:#fff;">
Contact Details
 </td>
 
</tr>
<tr>
<td align="left" valign="top" style=" background-color:#fff;">

    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
   <asp:TextBox ID="txt_address" runat="server" Width="200"></asp:TextBox>
 </td>
 
<td align="left" valign="top" style=" background-color:#fff;">
  <asp:TextBox ID="txt_contact" runat="server" ></asp:TextBox>
   <asp:Button ID="btn_References" runat="server" Text="Add" 
        onclick="btn_References_Click" />
 </td>
 
</tr>
</table>
 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px; padding-top:10px; padding-bottom:10px; ">



    <asp:GridView ID="gv_references" runat="server" AutoGenerateColumns="false" 
        Width="64%" ShowHeader="false" onrowcommand="gv_references_RowCommand" 
        onrowdeleting="gv_references_RowDeleting"  >
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
    
    <asp:TemplateField  ItemStyle-Width="140">
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
        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png" CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
 </td>
</tr>


<tr>
<td align="left" valign="top" colspan="3" ><b>16. Have you applied earlier, if so please furnish details thereof: </b>

 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px; padding-top:10px; padding-bottom:10px; ">
Name of the Organization: 
    <asp:DropDownList ID="ddl_org" runat="server">
    <asp:ListItem Text="-- Select Organization --" Value="-- Select Organization --"></asp:ListItem>
 <asp:ListItem Text="EMMC" Value="EMMC"></asp:ListItem>
  <asp:ListItem Text="BECIL" Value="BECIL"></asp:ListItem>
    </asp:DropDownList>
       <br />
 
 Name of the Post 
    <asp:TextBox ID="txt_org_post" runat="server"></asp:TextBox> <br />
 
 Date of Applied <asp:TextBox ID="txt_Date_of_applied" runat="server"></asp:TextBox>  <br />
    <asp:CalendarExtender ID="CalendarExtender1"  TargetControlID="txt_Date_of_applied" runat="server">
    </asp:CalendarExtender>
 
 Outcome  <asp:TextBox ID="txt_outcome" runat="server"></asp:TextBox> 

</td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" ><b>17. Languages known</b> (Tick appropriate boxes) 


 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px;">

<table  style=" background-color:#000;" cellpadding="1" cellspacing="1">
<tr>
<td align="left" valign="top" style=" background-color:#fff;">
Language
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
 Read
 </td>
 
<td align="left" valign="top" style=" background-color:#fff;">
Speak
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
Write
 </td>
</tr>
<tr>
<td align="left" valign="top" style=" background-color:#fff;">

    <asp:TextBox ID="txt_language" runat="server"></asp:TextBox>
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">
     <asp:CheckBox ID="chk_read" runat="server" />
 </td>
 <td align="left" valign="top" style=" background-color:#fff;">

       <asp:CheckBox ID="chk_speak" runat="server" />
 </td>
<td align="left" valign="top" style=" background-color:#fff;">
     <asp:CheckBox ID="chk_write" runat="server" />
   <asp:Button ID="btn_language" runat="server" Text="Add" 
        onclick="btn_language_Click" />
 </td>
 
</tr>
</table>
 </td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px; padding-top:10px; padding-bottom:10px; ">



    <asp:GridView ID="gv_Language" runat="server" AutoGenerateColumns="false" 
        Width="34%" ShowHeader="false" onrowcommand="gv_Language_RowCommand" 
        onrowdeleting="gv_Language_RowDeleting" >
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
    
    <asp:TemplateField  ItemStyle-Width="30">
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
        <asp:ImageButton ID="btn_Delete" runat="server" Width="16" ImageUrl="~/images/delete_icon.png" CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" ><b>18. How did you learn about the vacancy. </b>



 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px;">
    <asp:CheckBoxList ID="chk_about_company" RepeatColumns="4" runat="server">
    <asp:ListItem Text="Website" Value="Website"></asp:ListItem>
    <asp:ListItem Text="Advertisement" Value="Advertisement"></asp:ListItem>
    <asp:ListItem Text="Training Institutes" Value="Training Institutes"></asp:ListItem>
    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
    </asp:CheckBoxList>
</td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" ><b>19. Note: Please provide self attested photocopies of following documents </b>
 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" style="padding-left:23px;">
a) Educational / Professional Certificates <br />
b) Date of Birth Certificate <br />
c) Experience Certificates <br />
d) Caste Certificate, if applicable
</td>
</tr>

<tr>
<td align="left" valign="top" colspan="3" ><b>20.  Upload Resume</b> Max Size(2 mb)
    <asp:FileUpload ID="upl_resume" runat="server" />
 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" ><b>20.  Upload Photo</b> Dimension (Width:130px,Hieght:153px) Size (500KB)
    <asp:FileUpload ID="upd_photo" runat="server" />
 </td>
</tr>
<tr>
<td align="left" valign="top" colspan="3" ><b>20. Upload Signature</b>  Dimension (Width:130px,Hieght:30px) Size (500KB)
    <asp:FileUpload ID="upd_sign" runat="server" />
 </td>
</tr>
<tr>
<td align="center" valign="top" colspan="3" >
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClientClick="return Validation();"
        onclick="btn_submit_Click" />
 </td>
</tr>
</table>
</td>
</tr>
</table>
</asp:Content>

