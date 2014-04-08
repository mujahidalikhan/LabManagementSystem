using System;
using System.Collections.Generic;
using System.Linq;
using LMIS.DBPersistence;
using LMIS.DBModel;

namespace LMIS.DBController
{
    public class EventsController
    {
        readonly PersistenceManager _mPersistenceManager = new PersistenceManager();

        public int AddEvent (Events objEvents)
        {
           return (int)_mPersistenceManager.Save(objEvents);
        }

        public void UpdateEvent(Events objEvents)
        {
            _mPersistenceManager.Update(objEvents);
        }
        public void DeleteEvent(int calendarKey)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<Events>("CalendarKey", calendarKey);
            foreach (var objEvent in EeventList)
            {
                _mPersistenceManager.Delete(objEvent);   
            }
        }

        public Events GetEvent(int calendarKey)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<Events>("CalendarKey", calendarKey);
            return EeventList.Count > 0 ? EeventList[0] : new Events();
        }

        public List<Events> GetEvent()
        {
            var EeventList = _mPersistenceManager.RetrieveAll<Events>();
            return EeventList.Count > 0 ? EeventList.ToList() : new List<Events>();
        }


        public List<Events> GetEvent(DateTime startDate, DateTime endDate)
        {
            var EeventList = _mPersistenceManager.RetrieveAllBetween<Events>("StartDate", startDate.Date, endDate.Date); ;
            return EeventList.Count > 0 ? EeventList.ToList() : new List<Events>();
        }


        

        public List<Events> GetEventByJob(int JobId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<Events>("JobId", JobId);
            return EeventList.Count > 0 ? EeventList.ToList() : new List<Events>();
        }



    }
}