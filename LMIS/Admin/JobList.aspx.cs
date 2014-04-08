using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class JobList : System.Web.UI.Page
    {
        private static List<JobInfo> qotationList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            if(Page.Request.QueryString["Date"] != null)
            {
                String [] tempDate = Page.Request.QueryString["Date"].Split('-');
                DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                qotationList = Global.ObjDashboardController.getListJobCountByDate(jobDate);
            }
            else if (Page.Request.QueryString["Status"] != null)
            {
                qotationList = Global.ObjDashboardController.getJobInfoByStatus(Page.Request.QueryString["Status"]);
            }
            else if (Page.Request.QueryString["DateProcess"] != null)
            {
                String[] tempDate = Page.Request.QueryString["DateProcess"].Split('-');
                DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                qotationList = Global.ObjDashboardController.getListPaidJobOfLastSevenDays(jobDate);
            }
            else if (Page.Request.QueryString["DateApproved"] != null)
            {
                String[] tempDate = Page.Request.QueryString["DateApproved"].Split('-');
                DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                qotationList = Global.ObjDashboardController.getListApprovedDateJobOfThisWeek(jobDate);
            }
            else if (Page.Request.QueryString["DateEmail"] != null)
            {
                String[] tempDate = Page.Request.QueryString["DateEmail"].Split('-');
                DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                qotationList = Global.ObjDashboardController.getListEmailByLastSevenDays(jobDate);
            }
            else if (Page.Request.QueryString["DateComplete"] != null)
            {
                String[] tempDate = Page.Request.QueryString["DateComplete"].Split('-');
                DateTime jobDate = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));
                qotationList = Global.ObjDashboardController.getListCompleteInSevenDays(jobDate);
            }
            else
            {
                qotationList = Global.ObjJobController.GetJobInfo();
            }
            
            JobTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow{TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
            tableRow.Cells.Add(new TableHeaderCell {Text = "Lab Number", Height = Unit.Pixel(20)});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Customer Name"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Date Created"});
            //tableRow.Cells.Add(new TableHeaderCell {Text = "Validity"});
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
                   

                    tableRow.Cells.Add(new TableCell { Text = labNumber });
                    if (objJobInfo.Customer != null)
                        tableRow.Cells.Add(new TableCell {Text = objJobInfo.Customer.CustName});
                    else
                        tableRow.Cells.Add(new TableCell { Text = "" });
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.CreateDate.ToShortDateString()});
                    //tableRow.Cells.Add(new TableCell {Text = objJobInfo.Validatily.ToShortDateString()})
                        ;
                    tableRow.Cells.Add(new TableCell {Text = objJobInfo.Status});
                    var tableCell = new TableCell();
                    if (objJobInfo.Customer != null)
                    {
                        if (objJobInfo.Customer.Status == "Deleted")
                        {
                            tableCell.Text = String.Format(
                                " <a href=\"DeleteJobInfo.aspx?qid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" +
                                " <a href=\"ViewJob.aspx?qid={0}\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/sidemenu/file.png' width='16' height='16' alt='icon' />View</a>",
                                objJobInfo.JobId);
                        }
                        else
                            switch (objJobInfo.Status)
                            {
                                case "Awaiting Start":
                                    tableCell.Text = String.Format(

                                        " <a href=\"DeleteJobInfo.aspx?qid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" +
                                        " <a href=\"ViewJob.aspx?qid={0}&st=ap\" title=\"View Job Detail\" class=\"icon-5 info-tooltip\"><img src='../images/icons/error/accept.png' width='16' height='16' alt='icon' />Start</a>",
                                        objJobInfo.JobId);
                                    break;
                                case "Reject":
                                case " Awaiting Approval":
                                case "Incomplete":
                                    tableCell.Text = String.Format(
                                        "<a href=\"AddJob.aspx?qid={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a> " +
                                        " <a href=\"DeleteJobInfo.aspx?qid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" +
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