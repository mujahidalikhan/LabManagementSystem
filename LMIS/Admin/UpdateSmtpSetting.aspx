<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateSmtpSetting.aspx.cs" Inherits="LMIS.Admin.UpdateSmtpSetting"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="z-index: 720;" class="simplebox grid740">
                            	<div style="z-index: 690;" class="body">
    
  
        

                        	
    	<div style="z-index: 680;" class="st-form-line">	
	
		<!-- start id-form -->
		 	<div style="z-index: 680;" class="st-form-line">	
			<span class="st-labeltext">Server Address:</span>
			    <asp:TextBox ID="serverAddress" runat="server" class="st-forminput" 
                    Width="202px"></asp:TextBox>
                    <span class="st-form-error">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                enableclientscript="False"
                    ErrorMessage="*Please Enter Server Address" ControlToValidate="serverAddress" 
                    CssClass="st-form-error" Display="Dynamic" Width="214px"></asp:RequiredFieldValidator>
                    </span>
             <div style="z-index: 670;" class="clear"></div>
		</div>
		 	<div style="z-index: 680;" class="st-form-line">	
			<span class="st-labeltext">Server Port:</span>
			
                <asp:TextBox ID="serverPort" runat="server" class="st-forminput" 
                    Width="202px"></asp:TextBox>
            
			<span class="st-form-error">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 enableclientscript="False"
                    ErrorMessage="*Please Enter Server Port" ControlToValidate="serverPort" 
                    CssClass="st-form-error" Display="Dynamic" Width="214px"></asp:RequiredFieldValidator></span>
            </div>
            
            <div style="z-index: 680;" class="st-form-line">	
			<span class="st-labeltext">User Name:</span>
			
                <asp:TextBox ID="userName" runat="server" class="st-forminput" 
                    Width="202px"></asp:TextBox>
            
			<span class="st-form-error">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*Please enter user name" 
                     enableclientscript="False"
                    ControlToValidate="userName" CssClass="st-form-error" Width="214px" 
                    Display="Dynamic"></asp:RequiredFieldValidator></span>
            </div>

        	<div style="z-index: 680;" class="st-form-line">	
			<span class="st-labeltext">Password:</span>
			
                <asp:TextBox ID="userPasswrod" runat="server" class="st-forminput"  type="Password" 
                    Width="202px"></asp:TextBox>
                    <span class="st-form-error">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 enableclientscript="False"
                    ErrorMessage="*Please enter User name" ControlToValidate="userPasswrod" 
                    CssClass="st-form-error" Display="Dynamic" Width="214px"></asp:RequiredFieldValidator></span>
            </div>

            <div style="z-index: 680;" class="st-form-line">	
			<span class="st-labeltext">From Name:</span>
		
                <asp:TextBox ID="fromName" runat="server" 
                    class="st-forminput" 
                    Width="202px"></asp:TextBox>
        <span class="st-form-error">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                enableclientscript="False"
                    ErrorMessage="*Please Enter Password" ControlToValidate="fromName" 
                    CssClass="st-form-error" Display="Dynamic" Width="214px"></asp:RequiredFieldValidator></span>
        </div>
        <div style="z-index: 680;" class="st-form-line">	
			<span class="st-labeltext">From Email:</span>
			
                <asp:TextBox ID="fromEmail" runat="server"   
                    class="st-forminput" 
                    Width="202px"></asp:TextBox>
            <span class="st-form-error">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="fromEmail"
                     enableclientscript="False" 
                    ErrorMessage="*Please enter a valid Email Address" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    CssClass="st-form-error" Display="Dynamic" Width="214px"></asp:RegularExpressionValidator></span>

                   
            </div>

            <div style="z-index: 680;" class="st-form-line">	
			<span class="st-labeltext">Enable SSL:</span>
			
                <asp:CheckBox ID="EnableSSL" runat="server" Checked="True" />
            </div>
        
    

  	    <asp:Button ID="btnUpdateSmtpSetting" runat="server"  Text ="Update"  
                class="st-button"  Width="120px" onclick="btnUpdateSmtpSetting_Click" />
	

                                
                           
                        </div>
</div>
</div>
</asp:Content>
