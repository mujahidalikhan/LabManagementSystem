using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class ListSampleBottle : System.Web.UI.Page
    {
        private static List<Bottle> listBottle;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
                return;

            listBottle = Global.objBottleController.Get();
            SampleBottleTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tableRow.Cells.Add(new TableHeaderCell { Text = " Preservative / Chemical", Height = Unit.Pixel(20) });
            tableRow.Cells.Add(new TableHeaderCell { Text = "VolumeType" ,ColumnSpan = 3});
            tableRow.Cells.Add(new TableHeaderCell { Text = "Options" });
            SampleBottleTable.Rows.Add(tableRow);

            foreach (Bottle objBottle in listBottle)
            {
                tableRow = new TableRow { TableSection = TableRowSection.TableBody };
                tableRow.Cells.Add(new TableCell { Text = objBottle.PreservativeChemical });

              
                    tableRow.Cells.Add(new TableCell { Text = objBottle.VolumeType1 });
                    tableRow.Cells.Add(new TableCell { Text = objBottle.VolumeType2 });
                    tableRow.Cells.Add(new TableCell { Text = objBottle.VolumeType3 });
           
              
                var tableCell = new TableCell
                {
                    Text = String.Format(
                        "<a href=\"AddEditBottle.aspx?bId={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\">" +
                        "<img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a> " +
                        " <a href=\"DeleteBottle.aspx?bid={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\">" +
                        "<img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                        objBottle.bottleId)
                };

                tableRow.Cells.Add(tableCell);
                SampleBottleTable.Rows.Add(tableRow);
            }
        }

  
        protected void btnAddEditSampleBottle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditBottle.aspx");
        }
    }
}