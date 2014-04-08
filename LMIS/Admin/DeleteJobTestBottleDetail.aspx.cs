using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Admin
{
    public partial class DeleteJobTestBottleDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["bid"]== null || IsPostBack) return;
            Global.objJobTestBottleDetailController.Delete(Int32.Parse(Page.Request.QueryString["bid"]));
            Response.Redirect(string.Format("AddJob.aspx?qid={0}&etd=true", Page.Request.QueryString["qid"]));
        }
    }
}
