<%@ Page Title="Delete Job " Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="DeleteJobInfo.aspx.cs" Inherits="LMIS.Admin.DeleteQInfo"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Delete Job Task </h3>
        </div>
        <div style="z-index: 690;" class="body">
            <br /> 
              <span class="st-labeltext">Reason of Delete </span>
            <asp:TextBox ID="ReasonToDelete" runat="server" Height="159px" TextMode="MultiLine" 
           Width="525px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                    ErrorMessage="*Enter Job Remove Condition" ControlToValidate="ReasonToDelete"
                    CssClass="st-form-error"></asp:RequiredFieldValidator>
        </div>
         <div style="z-index: 460;" class="button-box">
                <asp:Button ID="Button1" runat="server" Text="Delete Job " 
                    OnClick="Button1_Click" CssClass="st-button "
                    Width="136px" />
                <asp:Button ID="Reset_Button" runat="server" Text="Cancel &amp; GoBack" Width="136px"
                    CssClass="st-clear" CausesValidation="False" 
                    onclick="Reset_Button_Click" />
            </div>
        </div>
   
</asp:Content>