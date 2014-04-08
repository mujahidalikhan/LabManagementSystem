using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;
using System.Web.UI.HtmlControls;


namespace LMIS.Admin
{
    public partial class AddEditJob : System.Web.UI.Page
    {
        private static decimal JobTotal;
        private static decimal rewarDiscount;
        private static decimal finalTotal;
        private static decimal MicItemsCostval;
        private static int appliedRewardPoints;
        private static JobInfo objJobInfo;
        private static bool descAdded;
        private static bool testAdded;
        private static decimal rewardRate = 0;
        private static readonly DbController objDbController = new DbController();
        private static CustomerInfo objCustomerInfo;
        ContactInfo objContactInfo;
        ActiveTestsInfo objActiveTestInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(GetType(), "onload"," <script type=\"text/javascript\"> $(function () { $(\"#<%= SampleReciveOnDate.ClientID %>\").datepicker({ dateFormat: 'dd/mm/yy' }).val(); }); </script>");

            if (!IsPostBack)
            {
                AllTest.Checked = false;
                uncheckAll.Checked = false;
                myMV.ActiveViewIndex = 0;
                objCustomerInfo = new CustomerInfo();
                objActiveTestInfo = new ActiveTestsInfo();

                descAdded = false;
                testAdded = false;
                objJobInfo = new JobInfo();
                var objRewardvalue = objDbController.GetRewardValue();
                rewardRate = objRewardvalue.ExchageRate;

                ClientName.Items.Clear();
                List<CustomerInfo> ListCustomer = objDbController.GetCustomerInfo();
                foreach (var customer in ListCustomer)
                {
                    ClientName.Items.Add(new ListItem() { Text = customer.CustName, Value = customer.CustID.ToString() });

                }


                List<Specification> listSpecification = SpecificationController.GetDistanceSpecification();
                industryType.Items.Clear();
                foreach (Specification specification in listSpecification)
                {
                    industryType.Items.Add(specification.SpecificationName);
                }

                if (industryType.Items.Count > 0)
                {
                    industryType.SelectedIndex = 0;
                    GetSpecificationTest();
                }


                if (ClientName.Items.Count > 0)
                {
                    ClientName.SelectedIndex = 0;
                    UpdateCustomerInformation();
                }

               
               
                JobDate.Text = DateTime.Now.ToString("dd/MM/yy");
                ReqLetterDate.Text = DateTime.Now.ToString("dd/MM/yy");
                SampleReciveOnDate.Text = DateTime.Now.ToString("dd/MM/yy");

                List<PackingInfo> listPackingInfo = Global.ObjDbController.GetPackingInfo();
                foreach (PackingInfo packingInfo in listPackingInfo)
                {
                    SamplePacking.Items.Add(new ListItem() { Text = packingInfo.PackingDescription, Value = packingInfo.PackingName});
                }
               
            }



            if (Page.Request.QueryString["qid"] != null)
            {
                objJobInfo =
                    Global.ObjJobController.GetJobInfo(Int32.Parse(Page.Request.QueryString["qid"]));
                if (objJobInfo.JobId != 0)
                    JobId.Value = objJobInfo.JobId.ToString();
            }

            if (JobId.Value != "-1")
            {
                btnJobInformation.Text = "Edit Job Information";
                addTestDetail.Visible = true;
                if (objJobInfo == null || objJobInfo.JobId == 0)
                    objJobInfo = Global.ObjJobController.GetJobInfo(Int32.Parse(JobId.Value));
            }




