using System;

namespace LMIS.Sampler
{
    public partial class ViewJob : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Page.Request.QueryString["st"] != null)
            {
                ctlupdateJobStatus.JobStaus = "In Progress";
            }
            else
            {
                ctlupdateJobStatus.isViewRequest = true;
            }
        }
    }
}