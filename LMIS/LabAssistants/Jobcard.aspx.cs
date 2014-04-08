using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;


namespace LMIS.LabAssistants
{
    public partial class Jobcard : System.Web.UI.Page
    {
        private static readonly DbController objDbController = new DbController();
        private ActiveTestsInfo objActiveTestInfo;
        private static string selectedTest;

        protected void Page_Load(object sender, EventArgs e)
        {
            IList<TestResult> testResult = objDbController.GetTestResult(Int32.Parse(Page.Request.QueryString["atid"]));
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {
                SampleInformationTable.Controls.Clear();
                var SampleInformationTableHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
                SampleInformationTableHeadereRow.Cells.Add(new TableHeaderCell { Text = "Sample Description", Height = Unit.Pixel(20) });
                SampleInformationTableHeadereRow.Cells.Add(new TableHeaderCell { Text = "Point Number", Height = Unit.Pixel(20) });
                SampleInformationTableHeadereRow.Cells.Add(new TableHeaderCell { Text = "Type of Sampling", Height = Unit.Pixel(20) });
                SampleInformationTable.Rows.Add(SampleInformationTableHeadereRow);
                var listSampleDetail = SampleDetailController.Get(Int32.Parse(Page.Request.QueryString["atid"]), true);
                if (listSampleDetail.Count > 0)
                {
                    foreach (var result in listSampleDetail)
                    {
                        using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                        {
                            tableBodyRow.Cells.Add(new TableCell { Text = result.SampleDescription });
                           
                            if (result.SampleCollectDate != null)
                            {
                                tableBodyRow.Cells.Add(new TableCell
                                {
                                    Text =
                                        String.Format("{0}/{1}/{2} {3}:{4}",
                                                      result.SampleCollectDate.Value.Day,
                                                      result.SampleCollectDate.Value.Month,
                                                      result.SampleCollectDate.Value.Year,
                                                      result.SampleCollectDate.Value.Hour,
                                                      result.SampleCollectDate.Value.Minute)
                                });
                            }
                            else
                            {
                                tableBodyRow.Cells.Add(new TableCell { Text = "&nbsp;" });
                            }
                            tableBodyRow.Cells.Add(new TableCell { Text = result.TypeOfSampling });
                            SampleInformationTable.Rows.Add(tableBodyRow);
                        }
                    }
                }
                else
                {
                    using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                    {
                        tableBodyRow.Cells.Add(new TableCell { Text = "&nbsp;" });
                        tableBodyRow.Cells.Add(new TableCell { Text = "&nbsp;" });
                        tableBodyRow.Cells.Add(new TableCell { Text = "&nbsp; " });
                        SampleInformationTable.Rows.Add(tableBodyRow);
                    }

                }
                selectedTest = "0";
                objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));
                industryType.Text = objActiveTestInfo.IndustryId.ToString();
                ClientName.Text = objActiveTestInfo.Customer.CustName;
                analysisCondition.Text = objActiveTestInfo.AnalysisCondition;
                labNumber.Text = objActiveTestInfo.LabNumber;
                if (objActiveTestInfo.EstimatedEndTime != null)
                {
                    datepicker.Disabled = true;
                    datepicker.Value = string.Format("{0}/{1}/{2}", objActiveTestInfo.EstimatedEndTime.Value.Day,
                                                     objActiveTestInfo.EstimatedEndTime.Value.Month,
                                                     objActiveTestInfo.EstimatedEndTime.Value.Year);
                }

                statusList.Text = objActiveTestInfo.CurrentStatus;
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

            TestInfoTable.Controls.Clear();
            TableHeaderRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tablHeadereRow.Cells.Add(new TableHeaderCell {Text = "Accredited Test Parameter", Height = Unit.Pixel(20)});
            tablHeadereRow.Cells.Add(new TableHeaderCell {Text = "Unit", Height = Unit.Pixel(20)});
            tablHeadereRow.Cells.Add(new TableHeaderCell {Text = "Result"});
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Status" });
            tablHeadereRow.Cells.Add(new TableHeaderCell {Text = "MDL"});
            tablHeadereRow.Cells.Add(new TableHeaderCell {Text = "Standard"});
            tablHeadereRow.Cells.Add(new TableHeaderCell {Text = "Method"});
            tablHeadereRow.Cells.Add(new TableHeaderCell {Text = "Equipment"});
            TestInfoTable.Rows.Add(tablHeadereRow);



