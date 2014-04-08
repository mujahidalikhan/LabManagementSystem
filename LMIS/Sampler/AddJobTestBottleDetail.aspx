<%@ Page Title="" Language="C#" MasterPageFile="~/Sampler/Sampler.Master" AutoEventWireup="true" CodeBehind="AddJobTestBottleDetail.aspx.cs" Inherits="LMIS.Sampler.AddJobTestBottleDetail"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Add Job Test Bottle Information</h3>
        </div>
        <div style="z-index: 690;" class="body">
        <div ID="DivJobTestBottleDetail" runat="server" >
            <br />
                                <table style="margin-left:  20px;">
                                    <tr>
                                        <td  align="left">
                                            Select Bottle:
                                        </td>
                                        <td colspan="3">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="SampleBottle" runat="server" Width="250px" />
                                        </td>
                                        </tr >
                                        
                                         <tr>
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>

                                        <tr>
                                        
                                        <td colspan="4" >
                                           <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Test Description </span>
               
                <asp:DropDownList  ID="JobTestDescription"  class="styled-select"
                    runat="server" OnSelectedIndexChanged="JobTestDescription_SelectedIndexChanged"
                    AutoPostBack="True" >
                    <asp:ListItem Value="0">---</asp:ListItem>
                </asp:DropDownList>
                  
                <br />
                  
                <br />
              
                <span class="st-labeltext">Description Detail :</span>
                <textarea id="TestDetail" class="st-forminput" style="width: 331px; height: 56px;" 
                    runat="server"></textarea>
                <br />
                <br />
                 <span class="st-labeltext">Group Test(s):</span>
               
                <asp:DropDownList  ID="JobTestParameters"  class="styled-select" 
                    runat="server" AutoPostBack="True"
                    onselectedindexchanged="JobTestParameters_SelectedIndexChanged" >
                    <asp:ListItem Value="0">---</asp:ListItem>
                </asp:DropDownList>
                  
                                               <br />
                    
                                               <br />

<span class="st-labeltext">Test Parameter(s):</span>
               
                <asp:DropDownList  ID="TestParameter"  class="styled-select" 
                    runat="server" AutoPostBack="True"
                    onselectedindexchanged="JobTestParameters_SelectedIndexChanged" >
                    <asp:ListItem Value="0">---</asp:ListItem>
                </asp:DropDownList>                                               <br />
            </div>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Bottle Count:
                                        </td>
                                        <td colspan="2">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="JobDetailBottleCount" runat="server" Width="235px"></asp:TextBox>
                                        </td>
                                        <td >
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                CssClass="st-form-error" ErrorMessage="*Please enter Bottle Count" 
                                                ControlToValidate="JobDetailBottleCount" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                                class="st-form-error" ControlToValidate="JobDetailBottleCount" 
                                                Display="Dynamic" ErrorMessage="*Enter only integer" 
                                                ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td colspan="2">
                                    <br />
                                    </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Button ID="btnSkipAddingBottle" runat="server" 
                                                OnClick="btnSkipAddingBottle_Click" Text="Add Bottle" CssClass="st-clear"
                                                CausesValidation="False" Width="156px" />
                                            &nbsp;
                                            </td>
                                    </tr>
                                     <tr>
                                    <td colspan="2">
                                    <br />
                                    </td>
                                    </tr>
                                </table>
                            </div>
                            </div>
                            </div>
</asp:Content>
