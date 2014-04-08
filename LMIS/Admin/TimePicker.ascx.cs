using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Admin
{
    public partial class TimePicker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public long SetTime
        {
            set
            {
                try
                {
                    var timeTicks = value;
                    var dt = new DateTime(timeTicks);
                    var currentTime = dt.ToLongTimeString();
                    var times = currentTime.Split(':');
                    lstHour.Text = Convert.ToInt32(times[0]).ToString("00");
                    lstmin.Text = Convert.ToInt32(times[1]).ToString("00");
                    var times1 = times[2].Split(' ');
                   
                    lstDtpart.Text = times1[1].ToString();
                }
                catch
                {
                }
            }
        }

        public long GetTicks
        {
            get
            {
                var s = GetTime;
                DateTime t = DateTime.ParseExact(s, "hh:mm tt", CultureInfo.InvariantCulture);
                //if you really need a TimeSpan this will get the time elapsed since midnight:
                var ts = t.TimeOfDay;
                return ts.Ticks;
            }
        }
        public string GetTime
        {

            get
            {

                string time = string.Format("{0}:{1} {2}", lstHour.Text, lstmin.Text, lstDtpart.Text);

                return time;

            }

            set
            {

                try
                {
                    string mytime = value;
                    string[] times = mytime.Split(':');
                    lstHour.Text = Convert.ToInt32(times[0]).ToString("00");
                    lstmin.Text = Convert.ToInt32(times[1]).ToString("00");
                    string[] times1 = times[2].Split(' ');
                    lstDtpart.Text = times1[1];
                }

                catch
                {
                }

            }

        }
    }
}