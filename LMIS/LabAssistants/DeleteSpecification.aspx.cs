using System;
using LMIS.DBController;

namespace LMIS.LabAssistants
{
    public partial class DeleteSpecification : System.Web.UI.Page
    {
   
    protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {
                switch (Page.Request.QueryString["spn"])
                {
                    case "1":
                        SpecificationController.DeleteSpecification1(Int32.Parse(Page.Request.QueryString["sid"]));
                        break;
                   
                }

            }
            Response.Redirect(String.Format("ListSpecification.aspx?spn={0}", Page.Request.QueryString["spn"]));
        }
    }
}