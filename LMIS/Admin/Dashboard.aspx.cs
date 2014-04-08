using System;
using System.Web.UI.DataVisualization.Charting;

namespace LMIS.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    return;
                }
                DrawCreateJobChart();
                DrawPaidJobAmountChart();
                LoadStats();
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadStats()
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                MonthlyWorkSheet(dateTime);
                MonthlyJobSheet(dateTime);
                YearlyWorkSheet(dateTime);
                YearlyJobSheet(dateTime);
            }
            catch (Exception ex)
            {

            }
        }

        private void MonthlyJobSheet(DateTime dateTime)
        {
            JobCardCreatedThisWeekJM.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateCreated={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobCardAwatingSamplingJM.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?StatusAwaiting=Inactive");
            JobCardActiveJM.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?StatusActive=Active");
            JobCardCompleteThisWeekJM.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateCardComplete={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            SampleCollectThisWeekJM.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateCollect={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobCardCompleteLastWeekJM.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateLastComplete={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);

            lblJobCardCreatedThisWeekJM.Text = Global.ObjDashboardController.getActiveTestInfoByDate(dateTime).ToString();
            lblJobCardAwatingSamplingJM.Text = Global.ObjDashboardController.getJobCardCountByStatus("Inactive").ToString();
            lblJobCardActiveJM.Text = Global.ObjDashboardController.getJobCardCountByStatus("Active").ToString();
            lblJobCardCompleteThisWeekJM.Text = Global.ObjDashboardController.getJobCardCompleteInSevenDays(dateTime).ToString();
            lblSampleCollectThisWeekJM.Text = Global.ObjDashboardController.getSampleCollectOfWeek(dateTime).ToString();
            lblJobCardCompleteLastWeekJM.Text = Global.ObjDashboardController.getJobCardCompleteLastSevenDays(dateTime).ToString();
        }

        private void MonthlyWorkSheet(DateTime dateTime)
        {
            TodayNewJobsWM.NavigateUrl = String.Format("~/Admin/JobList.aspx?Date={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobsAwaitingStartWM.NavigateUrl = String.Format("~/Admin/JobList.aspx?Status=Awaiting Start");
            JobsProcessedLastWeekWM.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateProcess={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobsApprovedThisWeekWM.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateApproved={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobsEmailSendThisWeekWM.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateEmail={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobCompleteThisWeekWM.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateComplete={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);

            lblTodayNewJobsWM.Text = Global.ObjDashboardController.getJobCountByDate(dateTime).ToString();
            lblJobsAwaitingStartWM.Text = Global.ObjDashboardController.getJobCountByStatus("Awaiting Start").ToString();
            lblJobsProcessedLastWeekWM.Text = Global.ObjDashboardController.getPaidJobOfLastSevenDays(dateTime).ToString();
            lblJobsApprovedThisWeekWM.Text = Global.ObjDashboardController.getApprovedDateJobOfThisWeek(dateTime).ToString();
            lblJobsEmailSendThisWeekWM.Text = Global.ObjDashboardController.getEmailByLastSevenDays(dateTime).ToString();
            lblJobCompleteThisWeekWM.Text = Global.ObjDashboardController.getCompleteInSevenDays(dateTime).ToString();
        }

        private void YearlyJobSheet(DateTime dateTime)
        {
            JobCardCreatedThisWeekJY.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateCreated={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobCardAwatingSamplingJY.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?StatusAwaiting=Inactive");
            JobCardActiveJY.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?StatusActive=Active");
            JobCardCompleteThisWeekJY.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateCardComplete={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            SampleCollectThisWeekJY.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateCollect={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobCardCompleteLastWeekJY.NavigateUrl = String.Format("~/Admin/ListTestMaster.aspx?DateLastComplete={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);

            lblJobCardCreatedThisWeekJY.Text = Global.ObjDashboardController.getActiveTestInfoByDate(dateTime).ToString();
            lblJobCardAwatingSamplingJY.Text = Global.ObjDashboardController.getJobCardCountByStatus("Inactive").ToString();
            lblJobCardActiveJY.Text = Global.ObjDashboardController.getJobCardCountByStatus("Active").ToString();
            lblJobCardCompleteThisWeekJY.Text = Global.ObjDashboardController.getJobCardCompleteInSevenDays(dateTime).ToString();
            lblSampleCollectThisWeekJY.Text = Global.ObjDashboardController.getSampleCollectOfWeek(dateTime).ToString();
            lblJobCardCompleteLastWeekJY.Text = Global.ObjDashboardController.getJobCardCompleteLastSevenDays(dateTime).ToString();
        }

        private void YearlyWorkSheet(DateTime dateTime)
        {
            TodayNewJobsWY.NavigateUrl = String.Format("~/Admin/JobList.aspx?Date={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobsAwaitingStartWY.NavigateUrl = String.Format("~/Admin/JobList.aspx?Status=Awaiting Start");
            JobsProcessedLastWeekWY.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateProcess={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobsApprovedThisWeekWY.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateApproved={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobsEmailSendThisWeekWY.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateEmail={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
            JobCompleteThisWeekWY.NavigateUrl = String.Format("~/Admin/JobList.aspx?DateComplete={0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);

            lblTodayNewJobsWY.Text = Global.ObjDashboardController.getJobCountByDate(dateTime).ToString();
            lblJobsAwaitingStartWY.Text = Global.ObjDashboardController.getJobCountByStatus("Awaiting Start").ToString();
            lblJobsProcessedLastWeekWY.Text = Global.ObjDashboardController.getPaidJobOfLastSevenDays(dateTime).ToString();
            lblJobsApprovedThisWeekWY.Text = Global.ObjDashboardController.getApprovedDateJobOfThisWeek(dateTime).ToString();
            lblJobsEmailSendThisWeekWY.Text = Global.ObjDashboardController.getEmailByLastSevenDays(dateTime).ToString();
            lblJobCompleteThisWeekWY.Text = Global.ObjDashboardController.getCompleteInSevenDays(dateTime).ToString();
        }

        protected void Timer2_Tick(object sender, System.EventArgs e)
        {
            DrawCreateJobChart();
            DrawPaidJobAmountChart();
            LoadStats();
        }


        protected void GO_Click(object sender, EventArgs e)
        {
            DrawCreateJobChart();
        }
        private void DrawCreateJobChart()
        {
            try
            {
                Chart1.Series["Series1"].Points.Clear();
                Chart1.Series["Series1"].ChartType = SeriesChartType.SplineArea;
                Chart1.Series["Series1"].BorderWidth = 3;
                Chart1.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
                Chart1.ChartAreas[0].AxisX.IsMarginVisible = false;

                DateTime dateTime = new DateTime(Int32.Parse(DropDownListYear.SelectedItem.Text), Int32.Parse(DropDownListMonth.SelectedItem.Text), 1);
                for (var j = 1; j <= DateTime.DaysInMonth(Int32.Parse(DropDownListYear.SelectedItem.Text), Int32.Parse(DropDownListMonth.SelectedItem.Text)); j++)
                {
                    try
                    {
                        Chart1.Series["Series1"].Points.AddXY((dateTime + new TimeSpan(j - 1, 0, 0, 0)).Date,
                                                              Global.ObjDashboardController.getJobCountByDateBetween(
                                                                  (dateTime + new TimeSpan(j - 1, 0, 0, 0)).Date)
                            );
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Yearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawPaidJobAmountChart();
        }
        private void DrawPaidJobAmountChart()
        {
            try
            {
                Chart3.Series["Series1"].Points.Clear();
                Chart3.Series["Series1"].ChartType = SeriesChartType.SplineArea;
                Chart3.Series["Series1"].BorderWidth = 3;
                Chart3.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
                Chart3.ChartAreas[0].AxisX.IsMarginVisible = false;
                DateTime dateTime = new DateTime(Int32.Parse(Yearly.SelectedItem.Text), 1, 1);
                for (var j = 1; j <= 12; j++)
                {
                    DateTime dt = new DateTime(Int32.Parse(Yearly.SelectedItem.Text), j, 1);
                    Chart3.Series["Series1"].Points.AddXY(dt.Date, Global.ObjDashboardController.getJobPaidAmountByDate(dt));
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void DropDownListMonth1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, Int32.Parse(DropDownListMonth1.SelectedItem.Text), DateTime.Now.Day);
            MonthlyWorkSheet(dateTime);
            
        }

        protected void DropDownListMonth2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, Int32.Parse(DropDownListMonth2.SelectedItem.Text), DateTime.Now.Day);
            MonthlyJobSheet(dateTime);
          
        }

        protected void DropDownListYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(Int32.Parse(DropDownListYear1.SelectedItem.Text), DateTime.Now.Month, DateTime.Now.Day);
            YearlyWorkSheet(dateTime);
            
        }

        protected void DropDownListYear2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(Int32.Parse(DropDownListYear2.SelectedItem.Text), DateTime.Now.Month, DateTime.Now.Day);
            YearlyJobSheet(dateTime);
        }


    }
}