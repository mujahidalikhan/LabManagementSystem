using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;


namespace LMIS.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        private static List<SystemUsers> userList;
       static readonly DbController objDbController = new DbController();

       protected void Page_Load(object sender, EventArgs e)
       {
           if (IsPostBack) return;
           userList = objDbController.GetSystemUser();
           SystemUserTable.Controls.Clear();
           TableRow tableRow = new TableHeaderRow {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
           tableRow.Cells.Add(new TableHeaderCell {Text = "Last Name", Height = Unit.Pixel(20)});
           tableRow.Cells.Add(new TableHeaderCell {Text = "First Name"});
           tableRow.Cells.Add(new TableHeaderCell {Text = "Email"});
           tableRow.Cells.Add(new TableHeaderCell {Text = " User Name"});
           tableRow.Cells.Add(new TableHeaderCell {Text = "Type"});
           tableRow.Cells.Add(new TableHeaderCell {Text = "Options", Width = 120});
           SystemUserTable.Rows.Add(tableRow);
           if (userList.Count <= 0) return;
           foreach (SystemUsers objSystemUsers in userList)
           {
               try
               {
                   using (var row = new TableRow())
                   {
                       row.Cells.Add(new TableCell {Text = objSystemUsers.FirstName});
                       row.Cells.Add(new TableCell {Text = objSystemUsers.LastName});
                       row.Cells.Add(new TableCell {Text = objSystemUsers.EmailAddress});
                       row.Cells.Add(new TableCell {Text = objSystemUsers.UserName});
                       string userType;
                       switch (objSystemUsers.Type)
                       {
                           case 'L':
                               userType = "Lab Assistants";
                               break;
                           case 'M':
                               userType = "Verification";
                               break;
                           case 'A':
                               userType = "Admin";
                               break;
                           case 'S':
                               userType = "Batching";
                               break;
                           case 'C':
                               userType = "CEO";
                               break;
                           default:
                               userType = objSystemUsers.Type.ToString();
                               break;
                       }
                       row.Cells.Add(new TableCell {Text = userType});
                       row.Cells.Add(new TableCell
                                         {
                                             Text =
                                                 String.Format(
                                                     "<a href=\"AddEditUser.aspx?user_id={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"> <img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a>  <a href=\"DeleteUser.aspx?user_id={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                                                     objSystemUsers.UserId)
                                         });


                       SystemUserTable.Rows.Add(row);
                   }
               }
               catch(Exception ex)
               {
                   
               }

           }
       }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditUser.aspx");

        }


      
    }
}
