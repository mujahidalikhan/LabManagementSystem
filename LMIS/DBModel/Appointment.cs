using System;

namespace LMIS.DBModel
{
    public class Appointment
    {
        public virtual int CalendarKey { set; get; }
        public virtual string Title { set; get; }
        public virtual DateTime StartDate { set; get; }
        public virtual DateTime EndDate { set; get; }
        public virtual bool AllDayEvent { set; get; }
        public virtual string BackgroundColor { set; get; }
        public virtual string AppointmentType { set; get; }
    }
}