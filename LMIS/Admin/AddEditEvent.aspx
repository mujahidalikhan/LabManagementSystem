<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddEditEvent.aspx.cs" Inherits="LMIS.Admin.AddEditEvent" %>
<%@ Register TagPrefix="uc1" TagName="AddEventControl" Src="../SampleScheduler/AddEventControl.ascx" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:AddEventControl ID="ctlAddEventControl" runat="server" />
</asp:Content>
