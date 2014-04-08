using System;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.LabAssistants
{
    public partial class SamplerTestMaster : System.Web.UI.Page
    {
        private static readonly DbController objDbController = new DbController();
        CustomerInfo objCustomerInfo = new CustomerInfo();
        private SampleDetail objActiveSampleInfo = new SampleDetail();

        protected void Page_Load(object sender, EventArgs e)
        {
            datepicker.Value = string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);;
            timeInStart.SetTime = DateTime.Now.TimeOfDay.Ticks;
            if (Page.Request.QueryString.Count <= 0 || IsPostBack) return;
            objActiveSampleInfo = SampleDetailController.GetByTestid(Int32.Parse(Page.Request.QueryString["atid"]));

            ActiveTestsInfo objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));

            industryType.Text = objActiveTestInfo.Industry.ToString();
            ClientName.Text = objActiveTestInfo.Customer.CustName;
            sampleInformation.Text = objActiveSampleInfo.SampleInformation;
            sampleDescription.Text = objActiveSampleInfo.SampleDescription;
            sampleType.Text = objActiveSampleInfo.TypeOfSampling;
      
            if(objActiveSampleInfo.PackingId != 0)
            samplePacking.SelectedValue = objActiveSampleInfo.PackingId.ToString();
            labNumber.Text = objActiveTestInfo.LabNumber;
            if (objActiveSampleInfo.SampleCollectDate != null)
            {
                datepicker.Value = objActiveSampleInfo.SampleCollectDate.Value.ToShortDateString();
                timeInStart.SetTime = objActiveSampleInfo.SampleCollectDate.Value.Ticks;
            }
            string[] currentTestList = objActiveTestInfo.JobDetail.TestInfo.Split(',');
            foreach (var tList in currentTestList)
            {
                testList.Text += (tList + "<br />");
            }

            switch (objActiveTestInfo.Attention)
            {
                case 1:
                    Attention.Text = objActiveTestInfo.Customer.Person1;
                    break;
                case 2:
                    Attention.Text = objActiveTestInfo.Customer.Person2;
                    break;
                case 3:
                    Attention.Text = objActiveTestInfo.Customer.Person3;
                    break;
            }

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0)
            {
                objCustomerInfo = objDbController.GetCustomerData(ClientName.Text);
                if (objCustomerInfo.CustID == 0)
                    return;
                string[] dates = datepicker.Value.Split('/');
                objActiveSampleInfo = SampleDetailController.GetByTestid(Int32.Parse(Page.Request.QueryString["atid"]));
                var tmpDate =new DateTime(Int32.Parse(dates[2]),Int32.Parse(dates[1]),Int32.Parse(dates[0])).Date;
                var time = new TimeSpan(timeInStart.GetTicks);
                var sampleDate = new DateTime(tmpDate.Year,tmpDate.Month,tmpDate.Day,time.Hours,time.Minutes,0);
                ActiveTestsInfo objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));
                objActiveSampleInfo.SampleInformation = sampleInformation.Text;
                objActiveSampleInfo.SampleDescription = sampleDescription.Text;
                objActiveSampleInfo.SampleCollectDate = sampleDate;
                objActiveSampleInfo.TypeOfSampling = sampleType.Text;
                objActiveSampleInfo.PackingId = Int32.Parse(samplePacking.SelectedValue);
                objActiveSampleInfo.IsSampleTaken = true;
                objActiveSampleInfo.NumberOfBottleCollect = SampleCount.Text;
                objActiveSampleInfo.TracingPoint = TrackingPoint.Text;

                SampleDetailController.Update(objActiveSampleInfo);
                objActiveTestInfo.CurrentStatus = "Active";
                objActiveTestInfo.SampleRecievedOn = objActiveSampleInfo.SampleCollectDate;

                RecordHistory objRecordHistory = new RecordHistory();
                objRecordHistory.Description = "Status Updated";
                objRecordHistory.UserName = Session["userName"].ToString();
                objRecordHistory.JobID = objActiveTestInfo.ActiveTestId;
                objRecordHistory.Status = objActiveTestInfo.CurrentStatus;
                objRecordHistory.Timestamp = DateTime.Now.ToString();
                objDbController.AddRecordHistory(objRecordHistory);

                objDbController.UpdateActiveTestInfo(objActiveTestInfo);
            }
           
            Response.Redirect("Dashboard.aspx");
        }



        protected void Reset_Button_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = null;
            Response.Redirect("TestMaster.aspx");
        }

 
    }
}