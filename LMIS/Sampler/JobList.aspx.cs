using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBModel;

namespace LMIS.Sampler
{
    public partial class JobList : System.Web.UI.Page
    {
        private static List<JobInfo> qotationList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            qotationList = Global.ObjJobController.GetJobInfo();
            JobTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow
                                    {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
            tableRow.Cells.Add(new TableHeaderCell {Text = "Lab Number", Height = Unit.Pixel(20)});
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
                    string labNumber = objJobInfo.JobNumber;
                    try
                    {
                        if (objJobInfo.JobNumber.Contains("/"))
                        {
                            string val1 = objJobInfo.JobNumber.Remove(objJobInfo.JobNumber.Length - 4, objJobInfo.JobNumber.Length - (objJobInfo.JobNumber.Length - 4));
                            string val2 = objJobInfo.JobNumber.Remove(0, objJobInfo.JobNumber.Length - 1);
                            labNumber = val1 + val2;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    tableRow.Cells.Add(new TableCell { Text = labNumber });
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.Customer.CustName});
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.CreateDate.ToShortDateString()});
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.Validatily.ToShortDateString()})
                        ;
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.Status});
                    var tableCell = new TableCell();
                    if (objJobInfo.Customer.Status == "Deleted")
                    {
                        tableCell.Text = String.Format(
                                  " <a href=\"DeleteQInfo.aspx?qid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" +
                                  " <a href=\"ViewJob.aspx?qid={0}\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>",
                                  objJobInfo.JobId);
                    }
                    else switch (objJobInfo.Status)
                    {
                        case "Awaiting Start":
                            tableCell.Text = String.Format(

                                " <a href=\"DeleteQInfo.aspx?qid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" +
                                " <a href=\"ViewJob.aspx?qid={0}&st=ap\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/error/accept.png' width='16' height='16' alt='icon' />Start</a>",
                                objJobInfo.JobId);
                            break;
                        case "Reject":
                        case " Awaiting Approval":
                        case "Incomplete":
                            tableCell.Text = String.Format(
                                "<a href=\"AddJob.aspx?qid={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a> " +
                                " <a href=\"DeleteQInfo.aspx?qid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" +
                                " <a href=\"ViewJob.aspx?qid={0}\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>",
                                objJobInfo.JobId);
                            break;
                        default:
                            if (objJobInfo.Status != "In Progress")
                            {
                                tableCell.Text = String.Format(
                                    " <a href=\"ViewJob.aspx?qid={0}\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>",
                                    objJobInfo.JobId);
                            }
                            else
                            {
                                tableCell.Text = String.Format(
                                    " <a href=\"ViewJob.aspx?qid={0}\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>",
                                    objJobInfo.JobId);
                            }
                            break;
                    }
                    tableRow.Cells.Add(tableCell);
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