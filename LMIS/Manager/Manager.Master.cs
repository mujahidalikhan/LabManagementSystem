using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Manager
{
    public partial class Manager : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null ||Session["userType"].ToString()!="M")
            {
                Response.Redirect("~/Default.aspx");

            }
            displayUserName.Text = Session["userName"].ToString();
        }

    
        protected void logoutButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}