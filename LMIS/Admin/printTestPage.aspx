<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printTestPage.aspx.cs" Inherits="LMIS.Admin.printTestPage"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="PlaceholderPdf" runat="server"></asp:PlaceHolder>
    <div>
        <table border="1">
            <tr>
                <td colspan="2">
                    aspdotnetcodebook
                </td>
            </tr>
            <tr>
                <td>
                    cell1
                </td>
                <td>
                    cell2
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblLabel" runat="server" Text="Label Test"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>