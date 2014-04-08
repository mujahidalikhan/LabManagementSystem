<%@ Page Title="" Language="C#" MasterPageFile="~/LabAssistants/LabAssistants.Master" AutoEventWireup="true" CodeBehind="ListSpecification.aspx.cs" Inherits="LMIS.LabAssistants.ListSpecification"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<%@ Register TagPrefix="uc1" TagName="ListSpecification" Src="../SpecificationControl/ListSpecification.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <uc1:ListSpecification ID="ctlListSpecification" runat="server" />

</asp:Content>