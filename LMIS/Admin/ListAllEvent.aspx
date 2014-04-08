<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListAllEvent.aspx.cs" Inherits="LMIS.Admin.ListAllEvent"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<%@ Register TagPrefix="uc1" TagName="ListAllEventControl" Src="../SampleScheduler/ListAllEventControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:ListAllEventControl ID="ctlListAllEventControl" runat="server" />
</asp:Content>

