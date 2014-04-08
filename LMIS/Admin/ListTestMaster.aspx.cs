using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class ListTestMaster : System.Web.UI.Page
    {
        private static IList<ActiveTestsInfo> _activeTestsInfoList;
        private static IList<PointsInfo> _pointsInfo;
        private static JobInfo _jobInfo;
        private static readonly DbController ObjDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                if (Page.Request.QueryString["DateCreated"] != null)
                {
                    String[] tempDate = Page.Request.QueryString["DateCreated"].Split('-');
                    DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                    _activeTestsInfoList = Global.ObjDashboardController.getListActiveTestInfoByDate(jobDate);
                }
                else if (Page.Request.QueryString["StatusAwaiting"] != null)
                {
                    _activeTestsInfoList = Global.ObjDashboardController.getListJobCardCountByStatus(Page.Request.QueryString["Status"]);
                }
                else if (Page.Request.QueryString["StatusActive"] != null)
                {
                    _activeTestsInfoList = Global.ObjDashboardController.getListJobCardCountByStatus(Page.Request.QueryString["Status"]);
                }
                else if (Page.Request.QueryString["DateCardComplete"] != null)
                {
                    String[] tempDate = Page.Request.QueryString["DateCardComplete"].Split('-');
                    DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                    _activeTestsInfoList = Global.ObjDashboardController.getListJobCardCompleteInSevenDays(jobDate);
                }
                else if (Page.Request.QueryString["DateCollect"] != null)
                {
                    String[] tempDate = Page.Request.QueryString["DateCollect"].Split('-');
                    DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                    _activeTestsInfoList = Global.ObjDashboardController.getListSampleCollectOfWeek(jobDate);
                }
                else if (Page.Request.QueryString["DateLastComplete"] != null)
                {
                    String[] tempDate = Page.Request.QueryString["DateLastComplete"].Split('-');
                    DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                    _activeTestsInfoList = Global.ObjDashboardController.getListJobCardCompleteLastSevenDays(jobDate);
                }
                else
                {
                    _activeTestsInfoList = ObjDbController.RetrieveAllTestInfo();
                }


                testMasterList.Controls.Clear();
                TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Lab Number" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Specification" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Std" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Status"});
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Sampling Date" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Options", Width = 120 });
                testMasterList.Rows.Add(tablHeadereRow);

                if (_activeTestsInfoList.Count > 0)
                {
                    int counter = 0;
                    foreach (ActiveTestsInfo objActiveTestInfo in _activeTestsInfoList)
                    {
                        _jobInfo = ObjDbController.GetJobInfoByJobId(objActiveTestInfo.JobInfoId);
                        try
                        {
                            using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                            {
                                tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.JobDetail.JobInfo.JobNumber});
                                tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.Specification });
                                tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.Standard });
                                //tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.JobDetail.TestInfo });
                                tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.CurrentStatus });
                                tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.DateCreated.ToShortDateString() });

                                tableBodyRow.Cells.Add(new TableCell
                                                           {
                                                               Text = String.Format(
                                                                   " <a href=\"Jobcard.aspx?atid={0}\" title=\"Job Card\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>" +
                                                                   " <a href=\"DeleteActiveTest.aspx?atid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                                                                   objActiveTestInfo.ActiveTestId)
                                                           });
                                testMasterList.Rows.Add(tableBodyRow);
                            }
                            counter++;
                        }
                        catch (Exception ex)
                        {

                        }
                    }


                }
            }
        }



    }
}