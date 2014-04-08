<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEventControl.ascx.cs" Inherits="LMIS.SampleScheduler.AddEventControl"  %>
 <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Add Event</h3>
        </div>
        <div style="z-index: 690;" class="body">
            <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
                <asp:Panel ID="pnl1" runat="server">
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

            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Sample/Bottle Title: </span>
                <asp:TextBox class="st-forminput" ID="EventTitle"  value="" type="text"
                    runat="server" Width="335px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" 
                    runat="server" ControlToValidate="EventTitle" CssClass="st-form-error" 
                    ErrorMessage="*Please enter sample title"></asp:RequiredFieldValidator>
            </div>
                 <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Sample Count</span>
                <asp:TextBox class="st-forminput" ID="SampleCount"  value="" type="text"
                    runat="server" Width="335px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="SampleCount" CssClass="st-form-error" 
                    ErrorMessage="*Please enter sample count"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Start Date: </span>
                <script type="text/javascript">
                    $(function () {
                        $("#<%= datepicker.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                    });
                </script>
                <input type="text" id="datepicker" class="datepicker-input" style="width: 180px;"
                    runat="server" />
                 
                    <select id="startHr" name="startHr" class="styled-selectSmall "
                        runat="server">
                        <option value="00">00</option>
                        <option value="01">01</option>
                        <option value="02">02</option>
                        <option value="03">03</option>
                        <option value="04">04</option>
                        <option value="05">05</option>
                        <option value="06">06</option>
                        <option value="07">07</option>
                        <option value="08">08</option>
                        <option value="09">09</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                        <option value="13">13</option>
                        <option value="14">14</option>
                        <option value="15">15</option>
                        <option value="16">16</option>
                        <option value="17">17</option>
                        <option value="18">18</option>
                        <option value="19">19</option>
                        <option value="20">20</option>
                        <option value="21">22</option>
                        <option value="23">23</option>
                    </select>:<select id="StartMin" runat="server" class="styled-selectSmall ">
                        <option value="00">00</option>
                        <option value="15">15</option>
                        <option value="30">30</option>
                        <option value="45">45</option>
                    </select>
                <!-- end default date picker -->
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName0" 
                    runat="server" ControlToValidate="datepicker" CssClass="st-form-error" 
                    ErrorMessage="*Please enter start date"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">End Date: </span>
                <script type="text/javascript">
                    $(function () {
                        $("#<%= EndDate.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                    });
                </script>
                <input type="text" id="EndDate" class="datepicker-input" style="width: 180px;" runat="server" />
                <select id="EndHr" name="EndHr" runat="server" class="styled-selectSmall ">
                    <option value="00">00</option>
                    <option value="01">01</option>
                    <option value="02">02</option>
                    <option value="03">03</option>
                    <option value="04">04</option>
                    <option value="05">05</option>
                    <option value="06">06</option>
                    <option value="07">07</option>
                    <option value="08">08</option>
                    <option value="09">09</option>
                    <option value="10">10</option>
                    <option value="11">11</option>
                    <option value="12">12</option>
                    <option value="13">13</option>
                    <option value="14">14</option>
                    <option value="15">15</option>
                    <option value="16">16</option>
                    <option value="17">17</option>
                    <option value="18">18</option>
                    <option value="19">19</option>
                    <option value="20">20</option>
                    <option value="21">22</option>
                    <option value="23">23</option>
                </select>:<select id="EndMin" runat="server" class="styled-selectSmall ">
                    <option value="00">00</option>
                    <option value="15">15</option>
                    <option value="30">30</option>
                    <option value="45">45</option>
                </select><!-- end default date picker -->
                <asp:Label ID="lblDateError" runat="server" CssClass="st-form-error" 
                    Text="*End Date Must be grater then start date" Visible="False"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName1" 
                    runat="server" ControlToValidate="EndDate" CssClass="st-form-error" 
                    ErrorMessage="*Please enter end date"></asp:RequiredFieldValidator>
            </div>
            
              <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">All Day Event:: </span>
                 
                <asp:DropDownList  ID="isAllDayEvent" class="styled-selectSmall"
                    runat="server" >
                    <asp:ListItem Value="false">No</asp:ListItem>
                    <asp:ListItem Value="true">Yes</asp:ListItem>
                </asp:DropDownList>
                
               
            </div>

            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Select Job:</span>
               
                    <asp:DropDownList ID="JobList" runat="server" 
                    OnSelectedIndexChanged="JobList_SelectedIndexChanged"  class="styled-select"
                        AutoPostBack="True" >
                        <asp:ListItem Value="0">---</asp:ListItem>
                </asp:DropDownList>
                </div>
           
        
                            <br />

<div id="Div1" align="center">
                <table width="75%" align="center">
                    <tr>
                        <th width="45%">
                            Sample Bottle
                        </th>
                        <th width=" 10%">
                            &nbsp;
                        </th>
                        <th widht="45%">
                            Selected Sample Bottle
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ListBox ID="SampleBottle" runat="server" Style="width: 100%; height: 150px;"
                                SelectionMode="Multiple"></asp:ListBox>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="BtnShiftSampleBottleToSelectedBottle" runat="server" 
                                Height="18px" ImageUrl="../images/icons/button/arrow-right.png"
                                Width="18px" CausesValidation="False" OnClick="BtnShiftSampleBottleToSelectedBottle_Click"
                                BorderStyle="None" />
                            <br />
                            <br />
                            <br />
                            <asp:ImageButton ID="BtnShiftSelectedBottleToSampleBottle" runat="server" 
                                Height="18px" ImageUrl="../images/icons/button/arrow-left.png"
                                Width="18px" CausesValidation="False" OnClick="BtnShiftSelectedBottleToSampleBottle_Click"
                                BorderStyle="None" />
                        </td>
                        <td align="center">
                            <asp:ListBox ID="SelectedSampleBottle" runat="server" Style="width: 100%; height: 150px"
                                SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </div>
            <br />

          
            <div id="SystemUserRightsDiv" align="center">
                <table width="75%" align="center">
                    <tr>
                        <th width="45%">
                            Available Sampler
                        </th>
                        <th width=" 10%">
                            &nbsp;
                        </th>
                        <th widht="45%">
                            Assigned Sampler
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ListBox ID="ListAvailableRights" runat="server" Style="width: 100%; height: 150px;"
                                SelectionMode="Multiple"></asp:ListBox>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="BtnShiftAvailableToAssigned" runat="server" Height="18px" ImageUrl="../images/icons/button/arrow-right.png"
                                Width="18px" CausesValidation="False" OnClick="BtnShiftAvailableToAssigned_Click"
                                BorderStyle="None" />
                            <br />
                            <br />
                            <br />
                            <asp:ImageButton ID="BtnShiftAssignedToAvailable" runat="server" Height="18px" ImageUrl="../images/icons/button/arrow-left.png"
                                Width="18px" CausesValidation="False" OnClick="BtnShiftAssignedToAvailable_Click"
                                BorderStyle="None" />
                        </td>
                        <td align="center">
                            <asp:ListBox ID="ListAssignedRights" runat="server" Style="width: 100%; height: 150px"
                                SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
             </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                
                <div style="z-index: 680;" class="st-form-line">
            <script type="text/javascript">
                function colorChanged(sender) {
                    sender.get_element().style.color = "#" + sender.get_selectedColor();
                }
                function button2_onclick() {

                }

            </script>
            <ajaxToolkit:ColorPickerExtender runat="server" ID="ColorPickerExtender1" TargetControlID="Color1" OnClientColorSelectionChanged="colorChanged" />
              <div style="z-index: 680;" class="st-form-line">
            <span class="st-labeltext">Select Color:   </span>
            <asp:TextBox ID="Color1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Select Color"
                ControlToValidate="Color1" CssClass="st-form-error"></asp:RequiredFieldValidator>
    </div>

            <div style="z-index: 460;" class="button-box">
                <asp:Button name="AddEvent" ID="AddEvent" class="st-button" type="Add Event" runat="server"
                    Text="Add Event" OnClick="AddEvent_Click" Width="130px" />
                <input name="button" id="button2" value="Reset" class="st-clear" type="reset" style="width: 130px;">
                <br />
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Text="*Unknown error occur while adding Event"
                    Visible="False" CssClass="st-form-error"></asp:Label>
            </div>
             </div>
             </div>
             </div>
             

       

