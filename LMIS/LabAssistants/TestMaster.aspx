<%@ Page Title="" Language="C#" MasterPageFile="~/LabAssistants/LabAssistants.Master" AutoEventWireup="true" CodeBehind="TestMaster.aspx.cs" Inherits="LMIS.LabAssistants.TestMaster"  EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    

    <style type="text/css">
        .style1
        {
            height: 34px;
            
        }
        .style2
        {
            height: 34px;
            width: 133px;
        }
        

        .CalendarCSS  
        {  
            background-color:white;;  
            color:black;  
            }  
 
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="grid740">
                        	<div class="simplebox">
                            	<div class="titleh"><h3>Create Test Master</h3></div>
                                <div class="body padding10">
   
	<table border="0" cellpadding="0" cellspacing="0"  id="id-form">
		<tr>
			<th valign="top" class="style1">Customer Name:</th>
			<td class="style1">
			   <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="Server" />
               <ajaxtoolkit:autocompleteextender 
               runat="server" 
               ID="autoComplete1" 
               TargetControlID="ClientName"
               ServiceMethod="GetCompletionList"
               ServicePath="ClientName.asmx"
               MinimumPrefixLength="2" 
               CompletionInterval="100">
                   
               </ajaxtoolkit:autocompleteextender>
                <asp:TextBox AutoPostBack ="true" ID="ClientName" runat="server" 
                    class="st-forminput" 
                    Width="202px" ontextchanged="ClientName_TextChanged"></asp:TextBox>
            </td>
			<td class="style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientName" runat="server" 
                    ErrorMessage="enter client name" ControlToValidate="ClientName"></asp:RequiredFieldValidator>
            </td>
	
			<th valign="top" class="style1">Lab Number:</th>
			<td class="style1">
                <asp:TextBox ID="labNumber" runat="server" class="st-forminput" 
                    Width="202px"></asp:TextBox>
            </td>
			<td class="style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="enter lab number" ControlToValidate="ClientName"></asp:RequiredFieldValidator>
            </td>
		</tr>
        	<tr>
			<th valign="top" class="style1">Attention:</th>
			<td class="style1">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" CssClass="styled-select"
               
                >
                </asp:DropDownList>
            </td>
			<td class="style2">
                &nbsp;</td>
		
			<th valign="top" class="style1">Industry Type:</th>
			<td class="style1">
                <asp:DropDownList AutoPostBack = "true" ID="industryType" runat="server" Width="200px" CssClass="styled-select"
                    onselectedindexchanged="industryType_SelectedIndexChanged" Enabled="False" 
             
                >
                </asp:DropDownList>
            </td>
			<td class="style2">
                &nbsp;</td>
		</tr>
        	<tr>
			<th valign="top" class="style1">Sample Information:</th>
			<td class="style1">
                <asp:TextBox ID="sampleInformation" runat="server"  class="st-forminput" 
                    Width="202px" Enabled="False"></asp:TextBox>
            </td>
			<td class="style2">
                &nbsp;</td>
		
			<th valign="top" class="style1">Sample Packing:</th>
			<td class="style1">
                 <asp:DropDownList ID="samplePacking" runat="server" Width="200px" CssClass="styled-select"
                DataSourceID="SqlDataSource2" 
                     DataTextField="PackingName" DataValueField="PackingInfoId" Enabled="False"
                >
                </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                     SelectCommand="SELECT [PackingName], [PackingInfoId] FROM [PackingInfo]">
                 </asp:SqlDataSource>
            </td>
			<td class="style2">
                &nbsp;</td>
		</tr>
        	<tr>
			<th valign="top" class="style1">Sample Description:</th>
			<td class="style1">
                <asp:TextBox ID="sampleDescription" runat="server" class="st-forminput" 
                    Width="202px" Enabled="False"></asp:TextBox>
            </td>
			<td class="style2">
                &nbsp;</td>
           
			<th valign="top" class="style1">
                <p class="MsoNormal">
                    Assign:</p>
                </th>
			<td class="style1">
                <asp:DropDownList ID="assignToUser" runat="server" Width="200px" CssClass="styled-select"
             
                >
                </asp:DropDownList>
            </td>

		</tr>
                	<tr>
			<th valign="top" class="style1">Sample Recieved On:</th>
			
            
            
            	<td colspan="2">
		
        <asp:Label runat="server" ID="sampleRecieveDate"></asp:Label>
			
            <th valign="top" class="style1">
                <p class="MsoNormal">
                    Specification Type:</p>
                </th>
			<td class="style1">
                <asp:DropDownList ID="spcType" runat="server" Width="200px" CssClass="styled-select" Enabled="False">
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
			<th valign="top" class="style1">Type of Sampling:</th>
			<td class="style1">
                <asp:TextBox ID="sampleType" runat="server" class="st-forminput" 
                    Width="202px" Enabled="False"></asp:TextBox>
            </td>
			<td class="style2">
                &nbsp;</td>
              <th>
                            Associated Tests: &nbsp;
                        </th>
                        <td>
                            <asp:DropDownList ID="testList" runat="server" Width="200px" CssClass="styled-select"
                                onselectedindexchanged="testList_SelectedIndexChanged"  
                                AutoPostBack="True" Enabled="False" >
                            </asp:DropDownList>
                        </td>
		</tr>
        
                	<tr>
			<th valign="top" class="style1">Analysis Condition:</th>
			<td class="style1" colspan="4">
                <asp:TextBox ID="analysisCondition" Rows="3" runat="server" 
                    Height="97px" 
                    Width="380px" TextMode="MultiLine" ></asp:TextBox>
                    
              
                    
                    

            &nbsp;</td>
			<td class="style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ErrorMessage="enter analysis condition" ControlToValidate="ClientName"></asp:RequiredFieldValidator>
            </td>
		</tr>
        <tr>
            <td></td>
            <td>
                 <table>  	
	<tr>
		<th>
		    <asp:Button ID="Button1" runat="server"  Text ="Submit"  
                class="st-button" Width="120px" onclick="Button1_Click" 
                 />
			
			</th>
		<td valign="top">
			
			<asp:Button ID="Reset_Button" runat="server" Text="Reset"  class="form-reset" 
                Width="120px" CssClass="st-clear" onclick="Reset_Button_Click" 
                CausesValidation="False" />
		</td>
		<td class="style3"></td>
	</tr>
	</table>

        



            

            </div>
            </div>
            </div>
         
        

</asp:Content>
