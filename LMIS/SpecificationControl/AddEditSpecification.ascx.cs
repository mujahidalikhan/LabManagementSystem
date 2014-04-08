using System;
using LMIS.DBModel;
using LMIS.DBController;
namespace LMIS.SpecificationControl
{
    public partial class AddEditSpecification : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["sid"] == null || IsPostBack || Page.Request.QueryString["spn"] == null)
                return;

            switch (Page.Request.QueryString["spn"])
            {
                case "1":
                    {
                        var objSpecification =
                            SpecificationController.GetSpecification1(
                                Int32.Parse(Page.Request.QueryString["sid"]));
                        testParameter.Text = objSpecification.TestId.ToString();
                      
                        stdA.Text = objSpecification.StdA;
                        stdB.Text = objSpecification.StdB;
                        customized.Text = objSpecification.Others;
                        break;
                    }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            if (Page.Request.QueryString["sid"] != null)
            {
                switch (Page.Request.QueryString["spn"])
                {
                    case "1":
                        {
                            var objSpecification = new Specification
                                                       {
                                                           SpecificationId =
                                                               Int32.Parse(Page.Request.QueryString["sid"]),
                                                           TestId = Global.ObjDbController.GetTestParameterInfo(Int32.Parse(testParameter.Text)),
                                                          
                                                           StdA = stdA.Text,
                                                           StdB = stdB.Text,
                                                           Others = customized.Text
                                                       };
                            SpecificationController.UpdateSpecification1(objSpecification);
                            break;
                        }
                   
                }





            }
            else
            {
                switch (Page.Request.QueryString["spn"])
                {
                    case "1":
                        {
                            Specification objSpecification = new Specification()
                            {
                                SpecificationName = "Specification 1",
                               
                                StdA = stdA.Text,
                                StdB = stdB.Text,
                                Others = customized.Text,
                            };
                            SpecificationController.AddSpecification1(objSpecification);
                        }
                        break;
            
                }
            }

            Response.Redirect(string.Format("ListSpecification.aspx?spn={0}", Page.Request.QueryString["spn"]));
        }
    }
}