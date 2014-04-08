using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class ArchiveJobList : System.Web.UI.Page
    {
        private static List<JobInfoArchive> qotationList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            qotationList = Global.ObjJobController.GetJobInfoArchive();
            JobTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow
                                    {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
            tableRow.Cells.Add(new TableHeaderCell {Text = "Job Number", Height = Unit.Pixel(20)});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Customer Name"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Date Created"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Validity"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Status"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Options"});
            JobTable.Rows.Add(tableRow);


            if (qotationList.Count <= 0) return;

            foreach (var objJobInfo in qotationList)
            {
                try
                {
                    tableRow = new TableRow {TableSection = TableRowSection.TableBody};
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.JobNumber});
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.Customer.CustName});
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.CreateDate.ToShortDateString()});
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.Validatily.ToShortDateString()})
                        ;
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.Status});
                    TableCell tableCell;
                    using (tableCell = new TableCell())
                    {
                        tableCell.Text = String.Format(
                            " <a href=\"ViewArchiveJob.aspx?qid={0}\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>",
                            objJobInfo.JobId);

                        tableRow.Cells.Add(tableCell);
                    }
                    JobTable.Rows.Add(tableRow);
                }
                catch(Exception ex)
                {
                    
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddJob.aspx");
        }

       
    }
}