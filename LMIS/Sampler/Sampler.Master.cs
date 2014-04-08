using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Sampler
{
    public partial class Sampler : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null || Session["userType"].ToString() != "S")
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