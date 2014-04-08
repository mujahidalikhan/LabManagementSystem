using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.LabAssistants
{
    public partial class LabAssistants : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null || Session["userType"] == null)
            {
                HttpCookie _userInfoCookies = Request.Cookies["UserInfo"];
                if (_userInfoCookies != null)
                {
                    Session["userId"] = _userInfoCookies["userId"];
                    Session["userType"] = _userInfoCookies["userType"];
                    Session["userName"] = _userInfoCookies["userName"];
                  
                }
            }

            if (Session["userId"] == null || Session["userType"]==null || Session["userType"].ToString() != "L")
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