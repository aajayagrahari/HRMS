<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Master/EmployeeMaster.master"
    AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
    <div class="accountInfo">
        <fieldset class="changePassword">
            <legend>Change Password</legend>
            <p>
                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                <asp:TextBox ID="CurrentPassword" runat="server" CssClass="TextBoxdesign" TextMode="Password" Width="65%"></asp:TextBox>
                 <asp:RequiredFieldValidator CssClass="Required" ID="rfvtxtOldPassword" runat="server"
                                            ErrorMessage="*" ToolTip="Please Enter the Old Password" SetFocusOnError="true"
                                            ControlToValidate="CurrentPassword" ValidationGroup="Req_Blank" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                <asp:TextBox ID="NewPassword" runat="server" CssClass="TextBoxdesign" TextMode="Password" Width="65%"></asp:TextBox>
                 <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="*" ToolTip="Please Enter New Password" SetFocusOnError="true"
                                            ControlToValidate="NewPassword" ValidationGroup="Req_Blank" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="TextBoxdesign" TextMode="Password" Width="65%"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="Required" ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="*" ToolTip="Please Re-Enter New Password" SetFocusOnError="true"
                                            ControlToValidate="ConfirmNewPassword" ValidationGroup="Req_Blank" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
            </p>
        </fieldset>
        <p >
            <asp:Button ID="ChangePasswordPushButton" runat="server" Text="Submit" OnClick="ChangePasswordPushButton_Click" />
            <asp:Button ID="CancelPushButton" runat="server" Text="Cancel" />
            
        </p>
    </div>
</asp:Content>
