using System;
using System.Collections.Generic;
using System.Linq;
using LMIS.DBPersistence;
using LMIS.DBModel;

namespace LMIS.DBController
{
    public class AppointmentController
    {
        readonly private static PersistenceManager _mPersistenceManager = new PersistenceManager();

        public static int AddEvent(Appointment objAppointment)
        {
           return (int)_mPersistenceManager.Save(objAppointment);
        }

        public static void UpdateEvent(Appointment objAppointment)
        {
            _mPersistenceManager.Update(objAppointment);
        }
        public static void DeleteEvent(int calendarKey)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<Appointment>("CalendarKey", calendarKey);
            foreach (var appointment in EeventList)
            {
                List<AppointmentList> appointmentList =
                   AppointmentListController.GetEventByAppointmentId(appointment.CalendarKey);
                foreach (var list in appointmentList)
                {
                    AppointmentListController.DeleteEvent(list.CalendarKey);
                }
                _mPersistenceManager.Delete(appointment);
            }
           
        }

        public static Appointment GetEvent(int calendarKey)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<Appointment>("CalendarKey", calendarKey);
            return EeventList.Count > 0 ? EeventList[0] : new Appointment();
        }

        public static List<Appointment> GetEvent()
        {
            var EeventList = _mPersistenceManager.RetrieveAll<Appointment>();
            return EeventList.Count > 0 ? EeventList.ToList() : new List<Appointment>();
        }



        public static List<Appointment> GetEvent(DateTime starDate, DateTime endDate)
        {
            string[] columnName = {"StartDate", "EndDate"};
            object[] value = {starDate, endDate};
            var EeventList = _mPersistenceManager.RetrieveEquals<Appointment>(columnName, value);
            return EeventList.Count > 0 ? EeventList.ToList() : new List<Appointment>();
        }

    }
}