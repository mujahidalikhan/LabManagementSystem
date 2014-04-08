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
    public partial class AddEditIndustry : System.Web.UI.Page
    {
        static readonly DbController objDbController = new DbController();
        private IndustryInfo objIndustryInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
           List<TestParameterInfo> objListTestParameterInfo =  objDbController.GetIndustryTestInfo();
            foreach (var testParameterInfo in objListTestParameterInfo)
            {
                ListItem li = new ListItem();
                li.Value = testParameterInfo.TestParameterId.ToString();
                li.Text = testParameterInfo.ShortTerm;
                testList.Items.Add(li);
            }
            if (Page.Request.QueryString.Count > 0 && !IsPostBack)
            {

                objIndustryInfo = objDbController.GetIndustryInfo(Int32.Parse(Page.Request.QueryString["industryId"]));
                industryName.Text = objIndustryInfo.IndustryName;
                comments.Text = objIndustryInfo.Comments;
                
              

            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (Page.Request.QueryString["industryId"] != null)
            {
                List<TestParameterInfo> objTestParameterInfo = objDbController.GetIndustryTestInfo(objIndustryInfo.IndustryID);
                foreach (var testParameterInfo in objTestParameterInfo)
                {
                    testList.Items.FindByValue(testParameterInfo.TestParameterId.ToString()).Selected = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0)
            {
                objIndustryInfo = new IndustryInfo()
                                      {
                                          IndustryID =Int32.Parse(Page.Request.QueryString["industryId"]), 
                                          IndustryName = industryName.Text,
                                          Comments = comments.Text

                                      };
                objDbController.UpdateIndustry(objIndustryInfo);
                  int[] tempSelectedIndices = testList.GetSelectedIndices();
                var selectedTest = new int[tempSelectedIndices.Length];
                for (int i = 0; i < tempSelectedIndices.Length; i++)
                {

                    selectedTest[i] = Int32.Parse(testList.Items[tempSelectedIndices[i]].Value);
                }
                objDbController.UpdateSystemIndustry(objIndustryInfo.IndustryID, selectedTest);
            }
            else
            {
                #region add industry info

                int industryId = objDbController.AddSystemIndustry(industryName.Text, comments.Text);

                #endregion

                #region add associated test

                int[] tempSelectedIndices = testList.GetSelectedIndices();
                int[] selectedTest = new int[tempSelectedIndices.Length];
                for (int i = 0; i < tempSelectedIndices.Length; i++)
                {

                    selectedTest[i] = Int32.Parse(testList.Items[tempSelectedIndices[i]].Value);
                }
                objDbController.AddSystemIndustry(industryId, selectedTest);
             

                #endregion
            }
            Response.Redirect("IndustryList.aspx");

        }
    }
}