<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="LMIS.Sampler.Appointment"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>

<%@ Register TagPrefix="uc1" TagName="AppointScheduleControl" Src="../AppointScheduler/AppointScheduleControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:AppointScheduleControl ID="ctlAppointScheduleControl" runat="server" />
</asp:Content>
