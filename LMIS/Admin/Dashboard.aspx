<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="LMIS.Admin.Dashboard" EnableViewStateMac="false"
    EnableSessionState="True" EnableEventValidation="false" ValidateRequest="false"
    ViewStateEncryptionMode="Never" %>

<%@ Import Namespace="LMIS" %>
<%@ Import Namespace="LMIS.DBController" %>
<%@ Import Namespace="LMIS.DBModel" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <asp:Timer ID="Timer1" runat="server" Interval="300000">
        </asp:Timer>
        <asp:Timer ID="Timer2" runat="server" Interval="300000" OnTick="Timer2_Tick">
        </asp:Timer>
    </div>
    <table style="margin-left: -1%; width: 100%;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div style="margin-top: 15px; margin-right: 32px; width: 465px; height: 325px" class="simplebox grid450-left">
                            <!-- start statistics codes -->
                            <div class="simplebox">
                                <div class="titleh">
                                    <h3>
                                        WorkSheet</h3>
                                </div>
                                 <div style="z-index: 680;" class="st-form-line">
                                    <span class="st-labeltext">Select Month</span>
                                    <asp:DropDownList ID="DropDownListMonth1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListMonth1_SelectedIndexChanged"
                                        Width="186px">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="body">
                                    <ul class="statistics">
                                        <li>
                                            <asp:HyperLink ID="TodayNewJobsWM" runat="server">Today New Jobs</asp:HyperLink>
                                            <p>
                                                <span class="blue"><b>
                                                    <asp:Label ID="lblTodayNewJobsWM" runat="server" /></b> </span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsAwaitingStartWM" runat="server">Jobs Awaiting Start</asp:HyperLink>
                                            <p>
                                                <span class="red"><b>
                                                    <asp:Label ID="lblJobsAwaitingStartWM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsProcessedLastWeekWM" runat="server">Jobs Processed Last Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobsProcessedLastWeekWM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsApprovedThisWeekWM" runat="server">Jobs Approved This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobsApprovedThisWeekWM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsEmailSendThisWeekWM" runat="server">Jobs Email Send This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobsEmailSendThisWeekWM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCompleteThisWeekWM" runat="server">Job Complete This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobCompleteThisWeekWM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <!-- end statistics codes -->
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div style="margin-top: 15px; margin-right: 32px; width: 465px; height: 325px" class="simplebox grid450-left">
                            <div class="simplebox">
                                <div class="titleh">
                                    <h3>
                                        JobSheet</h3>
                                </div>
                                <div style="z-index: 680;" class="st-form-line">
                                    <span class="st-labeltext">Select Month</span>
                                    <asp:DropDownList ID="DropDownListMonth2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListMonth2_SelectedIndexChanged"
                                        Width="186px">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="body">
                                    <ul class="statistics">
                                        <li>
                                            <asp:HyperLink ID="JobCardCreatedThisWeekJM" runat="server">Job Card Created This Week</asp:HyperLink>
                                            <p>
                                                <span class="blue"><b>
                                                    <asp:Label ID="lblJobCardCreatedThisWeekJM" runat="server" /></b> </span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardAwatingSamplingJM" runat="server">Job Card Awating Sampling</asp:HyperLink>
                                            <p>
                                                <span class="red"><b>
                                                    <asp:Label ID="lblJobCardAwatingSamplingJM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardActiveJM" runat="server">Job Card Active</asp:HyperLink>
                                            <p>
                                                <span class="red"><b>
                                                    <asp:Label ID="lblJobCardActiveJM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardCompleteThisWeekJM" runat="server">Job Card Complete This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobCardCompleteThisWeekJM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="SampleCollectThisWeekJM" runat="server">Sample Collect This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblSampleCollectThisWeekJM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardCompleteLastWeekJM" runat="server">Job Card Complete Last Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobCardCompleteLastWeekJM" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div style="margin-top: 15px; margin-right: 32px; width: 465px; height: 325px" class="simplebox grid450-left">
                            <!-- start statistics codes -->
                            <div class="simplebox">
                                <div class="titleh">
                                    <h3>
                                        WorkSheet</h3>
                                </div>
                                 <div style="z-index: 680;" class="st-form-line">
                                    <span class="st-labeltext">Select Year</span>
                                    <asp:DropDownList ID="DropDownListYear1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListYear1_SelectedIndexChanged"
                                        Width="186px">
                                        <asp:ListItem>2010</asp:ListItem>
                                        <asp:ListItem>2011</asp:ListItem>
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                        <asp:ListItem>2021</asp:ListItem>
                                        <asp:ListItem>2022</asp:ListItem>
                                        <asp:ListItem>2023</asp:ListItem>
                                        <asp:ListItem>2024</asp:ListItem>
                                        <asp:ListItem>2025</asp:ListItem>
                                        <asp:ListItem>2026</asp:ListItem>
                                        <asp:ListItem>2027</asp:ListItem>
                                        <asp:ListItem>2028</asp:ListItem>
                                        <asp:ListItem>2029</asp:ListItem>
                                        <asp:ListItem>2030</asp:ListItem>
                                        <asp:ListItem>2031</asp:ListItem>
                                        <asp:ListItem>2032</asp:ListItem>
                                        <asp:ListItem>2033</asp:ListItem>
                                        <asp:ListItem>2034</asp:ListItem>
                                        <asp:ListItem>2035</asp:ListItem>
                                        <asp:ListItem>2036</asp:ListItem>
                                        <asp:ListItem>2037</asp:ListItem>
                                        <asp:ListItem>2038</asp:ListItem>
                                        <asp:ListItem>2039</asp:ListItem>
                                        <asp:ListItem>2040</asp:ListItem>
                                        <asp:ListItem>2041</asp:ListItem>
                                        <asp:ListItem>2042</asp:ListItem>
                                        <asp:ListItem>2043</asp:ListItem>
                                        <asp:ListItem>2044</asp:ListItem>
                                        <asp:ListItem>2045</asp:ListItem>
                                        <asp:ListItem>2046</asp:ListItem>
                                        <asp:ListItem>2047</asp:ListItem>
                                        <asp:ListItem>2048</asp:ListItem>
                                        <asp:ListItem>2050</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="body">
                                    <ul class="statistics">
                                        <li>
                                            <asp:HyperLink ID="TodayNewJobsWY" runat="server">Today New Jobs</asp:HyperLink>
                                            <p>
                                                <span class="blue"><b>
                                                    <asp:Label ID="lblTodayNewJobsWY" runat="server" /></b> </span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsAwaitingStartWY" runat="server">Jobs Awaiting Start</asp:HyperLink>
                                            <p>
                                                <span class="red"><b>
                                                    <asp:Label ID="lblJobsAwaitingStartWY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsProcessedLastWeekWY" runat="server">Jobs Processed Last Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobsProcessedLastWeekWY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsApprovedThisWeekWY" runat="server">Jobs Approved This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobsApprovedThisWeekWY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobsEmailSendThisWeekWY" runat="server">Jobs Email Send This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobsEmailSendThisWeekWY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCompleteThisWeekWY" runat="server">Job Complete This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobCompleteThisWeekWY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <!-- end statistics codes -->
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div style="margin-top: 15px; margin-right: 32px; width: 465px; height: 325px" class="simplebox grid450-left">
                            <div class="simplebox">
                                <div class="titleh">
                                    <h3>
                                        JobSheet</h3>
                                </div>
                                <div style="z-index: 680;" class="st-form-line">
                                    <span class="st-labeltext">Select Year</span>
                                    <asp:DropDownList ID="DropDownListYear2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListYear2_SelectedIndexChanged"
                                        Width="186px">
                                        <asp:ListItem>2010</asp:ListItem>
                                        <asp:ListItem>2011</asp:ListItem>
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                        <asp:ListItem>2021</asp:ListItem>
                                        <asp:ListItem>2022</asp:ListItem>
                                        <asp:ListItem>2023</asp:ListItem>
                                        <asp:ListItem>2024</asp:ListItem>
                                        <asp:ListItem>2025</asp:ListItem>
                                        <asp:ListItem>2026</asp:ListItem>
                                        <asp:ListItem>2027</asp:ListItem>
                                        <asp:ListItem>2028</asp:ListItem>
                                        <asp:ListItem>2029</asp:ListItem>
                                        <asp:ListItem>2030</asp:ListItem>
                                        <asp:ListItem>2031</asp:ListItem>
                                        <asp:ListItem>2032</asp:ListItem>
                                        <asp:ListItem>2033</asp:ListItem>
                                        <asp:ListItem>2034</asp:ListItem>
                                        <asp:ListItem>2035</asp:ListItem>
                                        <asp:ListItem>2036</asp:ListItem>
                                        <asp:ListItem>2037</asp:ListItem>
                                        <asp:ListItem>2038</asp:ListItem>
                                        <asp:ListItem>2039</asp:ListItem>
                                        <asp:ListItem>2040</asp:ListItem>
                                        <asp:ListItem>2041</asp:ListItem>
                                        <asp:ListItem>2042</asp:ListItem>
                                        <asp:ListItem>2043</asp:ListItem>
                                        <asp:ListItem>2044</asp:ListItem>
                                        <asp:ListItem>2045</asp:ListItem>
                                        <asp:ListItem>2046</asp:ListItem>
                                        <asp:ListItem>2047</asp:ListItem>
                                        <asp:ListItem>2048</asp:ListItem>
                                        <asp:ListItem>2050</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="body">
                                    <ul class="statistics">
                                        <li>
                                            <asp:HyperLink ID="JobCardCreatedThisWeekJY" runat="server">Job Card Created This Week</asp:HyperLink>
                                            <p>
                                                <span class="blue"><b>
                                                    <asp:Label ID="lblJobCardCreatedThisWeekJY" runat="server" /></b> </span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardAwatingSamplingJY" runat="server">Job Card Awating Sampling</asp:HyperLink>
                                            <p>
                                                <span class="red"><b>
                                                    <asp:Label ID="lblJobCardAwatingSamplingJY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardActiveJY" runat="server">Job Card Active</asp:HyperLink>
                                            <p>
                                                <span class="red"><b>
                                                    <asp:Label ID="lblJobCardActiveJY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardCompleteThisWeekJY" runat="server">Job Card Complete This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobCardCompleteThisWeekJY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="SampleCollectThisWeekJY" runat="server">Sample Collect This Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblSampleCollectThisWeekJY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="JobCardCompleteLastWeekJY" runat="server">Job Card Complete Last Week</asp:HyperLink>
                                            <p>
                                                <span class="green"><b>
                                                    <asp:Label ID="lblJobCardCompleteLastWeekJY" runat="server" />
                                                </b></span>
                                            </p>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div style="margin-top: 15px; margin-right: 5px; width: 465px;" class="simplebox grid450-left">
                            <div class="titleh">
                                <h3>
                                    Jobs Created in Last 7 Days
                                </h3>
                            </div>
                            <div class="body padding10">
                                <div style="z-index: 680;" class="st-form-line">
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td>
                                                <span>Select Month</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListMonth" runat="server" Width="70px">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <span>Select Year</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListYear" runat="server" Width="70px">
                                                    <asp:ListItem>2010</asp:ListItem>
                                                    <asp:ListItem>2011</asp:ListItem>
                                                    <asp:ListItem>2012</asp:ListItem>
                                                    <asp:ListItem>2013</asp:ListItem>
                                                    <asp:ListItem>2014</asp:ListItem>
                                                    <asp:ListItem>2015</asp:ListItem>
                                                    <asp:ListItem>2016</asp:ListItem>
                                                    <asp:ListItem>2017</asp:ListItem>
                                                    <asp:ListItem>2018</asp:ListItem>
                                                    <asp:ListItem>2019</asp:ListItem>
                                                    <asp:ListItem>2020</asp:ListItem>
                                                    <asp:ListItem>2021</asp:ListItem>
                                                    <asp:ListItem>2022</asp:ListItem>
                                                    <asp:ListItem>2023</asp:ListItem>
                                                    <asp:ListItem>2024</asp:ListItem>
                                                    <asp:ListItem>2025</asp:ListItem>
                                                    <asp:ListItem>2026</asp:ListItem>
                                                    <asp:ListItem>2027</asp:ListItem>
                                                    <asp:ListItem>2028</asp:ListItem>
                                                    <asp:ListItem>2029</asp:ListItem>
                                                    <asp:ListItem>2030</asp:ListItem>
                                                    <asp:ListItem>2031</asp:ListItem>
                                                    <asp:ListItem>2032</asp:ListItem>
                                                    <asp:ListItem>2033</asp:ListItem>
                                                    <asp:ListItem>2034</asp:ListItem>
                                                    <asp:ListItem>2035</asp:ListItem>
                                                    <asp:ListItem>2036</asp:ListItem>
                                                    <asp:ListItem>2037</asp:ListItem>
                                                    <asp:ListItem>2038</asp:ListItem>
                                                    <asp:ListItem>2039</asp:ListItem>
                                                    <asp:ListItem>2040</asp:ListItem>
                                                    <asp:ListItem>2041</asp:ListItem>
                                                    <asp:ListItem>2042</asp:ListItem>
                                                    <asp:ListItem>2043</asp:ListItem>
                                                    <asp:ListItem>2044</asp:ListItem>
                                                    <asp:ListItem>2045</asp:ListItem>
                                                    <asp:ListItem>2046</asp:ListItem>
                                                    <asp:ListItem>2047</asp:ListItem>
                                                    <asp:ListItem>2048</asp:ListItem>
                                                    <asp:ListItem>2050</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button class="button" ID="GO" runat="server" Text="GO" OnClick="GO_Click" CssClass="button"
                                                    EnableTheming="True" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:Chart ID="Chart1" runat="server" Height="275px" Width="450px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                                    ImageType="Png" BackColor="#D3DFF0" BorderDashStyle="Solid" Palette="BrightPastel"
                                    BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
                                    <Legends>
                                        <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                                            Font="Trebuchet MS, 8.25pt, style=Bold">
                                        </asp:Legend>
                                    </Legends>
                                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                    <Series>
                                        <asp:Series Name="Series1" ChartType="Area" BorderColor="180, 26, 59, 105" LabelFormat="C"
                                            YValueType="Int32">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                            BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                            <Area3DStyle Rotation="10" Perspective="10" LightStyle="Realistic" Inclination="15"
                                                IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
                                            <AxisY LineColor="64, 64, 64, 64">
                                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisY>
                                            <AxisX LineColor="64, 64, 64, 64">
                                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisX>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div style="margin-top: 15px; margin-right: 5px; width: 465px;" class="simplebox grid450-left">
                            <div class="titleh">
                                <h3>
                                    Jobs Start in Last 7 Days</h3>
                            </div>
                            <div class="body padding10">
                                <div style="z-index: 680;" class="st-form-line">
                                    <span class="st-labeltext">Select Year</span>
                                    <asp:DropDownList ID="Yearly" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Yearly_SelectedIndexChanged"
                                        Width="186px">
                                        <asp:ListItem>2010</asp:ListItem>
                                        <asp:ListItem>2011</asp:ListItem>
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                        <asp:ListItem>2021</asp:ListItem>
                                        <asp:ListItem>2022</asp:ListItem>
                                        <asp:ListItem>2023</asp:ListItem>
                                        <asp:ListItem>2024</asp:ListItem>
                                        <asp:ListItem>2025</asp:ListItem>
                                        <asp:ListItem>2026</asp:ListItem>
                                        <asp:ListItem>2027</asp:ListItem>
                                        <asp:ListItem>2028</asp:ListItem>
                                        <asp:ListItem>2029</asp:ListItem>
                                        <asp:ListItem>2030</asp:ListItem>
                                        <asp:ListItem>2031</asp:ListItem>
                                        <asp:ListItem>2032</asp:ListItem>
                                        <asp:ListItem>2033</asp:ListItem>
                                        <asp:ListItem>2034</asp:ListItem>
                                        <asp:ListItem>2035</asp:ListItem>
                                        <asp:ListItem>2036</asp:ListItem>
                                        <asp:ListItem>2037</asp:ListItem>
                                        <asp:ListItem>2038</asp:ListItem>
                                        <asp:ListItem>2039</asp:ListItem>
                                        <asp:ListItem>2040</asp:ListItem>
                                        <asp:ListItem>2041</asp:ListItem>
                                        <asp:ListItem>2042</asp:ListItem>
                                        <asp:ListItem>2043</asp:ListItem>
                                        <asp:ListItem>2044</asp:ListItem>
                                        <asp:ListItem>2045</asp:ListItem>
                                        <asp:ListItem>2046</asp:ListItem>
                                        <asp:ListItem>2047</asp:ListItem>
                                        <asp:ListItem>2048</asp:ListItem>
                                        <asp:ListItem>2050</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:Chart ID="Chart3" runat="server" Height="275px" Width="450px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                                    ImageType="Png" BackColor="#D3DFF0" BorderDashStyle="Solid" Palette="BrightPastel"
                                    BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
                                    <Legends>
                                        <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                                            Font="Trebuchet MS, 8.25pt, style=Bold">
                                        </asp:Legend>
                                    </Legends>
                                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                    <Series>
                                        <asp:Series Name="Series1" ChartType="StackedArea" BorderColor="180, 26, 59, 105"
                                            LabelFormat="C">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                            BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                            <Area3DStyle Rotation="10" Perspective="10" LightStyle="Realistic" Inclination="15"
                                                IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
                                            <AxisY LineColor="64, 64, 64, 64">
                                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisY>
                                            <AxisX LineColor="64, 64, 64, 64">
                                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisX>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
