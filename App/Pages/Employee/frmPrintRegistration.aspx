<%@ Page Title="" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true" CodeFile="frmPrintRegistration.aspx.cs" Inherits="Pages_Universal_frmPrintRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    function print() {

        var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
        disp_setting += "scrollbars=yes,width=650, height=600, left=100, top=25";
        var content_vlue = document.getElementById("printDiv").innerHTML;

        var docprint = window.open("", "", disp_setting);
        docprint.document.open();
        docprint.document.write('<html><head><title></title>');
        docprint.document.write('</head><body onLoad="self.print()"><center>');
        docprint.document.write(content_vlue);
        docprint.document.write('</center></body></html>');
        docprint.document.close();
        docprint.focus();
    }
    function btnPrint_onclick() {
       
        print();
    }
   
    </script>

  <script type = "text/javascript" >
      function preventBack() { window.history.forward(); }
      setTimeout("preventBack()", 10);
      window.onunload = function () { null };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%">
<tr>
<td align="left" valign="top">Registration Form <hr /></td>
</tr>

<tr>
<td align="center" valign="top">
<div id="printDiv">
   <table  style=" font-size:12px; color:Black; width:700px;">

   <tr>
<td align="left" valign="top" colspan="2" >
   <table style=" font-size:12px; color:Black;" width="100%" >
<tr>
<td align="left" valign="top" >
<img src="../../Images/logo.jpg" width="60" height="60" />
</td>
<td align="center" valign="top" >
   

   <table style=" font-size:12px; color:Black;">
<tr>

<td align="center" valign="top" ><b> BROADCAST ENGINEERING CONSULTANTS INDIA LTD </b></td>
</tr>
<tr>

<td align="center" valign="top" ><b>(A Govt. of India Enterprise)</b> </td>
</tr>
<tr>

<td align="center" valign="top" ><b> Head Office:</b> 14-B, Ring Road, I.P. Estate, New Delhi-110002 
 </td>
</tr>
<tr>

<td align="center" valign="top" ><b>Tel :</b> + 91(11) 23378823-25, <b>Fax No.</b> + 91(11) 23379885</td>
</tr>
<tr>

<td align="center" valign="top" ><b>Corporate Office:</b> C-56/A 17, Secto-62, Noida-201307 </td>
</tr>
<tr>

<td align="center" valign="top" ><b>Tel:</b> 0120-4177850, <b>Fax :</b> 0120-4177879</td>
</tr>
<tr>

<td align="center" valign="top" ><b>E-Mail:</b> jobs@becil.com ,&nbsp; Website: www.becil.com</td>
</tr>
</table>
</td>
<td align="left" valign="top" >
 <div style="border:0px solid #000; text-align:center; width:132px; height:150px; ">
<table ><tr>
<td align="center" valign="middle" >
<img id="photos" runat="server" width="132" height="150" alt="Please attach recent passport size photograph" />
</td></tr></table>


 </div>
</td>
</tr>

</table>
</td>
</tr>

<tr>
<td align="left" valign="top" colspan="2" >
<b> (Imp: Please read the details on prescribed educational, professional as well as experience requirements 
for the various <br />professionals before filling in the form, incomplete application will summarily be rejected) 
</b>
</td>

</tr>

<tr>
<td align="left" valign="top" colspan="2" style=" border-bottom:1px solid #000; " >



</td>

</tr>
<tr>
<td align="left" valign="top" >
<b> Registration No</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_registration_no" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Full Name </b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_full_name" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Post</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_post" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Father Name</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_father" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Date Of Birth</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_dob" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Category</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_category" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Address for Communication</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_c_Address" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> City</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_c_city" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> State</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_c_State" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Pin Code </b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_c_pincode" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b>Permanent Address </b> 
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_p_address" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b>City</b> 
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_p_city" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> State</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_p_state" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" > 
<b> Pin Code</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_p_pincode" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Email ID</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Phone No</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_phone" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Mobile No</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_Mobile" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b>Educational Qualifications</b>
<br /><br />
</td>
<td align="left" valign="top" >
    
    
</td>
</tr>

<tr>

