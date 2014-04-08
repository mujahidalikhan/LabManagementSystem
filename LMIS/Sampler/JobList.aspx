<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true"
    CodeBehind="JobList.aspx.cs" Inherits="LMIS.Sampler.JobList" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 460;" class="titleh">
            <h3>
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
        <asp:Button ID="Button1" runat="server" Text="Add New Job" OnClick="Button1_Click"
            CssClass="st-button" />
    </div>
</asp:Content>
