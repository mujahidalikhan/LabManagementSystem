<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddEditUser.aspx.cs" Inherits="LMIS.Admin.AddEditUser"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Add/Edit Bottle Information</h3>
        </div>
        <div style="z-index: 690;" class="body">
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext"> First Name:</span>
			
                <asp:TextBox ID="userFirstName" runat="server" class="st-forminput" 
                    Width="330px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                enableclientscript="False"
                    ErrorMessage="Please Enter Password" ControlToValidate="userFirstName" 
                    CssClass="st-form-error" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Last Name:</span>
			
                <asp:TextBox ID="userLastName" runat="server" class="st-forminput" 
                    Width="330px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 enableclientscript="False"
                    ErrorMessage="Please enter last name" ControlToValidate="userLastName" 
                    CssClass="st-form-error" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
                <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Email:</span>
		        <asp:TextBox ID="userEmailAddress" runat="server" class="st-forminput" 
                    Width="330px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Please enter email Address" 
                     enableclientscript="False"
                    ControlToValidate="userEmailAddress" CssClass="st-form-error" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="userEmailAddress"
                     enableclientscript="False" 
                    ErrorMessage="Please enter a valid Email Address" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    CssClass="st-form-error" Display="Dynamic"></asp:RegularExpressionValidator>
             </div>
                <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">User Name:</span>
		
                <asp:TextBox ID="userName" runat="server" class="st-forminput" 
                    Width="330px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 enableclientscript="False"
                    ErrorMessage="Please enter User name" ControlToValidate="userName" 
                    CssClass="st-form-error" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
                <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Password:</span>
		
                <asp:TextBox ID="userPassword" runat="server"  type="Password" 
                    class="st-forminput" 
                    Width="330px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                enableclientscript="False"
                    ErrorMessage="Please Enter Password" ControlToValidate="userPassword" 
                    CssClass="st-form-error" Display="Dynamic"></asp:RequiredFieldValidator>
             </div>
                <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Confirm Password:</span>
			
                <asp:TextBox ID="userConformPassword" runat="server"  type="Password" 
                    class="st-forminput" 
                    Width="330px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                 enableclientscript="False"
                    ErrorMessage="Please enter conform Password" 
                    ControlToValidate="userConformPassword" CssClass="st-form-error" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="userPassword" ControlToValidate="userConformPassword" 
                     enableclientscript="False"
                    CssClass="st-form-error" 
                    ErrorMessage="Confirm Password and Password not match" Display="Dynamic"></asp:CompareValidator>
                 </div>
                <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Type:</span>

                <asp:DropDownList ID="usertype" runat="server"   CssClass="styled-select">
                    <asp:ListItem Value="A">Admin</asp:ListItem>
                     <asp:ListItem Value="S">Batching</asp:ListItem>
                    <asp:ListItem Value="C">CEO</asp:ListItem>
                    <asp:ListItem Value="L">Lab Assistants</asp:ListItem>
                    <asp:ListItem Value="M">Verification</asp:ListItem>
                </asp:DropDownList>

        </div>
	<br/>
	<br/>
    
      <div style="z-index: 460;" class="button-box">
	    <asp:Button ID="Button1" runat="server"  Text =" Submit"  
                onclick="Button1_Click" CssClass="st-button " Width="120px" />
            <asp:Button ID="Reset_Button" runat="server" Text="Reset"  
                Width="120px" OnClientClick="this.form.reset();return false;" 
                CssClass="st-clear" />
		
    </div>
    </div>
    </div>

    
</asp:Content>
