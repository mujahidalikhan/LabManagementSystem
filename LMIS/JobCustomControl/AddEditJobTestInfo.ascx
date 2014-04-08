<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditJobTestInfo.ascx.cs"
    Inherits="LMIS.JobCustomControl.AddEditJobTestInfo" %>
<!-- Simple usage without double class -->
<div class="grid740" style="width: 98%; margin-right: 1%; margin-left: 1%; margin-top: 15px;">
    <div class="simplebox">
        <div class="titleh">
            <h3>
                Test Details</h3>
        </div>
        <div class="body padding10">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="PanalDiscription">
                            <table width="100%">
                                <tr style="border-bottom: outset; border-bottom-color: gainsboro; border-bottom-width: 1px;">
                                    <th>
                                        Description:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="discription" runat="server" Height="52px" Width="262px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" class="st-form-error"
                                            ErrorMessage="*Please enter discription" ControlToValidate="discription"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3" align="right">
                                        <asp:Label ID="descError" runat="server" class="st-form-error" Text="*Please enter discription"
                                            Visible="False"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnAddDesc" runat="server" Text="Add Item" class="form-reset" Width="120px"
                                            CssClass="st-clear" CausesValidation="False" OnClick="Button2_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="PanelTest">
                            <table width="100%">
                                <tr>
                                    <td colspan="6">
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <th valign="top" class="style1">
                                        Industry Type:
                                    </th>
                                    <td valign="top">
                                        <asp:DropDownList AutoPostBack="true" ID="industryType" runat="server" Height="32px"
                                            Width="277px" OnSelectedIndexChanged="industryType_SelectedIndexChanged" class="uniform">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <th valign="top" class="style1">
                                        Associated Tests:
                                    </th>
                                    <td class="style7">
                                        <asp:ListBox ID="testList" runat="server" SelectionMode="Multiple" Width="307px">
                                        </asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Sample Per week:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="samplePerWeek" runat="server" CssClass="st-forminput" 
                                            ViewStateMode="Disabled" Width="101px" />&nbsp;<asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator3" runat="server" class="st-form-error" 
                                            ControlToValidate="samplePerWeek" Display="Dynamic" 
                                            ErrorMessage="*Please enter only integer" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <th>
                                        Sample QTY
                                    </th>
                                    <td>
                                        <asp:TextBox ID="sampleQty" runat="server" CssClass="st-forminput" ViewStateMode="Disabled" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                            class="st-form-error" ControlToValidate="sampleQty" Display="Dynamic" 
                                            ErrorMessage="*Please enter only integer" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <th>
                                        Unit Price
                                    </th>
                                    <td>
                                        <asp:TextBox ID="unitPrice" runat="server" CssClass="st-forminput" 
                                            ViewStateMode="Disabled" Width="101px" />&nbsp;&nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                            class="st-form-error" ControlToValidate="unitPrice" Display="Dynamic" 
                                            ErrorMessage="*Please enter valid price" 
                                            ValidationExpression="^\d+(\.\d{1,6})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="3" align="right">
                                        <asp:Label ID="testError" runat="server" class="st-form-error" Text="*Please provide required information"
                                            Visible="False"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnAddTest" runat="server" Text="Add Test" class="form-reset" Width="120px"
                                            CssClass="st-clear" CausesValidation="False" OnClick="btnAddTest_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