            if (Page.Request.QueryString["qid"] != null && objJobInfo.JobId != 0 && !IsPostBack)
            {

                JobNumber.Text = objJobInfo.JobNumber;
                ClientName.Text = objJobInfo.Customer.CustName;
                objCustomerInfo = objJobInfo.Customer;
                customerAddress.Text = objJobInfo.Customer.Address;
                if (!String.IsNullOrEmpty(objCustomerInfo.Person1))
                {
                    ListItem li = new ListItem();
                    li.Value = "1";
                    li.Text = objCustomerInfo.Person1;

                    ddlAttention.Items.Add(li);
                }
                if (!String.IsNullOrEmpty(objCustomerInfo.Person2))
                {
                    ListItem li2 = new ListItem();
                    li2.Value = "2";
                    li2.Text = objCustomerInfo.Person2;
                    ddlAttention.Items.Add(li2);
                }
                if (!String.IsNullOrEmpty(objCustomerInfo.Person3))
                {
                    ListItem li3 = new ListItem();
                    li3.Value = "3";
                    li3.Text = objCustomerInfo.Person3;
                    ddlAttention.Items.Add(li3);
                }

                switch (objJobInfo.Attention)
                {
                    case 1:
                        ddlAttention.SelectedValue = "1";
                        TelNo.Text = objJobInfo.Customer.Phone1;
                        FaxNo.Text = objJobInfo.Customer.Fax1;
                        Email.Text = objJobInfo.Customer.Email1;
                        HomePhone.Text = objJobInfo.Customer.HPhone1;
                        break;
                    case 2:
                        ddlAttention.SelectedValue = "2";
                        TelNo.Text = objJobInfo.Customer.HPhone2;
                        FaxNo.Text = objJobInfo.Customer.Fax2;
                        Email.Text = objJobInfo.Customer.Email2;
                        HomePhone.Text = objJobInfo.Customer.HPhone2;
                        break;
                    case 3:
                        ddlAttention.SelectedValue = "3";
                        TelNo.Text = objJobInfo.Customer.HPhone3;
                        FaxNo.Text = objJobInfo.Customer.Fax3;
                        Email.Text = objJobInfo.Customer.Email3;
                        HomePhone.Text = objJobInfo.Customer.HPhone3;
                        break;
                }

                List<CustomerTestParameters> objList = objDbController.GetCustomerTestParameters(objCustomerInfo.CustID);
                customerDetails.Visible = true;
                Country.Text = objJobInfo.Customer.Country;
                customerDetails.Visible = true;
                RewardValue objRewardvalue = objDbController.GetRewardValue();
                rewardRate = objRewardvalue.ExchageRate;
                JobTotal = objJobInfo.TotalAmount;
                finalTotal = JobTotal - rewarDiscount;


            }

            try
            {
                FillSampleBottleDetailTable();
            }
            catch (Exception ex)
            {

            }

            try
            {
                FillTestInformation();
            }
            catch (Exception)
            {


            }
            FillJobDetailSelectedTestList();
            if (Page.Request.QueryString["etd"] != null && Page.Request.QueryString["etd"] == "true")
            {
                if (myMV.ActiveViewIndex == 0)
                {
                    myMV.ActiveViewIndex = 1;
                }
            }

            var date = JobDate.Text.Split('/');
            objJobInfo.JobNumber = string.Format("{0}/0{1}/{2}/{3}", date[2] + date[1], objJobInfo.JobId, Global.ObjJobController.CurrentJobDetail(objJobInfo.JobId).Count,
                objJobInfo.Customer.CustName.Remove(1, objJobInfo.Customer.CustName.Length - 1));
        }

