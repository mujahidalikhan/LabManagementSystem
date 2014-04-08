using System;
using System.Collections.Generic;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.AppointScheduler
{
    public partial class AddEditAppointControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            if (Page.Request.QueryString["aid"] != null)
            {
                Appointment objAppointment = AppointmentController.GetEvent(Int32.Parse(Page.Request.QueryString["aid"]));
                if (objAppointment.CalendarKey != 0)
                {
                    EventTitle.Text = objAppointment.Title;
                    datepicker.Value = string.Format("{0}/{1}/{2}", objAppointment.StartDate.Day, objAppointment.StartDate.Month, objAppointment.StartDate.Year);
                    startHr.Value = objAppointment.StartDate.Hour.ToString();
                    StartMin.Value = objAppointment.StartDate.Minute.ToString();
                    EndDate.Value = string.Format("{0}/{1}/{2}", objAppointment.EndDate.Day, objAppointment.EndDate.Month, objAppointment.EndDate.Year);
                    EndHr.Value = objAppointment.EndDate.Hour.ToString();
                    EndMin.Value = objAppointment.EndDate.Minute.ToString();
                    AppointTypeList.SelectedValue = objAppointment.AppointmentType;
                    AddEvent.Text = "Update Appointment";
                    Color1.Text = objAppointment.BackgroundColor.Replace("#", "");
                }
            }

        }

        protected void AddEvent_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string[] startDate = datepicker.Value.Split('/');
            string[] endDate = EndDate.Value.Split('/');

            DateTime eventStartDate =
                new DateTime(Int32.Parse(startDate[2]), Int32.Parse(startDate[1]), Int32.Parse(startDate[0])).Date;
            DateTime eventEndDate =
                new DateTime(Int32.Parse(endDate[2]), Int32.Parse(endDate[1]), Int32.Parse(endDate[0])).Date;

          

            if (AddEvent.Text == "Update Appointment")
            {
                Appointment objAppointment = AppointmentController.GetEvent(Int32.Parse(Page.Request.QueryString["aid"]));
                objAppointment.Title = EventTitle.Text;
                objAppointment.StartDate = eventStartDate;
                objAppointment.EndDate = eventEndDate;
                objAppointment.AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue);
                objAppointment.BackgroundColor = "#" + Color1.Text;
                objAppointment.AppointmentType = AppointTypeList.SelectedValue;


                objAppointment.StartDate += (new TimeSpan(Int32.Parse(startHr.Value), Int32.Parse(StartMin.Value), 0));
                objAppointment.EndDate += (new TimeSpan(Int32.Parse(EndHr.Value), Int32.Parse(EndMin.Value), 0));


                AppointmentController.UpdateEvent(objAppointment);
                List<AppointmentList> appointmentList =
                    AppointmentListController.GetEventByAppointmentId(objAppointment.CalendarKey);
                foreach (var list in appointmentList)
                {
                    AppointmentListController.DeleteEvent(list.CalendarKey);
                }
                int appointmentId = objAppointment.CalendarKey;
                if (AppointTypeList.SelectedValue == "One time")
                {

                    var objAppointmentList = new AppointmentList()
                                                 {
                                                     Title = EventTitle.Text,
                                                     StartDate = eventStartDate,
                                                     EndDate = eventEndDate,
                                                     AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                     BackgroundColor = "#" + Color1.Text,
                                                     AppointmentId = appointmentId
                                                 };
                    objAppointmentList.StartDate += (new TimeSpan(Int32.Parse(startHr.Value), Int32.Parse(StartMin.Value), 0));
                    objAppointmentList.EndDate += (new TimeSpan(Int32.Parse(EndHr.Value), Int32.Parse(EndMin.Value), 0));

                    AppointmentListController.AddEvent(objAppointmentList);
                }
                else if (AppointTypeList.SelectedValue == "Daily")
                {
                    var objAppointmentList = new AppointmentList()
                                                 {
                                                     Title = EventTitle.Text,
                                                     StartDate = eventStartDate,
                                                     EndDate = eventEndDate,
                                                     AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                     BackgroundColor = "#" + Color1.Text,
                                                     AppointmentId = appointmentId
                                                 };
                    for (DateTime i = eventStartDate; i <= eventEndDate; i = i.AddDays(1))
                    {
                        objAppointmentList.StartDate = i;
                        objAppointmentList.EndDate = i;
                        objAppointmentList.StartDate += (new TimeSpan(Int32.Parse(startHr.Value), Int32.Parse(StartMin.Value), 0));
                        objAppointmentList.EndDate += (new TimeSpan(Int32.Parse(EndHr.Value), Int32.Parse(EndMin.Value), 0));

                        AppointmentListController.AddEvent(objAppointmentList);
                    }
                }
                else if (AppointTypeList.SelectedValue == "Weekly")
                {
                    var objAppointmentList = new AppointmentList()
                                                 {
                                                     Title = EventTitle.Text,
                                                     StartDate = eventStartDate,
                                                     EndDate = eventEndDate,
                                                     AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                     BackgroundColor = "#" + Color1.Text,
                                                     AppointmentId = appointmentId
                                                 };
                    for (DateTime i = eventStartDate; i <= eventEndDate; i = i.AddDays(7))
                    {
                        objAppointmentList.StartDate = i;
                        objAppointmentList.EndDate = i;
                        objAppointmentList.StartDate += (new TimeSpan(Int32.Parse(startHr.Value), Int32.Parse(StartMin.Value), 0));
                        objAppointmentList.EndDate += (new TimeSpan(Int32.Parse(EndHr.Value), Int32.Parse(EndMin.Value), 0));

                        AppointmentListController.AddEvent(objAppointmentList);
                    }
                }
                else if (AppointTypeList.SelectedValue == "Monthly")
                {
                    var objAppointmentList = new AppointmentList()
                                                 {
                                                     Title = EventTitle.Text,
                                                     StartDate = eventStartDate,
                                                     EndDate = eventEndDate,
                                                     AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                     BackgroundColor = "#" + Color1.Text,
                                                     AppointmentId = appointmentId
                                                 };
                    for (DateTime i = eventStartDate; i <= eventEndDate; i = i.AddMonths(1))
                    {
                        objAppointmentList.StartDate = i;
                        objAppointmentList.EndDate = i;
                        objAppointmentList.StartDate += (new TimeSpan(Int32.Parse(startHr.Value), Int32.Parse(StartMin.Value), 0));
                        objAppointmentList.EndDate += (new TimeSpan(Int32.Parse(EndHr.Value), Int32.Parse(EndMin.Value), 0));

                        AppointmentListController.AddEvent(objAppointmentList);

                    }
                }
            }


            else
            {
                try
                {


                    var objEvent = new Appointment()
                                       {
                                           Title = EventTitle.Text,
                                           StartDate = eventStartDate,
                                           EndDate = eventEndDate,
                                           AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                           BackgroundColor = "#" + Color1.Text,
                                           AppointmentType = AppointTypeList.SelectedValue
                                       };


                    var appointmentId = AppointmentController.AddEvent(objEvent);



                    if (AppointTypeList.SelectedValue == "One time")
                    {

                        var objAppointmentList = new AppointmentList()
                                                     {
                                                         Title = EventTitle.Text,
                                                         StartDate = eventStartDate,
                                                         EndDate = eventEndDate,
                                                         AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                         BackgroundColor = "#" + Color1.Text,
                                                         AppointmentId = appointmentId
                                                     };
                        AppointmentListController.AddEvent(objAppointmentList);
                    }
                    else if (AppointTypeList.SelectedValue == "Daily")
                    {
                        var objAppointmentList = new AppointmentList()
                                                     {
                                                         Title = EventTitle.Text,
                                                         StartDate = eventStartDate,
                                                         EndDate = eventEndDate,
                                                         AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                         BackgroundColor = "#" + Color1.Text,
                                                         AppointmentId = appointmentId
                                                     };
                        for (DateTime i = eventStartDate; i <= eventEndDate; i = i.AddDays(1))
                        {
                            objAppointmentList.StartDate = i;
                            objAppointmentList.EndDate = i;
                            AppointmentListController.AddEvent(objAppointmentList);
                        }
                    }
                    else if (AppointTypeList.SelectedValue == "Weekly")
                    {
                        var objAppointmentList = new AppointmentList()
                                                     {
                                                         Title = EventTitle.Text,
                                                         StartDate = eventStartDate,
                                                         EndDate = eventEndDate,
                                                         AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                         BackgroundColor = "#" + Color1.Text,
                                                         AppointmentId = appointmentId
                                                     };
                        for (DateTime i = eventStartDate; i <= eventEndDate; i = i.AddDays(7))
                        {
                            objAppointmentList.StartDate = i;
                            objAppointmentList.EndDate = i;
                            AppointmentListController.AddEvent(objAppointmentList);
                        }
                    }
                    else if (AppointTypeList.SelectedValue == "Monthly")
                    {
                        var objAppointmentList = new AppointmentList()
                                                     {
                                                         Title = EventTitle.Text,
                                                         StartDate = eventStartDate,
                                                         EndDate = eventEndDate,
                                                         AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                                                         BackgroundColor = "#" + Color1.Text,
                                                         AppointmentId = appointmentId
                                                     };
                        for (DateTime i = eventStartDate; i <= eventEndDate; i = i.AddMonths(1))
                        {
                            objAppointmentList.StartDate = i;
                            objAppointmentList.EndDate = i;
                            AppointmentListController.AddEvent(objAppointmentList);

                        }
                    }
                }


                catch (Exception ex)
                {
                    lblError.Visible = true;
                }
            }
            Response.Redirect("Appointment.aspx");
        }
    }
}