using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.JobCustomControl
{
    public partial class UpdateJobStatus : System.Web.UI.UserControl
    {
        private  JobInfo objJobInfo = new JobInfo();
        private  List<JobDetail> listJobDetail   = new List<JobDetail>();
        private List<SampleDetail> objSampleDetail = new List<SampleDetail>();
        private SampleDetail objSample = new SampleDetail();
        private Bottle objBottle = new Bottle();
        private ActiveTestsInfo objActiveTestsInfo = new ActiveTestsInfo();
        PointsInfo objPointsInfo = new PointsInfo();

        public string JobStaus { set; get; }
        public bool isViewRequest = false;
        public bool isShowExportToExcel { set; get; }
        DBController.DbController objDBController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            objJobInfo = Global.ObjJobController.GetJobInfo(Int32.Parse(Page.Request.QueryString["qid"]));
            objActiveTestsInfo = objDBController.GetActiveTestInfoByQoutationInfoId(objJobInfo.JobId);
            objSampleDetail = objDBController.GetSampleList(objActiveTestsInfo.ActiveTestId);
            objSample = objDBController.GetSampleDetailByTestId(objActiveTestsInfo.ActiveTestId);
            try
            {
            objBottle = objDBController.GetBottleBybbottleId(Int32.Parse(objSample.BottleList));
            }
            catch (Exception)
            {
            }
            objPointsInfo = objDBController.GetPointByCustID(objJobInfo.Customer.CustID);

            if (objJobInfo.JobId == 0) return;
            JobNumber.Text = objJobInfo.JobNumber;
            ClientName.Text = objJobInfo.Customer.CustName;
            customerAddress.Text = objJobInfo.Customer.Address;
            if(isViewRequest)
                btnChangeJobStatus.Visible = false;

            if(Page.Request.QueryString["act"]!=null && Page.Request.QueryString["act"]=="R")
            {
                btnRejectJobStatus.Visible = true;
                DivReject.Visible = true;
                btnChangeJobStatus.Visible = false;
                btnSendMail.Visible = false;
            }
            switch (objJobInfo.Attention)
            {
                case 1:
                    dllAttention.Text = objJobInfo.Customer.Person1;
                    TelNo.Text = objJobInfo.Customer.Phone1;
                    FaxNo.Text = objJobInfo.Customer.Fax1;
                    Email.Text = objJobInfo.Customer.Email1;
                    HomePhone.Text = objJobInfo.Customer.HPhone1;
                    break;
                case 2:
                    dllAttention.Text = objJobInfo.Customer.Person2;
                    TelNo.Text = objJobInfo.Customer.Phone2;
                    FaxNo.Text = objJobInfo.Customer.Fax2;
                    Email.Text = objJobInfo.Customer.Email2;
                    HomePhone.Text = objJobInfo.Customer.HPhone2;
                    break;
                case 3:
                    dllAttention.Text = objJobInfo.Customer.Person3;
                    TelNo.Text = objJobInfo.Customer.Phone3;
                    FaxNo.Text = objJobInfo.Customer.Fax3;
                    Email.Text = objJobInfo.Customer.Email3;
                    HomePhone.Text = objJobInfo.Customer.HPhone3;
                    break;
            }

            Country.Text = objJobInfo.Customer.Country;
            JobDate.Text = objJobInfo.CreateDate.ToShortDateString();
            
            //RewardPoints.Text = objJobInfo.Customer.Reward.ToString();
            //TextBox1.Text = objJobInfo.Reward.ToString();
            listJobDetail = Global.ObjJobController.CurrentJobDetail(Int32.Parse(Page.Request.QueryString["qid"]));

            PointNumber.Text = Global.ObjJobController.CurrentJobDetail(objJobInfo.JobId).Count.ToString();
            
           
            if (objJobInfo.Status == "Reject")
            {
                DivReject.Visible = true;
                ReasonToDelete.Text = objJobInfo.Comments;
                ReasonToDelete.Enabled = false;
                ReasonToDelete.CssClass = "st-error-input";
            }
            FillTestDeatilTable();
            if (isShowExportToExcel)
                exportToExcel.Visible = true;

            try
            {
                FillSampleBottleDetailTable();
            }
            catch (Exception ex)
            {

            }
        }

        private void FillSampleBottleDetailTable()
        {

            int i = 1;
            for (; i < SampleBottleDetailTable.Rows.Count; )
            {
                SampleBottleDetailTable.Rows.RemoveAt(i);
            }
           
            var jobTestBottleDetailList = Global.objJobTestBottleDetailController.GetByJobID(Int32.Parse(Page.Request.QueryString["qid"]));
            foreach (JobTestBottleDetail objJobTestBottleDetail in jobTestBottleDetailList)
            {
                using (var row = new HtmlTableRow())
                {
                    row.Cells.Add(new HtmlTableCell { InnerHtml = Global.objBottleController.Get(objJobTestBottleDetail.BottleId).PreservativeChemical });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = Global.ObjDbController.GetTestParameterInfo(objJobTestBottleDetail.TestId).AccreditedTestParameter, VAlign = "Top" });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objJobTestBottleDetail.BottleRequired.ToString() });
                    row.BgColor =  "#FFFFFF";
                    SampleBottleDetailTable.Controls.Add(row);
                }
            }

            if (jobTestBottleDetailList.Count == 0)
                SampleBottle.Visible = false;
        }
        private void FillTestDeatilTable()
        {
            for (int i = 1; i < tblTestDeatil.Rows.Count; i++)
            {
                tblTestDeatil.Rows.RemoveAt(i);
            }
            var counter = 1;
           

            foreach (JobDetail objJobDetail in listJobDetail)
            {
                using (var row = new HtmlTableRow())
                {

                    if (objJobDetail.Descriptation != null)
                    {
                        row.Cells.Add(new HtmlTableCell { InnerHtml = counter.ToString(), Align = "center" });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Descriptation });
                        
                        counter++;
                    }
                    else
                    {
                        row.Cells.Add(new HtmlTableCell { InnerHtml = counter.ToString(), Align = "center" });
                        var currentTestList = objJobDetail.TestInfo.Split(',');
                        var testDescriptation = "<b><u> Parameter of Testing</u></b><br />";
                        foreach (string testVal in currentTestList)
                        {
                            testDescriptation += testVal + "," + "&nbsp;&nbsp;";
                        }
                       // testDescriptation += "<br /> <br /><br /><br /><b><u>Frequency</u></b><br />";
                      //  testDescriptation += string.Format("{0}sampls/week x 4 weeks/month = {1} samples/month <br /> <br />", objJobDetail.Frequency, (Int32.Parse(objJobDetail.Frequency) * 4));
                        row.Cells.Add(new HtmlTableCell { InnerHtml = testDescriptation, VAlign = "Top" });
                      
                       // row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Quantity + " samples", VAlign = "Top", Align = "center" });
                        counter++;
                    }
                    row.BgColor = "#FFFFFF";
                    tblTestDeatil.Controls.Add(row);
                }
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session["ActionType"] = "Print";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", string.Format("<script language=javascript>window.open('PrintJob.aspx?qid={0}','PrintMe','height=300px,width=300px,scrollbars=1');</script>", Page.Request.QueryString["qid"]));
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            if (JobStaus != null)
            {

                if (objJobInfo.Status == "Awaiting Approval" && JobStaus == "Awaiting Start")
                {
                    objJobInfo.ApprovedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
                    objJobInfo.Status = JobStaus;
                    Global.ObjJobController.UpdateJobInfo(objJobInfo);
                }
                else if (JobStaus != "In Progress")
                {
                    objJobInfo.Status = JobStaus;
                    Global.ObjJobController.UpdateJobInfo(objJobInfo);
                }
                else
                {
                    objJobInfo.Status = "In Progress";
                    Global.ObjJobController.UpdateJobInfo(objJobInfo);
                    Global.ObjJobController.ConvertJobToTestMaster(objJobInfo);
                    objJobInfo.Customer.Reward += 20;
                    objJobInfo.PaidDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day);
                    Global.ObjDbController.UpdateCustomer(objJobInfo.Customer);
                }

            }
            Response.Redirect("JobList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobList.aspx");
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            objJobInfo.EmailSend = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            Global.ObjJobController.UpdateJobInfo(objJobInfo);
            Session["ctrl"] = pnl1;
            Session["ToEmail"] = Email.Text;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('EmailJobcard.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");

        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            objJobInfo.Status = "Reject";
            objJobInfo.Comments = ReasonToDelete.Text;
            Global.ObjJobController.UpdateJobInfo(objJobInfo);
            Response.Redirect("JobList.aspx");
        }
   

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment; filename=CustomerDetail.xls");
            Response.ContentEncoding = Encoding.UTF8;
            using (var tw = new StringWriter())
            {
                var hw = new HtmlTextWriter(tw); 
                tbl.RenderControl(hw);
                Response.Write(tw.ToString());
            }
            Response.End(); 
        }
    }
}