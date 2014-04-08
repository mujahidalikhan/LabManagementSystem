<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ArchiveJobnList.aspx.cs" Inherits="LMIS.Admin.ArchiveJobList" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 460;" class="titleh">
            <h3>
                Archive
                Job List</h3>
        </div>
        <!-- Start Data Tables Initialisation code -->
        <script type="text/javascript" charset="utf-8">
            $(document).ready(function () {
                oTable = $("#<%= JobTable.ClientID %>").dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <!-- End Data Tables Initialisation code -->
        <asp:Table ID="JobTable" runat="server" class="display data-table" Width="100%"
            CellPadding="0" CellSpacing="0" border="0" />
    </div>
</asp:Content>
