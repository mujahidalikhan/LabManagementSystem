using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Manager
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private static List<ActiveTestsInfo> UrgentTrue;
        private static List<ActiveTestsInfo> Urgentfalse;
        private static List<ActiveTestsInfo> CompletedCount;
        private static DbController objDBController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            objDBController = new DbController();
            SpecificationTable.Controls.Clear();
            TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Specification", Height = Unit.Pixel(20) });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Urgent" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Non-Urgent" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Completed" });
            SpecificationTable.Rows.Add(tablHeadereRow);
            var specificationList = SpecificationController.GetDistanceSpecification();

            foreach (var objSpecification in specificationList)
            {
                UrgentTrue = objDBController.GetUrgentCount(objSpecification.SpecificationName, "True");
                Urgentfalse = objDBController.GetUrgentCount(objSpecification.SpecificationName, "False");
                CompletedCount = objDBController.GetComopletedCount(objSpecification.SpecificationName, "Completed");

                using (var tableBodyRow = new TableRow {TableSection = TableRowSection.TableBody})
                {
                    var tableCell = new TableCell();
                    tableCell.Text = String.Format(" <a href=\"DashboardSpecification.aspx?specid={0}\" title=\"{0}\" class=\"icon-2 info-tooltip\">{0}</a>", objSpecification.SpecificationName);
                    tableBodyRow.Cells.Add(tableCell);
                    tableBodyRow.Cells.Add(new TableCell { Text = UrgentTrue .Count.ToString(), ForeColor = Color.Red});
                    tableBodyRow.Cells.Add(new TableCell { Text = Urgentfalse.Count.ToString() });
                    tableBodyRow.Cells.Add(new TableCell { Text = CompletedCount.Count.ToString() });
                    SpecificationTable.Rows.Add(tableBodyRow);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var clickedButton = (LinkButton)sender;
        }
    }
}


