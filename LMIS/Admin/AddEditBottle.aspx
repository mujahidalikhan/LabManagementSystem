<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddEditBottle.aspx.cs" Inherits="LMIS.Admin.AddEditBottle" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

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
                <span class="st-labeltext">Preservative / Chemical</span>
                <asp:TextBox ID="PreservativeChemical" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                    ErrorMessage="*Enter Preservative Chemical" ControlToValidate="PreservativeChemical"
                    CssClass="st-form-error"></asp:RequiredFieldValidator></td>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Volume Type 1 </span>
                <asp:TextBox ID="VolumeType1" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Volume Type "
                    ControlToValidate="VolumeType1" CssClass="st-form-error"></asp:RequiredFieldValidator></td>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">VolumeType 2</span>
                <asp:TextBox ID="VolumeType2" runat="server" class="st-forminput" Width="189px"></asp:TextBox>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">VolumeType 3</span>
                <asp:TextBox ID="VolumeType3" runat="server" class="st-forminput" Width="186px"></asp:TextBox>
            </div>
            <div style="z-index: 460;" class="button-box">
                <asp:Button ID="Button1" runat="server" Text=" Submit" OnClick="Button1_Click" CssClass="st-button "
                    Width="120px" />
                <asp:Button ID="Reset_Button" runat="server" Text="Reset" Width="120px" OnClientClick="this.form.reset();return false;"
                    CssClass="st-clear" />
            </div>
        </div>
    </div>
</asp:Content>
