<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddEditIndustry.aspx.cs" Inherits="LMIS.Admin.AddEditIndustry" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Add/Edit Scope</h3>
        </div>
        <div style="z-index: 690;" class="body">
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Industry Name:</span>
                <asp:TextBox ID="industryName" runat="server" class="st-forminput" Width="186px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                    ErrorMessage="*Please enter Industry Name" ControlToValidate="industryName" CssClass="st-form-error"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Comments:</span>
                <asp:TextBox ID="comments" runat="server" class="st-forminput" Width="186px"></asp:TextBox>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Associated Tests:</span>
                <asp:ListBox ID="testList" runat="server" SelectionMode="Multiple" Width="307px"
                    Height="290px"></asp:ListBox>
            </div>
       <div style="z-index: 460;" class="button-box">
            
            <asp:Button ID="Button1" runat="server" Text=" Submit" class="st-button" OnClick="Button1_Click"
                Width="120px" />
            <asp:Button ID="Reset_Button" runat="server" Text="Reset" class="st-clear" Width="120px"
                OnClientClick="this.form.reset();return false;" />
        </div>
    </div>
    </div>
</asp:Content>
