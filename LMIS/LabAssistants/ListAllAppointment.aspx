<%@ Page Title="" Language="C#" MasterPageFile="~/LabAssistants/LabAssistants.Master" AutoEventWireup="true" CodeBehind="ListAllAppointment.aspx.cs" Inherits="LMIS.LabAssistants.ListAllAppointment"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<%@ Register TagPrefix="uc1" TagName="ListAllAppointControl" Src="../AppointScheduler/ListAllAppointControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:ListAllAppointControl ID="ctlListAllAppointControl" runat="server" />
</asp:Content>
