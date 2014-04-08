<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddEditJobTestInfo.aspx.cs" Inherits="LMIS.Admin.AddEditJobTestInfo" %>
<%@ Register TagPrefix="uc1" TagName="addEditJobTestInfo" Src="../JobCustomControl/AddEditJobTestInfo.ascx" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:addEditJobTestInfo ID="ctlAddEditJobTestInfo" runat="server" />
</asp:Content>
