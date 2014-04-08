<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Jobcard.aspx.cs" Inherits="LMIS.Admin.Jobcard" EnableViewStateMac="false"
    EnableSessionState="True" EnableEventValidation="false" ValidateRequest="false"
    ViewStateEncryptionMode="Never" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="simplebox grid740" style="width: 99%;">
            <div class="simplebox">
                <div class="titleh">
                    <h3>
                        Test Detail
                    </h3>
                </div>
                <div class="body padding10">
                    <div style="z-index: 680;" class="st-form-line">
                        <table width="100%">
                            <tr>
                                <td>
                                    <span class="st-labeltext">Customer Name:</span>
                                </td>
                                <td width="230px">
                                    <asp:Label ID="ClientName" runat="server" />
                                </td>
                                <td>
                                    <span class="st-labeltext">Lab Number</span>
                                </td>
                                <td width="230px">
                                    <asp:Label ID="labNumber" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="st-labeltext">Attention:</span>
                                </td>
                                <td>
                                    <asp:Label ID="Attention" runat="server" />
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="st-labeltext">Scope:</span>
                                </td>
                                <td>
                                    <asp:Label ID="industryType" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <span class="st-labeltext">Associated Tests: </span>
                                </td>
                                <td>
                                    <asp:Label ID="testList" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="z-index: 680;" class="st-form-line">
                        <span class="st-labeltext">Analysis Condition:</span>
                        <asp:TextBox ID="analysisCondition" Rows="3" runat="server" Height="64px" Width="450px"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div style="z-index: 680;" class="st-form-line">
                        <span class="st-labeltext">Estimated End Time</span>
                        <script type="text/javascript">
                            $(function () {
                                $("#<%= datepicker.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                            });
                        </script>
                        <input type="text" id="datepicker" class="datepicker-input" style="width: 180px;"
                            runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="datepicker"
                            CssClass="st-form-error" Display="Dynamic" ErrorMessage="*Please Enter Estimated Date"></asp:RequiredFieldValidator>
                    </div>
                     <div style="z-index: 680;" class="st-form-line">
                        <span class="st-labeltext">Status</span>
                         <asp:DropDownList ID="statusList" runat="server" class="styled-selectSmall">
                                            <asp:ListItem >Active </asp:ListItem>
                                            <asp:ListItem >Fail</asp:ListItem>
                                            <asp:ListItem >Cancel</asp:ListItem>
                                        </asp:DropDownList>
                </div>
            </div>
        </div>
            <br />
        <div class="simplebox grid740" style="width: 100%;">
            <div style="z-index: 460;" class="titleh">
                <h3>
                    Sample Information</h3>
            </div>
            <asp:Table ID="SampleInformationTable" runat="server" class="tablesorter" Width="100%"
                CellPadding="0" CellSpacing="0" border="0" />
        </div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
         <asp:Panel ID="pnl1" runat="server" Width="100%">
            <asp:UpdatePanel ID="ResultsUpdatePanel" runat="server">
                <ContentTemplate>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="ResultsUpdatePanel"
                            DynamicLayout="true">
                            <ProgressTemplate>
                                <img src="../images/loading/6.gif" alt="icon" style="margin-right: 15px;" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <div class="simplebox grid740" style="width: 100%;">
                        <div style="z-index: 460;" class="titleh">
                            <h3>
                                Test Results</h3>
                        </div>
                        <div style="width: 100%; overflow: auto; overflow-y: hidden; margin-bottom: 20px;
                            -ms-overflow-y: hidden;">
                            <asp:Table ID="TestInfoTable" runat="server" class="tablesorter" Width="100%" CellPadding="0"
                                CellSpacing="0" border="0" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <br />
        <br />
       <table>
            <tr>
                <td style="width: 200px">
                    <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button2_Click1"
                        Text="Print COA Reporter" CssClass="st-clear" Width="180px" />
                    &nbsp;
                    <asp:Button ID="Button4" runat="server" CausesValidation="False" Text="Send E-Card COA Reporter"
                        CssClass="st-clear" Width="180px" OnClick="Button3_Click" />
                </td>
                <td style="width: 200px">
                    <asp:Button ID="PrintCOA" runat="server" CausesValidation="False" Text="Print COA"
                        CssClass="st-clear" Width="180px" OnClick="PrintCOA_Click" />
                    &nbsp;
                    <asp:Button ID="ECardCOA" runat="server" CausesValidation="False" Text="Send E-Card COA"
                        CssClass="st-clear" Width="180px" OnClick="ECardCOA_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Update Job Card" OnClick="Button1_Click"
                Width="166px" BackColor="#A9B0BE" BorderColor="#A9B0BE" BorderStyle="Solid" CssClass="st-button" />
                
                  <asp:Button ID="Button2" runat="server" Text="Print Job Card" 
                Width="166px" BackColor="#A9B0BE" BorderColor="#A9B0BE" 
                BorderStyle="Solid" CssClass="st-button" onclick="Button2_Click1" />
                

            &nbsp;
            <asp:Button ID="Reset_Button" runat="server" Text="Go Back" Width="166px" CssClass="st-clear"
                OnClick="Reset_Button_Click" CausesValidation="False" />
        </p>
    </div>
</asp:Content>
