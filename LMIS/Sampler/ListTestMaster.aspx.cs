using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Sampler
{
    public partial class ListTestMaster : System.Web.UI.Page
    {
        private static IList<SampleDetail> SampleDetailList;
        private static readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SampleDetailList = SampleDetailController.GetSamplerTest();

                testMasterList.Controls.Clear();
                TableRow tablHeadereRow = new TableHeaderRow {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Job ", Height = Unit.Pixel(20) });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Customer Name", Height = Unit.Pixel(20) });
           
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Test Parmeters" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Date Created" });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Status" ,Width = 100});
                tablHeadereRow.Cells.Add( new TableHeaderCell { Text = "Options" ,Width = 100});
                testMasterList.Rows.Add(tablHeadereRow);

                if (SampleDetailList.Count > 0)
                {
                    int counter = 0;
                    foreach (SampleDetail sampleDeatil in SampleDetailList)
                    {
                        using (var tableBodyRow = new TableRow {TableSection = TableRowSection.TableBody})
                        {
                            ActiveTestsInfo objActiveTestInfo = Global.ObjDbController.GetActiveTestInfo(sampleDeatil.TestId);
                            if(objActiveTestInfo.ActiveTestId ==0)
                                continue;
                            tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.JobDetail.JobInfo.JobNumber });
                            tableBodyRow.Cells.Add( new TableCell {Text = objActiveTestInfo.Customer.CustName});
                           
                            tableBodyRow.Cells.Add(new TableCell { Text = objActiveTestInfo.JobDetail.TestInfo });
                            tableBodyRow.Cells.Add(new TableCell {Text = objActiveTestInfo.DateCreated.ToShortDateString()});
                            tableBodyRow.Cells.Add( new TableCell {Text = objActiveTestInfo.CurrentStatus});
                            tableBodyRow.Cells.Add( new TableCell
                                            {
                                                Text = String.Format(
                                                    "<a href=\"TestMaster.aspx?atid={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a> ",
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