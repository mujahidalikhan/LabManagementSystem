using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Manager
{
    public partial class ClientList : System.Web.UI.Page
    {
    
         private static List<CustomerInfo> userList;
        static readonly DbController objDbController = new DbController();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FillCustomerTable();
        }

        private void FillCustomerTable()
        {
            userList = objDbController.GetCustomerInfo();
            ClientListTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
            tableRow.Cells.Add(new TableHeaderCell {Text = "Name", Height = Unit.Pixel(20)});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Nature"});
            tableRow.Cells.Add(new TableHeaderCell { Text = "Specification" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Address" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Country" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "State" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "City" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Poscode" });

            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 1 Salutation" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 1 Name" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 1 Position" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 1 Hand Phone" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 1 Office Phone" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 1 Fax" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 1 Email" });

            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 2 Salutation" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 2 Name" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 2 Position" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 2 Hand Phone" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 2 Office Phone" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 2 Fax" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 2 Email" });


            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 3 Salutation" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 3 Name" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 3 Position" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 3 Hand Phone" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 3 Office Phone" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 3 Fax" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Person 3 Email" });

            ClientListTable.Rows.Add(tableRow);


            if (userList.Count <= 0) return;
            foreach (var objCustomerInfo in userList)
            {
                try
                {
                    using (var row = new TableRow())
                    {
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.CustName});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Nature});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Specification});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Address.Replace('`', ' ')});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Country});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.State});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.City});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Poscode.ToString()});


                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Salutation1});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Person1});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Position1});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Phone1});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.HPhone1});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Fax1});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Email1});



                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Salutation2});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Person2});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Position2});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Phone2});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.HPhone2});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Fax2});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Email2});


                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Salutation3});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Person3});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Position3});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Phone3});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.HPhone3});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Fax3});
                        row.Cells.Add(new TableCell {Text = objCustomerInfo.Email3});

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
         Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment; filename=CustomerDetail.xls");
            Response.ContentEncoding = Encoding.UTF8;
            FillCustomerTable();
            using (var tw = new StringWriter())
            {
                var hw = new HtmlTextWriter(tw); 
                ClientListTable.RenderControl(hw);
                Response.Write(tw.ToString());
            }
            Response.End(); 
        }
    }
}