﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true" CodeBehind="AddEditAppoint.aspx.cs" Inherits="LMIS.Sampler.AddEditAppoint"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<%@ Register TagPrefix="uc1" TagName="AddEditAppointControl" Src="../AppointScheduler/AddEditAppointControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:AddEditAppointControl ID="ctlAddEditAppointControl" runat="server" />
</asp:Content>
