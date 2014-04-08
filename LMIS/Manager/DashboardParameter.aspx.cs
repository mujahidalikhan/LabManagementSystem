using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Manager
{
    public partial class DashboardParameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Specname.Text = Page.Request.QueryString["specid"];
            ParamName.Text = Page.Request.QueryString["testName"];

            SpecificationTable.Controls.Clear();
            TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };

            //tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "No of Point" });
            //tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Year Month" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Lab No" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Point No" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Customer" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Sample Description" });
            SpecificationTable.Rows.Add(tablHeadereRow);

            List<Specification> listSpecificationTest = SpecificationController.GetSpecificationByName(Page.Request.QueryString["specid"]);
            TestParameterInfo objTestParameterInfo =
                Global.ObjDbController.GetTestParameterInfo(Int32.Parse(Page.Request.QueryString["testId"]));
            List<TestResult> listTestResult = Global.ObjDbController.GetTestResultByTestParameterInfoId(Int32.Parse(Page.Request.QueryString["testId"]));
            foreach (var testResult in listTestResult)
            {

                ActiveTestsInfo objActiveTestsInfo = Global.ObjDbController.GetActiveTestInfo(testResult.ActiveTestId);
                JobInfo objJobInfo = Global.ObjJobController.GetJobInfo(objActiveTestsInfo.JobInfoId);
                String SamplesDiscription = SampleDetailController.GetSamplerdescription(objActiveTestsInfo.ActiveTestId);
                using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                {
                    var tableCell = new TableCell();
                    //   tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestsInfo.ActiveTestId.ToString() });
                    //tableBodyRow.Cells.Add(new TableCell { Text = "1/1" });
                    //tableBodyRow.Cells.Add(new TableCell { Text = String.Format("{0}{1}", objActiveTestsInfo.DateCreated.Year, objActiveTestsInfo.DateCreated.Month) });
                    tableBodyRow.Cells.Add(new TableCell { Text = objJobInfo.JobNumber });
                    tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestsInfo.PointNumber.ToString() });
                    tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestsInfo.Customer.CustName });
                    tableBodyRow.Cells.Add(new TableCell { Text = SamplesDiscription });

                    tableBodyRow.BackColor = objActiveTestsInfo.Urgent == "True" ? System.Drawing.Color.Red : System.Drawing.Color.White;

                    if (objActiveTestsInfo.CurrentStatus == "Completed")
                    {
                        tableBodyRow.BackColor = System.Drawing.Color.Green;
                        tableBodyRow.ForeColor = System.Drawing.Color.White;
                    }

                    SpecificationTable.Rows.Add(tableBodyRow);
                }

            }
        }
    }
}