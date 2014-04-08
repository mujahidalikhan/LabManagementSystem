using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Manager
{
    public partial class DashboardSpecification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
                return;

            Specname.Text = Page.Request.QueryString["specid"];
            SpecificationTable.Controls.Clear();
            TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Test Parameter", Height = Unit.Pixel(20) });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Urgent" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Non-Urgent" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Completed" });
            SpecificationTable.Rows.Add(tablHeadereRow);


            List<Specification> listSpecificationTest =SpecificationController.GetSpecificationByName(Page.Request.QueryString["specid"]);

            foreach (var specification in listSpecificationTest)
            {
                int urgent = 0;
                int complete = 0;
                int nourgent = 0;
                List<TestResult> listTestResult = Global.ObjDbController.GetTestResultByTestParameterInfoId(specification.TestId.TestParameterId);
                foreach (var testResult in listTestResult)
                {
                    ActiveTestsInfo objActiveTestsInfo =
                        Global.ObjDbController.GetActiveTestInfo(testResult.ActiveTestId);
                    if(objActiveTestsInfo.CurrentStatus == "Completed")
                    {
                        complete++;
                    }
                    else if (objActiveTestsInfo.Urgent == "True")
                    {
                        urgent++;
                    }
                    else if (objActiveTestsInfo.Urgent == "False")
                    {
                        nourgent++;
                    }
                }
            
                using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                {
                    var tableCell = new TableCell();
                    tableCell.Text = String.Format(" <a href=\"DashboardParameter.aspx?testId={0}&specid={1}&testName={2}\" title=\"{0}\" class=\"icon-2 info-tooltip\">{2}</a>", specification.TestId.TestParameterId, Page.Request.QueryString["specid"], specification.TestId.AccreditedTestParameter);
                    tableBodyRow.Cells.Add(tableCell);
                    tableBodyRow.Cells.Add(new TableCell { Text = urgent.ToString(), ForeColor = Color.Red });
                    tableBodyRow.Cells.Add(new TableCell { Text = nourgent.ToString() });
                    tableBodyRow.Cells.Add(new TableCell { Text = complete.ToString() });
                    SpecificationTable.Rows.Add(tableBodyRow);
                }
            }
        }
    }
}