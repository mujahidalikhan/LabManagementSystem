using System;

namespace LMIS.Admin
{
    public partial class DeleteBottle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {

                Global.objBottleController.Delete(Int32.Parse(Page.Request.QueryString["bId"]));
            }
            Response.Redirect("ListSampleBottle.aspx");
        }
    }
}