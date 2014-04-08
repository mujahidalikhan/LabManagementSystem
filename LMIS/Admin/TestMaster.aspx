<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="TestMaster.aspx.cs" Inherits="LMIS.Admin.TestMaster" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<%@ Register Src="TimePicker.ascx" TagName="TimePicker" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 119px;
        }
        .style3
        {
            width: 123px;
        }
        .style4
        {
            width: 157px;
        }
        .style5
        {
            width: 69px;
        }
        .style6
        {
            width: 130px;
        }
        .style7
        {
            width: 126px;
        }
        .style8
        {
            width: 121px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="simplebox">
        <div class="titleh">
            <h3>
                Create Test Master</h3>
        </div>
        <div class="body padding10">
            <table border="0" cellpadding="0" cellspacing="0" id="id-form">
                <tr>
                    <th valign="top" class="style4">
                        Customer Name:
                    </th>
                    <td class="style5">
                        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
                        <ajaxToolkit:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="ClientName"
                            ServiceMethod="GetCompletionList" ServicePath="ClientName.asmx" MinimumPrefixLength="2"
                            CompletionInterval="100">
                        </ajaxToolkit:AutoCompleteExtender>
                        <asp:TextBox AutoPostBack="true" ID="ClientName" runat="server" class="st-forminput"
                            Width="202px" OnTextChanged="ClientName_TextChanged"></asp:TextBox>
                    </td>
                    <td class="style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server"
                            ErrorMessage="enter client name" ControlToValidate="ClientName"></asp:RequiredFieldValidator>
                    </td>
                    <th valign="top" class="style7">
                        Lab Number:
                    </th>
                    <td class="style1">
                        <asp:TextBox ID="labNumber" runat="server" class="st-forminput" Width="202px"></asp:TextBox>
                    </td>
                    <td class="style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter lab number"
                            ControlToValidate="ClientName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th valign="top" class="style4">
                        Attention:
                    </th>
                    <td class="style5">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="217px">
                        </asp:DropDownList>
                    </td>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <td class="style8">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <th valign="top" class="style4">
                        Sample Information:
                    </th>
                    <td class="style5">
                        <asp:TextBox ID="sampleInformation" runat="server" class="st-forminput" Width="202px"
                            Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <th valign="top" class="style7">
                        Sample Packing:
                    </th>
                    <td class="style1">
                        <asp:DropDownList ID="samplePacking" runat="server" Width="217px" DataSourceID="SqlDataSource2"
                            DataTextField="PackingName" DataValueField="PackingInfoId" Enabled="False">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand="SELECT [PackingName], [PackingInfoId] FROM [PackingInfo]"></asp:SqlDataSource>
                    </td>
                    <td class="style8">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <th valign="top" class="style4">
                        Sample Description:
                    </th>
                    <td class="style5">
                        <asp:TextBox ID="sampleDescription" runat="server" class="st-forminput" Width="202px"
                            Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <th valign="top" class="style7">
                        <p class="MsoNormal">
                            Assign:</p>
                    </th>
                    <td class="style1">
                        <asp:DropDownList ID="assignToUser" runat="server" Width="217px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th valign="top" class="style4">
                        Sample Recieved On:
                    </th>
                    <td class="style5" >
                        <asp:Label runat="server" ID="sampleRecieveDate"></asp:Label>
                    </td>
                     <td class="style6">
                        &nbsp;
                    </td>
                    <th valign="top" class="style7">
                        <p class="MsoNormal">
                            Specification Type:</p>
                    </th>
                    <td class="style1">
                        <asp:DropDownList ID="spcType" runat="server" Width="217px" Enabled="False">
                            <asp:ListItem Value="0">Default</asp:ListItem>
                            <asp:ListItem Value="1">Specification 1</asp:ListItem>
                            <asp:ListItem Value="2">Specification 2</asp:ListItem>
                            <asp:ListItem Value="3">Specification 3</asp:ListItem>
                            <asp:ListItem Value="4">Specification 4</asp:ListItem>
                            <asp:ListItem Value="5">Specification 5</asp:ListItem>
                            <asp:ListItem Value="6">Specification 6</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th valign="top" class="style4">
                        Type of Sampling:
                    </th>
                    <td class="style5">
                        <asp:TextBox ID="sampleType" runat="server" class="st-forminput" Width="202px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <th class="style7">
                        Associated Tests: &nbsp;
                    </th>
                    <td>
                        <asp:DropDownList ID="testList" runat="server" Width="217px" OnSelectedIndexChanged="testList_SelectedIndexChanged"
                            AutoPostBack="True" Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th valign="top" class="style4">
                        Analysis Condition:
                    </th>
                    <td class="style1" colspan="4">
                        <asp:TextBox ID="analysisCondition" Rows="3" runat="server" Height="97px" Width="380px"
                            TextMode="MultiLine"></asp:TextBox>
                        &nbsp;
                    </td>
                    <td class="style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="enter analysis condition"
                            ControlToValidate="ClientName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                    </td>
                    <td class="style5">
                        <table>
                            <tr>
                                <th>
                                    <asp:Button ID="Button1" runat="server" Text="Submit" class="st-button" Width="120px"
                                        OnClick="Button1_Click" />
                                </th>
                                <td valign="top">
                                    <asp:Button ID="Reset_Button" runat="server" Text="Reset" class="form-reset" Width="120px"
                                        CssClass="st-clear" OnClick="Reset_Button_Click" CausesValidation="False" />
                                </td>
                                <td class="style3">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
