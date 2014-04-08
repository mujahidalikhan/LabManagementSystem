using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public struct ReportStruct
    {
        public int _userId;
        public string _userName;
        public int _testId;
        public string _testName;
    }
    public partial class PerformanceReports : System.Web.UI.Page
    {
        private IList<TestParameterInfo> _listTestParameterInfo;
        private IList<SystemUsers> _listSystemUsers;
        private TestResult _objTestResult;
        private static readonly DbController ObjDbController = new DbController();
        Dictionary<int, ReportStruct> _mainList = new Dictionary<int, ReportStruct>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            _listSystemUsers = ObjDbController.GetSystemUserByRole('L');
            _listTestParameterInfo = ObjDbController.GetTestInfo();

            int count = 0;
            ReportStruct objReportStruct = new ReportStruct();
            foreach (var testParam in _listTestParameterInfo)
            {
                objReportStruct._testId = testParam.TestParameterId;
                objReportStruct._testName = testParam.AccreditedTestParameter;

                foreach (var user in _listSystemUsers)
                {
                    objReportStruct._userId = user.UserId;
                    objReportStruct._userName = user.FirstName + " " + user.LastName;
                    _mainList.Add(count, objReportStruct);
                    count++;
                }
            }

            ReportTable.Controls.Clear();
            TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "", Width = 50 });
            foreach (var user in _listSystemUsers)
            {
                tablHeadereRow.Cells.Add(new TableHeaderCell {Text = user.FirstName + " " + user.LastName, Width = 50});
            }
            ReportTable.Rows.Add(tablHeadereRow);

            int rowCount = 0;
            var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody };
            foreach (var entry in _mainList)
            {
                ReportStruct objRpt = entry.Value;
                _objTestResult = ObjDbController.GetTestResultByUserAndTestParam(objRpt._userId, objRpt._testId);


                if(rowCount == 0)
                {
                    tableBodyRow.Cells.Add(new TableCell { Text = objRpt._testName });
                }

                if ((rowCount % _listSystemUsers.Count) == 0 && rowCount != 0)
                {
                    ReportTable.Rows.Add(tableBodyRow);
                    tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody };
                    tableBodyRow.Cells.Add(new TableCell { Text = objRpt._testName });
                    tableBodyRow.Cells.Add(new TableCell { Text = _objTestResult.Result.ToString() });
                }
                else
                {
                    tableBodyRow.Cells.Add(new TableCell {Text = _objTestResult.Result.ToString()});
                }
                rowCount++;
            }
            

        }
    }
}