        protected void ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCustomerInformation();
        }

        private void UpdateCustomerInformation()
        {
            ddlAttention.Items.Clear();

            if (String.IsNullOrEmpty(ClientName.Text) || Int32.Parse(ClientName.SelectedValue) == -1)
            {
                customerDetails.Visible = false;
                return;
            }

            objCustomerInfo = objDbController.GetCustomerbyId(Int32.Parse(ClientName.Text));
            customerAddress.Text = objCustomerInfo.Address;

            ddlAttention.Items.Clear();

            List<ContactInfo> contactInof = objDbController.GetCusotmerContactInfo(Int32.Parse(ClientName.SelectedValue));
            foreach (ContactInfo objCustomerContactInfo in contactInof)
            {
                ddlAttention.Items.Add(new ListItem() { Text = objCustomerContactInfo.Name, Value = objCustomerContactInfo.Id.ToString() });
            }
            List<PointsInfo> objPointInfo = objDbController.GetPoints(Int32.Parse(ClientName.SelectedValue));
            foreach (PointsInfo objPointsInfo in objPointInfo)
            {
                JobRewardPoint.Items.Add(new ListItem() { Text = objPointsInfo.Points, Value = objPointsInfo.Id.ToString() });
            }


            if (contactInof.Count > 0)
            {
                objContactInfo = contactInof[0];
                TelNo.Text = objContactInfo.Phone;
                FaxNo.Text = objContactInfo.Fax;
                Email.Text = objContactInfo.Email;
                HomePhone.Text = objContactInfo.HPhone;
                Session["CustID"] = objContactInfo.CustID;
                objJobInfo.Customer = objCustomerInfo;
                Country.Text = objCustomerInfo.Country;
                customerDetails.Visible = true;
            }
        }

        protected void industryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSpecificationTest();
            //   FillTestDeatilTable();
        }

        private void GetSpecificationTest()
        {
            List<Specification> listSpecification =
                SpecificationController.GetSpecificationByName(industryType.SelectedItem.Text);


            check1.Items.Clear();
            foreach (Specification objSpecification in listSpecification)
            {


                check1.Items.Add(new ListItem(objSpecification.TestId.AccreditedTestParameter, objSpecification.TestId.TestParameterId.ToString()));


            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {



        }

        protected void btnAddTest_Click(object sender, EventArgs e)
        {

        }

        protected void ddlAttention_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAttention.SelectedValue != null)
                switch (ddlAttention.SelectedValue)
                {
                    case "1":
                        TelNo.Text = objCustomerInfo.HPhone1;
                        FaxNo.Text = objCustomerInfo.Fax1;
                        Email.Text = objCustomerInfo.Email1;
                        HomePhone.Text = objCustomerInfo.HPhone1;
                        break;
                    case "2":
                        TelNo.Text = objCustomerInfo.HPhone2;
                        FaxNo.Text = objCustomerInfo.Fax2;
                        Email.Text = objCustomerInfo.Email2;
                        HomePhone.Text = objCustomerInfo.HPhone2;
                        break;
                    case "3":
                        TelNo.Text = objCustomerInfo.HPhone3;
                        FaxNo.Text = objCustomerInfo.Fax3;
                        Email.Text = objCustomerInfo.Email3;
                        HomePhone.Text = objCustomerInfo.HPhone3;
                        break;
                }
        }

        protected void MicItemsCost_TextChanged(object sender, EventArgs e)
        {

            //while (true)
            //{
            //    try
            //    {
            //        MicItemsCostval = decimal.Parse(MicItemsCost.Text);
            //        if (rewardRate != 0)
            //        {
            //            rewarDiscount = (decimal.Parse(TextBox1.Text) / rewardRate);
            //            appliedRewardPoints = Int32.Parse(TextBox1.Text);
            //        }
            //        else
            //        {
            //            rewarDiscount = 0;
            //            appliedRewardPoints = 0;

            //        }
            //        finalTotal = (JobTotal + MicItemsCostval) - rewarDiscount;

            //        Label3.Text = rewarDiscount.ToString();
            //        Label4.Text = finalTotal.ToString();
            //        return;
            //    }
            //    catch (Exception)
            //    {
            //        MicItemsCost.Text = MicItemsCost.Text.Length <= 1 ? "0" : MicItemsCost.Text.Substring(0, MicItemsCost.Text.Length - 1);
            //    }
            //}

        }

        protected void addTestDetail_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex += 1;
        }

        protected void PaymentInfo_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex += 1;
        }

        protected void JobInfo_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex -= 1;
        }

        protected void btnJobInformation_Click(object sender, EventArgs e)
        {
            objJobInfo.Attention = Int32.Parse(ddlAttention.SelectedValue);
            var date = JobDate.Text.Split('/');
            objJobInfo.CreateDate = new DateTime(Int32.Parse(date[2]) + 2000, Int32.Parse(date[0]), Int32.Parse(date[1]));
            date = ReqLetterDate.Text.Split('/');
            objJobInfo.Validatily = new DateTime(Int32.Parse(date[2]) + 2000, Int32.Parse(date[0]), Int32.Parse(date[1]));
            objJobInfo.TermOfPayment = DateTime.Now;
            objJobInfo.JobNumber = JobNumber.Text;
            objJobInfo.Status = "Incomplete";
            if (btnJobInformation.Text == "Add Job Information")
            {
                objJobInfo.JobId = Global.ObjJobController.AddJobInfo(objJobInfo);
                JobId.Value = objJobInfo.JobId.ToString();
                //objJobInfo.JobNumber = string.Format("JN{0}{1:d2}{2:d3}", objJobInfo.CreateDate.ToString("yy"), objJobInfo.CreateDate.Month,objJobInfo.JobId);
                PointsInfo objPointsInfo = objDbController.GetPointByCustID(objJobInfo.Customer.CustID);

                objJobInfo.JobNumber = string.Format("{0}/0{1}/{2}/{3}", date[2] + date[1], objJobInfo.JobId, Global.ObjJobController.CurrentJobDetail(objJobInfo.JobId).Count,
                objJobInfo.Customer.CustName.Remove(1, objJobInfo.Customer.CustName.Length - 1));

                JobNumber.Text = objJobInfo.JobNumber;
                Global.ObjJobController.UpdateJobInfo(objJobInfo);
                addTestDetail.Visible = true;
                btnJobInformation.Text = "Edit Job Information";

                IntermediateCustomerContact objInter = new IntermediateCustomerContact();
                objInter.CustID = objCustomerInfo.CustID;
                objInter.ContactID = Int32.Parse(ddlAttention.SelectedValue);
                objInter.JobID = objJobInfo.JobNumber;
                objDbController.AddIntermediateCustomerContact(objInter);
            }
            else
            {
                Global.ObjJobController.UpdateJobInfo(objJobInfo);
            }
        }

        protected void btnSkipAddingBottle_Click(object sender, EventArgs e)
        {
            QuotatonTestDetail.Visible = true;
        }

        protected void TestInfo_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex -= 1;
        }

        protected void FinlizeJob_Click(object sender, EventArgs e)
        {
          




            objJobInfo.Status = "Awaiting Approval";
            objJobInfo.Payable = finalTotal;
            objJobInfo.RewardValue = rewarDiscount;
            objJobInfo.RewardPoint = appliedRewardPoints;
            objJobInfo.TotalAmount = JobTotal;
            objJobInfo.MicItemsCost = MicItemsCostval;
           

            var date = JobDate.Text.Split('/');
            objJobInfo.CreateDate = new DateTime(Int32.Parse(date[2]) + 2000, Int32.Parse(date[0]), Int32.Parse(date[1]));
            objJobInfo.JobNumber = 
                string.Format("{0}/0{1}/{2}/{3}", date[2] + date[1], objJobInfo.JobId,Global.ObjJobController.CurrentJobDetail(objJobInfo.JobId).Count ,
                objJobInfo.Customer.CustName.Remove(1, objJobInfo.Customer.CustName.Length - 1));
            Global.ObjJobController.UpdateJobInfo(objJobInfo);

            objDbController.UpdateCustomer(objCustomerInfo);

            string JobStaus = "Awaiting Start";
            if (JobStaus != null)
            {

                if (objJobInfo.Status == "Awaiting Approval" && JobStaus == "Awaiting Start")
                {
                    objJobInfo.ApprovedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
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
                    objJobInfo.PaidDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    Global.ObjDbController.UpdateCustomer(objJobInfo.Customer);
                }

            }

            Response.Redirect("JobList.aspx");
        }

        protected void AddJobTestBottleDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddJobTestBottleDetail.aspx?qid=" + objJobInfo.JobId);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void AllTest_CheckedChanged(object sender, EventArgs e)
        {
            if (AllTest.Checked)
            {
                uncheckAll.Checked = false;
                foreach (ListItem objListItem in check1.Items)
                {
                    objListItem.Selected = true;
                }
            }
            FillJobDetailSelectedTestList();

        }

        protected void check1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem objListItem in check1.Items)
            {
                if (objListItem.Selected != AllTest.Checked)
                {
                    if (AllTest.Checked == true)
                        AllTest.Checked = false;
                }
                if (objListItem.Selected != uncheckAll.Checked)
                {
                    if (uncheckAll.Checked == true && objListItem.Selected == false)
                        uncheckAll.Checked = false;
                }

            }

            FillJobDetailSelectedTestList();
        }

        private void FillJobDetailSelectedTestList()
        {
            JobDetailSelectedTestList.Items.Clear();
            foreach (ListItem objListItem in check1.Items)
            {
                if (objListItem.Selected)
                {
                    JobDetailSelectedTestList.Items.Add(new ListItem() { Text = objListItem.Text, Value = objListItem.Value });
                }
            }

        }

        protected void AllTest0_CheckedChanged(object sender, EventArgs e)
        {
            if (uncheckAll.Checked)
            {
                AllTest.Checked = false;
                foreach (ListItem objListItem in check1.Items)
                {
                    objListItem.Selected = false;
                }
            }
            FillJobDetailSelectedTestList();
        }

        protected void JobRewardPoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddBottleCount_Click(object sender, EventArgs e)
        {
            if (SampleBottle.Items.Count == 0 || JobDetailSelectedTestList.Items.Count == 0)
                return;
            if (String.IsNullOrEmpty(JobDetailSelectedTestList.SelectedValue))
                return;
            var objJobTestBottleDetail = new JobTestBottleDetail
            {
                JobDetailId = objJobInfo.JobId,
                BottleId = Int32.Parse(SampleBottle.SelectedValue),
                TestId = Int32.Parse(JobDetailSelectedTestList.SelectedValue),
                BottleRequired = Int32.Parse(JobDetailBottleCount.Text),
                JobDetailParentId = objJobInfo.JobId,
                JobInfoId = Int32.Parse(JobId.Value)
            };
            Global.objJobTestBottleDetailController.Add(objJobTestBottleDetail);
            JobDetailBottleCount.Text = null;
            SampleBottle.SelectedValue = SampleBottle.Items[0].Value;
            JobDetailSelectedTestList.SelectedValue = JobDetailSelectedTestList.Items[0].Value;

            FillSampleBottleDetailTable();
        }

        private void FillSampleBottleDetailTable()
        {

            int i = 1;
            for (; i < SampleBottleDetailTable.Rows.Count; )
            {
                SampleBottleDetailTable.Rows.RemoveAt(i);
            }

            var JobTestBottleDetailList = Global.objJobTestBottleDetailController.GetByJobID(Int32.Parse(JobId.Value));
            foreach (JobTestBottleDetail objJobTestBottleDetail in JobTestBottleDetailList)
            {
                using (var row = new HtmlTableRow())
                {
                    row.Cells.Add(new HtmlTableCell { InnerHtml = Global.objBottleController.Get(objJobTestBottleDetail.BottleId).PreservativeChemical });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = Global.ObjDbController.GetTestParameterInfo(objJobTestBottleDetail.TestId).AccreditedTestParameter, VAlign = "Top" });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objJobTestBottleDetail.BottleRequired.ToString() });
                    row.Cells.Add(new HtmlTableCell
                    {
                        InnerHtml = String.Format(
                            "<a href=\"DeleteJobTestBottleDetail.aspx?qid={0}&bId={1}\" title=\"Delete\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete </a>",
                            objJobInfo.JobId, objJobTestBottleDetail.ID),
                        VAlign = "top",
                        Align = "Center"
                    });
                    SampleBottleDetailTable.Controls.Add(row);
                }
            }
        }
        private void FillTestInformation()
        {
            int i = 1;
            for (; i < TestInformation.Rows.Count; )
            {
                TestInformation.Rows.RemoveAt(i);
            }

            var listTestInformation = Global.ObjJobController.JobDescriptionDetail(Int32.Parse(JobId.Value));
            foreach (JobDetail objJobDetail in listTestInformation)
            {
                using (var row = new HtmlTableRow())
                {
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.PointNumber.ToString(), Align = "Center"});

                    row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Urgent == "True" ? "Yes" : "No", Align = "Center" });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Specification, Align = "Center" });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Standard, Align = "Center" });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.TestInfo, Width = "150", Align = "Center" });
                    row.Cells.Add(new HtmlTableCell
                    {
                        InnerHtml = String.Format(
                            "<a href=\"DeleteJobDetail.aspx?qid={0}&qdid={1}\" title=\"Delete\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete </a>",
                            objJobInfo.JobId, objJobDetail.JobDetailId),
                        VAlign = "top",
                        Align = "Center"
                    });
                    TestInformation.Controls.Add(row);
                }
            }
        }
        protected void btnAddTestInformation_Click(object sender, EventArgs e)
        {
            var objJobDetail = new JobDetail
                                   {
                                       Descriptation = null,

                                   };
            var test = check1.Items.Cast<ListItem>().Where(lv => lv.Selected).Aggregate("",
                                                                                        (current, lv) =>
                                                                                        current +
                                                                                        (lv.Text + ","));



            test = test.TrimEnd(',');

            objJobDetail.TestInfo = test;

            objJobDetail.Point = JobRewardPoint.SelectedValue;
            objJobDetail.Urgent = URGENT.Checked.ToString();
            objJobDetail.Specification = industryType.SelectedValue;
            string standard = "";
            if (RadioButton1.Checked)
                standard = "StdA";
            else if (RadioButton2.Checked)
                standard = "StdB";
            else if (RadioButton3.Checked)
                standard = "Others";
            objJobDetail.Standard = standard;

            objJobDetail.JobInfo = objJobInfo;

            objJobDetail.PointNumber = Global.ObjJobController.CurrentJobDetail(objJobInfo.JobId).Count + 1;
            int JobDetailId = Global.ObjJobController.AddJobDetail(objJobDetail);





            var dateEvent = SampleReciveOnDate.Text.Split('/');
            var objEvent = new DBModel.Events
                               {
                                   Title = SamplePacking.SelectedItem.Text,
                                   StartDate =
                                       new DateTime(Int32.Parse(dateEvent[2])+2000, Int32.Parse(dateEvent[1]),
                                                    Int32.Parse(dateEvent[0])),
                                   EndDate =
                                       new DateTime(Int32.Parse(dateEvent[2]) + 2000, Int32.Parse(dateEvent[1]),
                                                    Int32.Parse(dateEvent[0])),
                                   AllDayEvent = true,
                                   BackgroundColor = "#56f100",
                                   JobId = objJobInfo.JobId
                               };
            try
            {
                var eventId = Global.ObjEventsController.AddEvent(objEvent);
                var objSampleDetail = new SampleDetail
                                          {
                                              SampleDescription = SamplePacking.SelectedItem.Text,
                                              EventId = eventId,
                                              AssigneDate =
                                                  new DateTime(Int32.Parse(dateEvent[2]) + 2000, Int32.Parse(dateEvent[0]),
                                                               Int32.Parse(dateEvent[1])),
                                              SampleCollectDate =
                                                  new DateTime(Int32.Parse(dateEvent[2]) + 2000, Int32.Parse(dateEvent[0]),
                                                               Int32.Parse(dateEvent[1])),
                                              TypeOfSampling = TypeOfSample.Text,
                                              JobDetailID = JobDetailId,
                                          };

                int sampleDetailId = SampleDetailController.Add(objSampleDetail);

                var date = JobDate.Text.Split('/');
                objJobInfo.JobNumber = string.Format("{0}/0{1}/{2}/{3}", date[2] + date[1], objJobInfo.JobId,
                                                     Global.ObjJobController.CurrentJobDetail(objJobInfo.JobId).Count,
                                                     objJobInfo.Customer.CustName.Remove(1,
                                                                                         objJobInfo.Customer.CustName.Length -
                                                                                         1));

                Global.ObjJobController.UpdateJobInfo(objJobInfo);
            }
            catch (Exception)
            {
            }
            FillTestInformation();
        }
    }
}