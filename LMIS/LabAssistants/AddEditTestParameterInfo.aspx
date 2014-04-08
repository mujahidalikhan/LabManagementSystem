<%@ Page Title="" Language="C#" MasterPageFile="~/LabAssistants/LabAssistants.Master" AutoEventWireup="true" CodeBehind="AddEditTestParameterInfo.aspx.cs" Inherits="LMIS.LabAssistants.AddEditTestParameterInfo"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="simplebox">
        <div class="titleh">
            <h3>
                Add/Edit Test Parameter
            </h3>
        </div>
        <div class="body padding10">
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Accredited Parameter:</span>
                <asp:TextBox ID="AccreditedTestParameter" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="AccreditedTestParameter" CssClass="st-form-error" 
                    ErrorMessage="*Please enter accredited parameter"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Test Method:</span>
                <asp:TextBox ID="TestMethod" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TestMethod" CssClass="st-form-error" 
                    ErrorMessage="*Please enter test method"></asp:RequiredFieldValidator>
           
        </div>
        <div style="z-index: 680;" class="st-form-line">
            <span class="st-labeltext">Unit:</span>
            <asp:TextBox ID="Unit" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="Unit" CssClass="st-form-error" 
                ErrorMessage="*Please enter unit"></asp:RequiredFieldValidator>
        </div>
        <div style="z-index: 680;" class="st-form-line">
            <span class="st-labeltext">Equipment:</span>
            <asp:TextBox ID="Equipment" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
        </div>
        <div style="z-index: 680;" class="st-form-line">
            <span class="st-labeltext">MDL:</span>
            <asp:TextBox ID="MDL" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
        </div>
        <div style="z-index: 680;" class="st-form-line">
            <span class="st-labeltext">Short Term:</span>
            <asp:TextBox ID="ShortTerm" runat="server" class="st-forminput" Width="188px"></asp:TextBox>
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
