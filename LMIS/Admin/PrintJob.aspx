<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintJob.aspx.cs" Inherits="LMIS.Admin.PrintJob"
    EnableViewStateMac="false" EnableSessionState="True" EnableEventValidation="false"
    ValidateRequest="false" ViewStateEncryptionMode="Never" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel runat="server" ID="pnl1">
        <div style="width: 98%; margin-right: 1%; margin-bottom: 10px; margin-top: 12px;
            height: 50px; margin-left: 1%; -moz-border-radius: 6px; -webkit-border-radius: 6px;
            border-radius: 6px;">
            <h3 align="left" style="font-family: Gautami; font-size: 20px; font-style: normal;
                color: #006600;">
                Job Information
            </h3>
        </div>
        <div class="body padding10">
            <!-- Simple usage without double class -->
            <div style="width: 98%; margin-right: 1%; margin-bottom: 2px; margin-top: 12px; margin-left: 1%;
                -moz-border-radius: 6px; -webkit-border-radius: 6px; border-radius: 6px; border: 1px solid #dcdcdc;
                -moz-border-radius: 6px; -webkit-border-radius: 6px; border-radius: 6px;">
                <div>
                    <div class="titleh" style="border: 1px solid #F8F8FF; background-color: #F5F5F5;">
                        <h3 style="font-family: 'Estrangelo Edessa'; font-size: large; font-style: normal;
                            text-decoration: underline; left: 10px" align="center">
                            Customer Information</h3>
                    </div>
                    <div class="body padding10">
                        <table>
                            <tr>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Job Number
                                </th>
                                <td colspan="5" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="JobNumber" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th valign="top" class="style1" rowspan="3" align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Customer Name:
                                </th>
                                <td class="style1" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="ClientName" runat="server"></asp:Label>
                                </td>
                                <td class="style2" style="gautami; font-family: 'Book Antiqua';">
                                    &nbsp;
                                </td>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Date:
                                </th>
                                <td colspan="2" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="JobDate" runat="server" Width="140px" />
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2" valign="top" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="customerAddress" runat="server" Width="262px"></asp:Label>
                                </td>
                                <td rowspan="2" style="gautami; font-family: 'Book Antiqua';">
                                    &nbsp;
                                </td>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Validity:
                                </th>
                                <td style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="Validity" runat="server" ViewStateMode="Disabled" />&nbsp;&nbsp;
                                    Days&nbsp;&nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Term of Payment:
                                </th>
                                <td style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="paymentDate" runat="server" />&nbsp;&nbsp; Days&nbsp;&nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="gautami; font-family: 'Book Antiqua';">
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <th valign="top" class="style1" rowspan="4" align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Attention:
                                </th>
                                <td valign="top" class="style1" rowspan="4" colspan="2" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="dllAttention" runat="server" />
                                </td>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Tel No:
                                </th>
                                <td colspan="2" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="TelNo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Home Phone No:
                                </th>
                                <td colspan="2" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="HomePhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Fax No:
                                </th>
                                <td colspan="2" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="FaxNo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" style="gautami; font-family: 'Book Antiqua';">
                                    Email Address:
                                </th>
                                <td colspan="2" style="gautami; font-family: 'Book Antiqua';">
                                    <asp:Label ID="Email" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 100%;">
                <div style="width: 98%; margin-right: 1%; margin-left: 1%; border: 1px solid #dcdcdc;
                    -moz-border-radius: 6px; -webkit-border-radius: 6px; border-radius: 6px;">
                    <div class="titleh" style="border: 1px solid #F8F8FF; background-color: #F5F5F5;">
                        <h3 style="font-family: 'Estrangelo Edessa'; font-size: large; font-style: normal;
                            text-decoration: underline; left: 10px" align="center">
                            Test Details</h3>
                    </div>
                    <br />
                    <div class="body padding10">
                        <br />
                        <table style="border: 1px solid #dcdcdc;" width="100%" cellpadding="0" cellspacing="0"
                            id="tblTestDeatil" runat="server">
                            <thead height=" 40px">
                                <tr style="background-color: gainsboro; border: outset; border-width: 1px">
                                    <th style="width: 5%;">
                                        NO
                                    </th>
                                    <th style="width: 70%;">
                                        DESCRIPTION
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
        <br />
        <br />
    </asp:Panel>
    <div class="button-box">
    </div>
    </form>
</body>
</html>