<td align="left" valign="top" colspan="2" >
    
    <asp:GridView ID="gv_education" runat="server" AutoGenerateColumns="false" 
        Width="100%" EmptyDataText="N/A" >
     
    <Columns>
    <asp:TemplateField ItemStyle-Width="40" HeaderText="SL No." ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
<%# Container.DataItemIndex+1 %>.
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="110" HeaderText="Examination Passed" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Qualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField  ItemStyle-Width="170" ItemStyle-HorizontalAlign="Center" HeaderText="UniverName of School/ College/University city">
    <ItemTemplate>
        <asp:Label ID="lbl_University" runat="server" Text='<%# Eval("Univercity") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="130" ItemStyle-HorizontalAlign="Center" HeaderText="Year of Passing ">
    <ItemTemplate>
        <asp:Label ID="lbl_PassingYear" runat="server" Text='<%# Eval("PassingYear") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="150" ItemStyle-HorizontalAlign="Center" HeaderText="Division/Grade">
    <ItemTemplate>
        <asp:Label ID="lbl_Grade" runat="server" Text='<%# Eval("Grade") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    </asp:GridView>

    <br /><br />
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> Professional Qualifications</b>
<br /><br />
</td>
<td align="left" valign="top" >
   
</td>
</tr>

<tr>

<td align="left" valign="top" colspan="2" >
   <asp:GridView ID="gv_pro_education" runat="server" AutoGenerateColumns="false" 
        Width="100%" EmptyDataText="N/A" >
    <Columns>
    <asp:TemplateField ItemStyle-Width="40" HeaderText="SL No." ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
<%# Container.DataItemIndex+1 %>.
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="110" HeaderText="Examination Passed" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Qualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField  ItemStyle-Width="170" ItemStyle-HorizontalAlign="Center" HeaderText="UniverName of School/ College/University city">
    <ItemTemplate>
        <asp:Label ID="lbl_University" runat="server" Text='<%# Eval("Univercity") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="130" ItemStyle-HorizontalAlign="Center" HeaderText="Year of Passing ">
    <ItemTemplate>
        <asp:Label ID="lbl_PassingYear" runat="server" Text='<%# Eval("PassingYear") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="150" ItemStyle-HorizontalAlign="Center" HeaderText="Division/Grade">
    <ItemTemplate>
        <asp:Label ID="lbl_Grade" runat="server" Text='<%# Eval("Grade") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    </asp:GridView>
</td>
</tr>


<tr>
<td align="left" valign="top" >
<b> Work Experience</b>
<br /><br />
</td>
<td align="left" valign="top" >
     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</td>
</tr>

<tr>

<td align="left" valign="top" colspan="2" >
   <asp:GridView ID="gv_work_experience" runat="server" AutoGenerateColumns="false" 
        Width="100%" EmptyDataText="N/A" >
    <Columns>
    <asp:TemplateField ItemStyle-Width="40" HeaderText="SL No." ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
<%# Container.DataItemIndex+1 %>.
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="110" HeaderText="Organization" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Organization" runat="server" Text='<%# Eval("Organization") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField  ItemStyle-Width="170" HeaderText="Designation" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Designation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="130" HeaderText="Duration" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Duration" runat="server" Text='<%# Eval("Duration") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField> 
    <asp:TemplateField ItemStyle-Width="150" HeaderText="Salary" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Salary" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="150" HeaderText="Jobprofile" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Jobprofile" runat="server" Text='<%# Eval("JobDescription") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    </asp:GridView>
</td>
</tr>

<tr>
<td align="left" valign="top" >
<b> Total years of experience</b>

</td>
<td align="left" valign="top" >
     <asp:Label ID="lbl_total_experience" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="left" valign="top" >
<b> References</b>
<br /><br />
</td>
<td align="left" valign="top" >
   
</td>
</tr>

<tr>

<td align="left" valign="top" colspan="2" >
   <asp:GridView ID="gv_references" runat="server" AutoGenerateColumns="false" 
        Width="64%" EmptyDataText="N/A"  >
    <Columns>
    <asp:TemplateField ItemStyle-Width="40" HeaderText=" SL No." ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