            foreach (var result in testResult)
            {

                TestParameterInfo objTestParameterInfo =
                    objDbController.GetTestParameterInfo(result.TestParameterInfoId);

                if (objTestParameterInfo.TestParameterId == 0)
                    continue;

                objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));
                using (var tableBodyRow = new TableRow {TableSection = TableRowSection.TableBody})
                {
                    tableBodyRow.Cells.Add(new TableCell {Text = objTestParameterInfo.AccreditedTestParameter});
                    tableBodyRow.Cells.Add(new TableCell {Text = objTestParameterInfo.Unit});

                    string currentSpc = "-";
                    currentSpc = objTestParameterInfo.MDL;
                    CustomerTestParameters objCustomerTestParameters =
                        objDbController.GetCustomerTestSpecification(objActiveTestInfo.Customer.CustID,
                                                                     0,
                                                                     result.TestParameterInfoId);
                    if (!result.IsValueEntered &&
                        (!result.IsLocked || result.TmpChangeBy == Int32.Parse(Session["userId"].ToString())))
                    {
                        var tb1 = new TextBox {ID = "result" + result.TestResultId, AutoPostBack = true};
                        tb1.TextChanged += ClientName_TextChanged;
                        tb1.Text = result.TempResultVal != 0 ? result.TempResultVal.ToString("0.00", CultureInfo.InvariantCulture) : "";
                        currentSpc = objActiveTestInfo.Standard;
                        tb1.ToolTip += string.Format("{0}|{1}", currentSpc, result.TestResultId);
                        var tableCell2 = new TableCell();
                        tableCell2.Controls.Add(tb1);
                        tableBodyRow.Cells.Add(tableCell2);
                        result.IsLocked = true;
                        result.TmpChangeBy = Int32.Parse(Session["userId"].ToString());
                        Global.ObjDbController.UpdateTestResult(result);

                       
                    }
                    else
                    {
                        var resultLabel = new Label
                                              {ID = "result" + result.TestResultId};

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
                    var mdl = new Label {ID = "mdl" + result.TestResultId, Text = objTestParameterInfo.MDL};
                    var tableMdlCell = new TableCell();
                    tableMdlCell.Controls.Add(mdl);
                    tableBodyRow.Cells.Add(tableMdlCell);
                    SpecificationController.SetSpecificationValueInTable(result, tableBodyRow, objActiveTestInfo.Specification, objTestParameterInfo.TestParameterId,
                                                                         objTestParameterInfo,objActiveTestInfo.Standard);
                    tableBodyRow.Cells.Add(new TableCell { Text = objTestParameterInfo.TestMethod });
                    tableBodyRow.Cells.Add(new TableCell {Text = objTestParameterInfo.Equipment});

                    TestInfoTable.Controls.Add(tableBodyRow);
                    if ((!result.IsValueEntered &&
                         (!result.IsLocked || result.TmpChangeBy == Int32.Parse(Session["userId"].ToString()))))
                    {
                        if (!IsPostBack)
                        {
                            var resultLabel = (TextBox) pnl1.FindControl("result" + result.TestResultId);
                            SetSpcValue(resultLabel);
                        }
                    }
                    else
                    {
                        try
                        {
                            var resultLabel = (Label) pnl1.FindControl("result" + result.TestResultId);
                            SetSpcValue(ref resultLabel);
                            resultLabel.ToolTip = null;
                        }
                        catch(Exception ex)
                        {
                            
                        }
                    }
                }
                isChangeRequest = true;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<TestResult> listUpdatedResult =
                Global.ObjDbController.GetTempUpdateResultByUser(Int32.Parse(Session["userId"].ToString()), Int32.Parse(Page.Request.QueryString["atid"]));
            foreach (var testResult in listUpdatedResult)
            {
                if (testResult.IsValueModify && !testResult.IsValueEntered)
                {
                    testResult.IsValueEntered = true;
                    testResult.Result = testResult.TempResultVal;
                  
                    testResult.LastUpdateBy = testResult.TmpChangeBy;
                    testResult.LastUpdateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                             DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                
                }

                testResult.IsLocked = false;
               
                Global.ObjDbController.UpdateTestResult(testResult);
            }


            List<TestResult> listTestdResult =
                Global.ObjDbController.GetTestResult(Int32.Parse(Page.Request.QueryString["atid"]));
            var isComplete = listTestdResult.All(testResult => testResult.IsValueEntered);
         
            objActiveTestInfo = objDbController.GetActiveTestInfo(Int32.Parse(Page.Request.QueryString["atid"]));

            string[] dates = datepicker.Value.Split('/');
            objActiveTestInfo.EstimatedEndTime =
                new DateTime(Int32.Parse(dates[2]), Int32.Parse(dates[1]), Int32.Parse(dates[0])).Date;
            objActiveTestInfo.LastKeyInBy = Int32.Parse(Session["userId"].ToString());
            objActiveTestInfo.LastUpdateDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                                DateTime.Now.Hour, DateTime.Now.Minute,
                                                                DateTime.Now.Second);

