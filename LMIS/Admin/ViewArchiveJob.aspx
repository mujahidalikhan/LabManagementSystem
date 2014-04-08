<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewArchiveJob.aspx.cs" Inherits="LMIS.Admin.ViewArchiveJob" %>
<%@ Register TagPrefix="uc1" TagName="viewArchiveJob" Src="../JobCustomControl/ViewArchiveJob.ascx" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <uc1:viewArchiveJob ID="ctlupdateJobStatus" runat="server" />

</asp:Content>

