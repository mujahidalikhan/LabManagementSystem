<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddEditCustomerTestParameters.aspx.cs" Inherits="LMIS.Admin.AddEditCustomerTestParameters" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="simplebox">
            <div class="titleh">
                <h3>
                    Customer Test Parameters</h3>
            </div>
            <div class="body padding10">
                <table>
                    <tr>
                        <th width="120px" align="left">
                            Industry List:
                        </th>
                        <td>
                            
                                        <asp:DropDownList ID="IndustryList" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="IndustryList_SelectedIndexChanged" 
                                            CssClass="styled-select">
                                            <asp:ListItem Value="0">---</asp:ListItem>
                                        </asp:DropDownList>
                               
                        </td>
                        </tr>
                        <tr>
                            <td colspan="2"> <br /></td>
                        </tr>
                        <tr>
                        <th align="left">
                            Associated Tests: &nbsp;
                        </th>
                        <td>
                            <asp:DropDownList ID="testList" runat="server" 
                                OnSelectedIndexChanged="testList_SelectedIndexChanged" CssClass="styled-select"
                                AutoPostBack="True">
                                <asp:ListItem Value="0">---</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        </tr>
                              <tr>
                            <td colspan="2"> <br /></td>
                        </tr>
                        <tr>
                        <th align="left">
                            Specification Type:
                        </th>
                        <td>
                            <asp:DropDownList ID="spcType" runat="server" CssClass="styled-select">
                                <asp:ListItem Value="0">Default</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <table>
                                <tr>
                                    <td>
                                        <b>StdA</b>
                                        <asp:RadioButton ID="stdA" GroupName="option" runat="server" />
                                    </td>
                                    <td width="25px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b>StdB</b>
                                        <asp:RadioButton ID="stdB" GroupName="option" runat="server" />
                                    </td>
                                    <td width="25px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <b>Default</b>
                                        <asp:RadioButton ID="defaultVal" GroupName="option" runat="server" Checked="True" />
                                    </td>
                                    <td width="25px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="addTestParameters" runat="server" Text="Add Test Parameters" class="st-clear"
                                            Width="153px" CausesValidation="False" OnClick="addTestParameters_Click1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="st-forminput" 
                                Text="*Please select Industry list, Associated List and Specificaton Type" 
                                Visible="False"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
                
                  <div style="margin-bottom: 15px; margin-top: 20px; width: 100%" class="grid740">
                                <div class="simplebox">
                                    <div class="titleh">
                                        <h3>
                                            Test Parameters
                                        </h3>
                                    </div>
                                    <div class="body padding10">
                                        <table border="0" width="98%" cellpadding="0" cellspacing="0" id="TestParametersTable"
                                            runat="server" class="display data-table">
                                            <thead height=" 40px">
                                                <tr>
                                                    <th>
                                                        Industy Name
                                                    </th>
                                                    <th>
                                                        Test Types
                                                    </th>
                                                    <th>
                                                        Std A
                                                    </th>
                                                    <th>
                                                        Std B
                                                    </th>
                                                    <th>
                                                        Default
                                                    </th>
                                                    <th>
                                                        Options
                                                    </th>
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
    
</asp:Content>
