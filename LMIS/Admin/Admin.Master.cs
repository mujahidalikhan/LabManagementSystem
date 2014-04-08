using System;
using System.Web;

namespace LMIS.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
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
            if (Session["userId"] == null || (Session["userType"].ToString() != "A" && Session["userType"].ToString() != "C"))
            {
                Response.Redirect("~/Default.aspx");

            }

            displayUserName.Text = Session["userName"].ToString();
        }

      

        protected void logoutButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}