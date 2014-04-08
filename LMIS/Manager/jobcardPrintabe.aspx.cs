using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;
using System.Web.UI.HtmlControls;
namespace LMIS.LabAssistants
{
    public partial class jobcardPrintabe : System.Web.UI.Page
    {
        private static readonly DbController objDbController = new DbController();
        private ActiveTestsInfo objActiveTestInfo;
        private CustomerInfo objCustomerInfo;
        private JobInfo objJobInfo;
        private SampleDetail objSampleDetail;
        private Bottle objBottle;
        private ContactInfo objContactInfo;
        private TestResult objTestResult;
        private SystemUsers objSystemUsers;
        private TestParameterInfo objParameterInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {
                objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));
                objCustomerInfo = objDbController.GetCustomerInfo(objActiveTestInfo.Customer.CustID);
                objJobInfo = objDbController.GetJobInfoByJobId(objActiveTestInfo.JobInfoId);
                objSampleDetail = objDbController.GetSampleDetailByTestId(objActiveTestInfo.ActiveTestId);
                objBottle = objDbController.GetBottleBybbottleId(objSampleDetail.JobBottleDetailId);
                objContactInfo = objDbController.GetContactInfo(objActiveTestInfo.Attention);
                objTestResult = objDbController.GetTestResultById(objActiveTestInfo.ActiveTestId);
                objSystemUsers = objDbController.GetSystemUser(objTestResult.LastUpdateBy);
                objParameterInfo = objDbController.GetTestParameterInfo(objTestResult.TestParameterInfoId);

                CustomerID.Text = objCustomerInfo.CustID.ToString();
                Address1.Text = objCustomerInfo.Address;
                City.Text = objCustomerInfo.City;
                Postcode.Text = objCustomerInfo.Poscode.ToString();
                State.Text = objCustomerInfo.State;
                Date.Text = objActiveTestInfo.DateCreated.ToShortDateString();
                ReportTo.Text = "";
                Instrument.Text = "";
                Signature1.Text = "";

                SpecificationID.Text = "";
                SpecificationDescription.Text = objActiveTestInfo.Specification;

                SampleDescription.Text = objActiveTestInfo.SampleDescription;
                NumberofSample.Text = "";
                SampleReceivedDate.Text = objActiveTestInfo.SampleRecievedOn.ToString();
                SamplePacking.Text = "";
                SampleDoneBy.Text = "";

                IList<TestResult> testResult = objDbController.GetTestResult(Int32.Parse(Page.Request.QueryString["atid"]));
                foreach (var result in testResult)
                {
                    TestParameterInfo objTestParameterInfo = objDbController.GetTestParameterInfo(result.TestParameterInfoId);
                    if (!(Int32.Parse(Page.Request.QueryString["tid"]) == 0 || Int32.Parse(Page.Request.QueryString["tid"]) == objTestParameterInfo.TestParameterId))
                        continue;
                    HtmlTableRow row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.TestParameterId.ToString() });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.AccreditedTestParameter });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = result.Result.ToString() });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.MDL });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.Unit });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.MDL });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.MDL.SkipWhile(c => c != '.').Skip(1).Count().ToString() });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.Equipment });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = objTestParameterInfo.TestMethod });
                    row.Cells.Add(new HtmlTableCell { InnerHtml = result.Status });

                    TestDetailTable.Controls.Add(row);
                }
            }
            if (Session["ActionType"].ToString() == "Print")
            {
                Helper.PrintWebControl(pnl1, (string)Session["Template"]);
            }
            else
            {
                Helper.EmailWebControl(pnl1, (string)Session["ToEmail"], (string)Session["Template"]);
            }
        }
    }
}