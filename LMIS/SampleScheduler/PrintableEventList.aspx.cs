using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;


namespace LMIS.SampleScheduler
{
    public partial class PrintableEventList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

                DateTime sartDate = DateTime.Now;
                DateTime endDate = DateTime.Now.AddDays(7);
                
                List<LMIS.DBModel.Events> eventList;
                if (Page.Request.QueryString["sd"] != null && Page.Request.QueryString["ed"]!= null )
                {
                    sartDate = DateTime.Parse(Page.Request.QueryString["sd"].ToString());
                    endDate = DateTime.Parse(Page.Request.QueryString["ed"].ToString());
                    eventList = Global.ObjEventsController.GetEvent(sartDate, endDate);
                }
                else
                {
                    eventList = Global.ObjEventsController.GetEvent();
                }
             
               

                JobTable.Controls.Clear();
                TableRow tableRow;
                tableRow = new TableHeaderRow {TableSection = TableRowSection.TableHeader};
                tableRow.Cells.Add(new TableHeaderCell { Text = "Job No" });
                tableRow.Cells.Add(new TableHeaderCell {Text =  "Test Description"});
                tableRow.Cells.Add(new TableHeaderCell { Text = "Bottle" });
                tableRow.Cells.Add(new TableHeaderCell {Text =  "Starts "});
                tableRow.Cells.Add(new TableHeaderCell {Text =  "Ends"});
                tableRow.Cells.Add(new TableHeaderCell {Text =  "Assigned To"});
                JobTable.Rows.Add(tableRow);

                if (eventList.Count > 0)
                {
                    int counter = 0;
                    foreach (LMIS.DBModel.Events objJobInfo in eventList)
                    {
                        using (var row = new HtmlTableRow())
                        {
                        
                            tableRow = new TableRow {TableSection = TableRowSection.TableBody};
                            var objSampleDetail = SampleDetailController.GetByEventId(objJobInfo.CalendarKey);
                            var objJobDiscroption =Global.ObjJobController.GetJobDetail(objSampleDetail.JobBottleDetailId);
                            var objJobDiscroptionParent =Global.ObjJobController.GetJobDetail(objJobDiscroption.ParentId);
                            var bottles = "";
                            try
                            {
                                var bottleId = objSampleDetail.BottleList.Split(',');
                                bottles = bottleId.Select(id => Global.objBottleController.Get(Int32.Parse(id))).Aggregate(bottles, (current, objBottle) => current + (objBottle.PreservativeChemical + "<br />"));
                            }
                            catch(Exception ex)
                            {
                                
                            }
                            
                            tableRow.Cells.Add(new TableCell { Text = objJobDiscroption.JobInfo.JobNumber });
                            tableRow.Cells.Add(new TableCell { Text = objJobDiscroptionParent.Descriptation });
                            tableRow.Cells.Add(new TableCell { Text = bottles });
                            tableRow.Cells.Add(new TableCell {Text = objJobInfo.StartDate.ToString()});
                            tableRow.Cells.Add(new TableCell {Text = objJobInfo.EndDate.ToString()});

                          var  tableCell = new TableCell();
                            var getSamplerList =
                                SampleAssociationController.GetByEventId(objJobInfo.CalendarKey);
                            var Sampler = getSamplerList.Select(sampler => Global.ObjDbController.GetSystemUser(sampler.SamplerID)).Aggregate("", (current, objSystemUser) => current + string.Format("{0} {1}<br />", objSystemUser.FirstName, objSystemUser.LastName));
                            Sampler = Sampler.TrimEnd('<');
                            tableCell.Text = Sampler;
                            tableRow.Cells.Add(tableCell);


                         


                            

                            JobTable.Rows.Add(tableRow);

                        }
                        counter++;

                    }
                }
                LMIS.Admin.Helper.PrintWebControl(pnl1, "");
        }
    }
}