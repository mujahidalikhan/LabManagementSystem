using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LMIS.DBController;
using LMIS.DBModel;
using System.Web.UI.HtmlControls;


namespace LMIS.LabAssistants
{
    public partial class TestMaster : System.Web.UI.Page
    {

        private static readonly DbController objDbController = new DbController();
        CustomerInfo objCustomerInfo = new CustomerInfo();
        private static ActiveTestsInfo objActiveTestInfo = new ActiveTestsInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                industryType.Items.Clear();
                var list = objDbController.GetIndustryInfo();
                foreach (var industryInfo in list)
                {
                    var li = new ListItem { Text = industryInfo.IndustryName, Value = industryInfo.IndustryID.ToString() };
                    industryType.Items.Add(li);
                }
                assignToUser.Items.Clear();
                var userList = objDbController.GetSystemUserByRole('A');
                foreach (var li in userList.Select(systemUserse => new ListItem { Text = string.Format("{0} {1}", systemUserse.FirstName, systemUserse.LastName), Value = systemUserse.UserId.ToString() }))
                {
                    assignToUser.Items.Add(li);
                }


            }

            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {

                objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));

             
                ClientName.Text = objActiveTestInfo.Customer.CustName;
                sampleInformation.Text = objActiveTestInfo.SampleInformation;
                sampleDescription.Text = objActiveTestInfo.SampleDescription;
                sampleType.Text = objActiveTestInfo.TypeOfSampling;
                analysisCondition.Text = objActiveTestInfo.AnalysisCondition;
                sampleRecieveDate.Text = objActiveTestInfo.SampleRecievedOn.ToString();
              //  samplePacking.SelectedValue = objActiveTestInfo.PackingId.ToString();
                string[] userList = objDbController.GetUserContact(objActiveTestInfo.Customer.CustID);
                for (int i = 0; i < 3; i++)
                {
                    var li = new ListItem { Text = userList[i], Value = (i + 1).ToString() };
                    DropDownList1.Items.Add(li);
                }
                DropDownList1.SelectedValue = objActiveTestInfo.Attention.ToString();
                DropDownList1.Enabled = false;
                assignToUser.Items.Clear();
                var userassignList = objDbController.GetSystemUserByRole('L');
                foreach (var li in userassignList.Select(systemUserse => new ListItem { Text = string.Format("{0} {1}", systemUserse.FirstName, systemUserse.LastName), Value = systemUserse.UserId.ToString() }))
                {
                    assignToUser.Items.Add(li);
                }
                assignToUser.SelectedValue = objActiveTestInfo.AssignTo.ToString();
                SystemUsers objSystemUsers = objDbController.GetSystemUser(objActiveTestInfo.AssignTo);
               // assignToUser.Items.FindByText(string.Format("{0} {1}", objSystemUsers.FirstName, objSystemUsers.LastName)).Selected = true;
                labNumber.Text = objActiveTestInfo.LabNumber;
              //  spcType.Items.FindByText(objActiveTestInfo.SpecificationType).Selected = true;
             //   DropDownList1.SelectedValue = objActiveTestInfo.Attention.ToString();
            }

        }
        protected override void OnLoadComplete(EventArgs e)
        {
            if (!IsPostBack)
            {

                //var d = (HtmlSelect)this.FindControl("d");
                // d.Value = objActiveTestInfo.SampleRecievedOn.Day.ToString();
            }
        }

        protected override void OnInitComplete(System.EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0)
            {
                objCustomerInfo = objDbController.GetCustomerData(ClientName.Text);
                if (objCustomerInfo.CustID == 0)
                    return;
                objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));
                objActiveTestInfo.AnalysisCondition = analysisCondition.Text;
                objActiveTestInfo.AssignTo = Int32.Parse(assignToUser.SelectedValue);
                objActiveTestInfo.LabNumber = labNumber.Text;
                objActiveTestInfo.CurrentStatus = "Inactive";

                RecordHistory objRecordHistory = new RecordHistory();
                objRecordHistory.Description = "Status Updated";
                objRecordHistory.UserName = Session["userName"].ToString();
                objRecordHistory.JobID = objActiveTestInfo.ActiveTestId;
                objRecordHistory.Status = objActiveTestInfo.CurrentStatus;
                objRecordHistory.Timestamp = DateTime.Now.ToString();
                objDbController.AddRecordHistory(objRecordHistory);

                objDbController.UpdateActiveTestInfo(objActiveTestInfo);
            }
            else
            {
                objCustomerInfo = objDbController.GetCustomerData(ClientName.Text);
                if (objCustomerInfo.CustID == 0)
                    return;
                //objDbController.AddActiveTestInfo(
                //    Int32.Parse(industryType.SelectedItem.Value),
                //    objCustomerInfo.CustID,
                //    DateTime.Now,
                //    sampleInformation.Text,
                //    sampleDescription.Text,
                //    sampleDate,
                //    sampleType.Text,
                //    analysisCondition.Text,
                //    Int32.Parse(samplePacking.SelectedItem.Value),
                //    "New",
                //    Int32.Parse(assignToUser.SelectedItem.Value),
                //      labNumber.Text,
                //     spcType.SelectedItem.Text,
                //     Int32.Parse(DropDownList1.SelectedValue)
                //    );
            }
            Response.Redirect("Dashboard.aspx");
        }

        protected void ClientName_TextChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            objCustomerInfo = objDbController.GetCustomerData(ClientName.Text);
            if (!String.IsNullOrEmpty(objCustomerInfo.Person1))
            {
                ListItem li = new ListItem();
                li.Value = "1";
                li.Text = objCustomerInfo.Person1;

                DropDownList1.Items.Add(li);
            }
            if (!String.IsNullOrEmpty(objCustomerInfo.Person2))
            {
                ListItem li2 = new ListItem();
                li2.Value = "2";
                li2.Text = objCustomerInfo.Person2;
                DropDownList1.Items.Add(li2);
            }
            if (!String.IsNullOrEmpty(objCustomerInfo.Person3))
            {
                ListItem li3 = new ListItem();
                li3.Value = "3";
                li3.Text = objCustomerInfo.Person3;
                DropDownList1.Items.Add(li3);
            }

            Session["CustID"] = objCustomerInfo.CustID;
            List<CustomerTestParameters> objList = objDbController.GetCustomerTestParameters(objCustomerInfo.CustID);

            industryType.Items.Clear();

            ListItem lv1 = new ListItem { Text = "--", Value = "0" };
            industryType.Items.Add(lv1);


            foreach (var customerTestParameterse in objList)
            {
                IndustryInfo objIndustryInfo = objDbController.GetIndustryInfo(customerTestParameterse.IndustyID);
                ListItem lv = new ListItem();
                lv.Text = objIndustryInfo.IndustryName;
                lv.Value = objIndustryInfo.IndustryID.ToString();
                industryType.Items.Add(lv);
            }

        }

        protected void Reset_Button_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = null;
            Response.Redirect("TestMaster.aspx");
        }

        protected void industryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["CustID"] == null)
                return;

            List<CustomerTestParameters> objList = objDbController.GetCustomerTestParameters(Int32.Parse(Session["CustID"].ToString()), Int32.Parse(industryType.SelectedValue));
            testList.Items.Clear();

            foreach (var customerTestParameterse in objList)
            {
                TestParameterInfo objGetTestParameterInfo =
                    objDbController.GetTestParameterInfo(customerTestParameterse.TestParametersId);
                ListItem lv1 = new ListItem { Text = objGetTestParameterInfo.AccreditedTestParameter, Value = objGetTestParameterInfo.TestParameterId.ToString() };
                testList.Items.Add(lv1);
            }

        }

        protected void testList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["CustID"] == null)
                return;
            var selectedVal = testList.SelectedValue;
            List<CustomerTestParameters> objList1 = objDbController.GetCustomerTestParameters(Int32.Parse(Session["CustID"].ToString()), Int32.Parse(industryType.SelectedValue));
            testList.Items.Clear();

            foreach (var customerTestParameterse in objList1)
            {
                TestParameterInfo objGetTestParameterInfo =
                    objDbController.GetTestParameterInfo(customerTestParameterse.TestParametersId);
                ListItem lv1 = new ListItem { Text = objGetTestParameterInfo.AccreditedTestParameter, Value = objGetTestParameterInfo.TestParameterId.ToString() };
                testList.Items.Add(lv1);
            }
            testList.SelectedValue = selectedVal;

            List<CustomerTestParameters> objList = objDbController.GetCustomerTestParameters(Int32.Parse(Session["CustID"].ToString()), Int32.Parse(industryType.SelectedValue), Int32.Parse(testList.SelectedValue));
            testList.Items.Clear();


            if (objList.Count > 0)
                spcType.SelectedValue = spcType.Items.FindByText(objList[0].Specification).Value;
        }

        protected void industryType_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}