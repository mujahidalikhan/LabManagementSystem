using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;
using System.Web.UI.HtmlControls;
namespace LMIS.Admin
{
    public partial class COAEmail : System.Web.UI.Page
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
        private int _height;
        protected void Page_Load(object sender, EventArgs e)
        {
            _height = 0;
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {
                objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));
                objCustomerInfo = objDbController.GetCustomerInfo(objActiveTestInfo.Customer.CustID);
                objDbController.GetJobInfoByJobId(objActiveTestInfo.JobInfoId);
                objSampleDetail = objDbController.GetSampleDetailByTestId(objActiveTestInfo.ActiveTestId);
                objBottle = objDbController.GetBottleBybbottleId(objSampleDetail.JobBottleDetailId);
                objContactInfo = objDbController.GetContactInfo(objActiveTestInfo.Attention);
                objTestResult = objDbController.GetTestResultById(objActiveTestInfo.ActiveTestId);
                objSystemUsers = objDbController.GetSystemUser(objTestResult.LastUpdateBy);
                objDbController.GetTestParameterInfo(objTestResult.TestParameterInfoId);
                IList<TestResult> testResult = objDbController.GetTestResult(Int32.Parse(Page.Request.QueryString["atid"]));
                objCustomerInfo = objDbController.GetCustomerInfo(objActiveTestInfo.Customer.CustID);

