using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBModel;

namespace LMIS.SampleScheduler
{
    public partial class ScheduleControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<JobInfo> GetPaidQuoatio = Global.ObjJobController.GetPaidJob();
                JobList.Items.Clear();
                foreach (var JobInfo in GetPaidQuoatio)
                {
                    JobList.Items.Add(new ListItem()
                    {
                        Text = JobInfo.JobNumber,
                        Value = JobInfo.JobId.ToString()
                    });
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditEvent.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAllEvent.aspx");

        }

        protected void JobList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}