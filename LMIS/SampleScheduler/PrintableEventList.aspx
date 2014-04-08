<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintableEventList.aspx.cs"
    Inherits="LMIS.SampleScheduler.PrintableEventList"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    table, th, td
        {
        border: 1px solid black;
        margin-left: 15px;
        margin-right: 15px;
        margin-top: 15px;
         font-size : 85%;
        font-family : "Myriad Web",Verdana,Helvetica,Arial,sans-serif;
        }
    th
    {
        height:50px;
        border-color: black;
        background-color: #E5E8EC;;
        }
    td
    {
        padding-left:  15px;
    }
    tr:nth-child(even) {
    background-color: #f3f8f3;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
            <asp:Panel runat="server" ID="pnl1">
    <div>
        <asp:Table ID="JobTable" runat="server" Width="95%" CellPadding="0" CellSpacing="0" border="1" />
    </div>
    </asp:Panel>
    </form>
</body>
</html>
