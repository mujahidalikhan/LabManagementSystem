<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="LMIS.Manager.ErrorPage"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="error-page">
                        	<img src="../images/icons/error/error-red-big.png" width="91" height="91" alt="icon" />
                            <h2 class="red">Opps... Error  Occur! </h2>
                            <p>Some Unknown error found </p>
                            <div class="padding30"><a href="Dashboard.aspx class="button">Go Back</a></div>
                        </div>
                        <!-- End Error Red -->
                        
                        
                        
                     
                        
</asp:Content>
