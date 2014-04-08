<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateJobWizard.aspx.cs" Inherits="LMIS.Admin.CreateJobWizard"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    
    <div>
<asp:MultiView ID="myMV" runat="server" >
<asp:View ID="myView1" runat="server">

 <asp:Label ID="lblShowMessage" runat="server" Text="A Questioner to know about you and your personal intrests:" Font-Bold="true" Font-Names="Verdana" Font-Size="Small"  /> <br /><br />

 <strong><span style="font-size: 9pt; font-family: Verdana">First Name: </span></strong>

 <asp:TextBox ID="txtFirstName" runat="server" /> <br />

 <strong><span style="font-size: 9pt; font-family: Verdana">Last Name: </span></strong>

 <asp:TextBox ID ="txtLastName" runat="server" />

  <strong><span style="font-size: 9pt; font-family: Verdana">Your Age:</span></strong> 
<asp:DropDownList ID="ddlAge" runat="server" Width="102px" >

 <asp:ListItem>10-15</asp:ListItem>

 <asp:ListItem>16-20</asp:ListItem>

 <asp:ListItem>21-25</asp:ListItem>

 <asp:ListItem>26-30</asp:ListItem>       

</asp:DropDownList><br />
<asp:Button ID="cmdNext" Width="50"  runat="server" Text=">" />
</asp:View>
<asp:View ID="myView2" runat="server">

 <strong><span style="font-size: 9pt; font-family: Verdana">What kind of games you like:</span></strong><br />

 <asp:RadioButton ID="rbQ1" Text="OutDoor"  GroupName="gnQV1" runat="server" />

 <asp:RadioButton ID="rbQ11" Text="InDoor"   GroupName="gnQV1" runat="server" /><br />

 <strong><span style="font-size: 9pt; font-family: Verdana">Where you want spend time more:</span></strong><br />

 <asp:RadioButton ID="rbQ2" Text="In Home" GroupName="gnQV2" runat="server" />

 <asp:RadioButton ID="rbQ22" Text="With Friends"  GroupName="gnQV2" runat="server" /><br />

 <asp:Button ID="cmdPrev1" Width="50"  runat="server" Text="<"  /> 

 <asp:Button ID="cmdNext1" Width="50"  runat="server" Text=">"  />

</asp:View>
<asp:View ID="myView3" runat="server"   >

 <strong><span style="font-size: 9pt; font-family: Verdana">Are you currently Employed:</span></strong><br />

 <asp:RadioButton ID="rbQ3" Text="Yes" GroupName="gnQV4" runat="server" />

 <asp:RadioButton ID="rbQ33" Text="No"  GroupName="gnQV4" runat="server" /><br />   

 <strong><span style="font-size: 9pt; font-family: Verdana">What is your marital Status:</span></strong><br />

 <asp:RadioButton ID="rbQ4" Text="Single"  GroupName="gnQV3" runat="server" />

 <asp:RadioButton ID="rbQ44" Text="Married"   GroupName="gnQV3" runat="server" /><br />

 <asp:Button ID="cmdPrev" Width="50"  runat="server" Text="<"  />

 <asp:Button ID="cmdFinish" runat="server" Text="Finish" />
</asp:View>            
</asp:MultiView> <br /><hr />
<asp:Label ID="lblValues" Visible="false" runat="server" /></div>
 </asp:Content>

