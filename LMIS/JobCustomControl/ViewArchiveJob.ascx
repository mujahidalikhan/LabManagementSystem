<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewArchiveJob.ascx.cs"
    Inherits="LMIS.JobCustomControl.ViewArchiveJob"  %>
<asp:Panel ID="pnl1" runat="server">
    <!-- Simple usage without double class -->
    <div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%;">
          <div class="simplebox">
        <div class="titleh">
            <h3>
               Delete Reason </h3>
        </div>
        <div class="body padding10">
            <span class="st-labeltext">Reason:</span>
            <asp:TextBox ID="DeletReason" runat="server"  class="st-error-input" 
                Height="75px" Width="650px" TextMode="MultiLine" />
        </div>
    </div>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="id-form">
        <tr>
            <td>
                <!-- Simple usage without double class -->
                <div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%;">
                    <div class="simplebox">
                        <div class="titleh">
                            <h3>
                                Customer Information</h3>
                        </div>
                        <div class="body padding10">
                            <table>
                                
                                <tr>
                                    <td align="left">
                                        Job Number
                                    </td>
                                    <td colspan="5" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="JobNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="style1" rowspan="3" align="left">
                                        Customer Name:
                                    </td>
                                    <td class="style1" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="ClientName" runat="server"></asp:Label>
                                    </td>
                                    <td class="style2">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        Date:
                                    </td>
                                    <td colspan="2" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="JobDate" runat="server" Width="140px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td rowspan="2" valign="top" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="customerAddress" runat="server" Width="262px"></asp:Label>
                                    </td>
                                    <td rowspan="2">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        Validity:
                                    </td>
                                    <td style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="Validity" runat="server" ViewStateMode="Disabled" />&nbsp;&nbsp;
                                        Days&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Term of Payment:
                                    </td>
                                    <td style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="paymentDate" runat="server" />&nbsp;&nbsp; Days&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="style1" rowspan="4" align="left">
                                        Attention:
                                    </td>
                                    <td valign="top" class="style1" rowspan="4" colspan="2" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="dllAttention" runat="server" />
                                    </td>
                                    <td align="left">
                                        Tel No:
                                    </td>
                                    <td colspan="2" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="TelNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Home Phone No:
                                    </td>
                                    <td colspan="2" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="HomePhone" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Fax No:
                                    </td>
                                    <td colspan="2" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="FaxNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Email Address:
                                    </td>
                                    <td colspan="2" style="clip: rect(4px, 10px, 4px, 15px)">
                                        <asp:Label ID="Email" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%;">
                    <div class="simplebox">
                        <div class="titleh">
                            <h3>
                                Test Details</h3>
                        </div>
                        <div class="body padding10">
                            <table border="0" width="100%" cellpadding="0" cellspacing="0" id="tblTestDeatil"
                                runat="server">
                                <thead height=" 40px">
                                    <tr style="background-color: gainsboro; border: outset; border-width: 1px">
                                        <td style="width: 5%;">
                                            NO
                                        </td>
                                        <td style="width: 70%;">
                                            DESCRIPTION
                                        </td>
                                        <td align="center" valign="top" width="5%">
                                            UNIT PRICE(RM)
                                        </td>
                                        <td valign="top" align="center" width="15%">
                                            QTY
                                        </td>
                                        <td valign="top" align="center" width="5%">
                                            AMOUNT (RM)
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%;">
                    <div class="simplebox">
                        <div class="titleh">
                            <h3>
                                Customer Reward Points Details</h3>
                        </div>
                        <div class="body padding10">
                            <table width="100%">
                                <tr>
                                    <td width="20%">
                                        Reward Points
                                    </td>
                                    <td width="20%">
                                        <asp:Label runat="server" ID="RewardPoints" />
                                    </td>
                                    <td width="20%">
                                        &nbsp;Reward Points To Use
                                    </td>
                                    <td width="20%">
                                        <asp:Label ID="TextBox1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
      
    </table>
</asp:Panel>
<asp:Button ID="Button1" runat="server" Text="Back" class="st-button" Width="120px"
    OnClick="Button1_Click" />
