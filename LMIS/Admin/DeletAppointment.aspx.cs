using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBController;

namespace LMIS.Admin
{
    public partial class DeletAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {

                AppointmentController.DeleteEvent(Int32.Parse(Page.Request.QueryString["aid"]));

            }
            Response.Redirect("ListAllAppointment.aspx");
        }
    }
}