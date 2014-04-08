using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;
namespace LMIS.SampleScheduler
{
    public partial class AddEventControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack) return;
            JobList.Items.Clear();
            JobList.Items.Add(new ListItem { Text = "---", Value = "0" });
            var GetPaidQuoatio = Global.ObjJobController.GetPaidJob();
            foreach (var JobInfo in GetPaidQuoatio)
            {
                JobList.Items.Add(new ListItem() { Text = JobInfo.JobNumber, Value = JobInfo.JobId.ToString() });
            }

            int eventtId = 0;
            if (Page.Request.QueryString["eId"] != null)
                eventtId = Int32.Parse(Page.Request.QueryString["eId"]);

            var listSystemUsers = Global.ObjDbController.GetSystemUserByRole('S');
            var listAssigneSystemUsers = SampleAssociationController.GetByEventId(eventtId);

            foreach (var systemUser in listSystemUsers)
            {
                var isAssociatedRoleRight =
                    listAssigneSystemUsers.Any(
                        rightse => rightse.SamplerID == systemUser.UserId);

                if (isAssociatedRoleRight)
                    ListAssignedRights.Items.Add(new ListItem() { Text = string.Format("{0} {1}", systemUser.FirstName, systemUser.LastName), Value = systemUser.UserId.ToString() });
                else
                    ListAvailableRights.Items.Add(new ListItem() { Text = string.Format("{0} {1}", systemUser.FirstName, systemUser.LastName), Value = systemUser.UserId.ToString() });
            }
        }

        protected void AddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                string[] startDate = datepicker.Value.Split('/');
                string[] endDate = EndDate.Value.Split('/');

                DateTime eventStartDate =
                    new DateTime(Int32.Parse(startDate[2]), Int32.Parse(startDate[1]), Int32.Parse(startDate[0])).Date;
                DateTime eventEndDate =
                    new DateTime(Int32.Parse(endDate[2]), Int32.Parse(endDate[1]), Int32.Parse(endDate[0])).Date;

                if (ValidateAction(eventStartDate, eventEndDate)) return;

                var objEvent = new DBModel.Events
                {
                    Title = String.Format(@"{0}\r\n{1}", EventTitle.Text, JobList.SelectedItem.Text),
                    StartDate = eventStartDate,
                    EndDate = eventEndDate,
                    AllDayEvent = Convert.ToBoolean(isAllDayEvent.SelectedValue),
                    BackgroundColor = "#" + Color1.Text,
                    JobId = Int32.Parse(JobList.SelectedValue)
                };
                objEvent.StartDate += (new TimeSpan(Int32.Parse(startHr.Value), Int32.Parse(StartMin.Value), 0));
                objEvent.EndDate += (new TimeSpan(Int32.Parse(EndHr.Value), Int32.Parse(EndMin.Value), 0));
                var eventId = Global.ObjEventsController.AddEvent(objEvent);

                string sampleBottle = "";
                foreach (ListItem item in SelectedSampleBottle.Items)
                {
                    if (item.Selected)
                        sampleBottle += SelectedSampleBottle.SelectedValue + ",";
                }
                sampleBottle = sampleBottle.TrimEnd(',');
                var objSampleDetail = new SampleDetail
                {
                    EventId = eventId,
                    AssigneDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                 //   JobBottleDetailId = Int32.Parse(JobTestParameters.SelectedValue),
                    TestId = Global.ObjDbController.GetActiveTestInfoByQoutationInfoId(Int32.Parse(JobList.SelectedValue)).ActiveTestId,
                    NumberOfBottleCollect = SampleCount.Text,
                    BottleList = sampleBottle
                };


                int sampleDetailId = SampleDetailController.Add(objSampleDetail);

                var objSampleAssociation = new SampleAssociation
                {
                    eventId = eventId,
                    AssignDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                    SampleDetailID = sampleDetailId,
                    TestId = Global.ObjDbController.GetActiveTestInfoByQoutationDetailId(objSampleDetail.JobBottleDetailId).ActiveTestId
                };

                foreach (ListItem sampler in ListAssignedRights.Items)
                {
                    objSampleAssociation.SamplerID = Int32.Parse(sampler.Value);
                    SampleAssociationController.Add(objSampleAssociation);
                }


                Response.Redirect("Schedule.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
            }
        }

        private bool ValidateAction(DateTime eventStartDate, DateTime eventEndDate)
        {
            if (eventEndDate < eventStartDate)
            {
                Page.SetFocus(EndDate);
                lblDateError.Visible = true;
                lblDateError.Text = "End Date Must be grater then start date";
                return true;
            }
          

            if (ListAssignedRights.Items.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "Please assign to at least one sampler";
                return true;
            }
           
            return false;
        }

        protected void JobList_SelectedIndexChanged(object sender, EventArgs e)
        {
         


            List<JobTestBottleDetail> listJobTestBottleDetail = Global.objJobTestBottleDetailController.GetByJobIDAndTestDetail(Int32.Parse(JobList.SelectedValue));
            SampleBottle.Items.Clear();
            SelectedSampleBottle.Items.Clear();
            foreach (var JobTestBottleDetail in listJobTestBottleDetail)
            {
                Bottle objBottle = Global.objBottleController.Get(JobTestBottleDetail.BottleId);
                SampleBottle.Items.Add(new ListItem(objBottle.PreservativeChemical, objBottle.bottleId.ToString()));
            }

        }




        protected void BtnShiftAvailableToAssigned_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var itemList = new ListItem[ListAvailableRights.Items.Count];
                for (int i = 0; i < ListAvailableRights.Items.Count; i++)
                {
                    itemList[i] = new ListItem
                    {
                        Text = ListAvailableRights.Items[i].Text,
                        Selected = ListAvailableRights.Items[i].Selected,
                        Value = ListAvailableRights.Items[i].Value,
                    };
                }

                foreach (ListItem item in itemList)
                {
                    if (!item.Selected) continue;

                    ListAssignedRights.Items.Add(item);
                    ListAvailableRights.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void BtnShiftAssignedToAvailable_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ListItem[] itemList = new ListItem[ListAssignedRights.Items.Count];
                for (int i = 0; i < ListAssignedRights.Items.Count; i++)
                {
                    itemList[i] = new ListItem
                    {
                        Text = ListAssignedRights.Items[i].Text,
                        Selected = ListAssignedRights.Items[i].Selected,
                        Value = ListAssignedRights.Items[i].Value,
                    };
                }


                foreach (ListItem item in itemList)
                {
                    if (!item.Selected) continue;
                    ListAvailableRights.Items.Add(item);
                    ListAssignedRights.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void JobTestParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            List<JobTestBottleDetail> listJobTestBottleDetail = Global.objJobTestBottleDetailController.GetByJobIDAndTestDetail(Int32.Parse(JobList.SelectedValue));
           SampleBottle.Items.Clear();
            SelectedSampleBottle.Items.Clear();
            foreach (var JobTestBottleDetail in listJobTestBottleDetail)
            {
                Bottle objBottle = Global.objBottleController.Get(JobTestBottleDetail.BottleId);
                SampleBottle.Items.Add(new ListItem(objBottle.PreservativeChemical,objBottle.bottleId.ToString()));
            }
        }

        protected void BtnShiftSampleBottleToSelectedBottle_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var itemList = new ListItem[SampleBottle.Items.Count];
                for (int i = 0; i < SampleBottle.Items.Count; i++)
                {
                    itemList[i] = new ListItem
                    {
                        Text = SampleBottle.Items[i].Text,
                        Selected = SampleBottle.Items[i].Selected,
                        Value = SampleBottle.Items[i].Value,
                    };
                }

                foreach (ListItem item in itemList)
                {
                    if (!item.Selected) continue;

                    SelectedSampleBottle.Items.Add(item);
                    SampleBottle.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void BtnShiftSelectedBottleToSampleBottle_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var itemList = new ListItem[SelectedSampleBottle.Items.Count];
                for (int i = 0; i < SelectedSampleBottle.Items.Count; i++)
                {
                    itemList[i] = new ListItem
                    {
                        Text = SelectedSampleBottle.Items[i].Text,
                        Selected = SelectedSampleBottle.Items[i].Selected,
                        Value = SelectedSampleBottle.Items[i].Value,
                    };
                }


                foreach (ListItem item in itemList)
                {
                    if (!item.Selected) continue;
                    SampleBottle.Items.Add(item);
                    SelectedSampleBottle.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}