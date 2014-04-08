using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class AddEditUser : System.Web.UI.Page
    {
       
       static readonly DbController objDbController = new DbController();
   
        private SystemUsers objSystemUsers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {
                
                    objSystemUsers=  objDbController.GetSystemUser(Int32.Parse(Page.Request.QueryString["user_id"]));
                    userFirstName.Text = objSystemUsers.FirstName;
                    userLastName.Text = objSystemUsers.LastName;
                    userEmailAddress.Text = objSystemUsers.EmailAddress;
                    userName.Text = objSystemUsers.UserName;
                    userPassword.Text = objSystemUsers.Password;
                    userConformPassword.Text = objSystemUsers.Password;

                if(objSystemUsers.Type=='L')
                {
                    usertype.Items[0].Selected =true;
                }
                else if (objSystemUsers.Type == 'M')
                {
                    usertype.Items[1].Selected = true;
                }
                else if (objSystemUsers.Type == 'A')
                {
                    usertype.Items[2].Selected = true;
                }
                else if (objSystemUsers.Type == 'S')
                {
                    usertype.Items[3].Selected = true;
                }
                else if (objSystemUsers.Type == 'F')
                {
                    usertype.Items[4].Selected = true;
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Page.Request.QueryString.Count > 0)
                {
                    var objSystemUser = new SystemUsers
                                            {
                                                UserId = Int32.Parse(Page.Request.QueryString["user_id"]),
                                                FirstName = userFirstName.Text,
                                                LastName = userLastName.Text,
                                                EmailAddress = userEmailAddress.Text,
                                                UserName = userName.Text,
                                                Password = userPassword.Text,
                                                Type = usertype.SelectedValue[0]
                                            };
                    objDbController.UpdateSystemUser(objSystemUser);

                }
                else
                {

                    objDbController.AddSystemUser(userFirstName.Text, userLastName.Text, userEmailAddress.Text,
                                                  userName.Text, userPassword.Text, usertype.SelectedValue[0]);
                }

                Response.Redirect("UserList.aspx");
            }
        }

    }
}