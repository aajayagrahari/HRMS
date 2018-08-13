<%@ Page Title="Reimbursement Form" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master" AutoEventWireup="true" CodeFile="frmReimbursement.aspx.cs" Inherits="Pages_Employee_frmReimbursement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <script type="text/javascript" language="javascript">
     function ValidateNumberOnly() {
         if ((event.keyCode < 48 || event.keyCode > 57)) {
             event.returnValue = false;
         }
     }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="90%" align="center"  style="border:1px solid #000000;font-size:14px;">
<tr><td><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr>
<tr><td bgcolor="SaddleBrown"><asp:Label ID="lblExpenceReimbursement" runat="server" Text="Expence Reimbursement Form" ForeColor="White"></asp:Label></td></tr>
<tr><td>
<table width="100%" align="center">
<tr>
<td width="20%">Employee Id</td>
<td width="20%"><asp:TextBox ID="txtEmployeeId" runat="server" CssClass="TextBoxdesign" ReadOnly="true"></asp:TextBox></td>
<td width="20%">Employee Name</td>
<td><asp:TextBox ID="txtEmployeeName" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
</tr>
<tr>
<td width="20%">Manager Name</td>
<td width="20%"><asp:TextBox ID="txtManagerName" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
<td width="20%">Department</td>
<td><asp:TextBox ID="txtDepartment" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
</tr>
<tr><td colspan="4" bgcolor="SaddleBrown"><asp:Label ID="lblExpencePeriod" runat="server" Text="Expence Period" ForeColor="White"></asp:Label> </td></tr>
<tr>
<td width="20%">From Date</td>
<td width="20%"><asp:TextBox ID="txtFromDate" runat="server" 
        CssClass="TextBoxdesign" AutoPostBack="True" 
        ontextchanged="txtFromDate_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="txtFromDate"
            Display="Dynamic" ErrorMessage="*" ToolTip="Date Of Expence Date is required" ValidationGroup="add"></asp:RequiredFieldValidator>
      <%--  <asp:RegularExpressionValidator runat="server" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20|30)\d\d"
            ControlToValidate="txtFromDate" ErrorMessage="*" ToolTip="Invalid Date Format(MM/dd/yyyy)"
            Display="Dynamic" SetFocusOnError="True" ID="revDateOfRetirement" ValidationGroup="add"></asp:RegularExpressionValidator>--%>

<ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                PopupPosition="Right" Format="dd/MM/yyyy" Enabled="True">
                            </ajax:CalendarExtender>
</td>
<td width="20%">To Date</td>
<td><asp:TextBox ID="txtToDate" runat="server" CssClass="TextBoxdesign" 
        AutoPostBack="True" ontextchanged="txtToDate_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvtxtToDate" runat="server" ControlToValidate="txtToDate"
            Display="Dynamic" ErrorMessage="*" ToolTip="Date Of Expence Date is required" ValidationGroup="add"></asp:RequiredFieldValidator>
       <%-- <asp:RegularExpressionValidator runat="server" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20|30)\d\d"
            ControlToValidate="txtToDate" ErrorMessage="*" ToolTip="Invalid Date Format(MM/dd/yyyy)"
            Display="Dynamic" SetFocusOnError="True" ID="RegularExpressionValidator1" ValidationGroup="add"></asp:RegularExpressionValidator>--%>
<ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                PopupPosition="Right" Format="dd/MM/yyyy" Enabled="True">
                            </ajax:CalendarExtender>
</td>
</tr>
<tr>
<td>Business Purpose</td>
<td colspan="3">
<asp:TextBox ID="txtBusinessPurpose" runat="server" TextMode="MultiLine" Width="300"> </asp:TextBox>&nbsp;<asp:LinkButton ID="lnkEdit" runat="server" 
        Text="Click here to Edit Rembursement Detail" Visible="false" onclick="lnkEdit_Click1" 
       ></asp:LinkButton>
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false"
        onclick="btnUpdate_Click" />
</td></tr>

<tr><td colspan="4" bgcolor="SaddleBrown"><asp:Label ID="lblItemWiseExpance" runat="server" Text="ItemWise Expences" ForeColor="White"></asp:Label></td></tr>
<tr>
<td>Date</td>
<td>Description</td>
<td>Category</td>
<td>Cost</td>
</tr>
<tr>
<td><asp:TextBox ID="txtDate" runat="server" CssClass="TextBoxdesign" 
        AutoPostBack="True" ontextchanged="txtDate_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvtxtDate" runat="server" ControlToValidate="txtDate"
            Display="Dynamic" ErrorMessage="*" ToolTip="Date Of Expence Date is required" ValidationGroup="add"></asp:RequiredFieldValidator>
       <%-- <asp:RegularExpressionValidator runat="server" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20|30)\d\d"
            ControlToValidate="txtDate" ErrorMessage="*" ToolTip="Invalid Date Format(MM/dd/yyyy)"
            Display="Dynamic" SetFocusOnError="True" ID="revtxtDate" ValidationGroup="add"></asp:RegularExpressionValidator>--%>
