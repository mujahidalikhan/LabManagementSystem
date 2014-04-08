using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Sampler
{
    public partial class DeleteQInfo : System.Web.UI.Page
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {
        
          
        }

        protected void Reset_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["qid"]!=null)
            {
                Global.ObjJobController.DeleteJobInfo(Int32.Parse(Page.Request.QueryString["qid"]), ReasonToDelete.Text);
            }
            Response.Redirect("JobList.aspx");
        }
    }
}