                LabNoAnalysis.Text = objActiveTestInfo.LabNumber;
                ReportDateAnalysis.Text = objActiveTestInfo.DateCreated.ToShortDateString();
                AnalysisTo1.Text = objCustomerInfo.CustName;
                AnalysisTo2.Text = objCustomerInfo.Address;
                AnalysisTo3.Text = objCustomerInfo.City + " " + objCustomerInfo.Poscode + " " + objCustomerInfo.State;
                AnalysisTo4.Text = objCustomerInfo.Country;
                AttentionAnalysis.Text = objContactInfo.Salutation + " " + objContactInfo.Name;
                SampleDescriptionAnalysis.Text = objSampleDetail.SampleDescription;
                if (objSampleDetail.SampleCollectDate != null)
                    SampleReceivedOn.Text = string.Format("{0}.{1}.{2}", objSampleDetail.SampleCollectDate.Value.Day, objSampleDetail.SampleCollectDate.Value.Month, objSampleDetail.SampleCollectDate.Value.Year);
                else
                {
                    SampleReceivedOn.Text = "-";
                }
                SamplePackingAnalysis.Text = objBottle.PreservativeChemical;
                SamplePackingAnalysis2.Text = objBottle.VolumeType1;
                SamplePackingAnalysis3.Text = objBottle.VolumeType2;
                SamplePackingAnalysis4.Text = objBottle.VolumeType3;
                TypeofSamplingAnalysis.Text = objSampleDetail.TypeOfSampling;
                AnalysisConditions.Text = objActiveTestInfo.AnalysisCondition;
                _height += 280;
                TestInfoTable.Controls.Clear();
                TableHeaderRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
                TableHeaderRow tableBodyRow3 = new TableHeaderRow { TableSection = TableRowSection.TableHeader };
                tableBodyRow3.Cells.Add(new TableCell { Text = "<hr style=\"margin-bottom: -1px\"> </hr>", ColumnSpan = 6 });
                TestInfoTable.Controls.Add(tableBodyRow3);
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Parameters", Height = Unit.Pixel(20), HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Height = Unit.Pixel(20), HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Result", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Specification", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Equipment", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Method", HorizontalAlign = HorizontalAlign.Left });
                TestInfoTable.Rows.Add(tablHeadereRow);
                TableHeaderRow tableBodyRow2 = new TableHeaderRow { TableSection = TableRowSection.TableHeader };
                tableBodyRow2.Cells.Add(new TableCell { Text = "<hr style=\"margin-bottom: -1px\"> </hr>", ColumnSpan = 6 });
                TestInfoTable.Controls.Add(tableBodyRow2);
                _height += 20;
                foreach (var result in testResult)
                {
                    TestParameterInfo objTestParameterInfo = objDbController.GetTestParameterInfo(result.TestParameterInfoId);
                    if (objTestParameterInfo.TestParameterId == 0)
                        continue;
                    using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                    {
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.AccreditedTestParameter });
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.Unit });
                        var resultLabel = new Label { ID = "result" + result.TestResultId };
                        resultLabel.Text = result.Result.ToString("0.00", CultureInfo.InvariantCulture);
                        string currentSpc = objActiveTestInfo.Standard;
                        resultLabel.ToolTip += string.Format("{0}|{1}", currentSpc, result.TestResultId);
                        var tableCell2 = new TableCell();
                        tableCell2.Controls.Add(resultLabel);
                        tableBodyRow.Cells.Add(tableCell2);
                        var mdl = new Label { ID = "mdl" + result.TestResultId, Text = objTestParameterInfo.MDL, ForeColor = System.Drawing.Color.Black };
                        var tableMdlCell = new TableCell();
                        tableMdlCell.Controls.Add(mdl);
                        tableBodyRow.Cells.Add(tableMdlCell);
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.Equipment });
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.TestMethod });
                        TestInfoTable.Controls.Add(tableBodyRow);
                        {
                            try
                            {
                                resultLabel = (Label)pnl1.FindControl("result" + result.TestResultId);
                                SetSpcValue(ref resultLabel);
                                resultLabel.ToolTip = null;
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    _height += 15;

                }

                TableRow tableBodyRow1 = new TableRow { TableSection = TableRowSection.TableBody };
                tableBodyRow1.Cells.Add(new TableCell { Text = "<hr style=\"margin-bottom: -6px\"> </hr>", ColumnSpan = 6 });
                TestInfoTable.Controls.Add(tableBodyRow1);
                NameAnalysis.Text = objSystemUsers.FirstName + " " + objSystemUsers.LastName;
                if (objSystemUsers.Type.ToString().ToUpper() == "L")
                    TypeAnalysis.Text = "Lab Assistant";
                else if (objSystemUsers.Type.ToString().ToUpper() == "S")
                    TypeAnalysis.Text = "Batching";
                else if (objSystemUsers.Type.ToString().ToUpper() == "M")
                    TypeAnalysis.Text = "Verification";
                _height += 120;
                if (_height >= 1830)
                {
                    int remainingHeight = _height % 1830;
                    for (int i = 0; i < remainingHeight; i += 15)
                    {
                        LabelSpace.Text = "<br />";
                    }
                }
                else
                {
                    int remainingHeight = 1830 - _height;
                    for (int i = 0; i < remainingHeight; i += 15)
                    {
                        LabelSpace.Text = "<br />";
                    }
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

        private void SetSpcValue(ref Label tb)
        {
            try
            {
                var tooltex = tb.ToolTip.Split('|');
                var list = new char[2] { '<', '*' };
                var val = tb.Text.TrimEnd(list);
                var stdA = (Label)pnl1.FindControl("stdA" + tb.ID.Substring(6));
                var stdB = (Label)pnl1.FindControl("stdB" + tb.ID.Substring(6));
                var mdl = (Label)pnl1.FindControl("mdl" + tb.ID.Substring(6));
                var currentVal = decimal.Parse(val);
                if (tb.Text.Contains("<") || tb.Text.Contains("*"))
                    return;
                var mdlValCheck = mdl.Text.Split('-');
                try
                {
                    if (mdlValCheck.Length == 2)
                    {
                        if (currentVal < decimal.Parse(mdlValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "<" + mdl.Text;

                            return;
                        }
                        tb.ForeColor = System.Drawing.Color.FromArgb(0x74, 0x88, 0x97);
                        tb.Text = val;
                    }
                    else
                    {
                        if (currentVal < decimal.Parse(mdlValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "<" + mdl.Text;

                            return;
                        }
                        tb.ForeColor = System.Drawing.Color.FromArgb(0x74, 0x88, 0x97);
                        tb.Text = val;
                    }
                }
                catch (Exception ex)
                {

                }

                var stdAValCheck = stdA.Text.Split('-');
                if (stdAValCheck[0].Contains("Standard"))
                {
                    if (stdAValCheck[0].Contains("Others"))
                        stdAValCheck[0] = stdAValCheck[0].Remove(0, 16);
                    else
                        stdAValCheck[0] = stdAValCheck[0].Remove(0, 11);
                }
                try
                {
                    if (stdAValCheck.Length == 2)
                    {
                        if (currentVal > decimal.Parse(stdAValCheck[0]) && currentVal < decimal.Parse(stdAValCheck[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.FromArgb(0x74, 0x88, 0x97);
                            tb.Text = val;
                            return;
                        }

                        else if (currentVal > decimal.Parse(stdAValCheck[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;
                            tb.Text = "*" + val;
                            return;
                        }
                    }
                    else
                    {
                        if (currentVal < decimal.Parse(stdAValCheck[0]) && currentVal > decimal.Parse(stdAValCheck[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.FromArgb(0x74, 0x88, 0x97);
                            tb.Text = val;
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}