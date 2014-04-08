<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true"
    CodeBehind="TestMaster.aspx.cs" Inherits="LMIS.Sampler.TestMaster" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<%@ Register TagPrefix="uc1" TagName="TimePicker" Src="~/Admin/TimePicker.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox grid740" style="width: 99%;">
        <div class="simplebox">
            <div class="titleh">
                <h3>
                    Add Sample Information Test Master</h3>
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
                               <span class="st-labeltext">   Attention:</span>
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
               
                            <span class="st-labeltext">Sample Information:</span>
                       
                            <asp:TextBox ID="sampleInformation" runat="server" class="st-forminput" Width="333px"></asp:TextBox>
                       
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Sample Informaiton "
                                ControlToValidate="sampleInformation" CssClass="st-form-error"></asp:RequiredFieldValidator>
                       </div>
                          <div style="z-index: 680;" class="st-form-line">
                   
                            <span class="st-labeltext">Sample Description:</span>
                     
                      
                            <asp:TextBox ID="sampleDescription" runat="server" Width="333px" TextMode="MultiLine"
                                Height="53px"></asp:TextBox>
                     
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter Sample Description"
                                ControlToValidate="sampleDescription" CssClass="st-form-error"></asp:RequiredFieldValidator>
                        </div>
                          <div style="z-index: 680;" class="st-form-line">
                   
                            <span class="st-labeltext">Sample Recieved On:</span>
                        
                            <table>
                                <tr>
                                    <td>
                                        <span class="st-labeltext">Selectd Date:</span>
                                    </td>
                                    <td >
                                        <!-- start default date picker -->
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#<%= datepicker.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                                            });
                                        </script>
                                        <input type="text" id="datepicker" class="datepicker-input" style="width: 220px;"
                                            runat="server" /><!-- end default date picker -->
                                    </td>
                                    <td colspan="2">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter sample date"
                                            ControlToValidate="datepicker" CssClass="st-form-error"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <span class="st-labeltext">Selectd Time:</span>
                                    </td>
                                    <td >
                                        &nbsp;&nbsp;
                                        <uc1:TimePicker ID="timeInStart" runat="server" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                          <div style="z-index: 680;" class="st-form-line">
                   
                            <span class="st-labeltext">Type of Sampling:</span>
                      
                            <asp:TextBox ID="sampleType" runat="server" class="st-forminput" Width="333px"></asp:TextBox>
                       
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter sampling type "
                                ControlToValidate="sampleType" CssClass="st-form-error"></asp:RequiredFieldValidator>
                          </div>
                          <div style="z-index: 680;" class="st-form-line">
                   
                            <span class="st-labeltext">Tracking Point:<br />
                              </span>&nbsp;<asp:TextBox ID="TrackingPoint" runat="server" class="st-forminput" Width="333px" Height="60px" 
                                  TextMode="MultiLine"></asp:TextBox>
                    
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter sampling tracking Point"
                                ControlToValidate="TrackingPoint" CssClass="st-form-error"></asp:RequiredFieldValidator>
                         </div>
                          <div style="z-index: 680;" class="st-form-line">
                   
                            <span class="st-labeltext">Sampe Count:</span>
                       
                            <asp:TextBox ID="SampleCount" runat="server" class="st-forminput" Width="333px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter sample count"
                                ControlToValidate="SampleCount" CssClass="st-form-error"></asp:RequiredFieldValidator>
                         </div>
                          <div style="z-index: 680;" class="st-form-line">
                   
                            <span class="st-labeltext">Sample Packing:</span>
                       
                   
                            <asp:DropDownList ID="samplePacking" runat="server" DataSourceID="SqlDataSource2"
                                DataTextField="PackingName" DataValueField="PackingInfoId" CssClass="styled-select">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                SelectCommand="SELECT [PackingName], [PackingInfoId] FROM [PackingInfo]"></asp:SqlDataSource>
                          </div>
                              <div style="z-index: 460;" class="button-box">
                   
                            <asp:Button ID="Button1" runat="server" Text="Save Sample Information" class="st-button"
                                Width="175px" OnClick="Button1_Click" />
                      
                            <asp:Button ID="Reset_Button" runat="server" Text="Reset" Width="175px" CssClass="st-clear"
                                OnClick="Reset_Button_Click" CausesValidation="False" />
                      </div>
            </div>
        </div>
    </div>
</asp:Content>
