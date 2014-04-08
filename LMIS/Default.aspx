<%@ Page Title="Home Page" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="LMIS._Default"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
       <div class="loginform">
        <div class="title">
            <img src="images/logo.png" width="112px" height="35px" /></div>
        <div class="body">
            <form id="form1" runat="server">
            <label class="log-lab">Username</label>
            <asp:TextBox type="text" class="login-input-user" ID="UserName" runat="server" />
            <label class="log-lab">Password</label>
            <asp:TextBox type="password" class="login-input-pass" ID="Password"  runat="server" />
            <asp:Label ID="errorMessage" runat="server" ForeColor="Maroon">Invalid user name or passowrd</asp:Label>
            <asp:Button ID="loging" runat="server" Text="Login" class="button" OnClick="login_Click" />
            </form>
        </div>
    </div>
    </asp:Content>