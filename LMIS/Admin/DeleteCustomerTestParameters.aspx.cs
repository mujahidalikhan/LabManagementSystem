using System;
using LMIS.DBController;


namespace LMIS.Admin
{
    public partial class DeleteCustomerTestParameters : System.Web.UI.Page
    {
             static readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {

                objDbController.DeleteCustomerTestParameters(Int32.Parse(Page.Request.QueryString["ctpId"]));

            }
            Response.Redirect("AddEditCustomerTestParameters.aspx?custId="+ Page.Request.QueryString["custId"]);
        }
    }
    
}