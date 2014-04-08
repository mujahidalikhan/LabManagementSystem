using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class AddEditPackingInfo : System.Web.UI.Page
    {

        static readonly DbController objDbController = new DbController();
        private PackingInfo objPackingInfo=new PackingInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {

                objPackingInfo = objDbController.GetPackingInfo(Int32.Parse(Page.Request.QueryString["pid"]));
                packingName.Text = objPackingInfo.PackingName;
                packingDescription.Text = objPackingInfo.PackingDescription;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.Request.QueryString.Count > 0 )
            {
                objPackingInfo.PackingInfoId = Int32.Parse(Page.Request.QueryString["pid"]);
                objPackingInfo.PackingName =  packingName.Text;
                objPackingInfo.PackingDescription = packingDescription.Text;
                objDbController.UpdatePackingInfo(objPackingInfo);
            }
            else
            {
                objDbController.AddPackingInfo(packingName.Text, packingDescription.Text);

            }
            Response.Redirect("SamplePackingList.aspx");
        }

       
    }
}