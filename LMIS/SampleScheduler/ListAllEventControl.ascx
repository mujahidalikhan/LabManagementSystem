<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListAllEventControl.ascx.cs"
    Inherits="LMIS.SampleScheduler.ListAllEventControl" %>
<style type="text/css">

.st-form-error
{
    color: #99616B;
    font-size: 12px;
    margin-left: 10px;
}



    .style1
    {
        font-size: 100%;
        text-decoration: none;
        border-style: none;
        border-color: inherit;
        border-width: 0;
        margin: 0;
        padding: 0;
    }
</style>
<div class="simplebox grid740" style="width: 99%;">
    <div style="z-index: 460;" class="titleh">
        <h3>
            Print Event List
        </h3>
    </div>
    <div style="z-index: 690;" class="body">
        <script type="text/javascript">
            $(function () {
                $("#<%= starteDate.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                $("#<%= endDate.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
            });
        </script>
        <div style="z-index: 680;" class="st-form-line">
            <span class="st-labeltext">Start Date:</span>
            <input type="text" id="starteDate" class="datepicker-input" style="width: 180px;"
                runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                    ErrorMessage="*Enter Start Date" ControlToValidate="starteDate"
                    CssClass="st-form-error"></asp:RequiredFieldValidator>
        </div>
        <div style="z-index: 680;" class="st-form-line">
            <span class="st-labeltext">End Date:</span>
            <input type="text" id="endDate" class="datepicker-input" style="width: 180px;" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName0" runat="server"
                    ErrorMessage="*Enter End Date" ControlToValidate="endDate"
                    CssClass="st-form-error"></asp:RequiredFieldValidator>
        </div>
         <div style="z-index: 460;" class="button-box">
                <asp:Button ID="Button2" runat="server" Text="Print Event List"  CssClass="st-button "
                    Width="120px" onclick="Button2_Click" />
               
            </div>
    </div>
</div>
<div class="simplebox grid740" style="width: 99%;">
    <div style="z-index: 460;" class="titleh">
        <h3>
            List of all event</h3>
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
        Width="103px" CausesValidation="False" />
</div>
