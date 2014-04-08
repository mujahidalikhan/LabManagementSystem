<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true"
    CodeBehind="AddJob.aspx.cs" Inherits="LMIS.Sampler.AddEditJob"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:MultiView ID="myMV" runat="server">
        <div class="body padding10">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" id="id-form">
                <tr>
                    <td>
                        <asp:View ID="myView1" runat="server">
                            
                            <div class="simplebox grid740" style="width: 99%;" runat="server" id="DivReject"
                                visible="False">
                                <br />
                                <div style="z-index: 710;" class="titleh">
                                    <h3>
                                        Job is rejected by manager
                                    </h3>
                                </div>
                                <div style="z-index: 690;" class="body">
                                    <br />
                                    <span class="st-labeltext">Reason of Reject</span><asp:TextBox ID="ReasonToDelete"
                                        runat="server" Height="97px" TextMode="MultiLine" Width="525px" CssClass="st-error-input"
                                        Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="simplebox grid740" style="width: 99%;">
                                <div style="z-index: 710;" class="titleh">
                                    <h3>
                                        Customer Information</h3>
                                </div>
                                <div style="z-index: 690;" class="body">
                                    <div style="z-index: 680;" class="st-form-line">
                                        <span class="st-labeltext">Job Number</span>
                                        <asp:TextBox ID="JobNumber" runat="server" Width="257px" CssClass="st-forminput  st-disable"
                                            Enabled="False"></asp:TextBox>
                                    </div>
                                    <div style="z-index: 680;" class="st-form-line">
                                        <span class="st-labeltext">Customer Name:</span>
                                      <%--  <ajaxToolkit:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="ClientName"
                                            ServiceMethod="GetCompletionList" ServicePath="ClientName.asmx" MinimumPrefixLength="2"
                                            CompletionInterval="100">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <asp:TextBox AutoPostBack="true" ID="ClientName" runat="server" class="st-forminput"
                                            Width="256px" OnTextChanged="ClientName_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                                            class="st-form-error" ErrorMessage="*Enter client name" ControlToValidate="ClientName"></asp:RequiredFieldValidator>--%>
                                            <asp:DropDownList ID="ClientName" runat="server" class="styled-selectSmall" Width="288px"
                                            AutoPostBack="True"
                                            Height="30px" onselectedindexchanged="ClientName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="customerDetails" runat="server" visible="False">
                                        <div style="z-index: 680;" class="st-form-line">
                                            <span class="st-labeltext">Address:</span>
                                            <asp:TextBox ID="customerAddress" runat="server" Height="95px" TextMode="MultiLine"
                                                Width="424px"></asp:TextBox>
                                        </div>
                                        <div style="z-index: 680;" class="st-form-line">
                                            <span class="st-labeltext">Attention:</span>
                                            <asp:DropDownList ID="ddlAttention" runat="server" Height="30px" Width="288px" OnSelectedIndexChanged="ddlAttention_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                        <div style="z-index: 680;" class="st-form-line">
                                            <span class="st-labeltext">Tel No:</span>
                                            <asp:Label ID="TelNo" runat="server" Width="250px"></asp:Label>
                                            <span>Home Phone No:</span>
                                            <asp:Label ID="HomePhone" runat="server" Width="250px"></asp:Label>
                                        </div>
                                        <div style="z-index: 680;" class="st-form-line">
                                            <span class="st-labeltext">Fax No:</span>
                                            <asp:Label ID="FaxNo" runat="server" Width="250px" />
                                            <span>Email Address:&nbsp;&nbsp; </span>&nbsp;<asp:Label ID="Email" runat="server"
                                                Width="250px" />
                                        </div>
                                        <div style="z-index: 680;" class="st-form-line">
                                            <span class="st-labeltext">Country</span>
                                            <asp:Label ID="Country" runat="server" Width="250px" />
                                        </div>
                                    </div>
                                     <div style="z-index: 680;" class="st-form-line">
                                        <span class="st-labeltext">Date Recived </span>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#<%= JobDate.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                                            });
                                        </script>
                                        <asp:TextBox ID="JobDate" runat="server" class="datepicker-input" Width="140px"></asp:TextBox>
                                    </div>
                                     <div style="z-index: 680;" class="st-form-line">
                                        <span class="st-labeltext">Req. Letter Date</span>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#<%= ReqLetterDate.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                                            });
                                        </script>
                                        <asp:TextBox ID="ReqLetterDate" runat="server" class="datepicker-input" Width="140px"></asp:TextBox>
                                    </div>
                                    <asp:HiddenField ID="JobId" runat="server" Value="-1" />
                                    <div style="z-index: 460;" class="button-box">
                                        <asp:Button ID="btnJobInformation" runat="server" Width="200px" Text="Add Job Information"
                                            OnClick="btnJobInformation_Click" CssClass="st-clear" />
                                        <asp:Button ID="addTestDetail" runat="server" Text="Add Test Information" OnClick="addTestDetail_Click"
                                            CausesValidation="False" Width="200px" Visible="False" CssClass="st-clear" />
                                    </div>
                                </div>
                            </div>
                            
                        </asp:View>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:View ID="View2" runat="server">
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
                            <div id="QuotatonTestDetail" runat="server">
                                <div style="z-index: 690; width: 90%" class="st-tinytitle">
                                    <h3>
                                        SAMPLE POINTS DETAILS</h3>
                                    <span class="st-labeltext">POINTS </span>
                                    <asp:DropDownList ID="JobRewardPoint" runat="server" AutoPostBack="True" OnSelectedIndexChanged="JobRewardPoint_SelectedIndexChanged"
                                        Width="216px">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="URGENT" runat="server" Text="URGENT" />
                                </div>
                                <div style="z-index: 690; width: 90%" class="st-tinytitle">
                                    <h3>
                                        SPECIFICATION DETAILS</h3>
                                    <span class="st-labeltext">SPECIFICATION</span>
                                    <asp:DropDownList ID="industryType" runat="server" AutoPostBack="true" Height="32px"
                                        OnSelectedIndexChanged="industryType_SelectedIndexChanged" Width="218px">
                                    </asp:DropDownList>
                                     <div style="z-index: 670;" class="clear"></div>
                                    <span class="st-labeltext">STANDARD</span><table>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="STANDARD" 
                                                    Text="STD A" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="STANDARD" 
                                                    Text="STD B" />
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="STANDARD" 
                                                    Text="OTHERS" />
                                            </td>
                                        </tr>
                                    </table>
                                   
                                </div>
                                
                                 <div style="z-index: 670;" class="clear"></div>
                                <div style="z-index: 690; width: 90%" class="st-tinytitle">
                                    <h3>
                                        TEST PARAMETER DETAILS</h3>
                                    <span class="st-labeltext">TEST TYPES</span> <div style="z-index: 670;" class="clear"></div>
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:CheckBox ID="AllTest" runat="server" AutoPostBack="True" Checked="False" 
                                        OnCheckedChanged="AllTest_CheckedChanged" Text="SELECT ALL" />
                                    &nbsp; &nbsp;<asp:CheckBox ID="uncheckAll" runat="server" AutoPostBack="True" 
                                        Checked="False" OnCheckedChanged="AllTest0_CheckedChanged" 
                                        Text="UNSELECT ALL" />
                                        
                                         <div style="z-index: 670;" class="clear">
                                             <br />
                                             <br />
                                    </div>
                                         <div class="simplebox grid740" 
                                        style="z-index: 720; margin-left: 20px; width: 323px; height: 150px; margin-top: -30px">
                                             <div class="body" 
                                                 style="z-index: 690; height: 150px; overflow: auto; overflow-x: hidden; -ms-overflow-x: hidden;">
                                                 <asp:CheckBoxList ID="check1" runat="server" AutoPostBack="True" 
                                                     OnSelectedIndexChanged="check1_SelectedIndexChanged" TextAlign="Right">
                                                 </asp:CheckBoxList>
                                             </div>
                                    </div>
                                    <div class="clear" style="z-index: 670;">
                                    </div>
                                   </div>
                               
                                <div id="DivJobTestBottleDetail" runat="server" visible="True">
                                    
                                     <div style="z-index: 690; width: 90%" class="st-tinytitle">
                                    <h3>
                                        SAMPLE BOTTLE</h3>

                                    <span class="st-labeltext">Select Bottle:</span>
                                    <asp:DropDownList ID="SampleBottle" runat="server" Width="250px" />
                                    <div style="z-index: 670;" class="clear">
                                    </div>
                                       <br>
                                        <span class="st-labeltext"> Select Test:  </span>
                                        
                                            <asp:DropDownList ID="JobDetailSelectedTestList" runat="server" Width="250px" />
                                      <div style="z-index: 670;" class="clear">
                                    </div>
                                    <span class="st-labeltext">Bottle Count:</span>
                                    <asp:TextBox ID="JobDetailBottleCount" runat="server" Width="235px"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="st-form-error"
                                        ErrorMessage="*Please enter Bottle Count" ControlToValidate="JobDetailBottleCount"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" class="st-form-error"
                                        ControlToValidate="JobDetailBottleCount" Display="Dynamic" ErrorMessage="*Enter only integer"
                                        ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                    <div style="z-index: 670;" class="clear">
                                    </div>
                                    <asp:Button ID="btnAddBottleCount" runat="server" CssClass="st-clear" OnClick="btnAddBottleCount_Click"
                                        Text="Add Sample Bottle" />
                                </div>
                                       <div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%;">
                                <div class="simplebox">
                                    <div class="titleh">
                                        <h3>
                                            Sample Bottle Detail
                                        </h3>
                                    </div>
                                    <div class="body padding10">
                                        <table id="SampleBottleDetailTable" runat="server" border="0" cellpadding="0" cellspacing="0"
                                            width="100%">
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
                                                    <td style="width: 11%;" align="center">
                                                        Options
                                                    </td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                                </div>
                                </div>
                                <br />
                                <br />
                                <asp:Button ID="JobInfo" runat="server" CausesValidation="False" CssClass="st-clear"
                                    OnClick="JobInfo_Click" Text="Edit Job Information" Width="180px" />
                                <asp:Button ID="PaymentInfo" runat="server" CausesValidation="False" CssClass="st-clear"
                                    OnClick="PaymentInfo_Click" Text="Add Payment Information" Width="178px" Visible="False" />
                                <asp:Button ID="FinlizeJob" runat="server" Text="Finlize Job" class="st-button" OnClick="FinlizeJob_Click"
                                    Width="178px" />
                             </ContentTemplate>
                                </asp:UpdatePanel>
                           
                        </asp:View>
                    </td>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                        </td>
                    </tr>
                </tr>
            </table>
        </div>
    </asp:MultiView>
</asp:Content>
