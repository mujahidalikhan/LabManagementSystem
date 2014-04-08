using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class SamplePackingList : System.Web.UI.Page
    {
        private static List<PackingInfo> listPackingInfo;
        static readonly DbController objDbController = new DbController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            listPackingInfo = objDbController.GetPackingInfo();
            if (listPackingInfo.Count <= 0) return;

            SamplePackingTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
            tableRow.Cells.Add(new TableHeaderCell { Text = "Packing Name", Height = Unit.Pixel(20) });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Paking Description" });
            tableRow.Cells.Add(new TableHeaderCell {Text = "Options"});
            SamplePackingTable.Rows.Add(tableRow);
            foreach (var objPackingInfo in listPackingInfo)
            {
                tableRow = new TableRow {TableSection = TableRowSection.TableBody};
                tableRow.Cells.Add(new TableCell { Text = objPackingInfo.PackingName });
                tableRow.Cells.Add(new TableCell { Text = objPackingInfo.PackingDescription });
                tableRow.Cells.Add(new TableCell { Text = String.Format("<a href=\"AddEditPackingInfo.aspx?pid={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a>  <a href=\"DeletePackingInfo.aspx?pid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>", objPackingInfo.PackingInfoId) });
                SamplePackingTable.Rows.Add(tableRow);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditPackingInfo.aspx");
        }
    }
}