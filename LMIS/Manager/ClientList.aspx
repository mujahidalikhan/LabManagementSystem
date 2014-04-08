<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="LMIS.Manager.ClientList"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 460;" class="titleh">
            <h3>
                Client List</h3>
        </div>
           <div style="z-index: 690;" class="body">
              <div style="width: 100%; overflow: auto; overflow-y: hidden; margin-bottom: 20px;-ms-overflow-y: hidden;">
    
       
        <asp:Table ID="ClientListTable" runat="server"  class="tablesorter" Width="100%" />
         <br />
          <br />
            </div>
        <br />
           <div style="z-index: 460;" class="button-box">
        <asp:Button ID="Button1" runat="server" Text="Export Client List" Width="147px" OnClick="Button1_Click"
            CssClass="st-button" />
            </div>
            </div>
    </div>
</asp:Content>
