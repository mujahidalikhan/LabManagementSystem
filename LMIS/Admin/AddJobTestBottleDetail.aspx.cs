using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBModel;
namespace LMIS.Admin
{
    public partial class AddJobTestBottleDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(IsPostBack)
                return;
            List<JobDetail> list = Global.ObjJobController.JobDescriptionDetail(Int32.Parse(Page.Request.QueryString["qid"]));
            JobTestDescription.Items.Clear();
            TestDetail.Value = "";
            JobTestDescription.Items.Add(new ListItem { Text = "---", Value = "0" });
            var counter = 1;
            foreach (JobDetail JobDetail in list)
            {
                JobTestDescription.Items.Add(new ListItem { Text = "Test Description " + counter, Value = JobDetail.JobDetailId.ToString() });
                counter++;
            }

            SampleBottle.Items.Clear();
            List<Bottle> listSampleBottle = Global.objBottleController.Get();
            foreach (var bottle in listSampleBottle)
            {
                SampleBottle.Items.Add(new ListItem { Text = bottle.PreservativeChemical, Value = bottle.bottleId.ToString() });
            }
        }
        protected void JobTestDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobDetail objJobDetail = Global.ObjJobController.GetJobDetail(Int32.Parse(JobTestDescription.SelectedValue));
            TestDetail.Value = objJobDetail.Descriptation;

            List<JobDetail> listChild =
                Global.ObjJobController.GetJobDetailByParent(
                    Int32.Parse(JobTestDescription.SelectedValue));

            JobTestParameters.Items.Clear();
            JobTestParameters.Items.Add(new ListItem { Text = "---", Value = "0" });
            var counter = 1;
            foreach (JobDetail JobDetail in listChild)
            {
                JobTestParameters.Items.Add(new ListItem { Text = "Test " + counter, Value = JobDetail.JobDetailId.ToString() });
                counter++;
            }

        }
        protected void JobTestParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobDetail objJobDetail = Global.ObjJobController.GetJobDetail(Int32.Parse(JobTestParameters.SelectedValue));
            TestParameter.Items.Clear();
            if(objJobDetail.JobDetailId == 0)
                return;

            String []testList =  objJobDetail.TestInfo.Split(',');

            foreach (var s in testList)
            {
                Global.ObjDbController.GetByTestName(s);
            }
            string[] currnetTestList = objJobDetail.TestInfo.Split(',');
            foreach (var test in currnetTestList)
            {
              TestParameterInfo objTestParameterInfo =   Global.ObjDbController.GetByTestName(test);
                if(objTestParameterInfo.TestParameterId != 0)
                {
                    TestParameter.Items.Add(new ListItem{Text = objTestParameterInfo.AccreditedTestParameter , Value = objTestParameterInfo.TestParameterId.ToString()});
                }
            }
        }

        protected void btnSkipAddingBottle_Click(object sender, EventArgs e)
        {
            if (SampleBottle.Items.Count == 0 || JobTestDescription.Items.Count == 0)
                return;
            var objJobTestBottleDetail = new JobTestBottleDetail
            {
                JobDetailId = Int32.Parse(JobTestParameters.SelectedValue),
                BottleId = Int32.Parse(SampleBottle.SelectedValue),
                TestId = Int32.Parse(TestParameter.SelectedValue),
                BottleRequired = Int32.Parse(JobDetailBottleCount.Text),
                JobDetailParentId = Int32.Parse(JobTestDescription.SelectedValue),
                JobInfoId = Int32.Parse(Page.Request.QueryString["qid"])
            };
            Global.objJobTestBottleDetailController.Add(objJobTestBottleDetail);
            Response.Redirect(string.Format("AddJob.aspx?qid={0}&etd=true", Page.Request.QueryString["qid"]));
        }

    }
}