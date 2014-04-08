using System;
using LMIS.DBController;

namespace LMIS
{
    public class Global : System.Web.HttpApplication
    {
        public static JobController ObjJobController = new JobController();
        public  static  DashboardController ObjDashboardController = new DashboardController();
        public static  EventsController ObjEventsController = new EventsController();
        public  static  SpecificationController ObjSpecificationController = new SpecificationController();
        public static DbController ObjDbController = new DbController();
        public static  BottleController objBottleController = new BottleController();
        public static JobTestBottleDetailController objJobTestBottleDetailController = new JobTestBottleDetailController();
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
