using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class ClientList : System.Web.UI.Page
    {
        private static List<CustomerInfo> userList;
        static readonly DbController objDbController = new DbController();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            userList = objDbController.GetCustomerInfo();
            ClientListTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tableRow.Cells.Add(new TableHeaderCell { Text = "Name", Height = Unit.Pixel(20) });
           
            tableRow.Cells.Add(new TableHeaderCell { Text = "Address" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "City" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "State" });
           
            tableRow.Cells.Add(new TableHeaderCell { Text = "Options" ,Width = 120});
            ClientListTable.Rows.Add(tableRow);


            if (userList.Count <= 0) return;
            foreach (var objSystemUsers in userList)
            {
                try
                {
                    using (var row = new TableRow())
                    {
                        row.Cells.Add(new TableCell {Text = objSystemUsers.CustName});
                     
                        row.Cells.Add(new TableCell {Text = objSystemUsers.Address.Replace('`', ' ')});
                        row.Cells.Add(new TableCell {Text = objSystemUsers.City});
                        row.Cells.Add(new TableCell { Text = objSystemUsers.State });
                        row.Cells.Add(new TableCell
                                          {
                                              Text =
                                                  String.Format(
                                                      "<a href=\"AddEditClient.aspx?custId={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"> <img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a>" +
                                                      "  <a href=\"DeleteClient.aspx?custId={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" ,
                                                      objSystemUsers.CustID)
                                          });


                        ClientListTable.Rows.Add(row);
                    }
                }
                catch(Exception ex)
                {
                    
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditClient.aspx");
        }
    }
}