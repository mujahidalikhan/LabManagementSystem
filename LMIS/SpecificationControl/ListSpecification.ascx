<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSpecification.ascx.cs"
    Inherits="LMIS.SpecificationControl.ListSpecification" %>
<div class="simplebox grid740" style="width: 99%;">
    <asp:HiddenField ID="ViewState" Value="" runat="server" />
    <asp:HiddenField ID="SpecID" Value="" runat="server" />
    <div style="z-index: 710;" class="titleh">
        <h3>
            Test Parameters</h3>
    </div>
    <div style="z-index: 690;" class="body">
        <div style="z-index: 680;" class="st-form-line">
            <table width=100%>
                <tr>
                    <td>
                        <span class="st-labeltext">Specification Name:</span>
                    </td>
                    <td colspan=6>
                        <asp:TextBox ID="SpecificationName" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="st-labeltext">Test Parameter:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="testParameterBox" runat="server" Width="265px" CssClass="styled-select">
                            <asp:ListItem>PARAMETERS</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:50px;" align="center">
                      StdA: 
                    </td>
                    <td>
                        <asp:TextBox ID="stdA" runat="server" class="st-forminput" Width="75px"></asp:TextBox>
                    </td>
                     <td style="width:50px;" align="center">
                        StdB:
                    </td>
                    <td>
                        <asp:TextBox ID="stdB" runat="server" class="st-forminput" Width="75px"></asp:TextBox>
                    </td>
                     <td style="width:50px;" align="center">
                        Others:
                    </td>
                    <td>
                        <asp:TextBox ID="others" runat="server" class="st-forminput" Width="75px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" 
                            Text="Specification already exist" Visible="False"></asp:Label>
                    </td>
                    
                    <td>
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
            Specification Detail list</h3>
    </div>
    <!-- Start Data Tables Initialisation code -->
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            oTable = $("#<%= SpecificationListTable.ClientID %>").dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <!-- End Data Tables Initialisation code -->
    <asp:Table ID="SpecificationListTable" runat="server" class="display data-table"
        Width="100%" CellPadding="0" CellSpacing="0" border="0" />
    <br />
    <br />
    <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="st-button"   Width="120px" OnClick="Submit_Click" />
    <%--   <asp:Button ID="btnAddSpecification" runat="server" Text="Add New Job " OnClick="Specification_Click"
        CssClass="st-button" />--%>
</div>
