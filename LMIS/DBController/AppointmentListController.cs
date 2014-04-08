using System;
using System.Collections.Generic;
using System.Linq;
using LMIS.DBPersistence;
using LMIS.DBModel;

namespace LMIS.DBController
{
    public class AppointmentListController
    {
        readonly private static  PersistenceManager _mPersistenceManager = new PersistenceManager();

        public static int AddEvent(AppointmentList objAppointmentList)
        {
           return (int)_mPersistenceManager.Save(objAppointmentList);
        }

        public static  void UpdateEvent(AppointmentList objAppointmentList)
        {
            _mPersistenceManager.Update(objAppointmentList);
        }
        public static void DeleteEvent(int calendarKey)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<AppointmentList>("CalendarKey", calendarKey);
            foreach (var objEvent in EeventList)
            {
                _mPersistenceManager.Delete(objEvent);   
            }
        }

        public static  AppointmentList GetEvent(int calendarKey)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<AppointmentList>("CalendarKey", calendarKey);
            return EeventList.Count > 0 ? EeventList[0] : new AppointmentList();
        }

        public static  List<AppointmentList> GetEvent()
        {
            var EeventList = _mPersistenceManager.RetrieveAll<AppointmentList>();
            return EeventList.Count > 0 ? EeventList.ToList() : new List<AppointmentList>();
        }
        public static List<AppointmentList> GetEventByAppointmentId(int appointmentId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<AppointmentList>("AppointmentId", appointmentId);
            return EeventList.Count > 0 ? EeventList.ToList() : new List<AppointmentList>();
        }


        public static  List<AppointmentList> GetEvent(DateTime starDate, DateTime endDate)
        {
            string[] columnName = {"StartDate", "EndDate"};
            object[] value = {starDate, endDate};
            var EeventList = _mPersistenceManager.RetrieveEquals<AppointmentList>(columnName, value);
            return EeventList.Count > 0 ? EeventList.ToList() : new List<AppointmentList>();
        }

    }
}