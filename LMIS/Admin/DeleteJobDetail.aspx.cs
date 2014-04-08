using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class DeleteQDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {
                Global.ObjJobController.DeleteJobDetail(Int32.Parse(Page.Request.QueryString["qdid"]));
                Response.Redirect(string.Format("AddJob.aspx?qid={0}&etd=true", Page.Request.QueryString["qid"]));
            }

           
           
        }
    }
}