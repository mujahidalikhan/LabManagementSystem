<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateRewardValue.aspx.cs" Inherits="LMIS.Admin.UpdateRewardValue"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

                        	<div class="simplebox">
                            	<div class="titleh"><h3>Reward Rate Setting</h3></div>
                                <div class="body padding10">
     
	<table border="0" width="100%" cellpadding="0" cellspacing="0">
	<tr valign="top">
	<td>
	
		<!-- start id-form -->
		<table border="0"  width="100%"  cellpadding="0" cellspacing="0"  id="id-form">
		<tr>
			<th valign="top" class="style4">Reward Value:</th>
			<td class="style6">
                <asp:TextBox ID="rewardValue" runat="server" class="st-forminput" 
                    Width="202px"></asp:TextBox>
            </td>
			<td class="style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                enableclientscript="False"
                    ErrorMessage="*Please Enter Reward Value" ControlToValidate="rewardValue" 
                     class="st-form-error" Display="Dynamic" Width="214px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" class="st-form-error"
                                runat="server" ControlToValidate="rewardValue" 
                    Display="Dynamic" ErrorMessage="*Please enter only integer"
                                ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            </td>
		</tr>
	
        
        </table>
        
	<br/>
	<br/>
    

  <table>  	
	<tr>
		<th>&nbsp;</th>
		<td class="style3">
		    <asp:Button ID="Button1" runat="server"  Text ="Update"  class="st-button" onclick="Button1_Click" Width="120px" />
		</td>
		<td class="style3">
            <asp:Label ID="errorMessage" runat="server"  class="st-form-error" 
                Visible="False">*Reward Value cannot be grater then 0</asp:Label>
        </td>
	</tr>
	</table>
	<!-- end id-form  -->

	</td>
	
</tr>

</table>

                                </div>
                            </div>
                        
    
</asp:Content>
