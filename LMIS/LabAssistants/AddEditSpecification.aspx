<%@ Page Title="" Language="C#" MasterPageFile="~/LabAssistants/LabAssistants.Master" AutoEventWireup="true" CodeBehind="AddEditSpecification.aspx.cs" Inherits="LMIS.LabAssistants.AddEditSpecification"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<%@ Register TagPrefix="uc1" TagName="AddEditSpecification" Src="../SpecificationControl/AddEditSpecification.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <uc1:AddEditSpecification ID="ctlAddEditSpecification" runat="server" />

</asp:Content>