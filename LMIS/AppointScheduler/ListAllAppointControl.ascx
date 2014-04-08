<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListAllAppointControl.ascx.cs" Inherits="LMIS.AppointScheduler.ListAllAppoint"  %>
  <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 460;" class="titleh">
            <h3>
                List of all Appointment(s)</h3>
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
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" CssClass="st-button"
            Width="103px" />
    </div>