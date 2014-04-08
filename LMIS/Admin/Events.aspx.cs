using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace LMIS.Admin
{
    public partial class Events : System.Web.UI.Page
    {


        public class CalendarDTO
        {
            public int id { get; set; }
            public string title { get; set; }
            public long start { get; set; }
            public long end { get; set; }
            public bool allDay { get; set; }
        }

        /* Retrieve Event data from database by CalendarKey
       ---------------------------------------------------------------------------------------------------*/
        [WebMethod]
        public static DBModel.Events GetEventData(int id)
        {

            DBModel.Events objEvents = Global.ObjEventsController.GetEvent(id);
            return Global.ObjEventsController.GetEvent(id);

        }

        /* Persist Event data to database.
        ---------------------------------------------------------------------------------------------------*/
        [WebMethod]
        public static DBModel.Events UpdateEventData(int id, string title, string start, string end, string allDayEvent, string backgroundColor)
        {

            var e = Global.ObjEventsController.GetEvent(id);
            if (e.CalendarKey != 0)
            {
                if (!string.IsNullOrEmpty(title)) //this happens when a Event is modified via drap & drop operation
                    e.Title = title;

                var date = start.Split('/',' ',':');
                e.StartDate = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[0]), Int32.Parse(date[1]),Int32.Parse(date[3]),Int32.Parse(date[4]),Int32.Parse(date[5]));

                if (string.IsNullOrEmpty(end))
                {
                    e.EndDate = e.StartDate;
                }
                else
                {
                    date = end.Split('/', ' ', ':');
                    e.EndDate = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[0]), Int32.Parse(date[1]),
                                             Int32.Parse(date[3]), Int32.Parse(date[4]), Int32.Parse(date[5]));
                }

                if (!string.IsNullOrEmpty(allDayEvent)) //this happens when a Event is modified via drap and drop operation
                    e.AllDayEvent = Convert.ToBoolean(allDayEvent);

                if (!string.IsNullOrEmpty(backgroundColor)) //this happens when a Event is modified via drag and drop operation
                    e.BackgroundColor = backgroundColor;

                Global.ObjEventsController.UpdateEvent(e);
                return e;
            }
            e = new DBModel.Events
            {
                Title = title,
                StartDate = Convert.ToDateTime(start),
                EndDate = Convert.ToDateTime(end),
                AllDayEvent = Convert.ToBoolean(allDayEvent),
                BackgroundColor = backgroundColor
            };
            Global.ObjEventsController.AddEvent(e);

            return null;
        }

        /* Delete Event from database by CalendarKey
        ---------------------------------------------------------------------------------------------------*/
        [WebMethod]
        public static void DeleteEvent(int id)
        {
            Global.ObjEventsController.DeleteEvent(id);
        }
        private long ToUnixTimespan(DateTime date)
        {
            TimeSpan tspan = date.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0));

            return (long)Math.Truncate(tspan.TotalSeconds);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        /* Only purpose is to write JSON string to browser so that FullCalendar can pick it up
        ---------------------------------------------------------------------------------------------------*/
        protected void Page_Load(object sender, EventArgs e)
        {
            //FullCalendar will use GET parameters so we know how much data to retrieve.. Very nice of him.
            string start = Request.QueryString["start"];
            string end = Request.QueryString["end"];

            DateTime dtStart = DateTime.MinValue;
            DateTime dtEnd = DateTime.MaxValue;
            //let's make sure those parameters are empty before we try to work with them.
            if (!string.IsNullOrEmpty(start))
                try
                {
                    dtStart = ConvertFromUnixTimestamp(Convert.ToDouble(start));
                }
                catch (FormatException ex)
                {
                    Response.Write("Problem parsing start date. EXCEPTION Message: " + ex.Message);
                    Response.End();
                }
            if (!string.IsNullOrEmpty(end))
                try
                {
                    dtEnd = ConvertFromUnixTimestamp(Convert.ToDouble(end));
                }
                catch (FormatException ex)
                {
                    Response.Write("Problem parsing end date. EXCEPTION Message: " + ex.Message);
                    Response.End();
                }



            List<DBModel.Events> q;

            if (Page.Request.QueryString["qid"] != null)
                q = Global.ObjEventsController.GetEventByJob(Int32.Parse(Page.Request.QueryString["qid"]));
            else
                q = Global.ObjEventsController.GetEvent();

            IList<CalendarDTO> tasksList = new List<CalendarDTO>();
            foreach (DBModel.Events ev in q)
            {
                tasksList.Add(new CalendarDTO
                {
                    id = ev.CalendarKey,
                    title = ev.Title,
                    start = ToUnixTimespan(ev.StartDate),
                    end = ToUnixTimespan(ev.EndDate),
                    allDay = ev.AllDayEvent
                });
            }
            var oSerializer = new JavaScriptSerializer();
            var sJSON = oSerializer.Serialize(tasksList);

         
          //  Response.Write(sJSON);
       
            string   sb = "[";
            foreach (DBModel.Events ev in q)
            {
                sb += string.Format("{{\"id\":{0},\"title\":\"{1}\",\"start\":\"{2}\",\"allDay\":{3}", ev.CalendarKey, ev.Title, ToUnixTimespan(ev.StartDate), ev.AllDayEvent.ToString().ToLower());
                if (ev.EndDate > ev.StartDate) //multi-day event
                    sb += string.Format(",\"end\":\"{0}\"", ToUnixTimespan(ev.EndDate));
                sb += "},";
            }
            sb = sb.Substring(0, sb.Length - 1);
            sb += "]";




            Response.Write(sb);

        }

        /* Utility to convert Unix timestamp into something .NET can work with.
        ---------------------------------------------------------------------------------------------------*/
        private DateTime ConvertFromUnixTimestamp(double p)
        {
            try
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return dt.AddSeconds(p);
            }
            catch (Exception ex)
            {
                Response.Write(String.Format("Problem converting '{0}' as DateTime. EXCEPTION Message: {1}", p, ex.Message));
                Response.End();
            }
            return DateTime.MinValue;
        }
    }
}