using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.AppointScheduler
{
    public partial class ListAllAppoint : System.Web.UI.UserControl
    {
        private static List<LMIS.DBModel.Appointment> eventList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                eventList = AppointmentController.GetEvent();

                JobTable.Controls.Clear();
                TableRow tableRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };



                TableCell tableCel2 = new TableHeaderCell { Text = "Title", Height = Unit.Pixel(20) };
                tableRow.Cells.Add(tableCel2);

                TableCell tableCell = new TableHeaderCell { Text = "Starts " };
                tableRow.Cells.Add(tableCell);
                TableCell tableCel3 = new TableHeaderCell { Text = "Ends" };
                tableRow.Cells.Add(tableCel3);


                tableRow.Cells.Add(new TableHeaderCell { Text = "Type" });


                TableCell tableCel6 = new TableHeaderCell { Text = "Options" };
                tableRow.Cells.Add(tableCel6);

                JobTable.Rows.Add(tableRow);


                if (eventList.Count > 0)
                {
                    int counter = 0;
                    foreach (Appointment objAppointment in eventList)
                    {
                        using (var row = new HtmlTableRow())
                        {

                            tableRow = new TableRow {TableSection = TableRowSection.TableBody};
                            tableRow.Cells.Add(new TableCell {Text = objAppointment.Title});
                            tableRow.Cells.Add( new TableCell {Text = objAppointment.StartDate.ToString()});
                            tableRow.Cells.Add( new TableCell {Text = objAppointment.EndDate.ToString()});
                            tableRow.Cells.Add(new TableCell() { Text = objAppointment.AppointmentType });
                            tableCell = new TableCell
                                            {
                                                Text = String.Format(
                                                 "<a href=\"AddEditAppoint.aspx?aid={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a> " +
                                                 " <a href=\"DeletAppointment.aspx?aid={0}\" title=\"Delete Event\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                                                    objAppointment.CalendarKey)
                                            };


                            tableRow.Cells.Add(tableCell);


                            JobTable.Rows.Add(tableRow);

                        }
                        counter++;

                    }
                }
            }



        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Appointment.aspx");
        }
    }
}