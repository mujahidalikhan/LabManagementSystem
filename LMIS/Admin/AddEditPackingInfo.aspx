<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddEditPackingInfo.aspx.cs" Inherits="LMIS.Admin.AddEditPackingInfo" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Add/Edit Packing Infomraiton</h3>
        </div>
        <div style="z-index: 690;" class="body">
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Packing Name:</span> 
                <asp:TextBox ID="packingName" runat="server" class="st-forminput" Width="186px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                    ErrorMessage="*Please Enter Packing  Name" ControlToValidate="packingName" CssClass="st-form-error"></asp:RequiredFieldValidator>
            
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Packing Description:</span>
                <asp:TextBox ID="packingDescription" runat="server" class="st-forminput" Width="186px"></asp:TextBox>
               
            </div>
            <div style="z-index: 460;" class="button-box">
                <asp:Button ID="Button1" runat="server" Text=" Submit" class="st-button" Width="120px"
                    OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>
