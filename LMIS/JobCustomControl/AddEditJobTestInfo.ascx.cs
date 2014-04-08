using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LMIS.DBModel;
using LMIS.DBController;
using System.Collections;



namespace LMIS.JobCustomControl
{
    public partial class AddEditJobTestInfo : System.Web.UI.UserControl
    {
        private static readonly DbController objDbController = new DbController();
        private static JobDetail objJobDetail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Page.Request.QueryString.Count <= 0) return;
            switch ((Page.Request.QueryString["actionType"]))
            {
                case "AT":
                case "ET":
                    PanalDiscription.Visible = false;


                    break;
                case "ED":
                    PanelTest.Visible = false;
                    break;
            }



            objJobDetail =
                Global.ObjJobController.GetJobDetail(Int32.Parse(Page.Request.QueryString["qdid"]));

            if (Page.Request.QueryString["actionType"] != "ED")
            {
                List<CustomerTestParameters> objList =
                    objDbController.GetCustomerTestParameters(objJobDetail.JobInfo.Customer.CustID);

                industryType.Items.Clear();

                ListItem lv1 = new ListItem { Text = "--", Value = "0" };
                industryType.Items.Add(lv1);

                ArrayList IndustyIdList = new ArrayList();

                foreach (var customerTestParameterse in objList)
                {

                    IndustryInfo objIndustryInfo = objDbController.GetIndustryInfo(customerTestParameterse.IndustyID);
                    if (IndustyIdList.Contains(customerTestParameterse.IndustyID))
                        continue;
                    IndustyIdList.Add(customerTestParameterse.IndustyID);
                    ListItem lv = new ListItem();
                    lv.Text = objIndustryInfo.IndustryName;
                    lv.Value = objIndustryInfo.IndustryID.ToString();
                    industryType.Items.Add(lv);
                }
                IndustyIdList.Clear();
            }


            switch ((Page.Request.QueryString["actionType"]))
            {

                case "ET":
                    samplePerWeek.Text = objJobDetail.Frequency;
                   
                    sampleQty.Text = objJobDetail.Quantity.ToString();
                    industryType.SelectedValue = objJobDetail.IndustryId.ToString();
                    btnAddTest.Text = "Update";
                    List<CustomerTestParameters> objList =
                        objDbController.GetCustomerTestParameters(objJobDetail.JobInfo.Customer.CustID,
                                                                  Int32.Parse(industryType.SelectedValue));
                    testList.Items.Clear();
                    foreach (var customerTestParameterse in objList)
                    {
                        TestParameterInfo objGetTestParameterInfo =
                            objDbController.GetTestParameterInfo(customerTestParameterse.TestParametersId);
                        ListItem lv1 = new ListItem
                        {
                            Text = objGetTestParameterInfo.AccreditedTestParameter,
                            Value = objGetTestParameterInfo.TestParameterId.ToString()
                        };
                        testList.Items.Add(lv1);
                    }

                    foreach (ListItem testItem in testList.Items)
                    {
                        if (objJobDetail.TestInfo.Contains(testItem.Text))
                        {
                            testItem.Selected = true;
                        }
                    }
                    PanalDiscription.Visible = false;


                    break;
                case "ED":
                    btnAddDesc.Text = "Update";
                    discription.Text = objJobDetail.Descriptation;
                    break;
            }





        }

        protected void industryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CustomerTestParameters> objList =
                objDbController.GetCustomerTestParameters(objJobDetail.JobInfo.Customer.CustID,
                                                          Int32.Parse(industryType.SelectedValue));
            testList.Items.Clear();
            foreach (var customerTestParameterse in objList)
            {
                TestParameterInfo objGetTestParameterInfo =
                    objDbController.GetTestParameterInfo(customerTestParameterse.TestParametersId);
                ListItem lv1 = new ListItem
                {
                    Text = objGetTestParameterInfo.AccreditedTestParameter,
                    Value = objGetTestParameterInfo.TestParameterId.ToString()
                };
                testList.Items.Add(lv1);
            }
        }

        protected void btnAddTest_Click(object sender, EventArgs e)
        {

            JobInfo objJobInfo = objJobDetail.JobInfo;

            if (btnAddTest.Text == "Update")
            {
                objJobDetail.Descriptation = null;
                objJobDetail.Frequency = samplePerWeek.Text;
                objJobDetail.Quantity = Int32.Parse(sampleQty.Text);
                
                objJobDetail.IndustryId = Int32.Parse(industryType.SelectedValue);
                string test = testList.Items.Cast<ListItem>().Where(lv => lv.Selected).Aggregate("",
                                                                                                 (current, lv) =>
                                                                                                 current +
                                                                                                 (lv.Text + ","));
                test = test.TrimEnd(',');
                objJobDetail.TestInfo = test;
               
                Global.ObjJobController.UpdateJobDetail(objJobDetail);

            }
            else
            {

                JobDetail objCurrebtJobDetail = new JobDetail { Descriptation = null, Frequency = samplePerWeek.Text, Quantity = Int32.Parse(sampleQty.Text), ParentId = Int32.Parse(Page.Request.QueryString["qdid"]), IndustryId = Int32.Parse(industryType.SelectedValue), JobInfo = Global.ObjJobController.GetJobInfo(Int32.Parse(Page.Request.QueryString["qid"])) };
                string test = testList.Items.Cast<ListItem>().Where(lv => lv.Selected).Aggregate("",
                                                                                                 (current, lv) =>
                                                                                                 current +
                                                                                                 (lv.Text + ","));
                test = test.TrimEnd(',');
                objCurrebtJobDetail.TestInfo = test;
               

                Global.ObjJobController.AddJobDetail(objCurrebtJobDetail);
            }
            objJobInfo.TotalAmount = 0;
            List<JobDetail> listQoutationDetail =
                Global.ObjJobController.CurrentJobDetail(objJobInfo.JobId);
           
            objJobInfo.Payable = objJobInfo.TotalAmount - objJobInfo.RewardValue;
            Global.ObjJobController.UpdateJobInfo(objJobInfo);


            Response.Redirect(string.Format("AddJob.aspx?qid={0}&etd=true", Page.Request.QueryString["qid"]));

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(discription.Text))
            {
                if (btnAddDesc.Text == "Update")
                {
                    objJobDetail.Descriptation = discription.Text;
                    Global.ObjJobController.UpdateJobDetail(objJobDetail);
                }
                else
                {
                    JobDetail objJobDetail = new JobDetail();
                    objJobDetail.Descriptation = discription.Text;
                    objJobDetail.JobInfo =
                        Global.ObjJobController.GetJobInfo(Int32.Parse(Page.Request.QueryString["qid"]));

                    Global.ObjJobController.AddJobDetail(objJobDetail);
                }

                Response.Redirect(string.Format("AddJob.aspx?qid={0}&etd=true", Page.Request.QueryString["qid"]));
            }
        }
    }
}
