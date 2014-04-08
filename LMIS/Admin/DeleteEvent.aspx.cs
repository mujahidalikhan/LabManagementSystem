using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Admin
{
    public partial class DeleteEvent : System.Web.UI.Page
    {
    

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {

                Global.ObjEventsController.DeleteEvent(Int32.Parse(Page.Request.QueryString["eid"]));

            }
            Response.Redirect("ListAllEvent.aspx");
        }
    }
}