<%# Container.DataItemIndex+1 %>.
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="110" HeaderText="Name" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField  ItemStyle-Width="170" HeaderText="Address" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Address" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="130" HeaderText="Contact" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Contact" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    
    </Columns>
    </asp:GridView>
</td>
</tr>

<tr>
<td align="left" valign="top" >
<b> Languages known </b>
<br /><br />
</td>
<td align="left" valign="top" >
   
</td>
</tr>

<tr>

<td align="left" valign="top" colspan="2" >
   <asp:GridView ID="gv_Language" runat="server" AutoGenerateColumns="false" 
        Width="50%" EmptyDataText="N/A" >
    <Columns>
    <asp:TemplateField ItemStyle-Width="40" HeaderText="SL No." ItemStyle-HorizontalAlign="Center" >
    <ItemTemplate>
<%# Container.DataItemIndex+1 %>.
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="130" HeaderText="Language"  ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Language" runat="server" Text='<%# Eval("Language") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField  ItemStyle-Width="30" HeaderText="Read" ItemStyle-HorizontalAlign="Center" >
    <ItemTemplate>
        <asp:Label ID="lbl_Read" runat="server" Text='<%# Eval("Reads") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="30" HeaderText="Speak" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Speak" runat="server" Text='<%# Eval("Speak") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="50" HeaderText="Write" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Write" runat="server" Text='<%# Eval("Write") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    </asp:GridView>
</td>
</tr>
<tr>
<td align="left" valign="top" colspan="2" >
<b>Have you applied earlier, if so please furnish details thereof:</b>
</td>


</tr>
<tr>
<td align="left" valign="top" >
<b>Name of the Organization:</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_org_name" runat="server" Text=""></asp:Label>
</td>

</tr>
<tr>
<td align="left" valign="top" >
<b> Name of the Post</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_name_of_post" runat="server" Text=""></asp:Label>
</td>

</tr>
<tr>
<td align="left" valign="top" >
<b> Date of Applied </b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_date_of_applied" runat="server" Text=""></asp:Label>
</td>

</tr>
<tr>
<td align="left" valign="top" >
<b> Outcome</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_Outcome" runat="server" Text=""></asp:Label>
</td>

</tr>
<tr>
<td align="left" valign="top" >
<b> How did you learn about the vacancy. 
</b>
</td>
<td align="left" valign="top" >
    <asp:Label ID="lbl_about_vacancy" runat="server" Text=""></asp:Label>
</td>

</tr>
<tr>
<td align="left" valign="top" >
<b>Note: Please provide self attested photocopies of following documents 

</b>
</td>
<td align="left" valign="top" >
    
</td>

</tr>
<tr>
<td align="left" valign="top"  style=" padding-left:30px;">
a) Educational / Professional Certificates <br />
b) Date of Birth Certificate <br />
c) Experience Certificates <br />
d) Caste Certificate, if applicable <br /><br />

</td>
<td align="left" valign="top" >
    
</td>

</tr>

<tr>
<td align="left" valign="top" >
<table>
<tr>
<td align="left" valign="top" >
 <b>Signature</b>
</td>
<td align="left" valign="top" >
<img id="sing" runat="server" width="300" height="40" />
</td>
</tr>
</table>


</td>
<td align="left" valign="top" >
    <b>Date</b> <asp:Label ID="lbl_Date" runat="server" Text="___________________________"></asp:Label>
</td>

</tr>
<tr>
<td align="left" valign="top" colspan="2" >
<table width="100%" style=" border:1px solid #000; padding:5px 5px 5px 5px;">
<tr>

<td align="center" valign="top" colspan="2" style="text-decoration:underline;"> 
For BECIL Office Records
</td>
</tr>
<tr>
<td align="left" valign="top" >
Receipt No. for Registration fee --------------------
</td>
<td align="left" valign="top" >
Date --------------
</td>
</tr>
</table>
</td>
</tr>


</table>
</div>
</td>
</tr>
<tr>

<td align="center" valign="top" style="padding-top:20px; padding-bottom:20px;" >
    <asp:Button ID="btn_print" runat="server" Text="Print" OnClientClick="return btnPrint_onclick()" />
</td>

</tr>
</table>
</asp:Content>

