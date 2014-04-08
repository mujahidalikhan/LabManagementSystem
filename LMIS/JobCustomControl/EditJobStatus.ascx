<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditJobStatus.ascx.cs" Inherits="LMIS.JobCustomControl.EditJobStatus"  %>

    
 <div style="margin-left: 5%; margin-right: 5%; margin-bottom: 15px; margin-top: 20px;
        width: 90%" class="grid740">
        <div class="simplebox">
            <div class="titleh">
                <h3>
                    Job Information
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </h3>
            </div>
            <div class="body padding10">
                  <asp:Panel ID="pnl1" runat="server">
                <table border="0" cellpadding="0" cellspacing="0" width = "100%" id="id-form">
                    
                    <tr>
                    <td>
                    
                      <!-- Simple usage without double class -->
                         <div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%;">
                        	<div class="simplebox">
                            	<div class="titleh"><h3>Customer Information</h3></div>
                                <div class="body padding10">
                             <table>       

                               
                    <tr>
                        <th align="left">
                            Job Number
                        </th>
                        <td colspan="5">
                            <asp:Label ID="JobNumber" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th valign="top" class="style1" rowspan="3" align="left">
                            Customer Name:
                        </th>
                        <td class="style1">
                            
                            <asp:Label ID="ClientName" runat="server" ></asp:Label>
                        </td>
                        <td class="style2" >
                            &nbsp;
                        </td>
                        <th align="left">
                            Date:
                        </th>
                        <td colspan="2">
                           
                            <asp:Label ID="JobDate" runat="server" Width="140px"/>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2" valign="top">
                            <asp:Label ID="customerAddress" runat="server" 
                                Width="262px"></asp:Label>
                        </td>
                        <td rowspan="2">
                            &nbsp;
                        </td>
                        <th align="left">
                            Validity:
                        </th>
                        <td>
                            <asp:Label ID="Validity" runat="server"  ViewStateMode="Disabled" />&nbsp;&nbsp;
                            Days&nbsp;&nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="left">
                            Term of Payment:
                        </th>
                        <td>
                            <asp:Label ID="paymentDate" runat="server"/>&nbsp;&nbsp;
                            Days&nbsp;&nbsp;
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
                        <th valign="top" class="style1" rowspan="3" align="left">
                            Attention:
                        </th>
                        <td valign="top" class="style1" rowspan="3" colspan="2">
                            <asp:Label ID ="dllAttention" runat="server"/>
                           
                        </td>
                        <th align="left">
                            Tel No:
                        </th>
                        <td colspan="2">
                            <asp:Label ID="TelNo" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="left">
                            Fax No:
                        </th>
                        <td colspan="2">
                            <asp:Label ID="FaxNo" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="left">
                            Email Address:
                        </th>
                        <td colspan="2">
                            <asp:Label ID="Email" runat="server" ></asp:Label>
                        </td>
                    </tr>
                   
                         </table>
                     </div>
                            </div>
                        </div>
                        </td>
                        </tr>
               
               
         
                    
                           <tr>
                        <td >
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
                                    
                                    <th style="width: 5%;" >
                                       NO
                                    </th>
                                    <th style="width: 60%;">
                                       DESCRIPTION
                                    </th>
                                    <th align="center" valign="top" width="5%" >
                                       UNIT PRICE(RM)
                                    </th>
                                    <th valign="top" align="center" width="15%">
                                        QTY
                                    </th>
                                    <th valign="top" align="center" width="5%">
                                        AMOUNT (RM)</th>
                                        

                                  <th valign="top" align="center" width="10%">
                                        Options</th>
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
                        <td >
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
                        <table width="650px">
                        <tr>
                        <th class="style5">
                            Reward Points 
                        </th>
                        <td><asp:Label runat="server" ID="RewardPoints"/></td>
                       
                         <th  style="width: 250px">&nbsp;Reward Points To Use</th>
                        <td > 
                            <asp:Label ID="TextBox1" runat="server" Enabled="False" Width="197px" Text="0"></asp:Label> 
                           
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
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div style="text-align: center;">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="ResultsUpdatePanel"
                                    DynamicLayout="true">
                                    <ProgressTemplate>
                                        
                                        <img src="../images/loading/6.gif" alt="icon" style="margin-right: 15px;" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            
                           </ContentTemplate>
                           </asp:UpdatePanel>
                          
                    </tr>
                </table>
                  </asp:Panel >
                 
                          
                                        <asp:Button ID="Button1" runat="server" Text="Back" class="st-button" 
                                            Width="120px" onclick="Button1_Click" />
                                                                                <asp:Button  ID="Button2" runat="server" 
                CausesValidation="False" onclick="Button2_Click1" Text="Print" 
                                        CssClass="st-button" Width="166px"/>
                                        
                                        
                                        <asp:Button  ID="Button3" runat="server" 
                CausesValidation="False"  Text="Update Job "
                                        CssClass="st-button" Width="166px" onclick="Button3_Click"/>
                                        
                                        
                                  

            </div>
        </div>
    </div>

