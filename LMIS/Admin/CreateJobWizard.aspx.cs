using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Admin
{
    public partial class CreateJobWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            myMV.ActiveViewIndex = 0;
        }

        protected void cmdNext_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex += 1;
        }

        protected void cmdPrev1_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex -= 1;
        }

        protected void cmdNext1_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex += 1;
        }

        protected void cmdPrev_Click(object sender, EventArgs e)
        {
            myMV.ActiveViewIndex -= 1;
        }

        protected void cmdFinish_Click(object sender, EventArgs e)
        {
            
        // MultiView Visible property to false

            myMV.Visible = false;


            
        //Set Label Control visible property to true


            lblValues.Text = "End";
        }
    }
}