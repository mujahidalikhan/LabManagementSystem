using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Manager
{
    public partial class ActiveTestList : System.Web.UI.Page
    {
        private static IList<ActiveTestsInfo> activeTestsInfoList;
        private static readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                activeTestsInfoList = objDbController.RetrieveAllTestInfo();

                testMasterList.Controls.Clear();
                TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Job ", Height = Unit.Pixel(20) });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Job Card"});
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Customer Name", Height = Unit.Pixel(20) });

                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Test Parmeters" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Date Created",Width = 100});
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Status" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Options", Width = 125 });
                testMasterList.Rows.Add(tablHeadereRow);

                if (activeTestsInfoList.Count > 0)
                {
                    int counter = 0;
                    foreach (ActiveTestsInfo objActiveTestInfo in activeTestsInfoList)
                    {
                        using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                        {
                            tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.JobDetail.JobInfo.JobNumber });
                            tableBodyRow.Cells.Add(new TableCell { Text = String.Format("JC{0:d4}", objActiveTestInfo.ActiveTestId)});
                            tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.Customer.CustName });
                          
                            tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.JobDetail.TestInfo });
                            tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.DateCreated.ToShortDateString() });
                            tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.CurrentStatus });
                            tableBodyRow.Cells.Add(new TableCell
                            {
                                Text = String.Format(
                                     " <a href=\"Jobcard.aspx?atid={0}\" title=\"Job Card\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>",
                                    objActiveTestInfo.ActiveTestId)
                            });
                            testMasterList.Rows.Add(tableBodyRow);
                        }
                        counter++;
                    }

                }
            }
        }



    }
}