<ajax:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                                PopupPosition="Right" Enabled="True">
                            </ajax:CalendarExtender>
</td>
<td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="250" CssClass="TextBoxdesign"></asp:TextBox></td>
<td><asp:TextBox ID="txtCategory" runat="server" CssClass="TextBoxdesign"></asp:TextBox></td>
<td><asp:TextBox ID="txtCost" runat="server" CssClass="TextBoxdesign" onkeypress="return ValidateNumberOnly();"></asp:TextBox> &nbsp;&nbsp;<asp:Button 
        ID="btnAdd" runat="server" ValidationGroup="add" Text="Add" Width="70" onclick="btnAdd_Click" /></td>
</tr>
<tr><td colspan="4" align="center">
<asp:GridView ID="gdvExpenceDetail" runat="server" AutoGenerateColumns="false" 
        Width="60%" onrowcommand="gdvExpenceDetail_RowCommand" 
        onrowdeleting="gdvExpenceDetail_RowDeleting" 
        onrowediting="gdvExpenceDetail_RowEditing">
<Columns>
<asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                    CommandName="Edit" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/Edit.gif" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                    CommandName="Delete" CssClass=""><img style="border:0px;vertical-align:middle; width :20px" alt="" src="../../Images/delete.png" ></asp:LinkButton>&nbsp;&nbsp;</ItemTemplate>
                        </asp:TemplateField>
<asp:TemplateField HeaderText="S.No">
<ItemTemplate><%# Container.DataItemIndex+1 %>
<asp:HiddenField ID="hdnExpanceId" runat="server" Value='<%# Eval("ExpanceId")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date">
<ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date")%>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description">
<ItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Category">
<ItemTemplate><asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Cost">
<ItemTemplate><asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost")%>'></asp:Label></ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</td></tr>
</table>
</td></tr>
<tr><td align="center"><asp:Button ID="btnSubmit" runat="server" Text="Submit"  
        onclick="btnSubmit_Click" /></td></tr>
        <tr><td><asp:GridView ID="gdvSubmittedDetail" runat="server" 
                AutoGenerateColumns="false" Width="100%" 
                onrowcommand="gdvSubmittedDetail_RowCommand">
        <Columns>
        <asp:TemplateField HeaderText="S.No.">
        <ItemTemplate><%# Container.DataItemIndex+1 %>
        <asp:HiddenField ID="hdnReimbursementDetailId" runat="server" Value='<%#Eval("ReimbursementDetailId")%>' />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date">
        <ItemTemplate><asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FromDate")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="To Date">
        <ItemTemplate><asp:Label ID="lblTo" runat="server" Text='<%#Eval("ToDate")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
        <ItemTemplate><asp:Label ID="lblReimbursementDate" runat="server" Text='<%#Eval("ReimbursementDate")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Reimbursement Discription">
        <ItemTemplate><asp:Label ID="lblReimbursementDiscription" runat="server" Text='<%#Eval("ReimbursementDescription")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Category">
        <ItemTemplate><asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Cost">
        <ItemTemplate><asp:Label ID="lblCost" runat="server" Text='<%#Eval("Cost")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Click here to Submit">
        <ItemTemplate><asp:Button ID="btnSubmit" runat="server" Text="Submit" CommandArgument='<%# Container.DataItemIndex %>' /></ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>There is no record....</EmptyDataTemplate>
        </asp:GridView></td></tr>
        <tr><td><br /></td></tr>
        <tr><td>
       
        <tr><td><asp:GridView ID="gdvAfterSubmitted" runat="server" 
                AutoGenerateColumns="false" Width="100%" 
                onrowcommand="gdvSubmittedDetail_RowCommand">
        <Columns>
        <asp:TemplateField HeaderText="S.No.">
        <ItemTemplate><%# Container.DataItemIndex+1 %>
        <asp:HiddenField ID="hdnReimbursementDetailId" runat="server" Value='<%#Eval("ReimbursementDetailId")%>' />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date">
        <ItemTemplate><asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FromDate")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="To Date">
        <ItemTemplate><asp:Label ID="lblTo" runat="server" Text='<%#Eval("ToDate")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
        <ItemTemplate><asp:Label ID="lblReimbursementDate" runat="server" Text='<%#Eval("ReimbursementDate")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Reimbursement Discription">
        <ItemTemplate><asp:Label ID="lblReimbursementDiscription" runat="server" Text='<%#Eval("ReimbursementDescription")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Category">
        <ItemTemplate><asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Cost">
        <ItemTemplate><asp:Label ID="lblCost" runat="server" Text='<%#Eval("Cost")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Click here to Submit">
        <ItemTemplate><asp:Button ID="btnSubmit" runat="server" Text="Submit" CommandArgument='<%# Container.DataItemIndex %>' /></ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>There is no record....</EmptyDataTemplate>
        </asp:GridView>
        </td></tr>
</table>
</asp:Content>

