<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" 
Inherits="LMIS.Sampler.Dashboard"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" 
ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="z-index: 690;" class="body">
    <div style="z-index: 680;" class="st-form-line">
        <div style="z-index: 460;" class="titleh">
            <h3>
                Specification</h3>
        </div>
        <!-- Start Data Tables Initialisation code -->
        <script type="text/javascript" charset="utf-8">
            $(document).ready(function () {
                oTable = $("#<%= SpecificationTable.ClientID %>").dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <!-- End Data Tables Initialisation code -->
        <asp:Table ID="SpecificationTable" runat="server" class="display data-table" Width="100%"
            CellPadding="0" CellSpacing="0" border="0" />
    </div>
        </div>
</asp:Content>
