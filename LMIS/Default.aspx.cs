using System;
using System.Web;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sender == null) throw new ArgumentNullException("sender");
            if (e == null) throw new ArgumentNullException("e");
            Session["userName"] =  null;
            Session["userId"] =    null;
            Session["userType"] =  null;
            errorMessage.Visible = false;

            Page.SetFocus(UserName);
        }

        protected void login_Click(object sender, EventArgs e)
        {
            var objDbController = new DbController();
            SystemUsers objSystemUsers;
            if ((objSystemUsers = objDbController.ValidateUser(UserName.Text, Password.Text)) != null)
            {

                Session["userName"] = string.Format("{0} {1}", objSystemUsers.FirstName, objSystemUsers.LastName);
                Session["userId"] = objSystemUsers.UserId;
                Session["userType"] = objSystemUsers.Type;


                HttpCookie _userInfoCookies = new HttpCookie("UserInfo");
                //Setting values inside it
                _userInfoCookies["userId"] = Session["userId"].ToString();
                _userInfoCookies["userType"] = Session["userType"].ToString();
                _userInfoCookies["userName"] = Session["userName"].ToString();
                //Adding Expire Time of cookies
                _userInfoCookies.Expires = DateTime.Now.AddMinutes(20);
                Response.Cookies.Add(_userInfoCookies);


                switch (Session["userType"].ToString())
                {
                    case "A":
                        Response.Redirect("Admin/DashboardAdmin.aspx");
                        break;
                    case "C":
                        Response.Redirect("Admin/Dashboard.aspx");
                        break;
                    case "L":
                        Response.Redirect("LabAssistants/Dashboard.aspx");
                        break;
                    case "M":
                        Response.Redirect("Manager/Dashboard.aspx");
                        break;
                    case "S":
                        Response.Redirect("Sampler/Dashboard.aspx");
                        break;
                   
                }

            }
            else
            {
                errorMessage.Visible = true;
            }
        }
    }
}
