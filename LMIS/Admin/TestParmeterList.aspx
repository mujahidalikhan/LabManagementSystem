<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="TestParmeterList.aspx.cs" Inherits="LMIS.Admin.TestParmeterList" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:hiddenfield id="ViewState" value="" runat="server"/>
<asp:hiddenfield id="ParamID" value="" runat="server"/>
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Test Parameters</h3>
        </div>
        <div style="z-index: 690;" class="body">
            <div style="z-index: 680;" class="st-form-line">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <span class="st-labeltext">Accredited Parameter:</span>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="AccreditedTestParameter" runat="server" class="st-forminput" Width="100px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <span class="st-labeltext">Test Method:</span>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="TestMethod" runat="server" class="st-forminput" Width="100px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <span class="st-labeltext">Short Term:</span>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="ShortTerm" runat="server" class="st-forminput" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span class="st-labeltext">Test Equipment:</span>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="Equipment" runat="server" class="st-forminput" Width="100px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <span class="st-labeltext">MDL:</span>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="MDL" runat="server" class="st-forminput" Width="100px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <span class="st-labeltext">Unit:</span>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="Unit" runat="server" class="st-forminput" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="5">
                            
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                            
                        </td>
                        
                        <td align="center">
                            <asp:Button ID="Add" runat="server" Text=" Add" CssClass="st-button " Width="120px"
                                OnClick="Add_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 460;" class="titleh">
            <h3>
                System Test Parameter List</h3>
        </div>
        <!-- Start Data Tables Initialisation code -->
        <script type="text/javascript" charset="utf-8">
            $(document).ready(function () {
                oTable = $("#<%= TestParmeterTable.ClientID %>").dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <!-- End Data Tables Initialisation code -->
        <asp:Table ID="TestParmeterTable" runat="server" class="display data-table" Width="100%"
            CellPadding="0" CellSpacing="0" border="0" />
    </div>
</asp:Content>
