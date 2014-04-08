<%@ Page Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true"
    CodeBehind="DashboardParameter.aspx.cs" Inherits="LMIS.Manager.DashboardParameter"
    EnableViewStateMac="false" EnableSessionState="True" EnableEventValidation="false"
    ValidateRequest="false" ViewStateEncryptionMode="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="z-index: 690;" class="body">
        <div style="z-index: 680;" class="st-form-line">
            <div style="z-index: 460;" class="titleh">
                <table>
                    <tr>
                        <td>
                            <h3>
                                Specification</h3>
                        </td>
                        <td>
                            <asp:Label ID="Specname" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <h3>
                                Test Parameter</h3>
                        </td>
                        <td>
                            <asp:Label ID="ParamName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
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
