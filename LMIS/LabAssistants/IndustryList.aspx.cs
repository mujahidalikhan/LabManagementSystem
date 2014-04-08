using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

using System.IO;
using System.Web.UI.HtmlControls;

namespace LMIS.LabAssistants
{
    public partial class IndustryList : System.Web.UI.Page
    {
private static List<IndustryInfo> listIndustryInfo;
        static readonly DbController objDbController = new DbController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            listIndustryInfo = objDbController.GetIndustryInfo();
            if (listIndustryInfo.Count <= 0) return;

            IndustryTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tableRow.Cells.Add(new TableHeaderCell { Text = "Industry Name", Height = Unit.Pixel(20) });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Associate Tests" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Comments" });
            tableRow.Cells.Add(new TableHeaderCell { Text = "Options", Width = 125 });
            IndustryTable.Rows.Add(tableRow);
            foreach (var objIndustryInfo in listIndustryInfo)
            {
                tableRow = new TableRow { TableSection = TableRowSection.TableBody };
                tableRow.Cells.Add(new TableCell { Text = objIndustryInfo.IndustryName });
                string testList = "";
                List<TestParameterInfo> objTestParameterInfo = objDbController.GetIndustryTestInfo(objIndustryInfo.IndustryID);
                foreach (var testParameterInfo in objTestParameterInfo)
                {
                    testList += testParameterInfo.ShortTerm + ",";
                }
                tableRow.Cells.Add(new TableCell { Text = testList.TrimEnd(',') });
                tableRow.Cells.Add(new TableCell { Text = objIndustryInfo.Comments });
                tableRow.Cells.Add(new TableCell
                {
                    Text = String.Format(
                        "<a href=\"AddEditIndustry.aspx?industryId={0}\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a>  <a href=\"DeleteIndustry.aspx?industryId={0}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                        objIndustryInfo.IndustryID)
                });
                IndustryTable.Rows.Add(tableRow);
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditIndustry.aspx");
        }
    }
}