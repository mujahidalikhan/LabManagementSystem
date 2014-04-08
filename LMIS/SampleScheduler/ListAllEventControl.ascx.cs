using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.SampleScheduler
{
    public partial class ListAllEventControl : System.Web.UI.UserControl
    {
        private static List<LMIS.DBModel.Events> eventList;

        protected void Page_Load(object sender, EventArgs e)
        {
            eventList = Global.ObjEventsController.GetEvent();

            JobTable.Controls.Clear();
            TableRow tableRow;
            tableRow = new TableHeaderRow {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};


            TableCell tableCel2 = new TableHeaderCell {Text = "Title", Height = Unit.Pixel(20)};
            tableRow.Cells.Add(tableCel2);

            TableCell tableCell = new TableHeaderCell {Text = "Starts "};
            tableRow.Cells.Add(tableCell);
            TableCell tableCel3 = new TableHeaderCell {Text = "Ends"};
            tableRow.Cells.Add(tableCel3);


            tableRow.Cells.Add(new TableHeaderCell {Text = "Job ID"});

            tableRow.Cells.Add(new TableHeaderCell {Text = "Assigned To"});

            TableCell tableCel6 = new TableHeaderCell {Text = "Options"};
            tableRow.Cells.Add(tableCel6);

            JobTable.Rows.Add(tableRow);


            if (eventList.Count > 0)
            {
                int counter = 0;
                foreach (LMIS.DBModel.Events objJobInfo in eventList)
                {
                    using (var row = new HtmlTableRow())
                    {

                        tableRow = new TableRow();
                        tableRow.TableSection = TableRowSection.TableBody;
                        tableCell = new TableCell();
                        tableCell.Text = objJobInfo.Title.Replace("\\r\\n", "<br  />");
                        tableRow.Cells.Add(tableCell);

                        tableCell = new TableCell();
                        tableCell.Text = objJobInfo.StartDate.ToString();
                        tableRow.Cells.Add(tableCell);


                        tableCell = new TableCell();
                        tableCell.Text = objJobInfo.EndDate.ToString();
                        tableRow.Cells.Add(tableCell);

                        tableRow.Cells.Add(new TableCell()
                                               {
                                                   Text =
                                                       Global.ObjJobController.GetJobInfo(
                                                           objJobInfo.JobId).JobNumber
                                               });


                        tableCell = new TableCell();
                        List<SampleAssociation> getSamplerList =
                            SampleAssociationController.GetByEventId(objJobInfo.CalendarKey);
                        string Sampler = "";
                        foreach (var sampler in getSamplerList)
                        {
                            SystemUsers objSystemUser = Global.ObjDbController.GetSystemUser(sampler.SamplerID);
                            Sampler += string.Format("{0} {1}<br />", objSystemUser.FirstName, objSystemUser.LastName);

                        }
                        Sampler = Sampler.TrimEnd('<');
                        tableCell.Text = Sampler;
                        tableRow.Cells.Add(tableCell);



                        tableCell = new TableCell();


                        tableCell.Text = String.Format(
                            " <a href=\"DeleteEvent.aspx?eid={0}\" title=\"Delete Event\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                            objJobInfo.CalendarKey);

                        tableRow.Cells.Add(tableCell);


                        JobTable.Rows.Add(tableRow);

                    }
                    counter++;

                }
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Schedule.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", string.Format("<script language=javascript>window.open('../SampleScheduler/PrintableEventList.aspx?sd={0}&ed={1}','PrintMe','height=300px,width=300px,scrollbars=1');</script>", starteDate.Value, endDate.Value));
       
        }


    }
}