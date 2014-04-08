<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="SamplePackingList.aspx.cs" Inherits="LMIS.Admin.SamplePackingList"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 460;" class="titleh">
            <h3>
                Sample Packing List</h3>
        </div>
        <!-- Start Data Tables Initialisation code -->
        <script type="text/javascript" charset="utf-8">
            $(document).ready(function () {
                oTable = $("#<%= SamplePackingTable.ClientID %>").dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <!-- End Data Tables Initialisation code -->
        <asp:Table ID="SamplePackingTable" runat="server" class="display data-table" Width="100%"
            CellPadding="0" CellSpacing="0" border="0" />
        
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add New Packing"
            Width="180px" CssClass="st-button" />
    </div>
</asp:Content>
