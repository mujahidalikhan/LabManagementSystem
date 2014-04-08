<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditSpecification.ascx.cs" Inherits="LMIS.SpecificationControl.AddEditSpecification"   %>
 <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Add/Edit Specification</h3>
        </div>
        <div style="z-index: 690;" class="body">
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Test Parameter:</span>
                <asp:TextBox ID="testParameter" runat="server" class="st-forminput"
                    Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" EnableClientScript="False"
                    ErrorMessage="Please Enter Test Parameter" ControlToValidate="testParameter"
                    CssClass="st-form-error" Display="Dynamic" Width="214px"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Unit:</span>
                <asp:TextBox ID="unit" runat="server" class="st-forminput" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="False"
                    ErrorMessage="Please enter Unit" ControlToValidate="unit" CssClass="st-form-error"
                    Display="Dynamic" Width="214px"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">StdA:</span>
                <asp:TextBox ID="stdA" runat="server" class="st-forminput" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter StdA"
                    EnableClientScript="False" ControlToValidate="stdA" CssClass="st-form-error"
                    Width="214px" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">StdB:</span>
                <asp:TextBox ID="stdB" runat="server" class="st-forminput" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="False"
                    ErrorMessage="Please enter StdB" ControlToValidate="stdB" CssClass="st-form-error"
                    Display="Dynamic" Width="214px"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Customized:</span>
                <asp:TextBox ID="customized" runat="server" class="st-forminput" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="False"
                    ErrorMessage="Please enter Customized" ControlToValidate="customized" CssClass="st-form-error"
                    Display="Dynamic" Width="214px"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 460;" class="button-box">
                <asp:Button ID="Button1" runat="server" Text=" Submit" OnClick="Button1_Click" CssClass="st-button"
                    Width="120px" />
                <asp:Button ID="Reset_Button" runat="server" Text="Reset" Width="120px" OnClientClick="this.form.reset();return false;"
                    CssClass="st-clear" />
            </div>
        </div>
    </div>