            RecordHistory objRecordHistory = new RecordHistory();
            objActiveTestInfo.CurrentStatus = statusList.Text;
            if (isComplete)
            {
                objActiveTestInfo.CurrentStatus = "Pending Verification";
                objActiveTestInfo.ActualEndTime =
                    new DateTime(Int32.Parse(dates[2]), Int32.Parse(dates[1]), Int32.Parse(dates[0])).Date;
                objRecordHistory.Description = "Status Updated";
            }
            else
            {
                objRecordHistory.Description = "Key In Test Result";
            }
            objRecordHistory.UserName = Session["userName"].ToString();
            objRecordHistory.JobID = objActiveTestInfo.ActiveTestId;
            objRecordHistory.Status = objActiveTestInfo.CurrentStatus;
            objRecordHistory.Timestamp = DateTime.Now.ToString();
            objDbController.AddRecordHistory(objRecordHistory);


            objDbController.UpdateActiveTestInfo(objActiveTestInfo);
            Global.ObjJobController.UpdateJobInfoByTestMasterStatus(
                objActiveTestInfo.JobDetail.JobInfo.JobId);
            Response.Redirect("ActiveTestList.aspx");
        }

        private static bool isChangeRequest = true;

        protected void ClientName_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox) sender;
            try
            {
                if (!isChangeRequest)
                {
                    isChangeRequest = true;
                    return;
                }

                string[] tooltex = tb.ToolTip.Split('|');
                char[] list = new char[2] {'<', '*'};
                string val = tb.Text.TrimEnd(list);
                float currentVal = float.Parse(val);
                String[] Specification = tooltex[0].Split('-');

                TestResult objTestResult = objDbController.GetTestResultById(Int32.Parse(tooltex[1]));
                objTestResult.IsValueModify = true;
                objTestResult.TempResultVal = currentVal;
                objDbController.UpdateTestResult(objTestResult);

                SetSpcValue(tb);
            }
            catch (Exception ex)
            {
                tb.Text = "";
            }
        }

        private void SetSpcValue(TextBox tb)
        {
            isChangeRequest = false;
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

        private void SetSpcValue(ref Label tb)
        {
            isChangeRequest = false;
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

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session["ActionType"] = "Print";

            ClientScript.RegisterStartupScript(GetType(), "onclick",
                                               string.Format(
                                                   "<script language=javascript>window.open('{0}','PrintMe','height=300px,width=300px,scrollbars=1');</script>",
                                                   string.Format("jobcardPrintabe.aspx?atid={0}&tid={1}",
                                                                 Page.Request.QueryString["atid"], selectedTest)));
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            CustomerInfo objCustomerInof = objDbController.GetCustomerData(ClientName.Text);
            ContactInfo objContactInfo = objDbController.GetContactInfo(objCustomerInof.CustID);
           
            Session["ToEmail"] = objContactInfo.Email;
            Session["ActionType"] = "Email";
            ClientScript.RegisterStartupScript(GetType(), "onclick",
                                               string.Format(
                                                   "<script language=javascript>window.open('{0}','PrintMe','height=300px,width=300px,scrollbars=1');</script>",
                                                   string.Format("jobcardPrintabe.aspx?atid={0}&tid={1}",
                                                                 Page.Request.QueryString["atid"], selectedTest)));
        }

      
        protected void Reset_Button_Click(object sender, EventArgs e)
        {

            List<TestResult> listUpdatedResult =
           Global.ObjDbController.GetTempUpdateResultByUser(Int32.Parse(Session["userId"].ToString()), Int32.Parse(Page.Request.QueryString["atid"]));
                foreach (var testResult in listUpdatedResult)
                {
             
                    testResult.IsLocked = false;
                    testResult.IsValueModify = false;
                    testResult.TempResultVal = 0;
                


                    Global.ObjDbController.UpdateTestResult(testResult);
                }
                Response.Redirect("Dashboard.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["ActionType"] = "Print";
            ClientScript.RegisterStartupScript(GetType(), "onclick",
                                               string.Format(
                                                   "<script language=javascript>window.open('{0}','PrintMe','height=300px,width=300px,scrollbars=1');</script>",
                                                   string.Format("jobcardPrintabe.aspx?atid={0}&tid={1}",
                                                                 Page.Request.QueryString["atid"], selectedTest)));
        }

   
    }
}