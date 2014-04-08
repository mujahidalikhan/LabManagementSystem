<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateJobStatus.ascx.cs"
    Inherits="LMIS.JobCustomControl.UpdateJobStatus" %>
<asp:Panel ID="pnl1" runat="server">
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
                            <div id="secresults" runat="server" class="secresults">
                                <table id="tbl" runat="server">
                                    <tr>
                                        <th align="left">
                                            Job Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </th>
                                        <td colspan="3">
                                            <asp:Label ID="JobNumber" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th valign="top" class="style1" rowspan="3" align="left">
                                            Customer Name:&nbsp;&nbsp;&nbsp;&nbsp;
                                        </th>
                                        <td class="style1">
                                            <asp:Label ID="ClientName" runat="server"></asp:Label>
                                        </td>
                                        <th align="left">
                                            Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </th>
                                        <td>
                                            <asp:Label ID="JobDate" runat="server" Width="140px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" valign="top">
                                            <asp:Label ID="customerAddress" runat="server" Width="262px"></asp:Label>
                                        </td>
                                       
                                    </tr>
                                   
                                    <tr>
                                        <td colspan="4">
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th valign="top" class="style1" rowspan="4" align="left">
                                            Attention:
                                        </th>
                                        <td valign="top" class="style1" rowspan="4">
                                            <asp:Label ID="dllAttention" runat="server" />
                                        </td>
                                        <th align="left">
                                            Tel No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </th>
                                        <td>
                                            <asp:Label ID="TelNo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="left">
                                            Home Phone No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </th>
                                        <td>
                                            <asp:Label ID="HomePhone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="left">
                                            Fax No:
                                        </th>
                                        <td>
                                            <asp:Label ID="FaxNo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="left">
                                            Country:
                                        </th>
                                        <td>
                                            <asp:Label ID="Country" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="left">
                                            Email Address:
                                        </th>
                                        <td>
                                            <asp:Label ID="Email" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
                            <table  id="tblTestDeatil"
                               runat="server" border="0" cellpadding="0" cellspacing="0"
                                                            width="100%"  class="tablesorter">
                             
                                
                                <thead height=" 40px">
                                                                <tr style="background-color: #E5E8EC; height: 40px; border-color: #E5E8EC; border-left: 1px;
                                                                    border-right: 1px">
                                                                    <td align="center">
                                                                       NO
                                                                    </td>
                                                                    <td align="center">
                                                                         DESCRIPTION
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
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%;">
                    <div class="simplebox">
                        <div class="titleh">
                            <h3>
                                Sampling Information</h3>
                        </div>
                        <div class="body padding10">
                             <span class="st-labeltext">    Point Number:</span>  <asp:Label ID="PointNumber" runat="server"></asp:Label>
                           
                            <br />
                             <br />
                            <p>
                            <asp:Panel ID="SampleBottle" runat="server">
                           <H4> Bottle Details</H4>
                             <table id="SampleBottleDetailTable" runat="server" border="0" cellpadding="0" cellspacing="0"
                                                            width="100%"  class="tablesorter">
                                                            <thead height=" 40px">
                                                                <tr style="background-color: #E5E8EC; height: 40px; border-color: #E5E8EC; border-left: 1px;
                                                                    border-right: 1px">
                                                                    <td align="center">
                                                                        Preservative/Chemical
                                                                    </td>
                                                                    <td align="center">
                                                                        Test Name
                                                                    </td>
                                                                    <td align="center">
                                                                        QTY
                                                                    </td>
                                                                  
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                         </asp:Panel>
                                                         </p>
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
        <%--<tr>
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
                        <th width="20%" align="left">
                            Reward Points 
                        </th>
                        <td width="20%"><asp:Label runat="server" ID="RewardPoints"/></td>
                        <th width="20%" align="left">&nbsp;Reward Points To Use</th>
                        <td width="20%"> 
                            <asp:Label  ID="TextBox1"  runat="server" Text=""></asp:Label>
                            </td>
                           
                        </tr>
                        </table>
                           </div>
                            </div>
                            </div>
                        </td>
                    </tr>--%>
    </table>
</asp:Panel>
<div class="simplebox grid740" style="width: 98%; margin-left: 10px;" runat="server"
    id="DivReject" visible="False">
    <div class="simplebox">
        <div class="titleh">
            <h3>
                Provide Reject Reason
            </h3>
        </div>
        <div class="body padding10">
            <span class="st-labeltext">Reject Reason </span>
            <asp:TextBox ID="ReasonToDelete" runat="server" Height="124px" TextMode="MultiLine"
                Width="358px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                ErrorMessage="*Enter Job Remove Condition" ControlToValidate="ReasonToDelete"
                CssClass="st-form-error"></asp:RequiredFieldValidator>
        </div>
    </div>
</div>
<br />
<asp:Button ID="Button1" runat="server" Text="Back" class="st-button" Width="120px"
    OnClick="Button1_Click" CausesValidation="False" />
<asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click1"
    Text="Print" CssClass="st-button" Width="166px" />
<asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" CssClass="st-button"
    Width="166px" Text="Send Mail" CausesValidation="False" />
<asp:Button ID="btnChangeJobStatus" runat="server" CausesValidation="False" Text="Start Job"
    CssClass="st-button" Width="166px" OnClick="Button3_Click" />
<asp:Button ID="btnRejectJobStatus" runat="server" Text="Reject" CssClass="st-button"
    Width="166px" OnClick="Reject_Click" Visible="False" />
<br />
<br />
<asp:Button ID="exportToExcel" runat="server" OnClick="Button3_Click1" CssClass="st-clear"
    Text="Export Customer Detail to Excel " Visible="False" Width="299px" />
