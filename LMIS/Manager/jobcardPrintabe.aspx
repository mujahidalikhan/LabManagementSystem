<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jobcardPrintabe.aspx.cs"
    Inherits="LMIS.LabAssistants.jobcardPrintabe"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>

<?xml version="1.0" encoding="utf-8" ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/2002/REC-xhtml1-20020801/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        td
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
        }
        .font8
        {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
        }
        .font7
        {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
        }
        .font6
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
        }
        .font5
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
        }
        .style2
        {
            width: 336pt;
            color: windowtext;
            font-size: 19.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: "Times New Roman" , serif;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style4
        {
            height: 16.5pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style5
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style6
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: right;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style7
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: right;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style8
        {
            height: 5.25pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style9
        {
            height: 16.5pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style10
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style11
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style13
        {
            height: 6.0pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style14
        {
            height: 15.0pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style15
        {
            height: 16.5pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style16
        {
            width: 151pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style17
        {
            height: 14.25pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style18
        {
            height: 12.75pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style19
        {
            width: 11pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style20
        {
            width: 181pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style21
        {
            height: 12.75pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style22
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: right;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style34
        {
            height: 10.5pt;
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style35
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style36
        {
            height: 13.5pt;
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style38
        {
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style40
        {
            height: 23pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style41
        {
            width: 476pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            height: 23pt;
        }
        .style42
        {
            height: 22pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style43
        {
            width: 476pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            height: 22pt;
        }
        .style44
        {
            height: 20pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style45
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style46
        {
            height: 18.0pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style47
        {
            height: 12.75pt;
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style49
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            width: 181pt;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style50
        {
            width: 181pt;
        }
        .style54
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            width: 181pt;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style55
        {
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Arial Narrow" , sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            height: 20pt;
        }
        .style56
        {
            width: 11pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            height: 20pt;
        }
        .style57
        {
            width: 181pt;
            color: windowtext;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            height: 20pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="pnl1" runat="server">
        <br />
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
            width: 925pt" width="1230">
            <colgroup>
                <col width="150" />
                <col width="146" />
                <col width="86" />
                <col width="105" />
                <col width="87" />
                <col width="63" />
                <col width="126" />
                <col width="121" />
                <col width="144" />
                <col width="138" />
                <col width="64" />
            </colgroup>
            <tr height="31">
                <td class="xl67" width="86" colspan="9" align="center">
                    <h1>
                        <b>COA Reporter</b></h1>
                </td>
            </tr>
            <tr height="18">
                <td class="xl67" height="18">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl77">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="19">
                <td class="xl67">
                    Lab Number
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="LabNumber" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    Date
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="Date" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="18">
                <td class="xl67">
                    Work ID
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="WorkID" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    Customer ID
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="CustomerID" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    Company Name
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="CompanyName" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    Address 1
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="Address1" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    Instrument
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="Instrument" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    City
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="City" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    Postcode
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="Postcode" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    Signature 1
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="Signature1" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
            </tr>
            <tr height="17">
                <td class="xl67" height="17">
                    State
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="State" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67" height="17">
                    Report To
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="ReportTo" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67" height="17">
                    Specification ID
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="SpecificationID" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    Specification Description
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="SpecificationDescription" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    COD Spec
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="CODSpec" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl86" height="17">
                    Sample Description
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="SampleDescription" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
                <td class="xl67">
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    Number of Sample
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="NumberofSample" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    Sample Packing
                </td>
                <td class="xl67">
                </td>
                <td class="xl67">
                    Sampling Done By
                </td>
                <td class="xl67">
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
            </tr>
            <tr height="17">
                <td class="xl67">
                    Sample Received Date
                </td>
                <td class="xl67">
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="SampleReceivedDate" runat="server"></asp:Label>
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="SamplePacking" runat="server"></asp:Label>
                </td>
                <td class="xl67" colspan="2">
                    <asp:Label ID="SampleDoneBy" runat="server"></asp:Label>
                </td>
                <td class="xl67">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div class="body padding10">
            <br />
            <table border="1" width="100%" id="TestDetailTable" runat="server">
                <thead>
                    <tr style="background-color: #acc7ce; border-width: 1; border-color: black">
                        <th>
                            Test Code
                        </th>
                        <th>
                            Parameters
                        </th>
                        <th>
                            Result
                        </th>
                        <th>
                            Spec/Limit
                        </th>
                        <th>
                            Unit
                        </th>
                        <th>
                            MDL
                        </th>
                        <th>
                            Decimal Point
                        </th>
                        <th>
                            Equipment
                        </th>
                        <th>
                            Method
                        </th>
                        <th>
                            Status
                        </th>
                    </tr>
                </thead>
                <tbody style="border-width: 1; border-color: black">
                </tbody>
            </table>
        </div>
      
    </asp:Panel>
    </form>
</body>
</html>
