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


                TestInfoTable.Controls.Clear();
                TableHeaderRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Accredited Test Parameter", Height = Unit.Pixel(20), HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Unit", Height = Unit.Pixel(20), HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Result", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Status", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "MDL", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Standard", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Method", HorizontalAlign = HorizontalAlign.Left });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Equipment", HorizontalAlign = HorizontalAlign.Left });
                TestInfoTable.Rows.Add(tablHeadereRow);

                IList<TestResult> testResult = objDbController.GetTestResult(Int32.Parse(Page.Request.QueryString["atid"]));
                foreach (var result in testResult)
                {

                    TestParameterInfo objTestParameterInfo =
                        objDbController.GetTestParameterInfo(result.TestParameterInfoId);

                    if (objTestParameterInfo.TestParameterId == 0)
                        continue;

                    objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));
                    using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                    {
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.AccreditedTestParameter });
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.Unit });

                        string currentSpc = "-";
                        currentSpc = objTestParameterInfo.MDL;
                        CustomerTestParameters objCustomerTestParameters =
                            objDbController.GetCustomerTestSpecification(objActiveTestInfo.Customer.CustID,
                                                                         0,
                                                                         result.TestParameterInfoId);
                        
                        {
                            var resultLabel = new Label { ID = "result" + result.TestResultId };

                            if (result.IsValueEntered)
                                resultLabel.Text = result.Result.ToString("0.00", CultureInfo.InvariantCulture);
                            else if (result.IsLocked)
                            {
                                SystemUsers objLockByUser = Global.ObjDbController.GetSystemUser(result.TmpChangeBy);
                                resultLabel.Text = "Locked User " +
                                                   objLockByUser.FirstName + " " +
                                objLockByUser.LastName;
                            }
                            else
                            {
                                resultLabel.Text = " ";
                            }
                            currentSpc = objActiveTestInfo.Standard;
                            resultLabel.ToolTip += string.Format("{0}|{1}", currentSpc, result.TestResultId);


                            var tableCell2 = new TableCell();
                            tableCell2.Controls.Add(resultLabel);
                            tableBodyRow.Cells.Add(tableCell2);


                        }
                        tableBodyRow.Cells.Add(new TableCell { Text = result.Status });
                        var mdl = new Label { ID = "mdl" + result.TestResultId, Text = objTestParameterInfo.MDL ,ForeColor =System.Drawing.Color.Black};
                        var tableMdlCell = new TableCell();
                        tableMdlCell.Controls.Add(mdl);
                        tableBodyRow.Cells.Add(tableMdlCell);
                        SpecificationController.SetSpecificationValueInTable(result, tableBodyRow, objActiveTestInfo.Specification, objTestParameterInfo.TestParameterId,
                                                                             objTestParameterInfo, objActiveTestInfo.Standard);
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.TestMethod });
                        tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.Equipment });

                        TestInfoTable.Controls.Add(tableBodyRow);
                        {
                            try
                            {
                                var resultLabel = (Label)pnl1.FindControl("result" + result.TestResultId);
                                SetSpcValue(ref resultLabel);
                                resultLabel.ToolTip = null;
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }

            }

            if ((string)Session["ActionType"].ToString() == "Print")
            {
                Helper.PrintWebControl(pnl1, (string)Session["Template"]);
            }
            else
            {
                Helper.EmailWebControl(pnl1, (string)Session["ToEmail"], (string)Session["Template"]);
            }
        }


        private void SetSpcValue(TextBox tb)
        {
            try
            {
                var tooltex = tb.ToolTip.Split('|');
                var list = new char[2] { '<', '*' };
                var val = tb.Text.TrimEnd(list);
                var stdA = (Label)pnl1.FindControl("stdA" + tb.ID.Substring(6));
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
                        tb.ForeColor = System.Drawing.Color.Black;
                        ;
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
                        tb.ForeColor = System.Drawing.Color.Black;
                        ;
                        tb.Text = val;
                    }
                }
                catch (Exception ex)
                {

                }

                var stdAValCheck = stdA.Text.Split('-');
                if (stdAValCheck[0].Contains("Standard"))
                {
                    stdAValCheck[0] = stdAValCheck[0].Remove(0, 11);
                }
                try
                {
                    if (stdAValCheck.Length == 2)
                    {
                        if (currentVal < decimal.Parse(stdAValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            ;
                            tb.Text = val;
                            return;
                        }

                    }
                    else
                    {
                        if (currentVal < decimal.Parse(stdAValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            ;
                            tb.Text = val;
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {

                }




                String[] Specification = tooltex[0].Split('-');
                try
                {
                    if (Specification.Length == 1)
                    {
                        if (tooltex[0] == "-")
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            ;
                            tb.Text = val;
                        }
                        else if (currentVal < decimal.Parse(tooltex[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;
                            tb.Text = "<" + val;
                        }
                        else if (currentVal > decimal.Parse(tooltex[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;
                            tb.Text = "*" + val;
                        }
                        else
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            ;
                            tb.Text = val;
                        }
                    }
                    else
                    {
                        if (currentVal < decimal.Parse(Specification[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;
                            tb.Text = "<" + val;
                        }
                        else if (currentVal > decimal.Parse(Specification[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;
                            tb.Text = "*" + val;
                        }
                        else
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            ;
                            tb.Text = val;
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
                var currentVal = float.Parse(val);
                if (tb.Text.Contains("<") || tb.Text.Contains("*"))
                    return;
                var mdlValCheck = mdl.Text.Split('-');
                try
                {
                    if (mdlValCheck.Length == 2)
                    {
                        if (currentVal < float.Parse(mdlValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "<" + mdl.Text;

                            return;
                        }
                        tb.ForeColor = System.Drawing.Color.Black;
                        tb.Text = val;
                    }
                    else
                    {
                        if (currentVal < float.Parse(mdlValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "<" + mdl.Text;

                            return;
                        }
                        tb.ForeColor = System.Drawing.Color.Black;
                        tb.Text = val;
                    }
                }
                catch (Exception ex)
                {

                }

                var stdAValCheck = stdA.Text.Split('-');
                if (stdAValCheck[0].Contains("Standard"))
                {
                    stdAValCheck[0] = stdAValCheck[0].Remove(0, 11);
                }
                try
                {
                    if (stdAValCheck.Length == 2)
                    {
                        if (currentVal < float.Parse(stdAValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            tb.Text = val;
                            return;
                        }

                    }
                    else
                    {
                        if (currentVal < float.Parse(stdAValCheck[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            tb.Text = val;
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {

                }




                String[] Specification = tooltex[0].Split('-');
                try
                {
                    if (Specification.Length == 1)
                    {
                        if (tooltex[0] == "-")
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            tb.Text = val;
                        }
                        else if (currentVal < float.Parse(tooltex[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "<" + val;

                        }
                        else if (currentVal > float.Parse(tooltex[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "*" + val;

                        }
                        else
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            tb.Text = val;
                        }
                    }
                    else
                    {
                        if (currentVal < float.Parse(Specification[0]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "<" + val;

                        }
                        else if (currentVal > float.Parse(Specification[1]))
                        {
                            tb.ForeColor = System.Drawing.Color.Red;

                            tb.Text = "*" + val;

                        }
                        else
                        {
                            tb.ForeColor = System.Drawing.Color.Black;
                            tb.Text = val;
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