using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LMIS.DBController;
using LMIS.DBModel;
namespace LMIS.LabAssistants
{
    public partial class AddEditTestParameterInfo : System.Web.UI.Page
    {

        static readonly DbController objDbController = new DbController();

        private TestParameterInfo objTestParameterInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {
                objTestParameterInfo =
                    objDbController.GetTestParameterInfo(Int32.Parse(Page.Request.QueryString["testId"]));
                AccreditedTestParameter.Text = objTestParameterInfo.AccreditedTestParameter;
                TestMethod.Text = objTestParameterInfo.TestMethod;
                Unit.Text = objTestParameterInfo.Unit;
                Equipment.Text = objTestParameterInfo.Equipment;
                MDL.Text = objTestParameterInfo.MDL;
                ShortTerm.Text = objTestParameterInfo.ShortTerm;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0)
            {
                var objSystemUser = new TestParameterInfo
                                        {
                                            TestParameterId = Int32.Parse(Page.Request.QueryString["testId"]),
                                            AccreditedTestParameter = AccreditedTestParameter.Text,
                                            TestMethod = TestMethod.Text,
                                            Unit = Unit.Text,
                                            Equipment = Equipment.Text,
                                            MDL = MDL.Text,
                                            ShortTerm = ShortTerm.Text
                                        };
                objDbController.UpdateTestParameter(objSystemUser);

            }
            else
            {
                //objDbController.AddSystemTestParameter(AccreditedTestParameter.Text, TestMethod.Text, Unit.Text,
                //                                       Equipment.Text, MDL.Text, ShortTerm.Text);
             
            }
            Response.Redirect("TestParmeterList.aspx");
        }
    }
}