<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true" CodeBehind="ViewJob.aspx.cs" Inherits="LMIS.Sampler.ViewJob"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<%@ Register TagPrefix="uc1" TagName="updateJobStatus" Src="../JobCustomControl/UpdateJobStatus.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <uc1:updateJobStatus ID="ctlupdateJobStatus" runat="server" />

</asp:Content>

