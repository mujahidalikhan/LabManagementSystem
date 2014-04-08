using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class Events
    {
        public virtual int CalendarKey { set; get; }
        public virtual string Title { set; get; }
        public virtual DateTime StartDate { set; get; }
        public virtual DateTime EndDate { set; get; }
        public virtual bool AllDayEvent { set; get; }
        public virtual string BackgroundColor { set; get; }
        public virtual int JobId { set; get; }
    }
}