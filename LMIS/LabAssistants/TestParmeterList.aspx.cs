using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;


namespace LMIS.LabAssistants
{
    public partial class TestParmeterList : System.Web.UI.Page
    {
        private static List<TestParameterInfo> userList;
        static readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
                return;

            userList = objDbController.GetIndustryTestInfo();
            TestParmeterTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tableRow.Cells.Add(new TableHeaderCell { Text = " Accredited Test Parameter", Height = Unit.Pixel(20) });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Test Method" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Unit" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Equipment" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "MDL" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Short Term" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Options",Width = 125});
            TestParmeterTable.Rows.Add(tableRow);
            if (userList.Count <= 0) return;
            foreach (TestParameterInfo objSystemUsers in userList)
            {
                tableRow = new TableRow { TableSection = TableRowSection.TableBody };
                tableRow.Cells.Add(new TableCell { Text = objSystemUsers.AccreditedTestParameter });
                tableRow.Cells.Add(new TableCell { Text = objSystemUsers.TestMethod });
                tableRow.Cells.Add(new TableCell { Text = objSystemUsers.Unit });
                tableRow.Cells.Add(new TableCell { Text = objSystemUsers.Equipment });
                tableRow.Cells.Add(new TableCell { Text = objSystemUsers.MDL });
                tableRow.Cells.Add(new TableCell { Text = objSystemUsers.ShortTerm });
                var tableCell = new TableCell
                {
                    Text = String.Format(
                        "<a href=\"AddEditTestParameterInfo.aspx?testId={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a>  <a href=\"DeleteTestParameter.aspx?testId={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                        objSystemUsers.TestParameterId)
                };

                tableRow.Cells.Add(tableCell);
                TestParmeterTable.Rows.Add(tableRow);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditTestParameterInfo.aspx");
        }
    }
}