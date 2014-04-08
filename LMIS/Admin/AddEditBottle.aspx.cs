using System;
using LMIS.DBModel;
namespace LMIS.Admin
{
    public partial class AddEditBottle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["bId"] != null  && !IsPostBack)
            {
                Bottle objBottle = Global.objBottleController.Get(Int32.Parse(Page.Request.QueryString["bId"]));
                PreservativeChemical.Text = objBottle.PreservativeChemical;
                VolumeType1.Text = objBottle.VolumeType1;
                VolumeType2.Text = objBottle.VolumeType2;
                VolumeType3.Text = objBottle.VolumeType3;
             }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.Request.QueryString["bId"]== null)
            {
                var objBottle = new Bottle
                                    {
                                        PreservativeChemical = PreservativeChemical.Text,
                                        VolumeType1 = VolumeType1.Text,
                                        VolumeType2 = VolumeType2.Text,
                                        VolumeType3 = VolumeType3.Text
                                    };
                Global.objBottleController.Add(objBottle);
            }
            else
            {
                var objBottle = Global.objBottleController.Get(Int32.Parse(Page.Request.QueryString["bId"]));
                objBottle.PreservativeChemical = PreservativeChemical.Text;
                objBottle.VolumeType1 = VolumeType1.Text;
                objBottle.VolumeType2 = VolumeType2.Text;
                objBottle.VolumeType3 = VolumeType3.Text;
                Global.objBottleController.Update(objBottle);   
            }

            Response.Redirect("ListSampleBottle.aspx");
        }
    }
}