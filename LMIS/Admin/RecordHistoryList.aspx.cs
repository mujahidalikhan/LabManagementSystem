using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class RecordHistoryList : System.Web.UI.Page
    {
        private static IList<RecordHistory> _recordHistory;
        private static readonly DbController ObjDbController = new DbController();
        protected void Page_Load(object sender, EventArgs e)
        {       
            if (!IsPostBack)
            {
                _recordHistory = ObjDbController.RetrieveAllRecordHistory();
                recordHistoryList.Controls.Clear();
                TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "User Name", Width = 100 });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Job ID", Width = 100 });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Date", Width = 100 });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Status", Width = 100 });
                tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Description", Width = 100 });
                recordHistoryList.Rows.Add(tablHeadereRow);

                if (_recordHistory.Count > 0)
                {
                    foreach (RecordHistory objRecordHistory in _recordHistory)
                    {
                        try
                        {
                            using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                            {
                                tableBodyRow.Cells.Add(new TableCell { Text = objRecordHistory.UserName });
                                tableBodyRow.Cells.Add(new TableCell { Text = objRecordHistory.JobID.ToString() });
                                tableBodyRow.Cells.Add(new TableCell { Text = objRecordHistory.Timestamp });
                                tableBodyRow.Cells.Add(new TableCell { Text = objRecordHistory.Status });
                                tableBodyRow.Cells.Add(new TableCell { Text = objRecordHistory.Description });
                                recordHistoryList.Rows.Add(tableBodyRow);
                            }
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