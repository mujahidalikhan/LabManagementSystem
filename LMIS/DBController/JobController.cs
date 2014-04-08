using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMIS.DBPersistence;
using LMIS.DBModel;

namespace LMIS.DBController
{
    public class JobController
    {
        readonly PersistenceManager _mPersistenceManager = new PersistenceManager();


        #region JobInfo
        public int AddJobInfo(JobInfo objJobInfo)
        {
            return (int)  _mPersistenceManager.Save(objJobInfo);
        }
        public void UpdateJobInfo(JobInfo objJobInfo)
        {
            _mPersistenceManager.Update(objJobInfo);
        }
        public void DeleteJobInfo(int JobId, string ReasonToDelete)
        {

            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("JobId",JobId);
            
            foreach (var JobInfo in listJobInfo)
            {

                var objJobInfoArchive = new JobInfoArchive
                                                                   {
                                                                       JobNumber = JobInfo.JobNumber,
                                                                       Attention = JobInfo.Attention,
                                                                       CC = JobInfo.CC,
                                                                       CreateDate = JobInfo.CreateDate,
                                                                       Validatily = JobInfo.Validatily,
                                                                       TermOfPayment = JobInfo.TermOfPayment,
                                                                       TotalAmount = JobInfo.TotalAmount,
                                                                       RewardPoint = JobInfo.RewardPoint,
                                                                       Payable = JobInfo.Payable,
                                                                       PaymentDate = JobInfo.PaymentDate,
                                                                       Status = JobInfo.Status,
                                                                       Reward = JobInfo.Reward,
                                                                       RewardValue = JobInfo.RewardValue,
                                                                       PaidDate = JobInfo.PaidDate,
                                                                       MicItemsCost = JobInfo.MicItemsCost,
                                                                       MicItemsDescription =
                                                                       JobInfo.MicItemsDescription,
                                                                       Customer = JobInfo.Customer,
                                                                       Comments = ReasonToDelete
                                                                   };                     

                var listJobDetail = _mPersistenceManager.RetrieveEquals<JobDetail>("JobInfo.JobId",JobId);

                _mPersistenceManager.Save(objJobInfoArchive);
                foreach (var JobDetail in listJobDetail)
                {
                    var objJobDetailArchive = new JobDetailArchive
                                                     {
                                                         Descriptation = JobDetail.Descriptation,
                                                         Frequency = JobDetail.Frequency,
                                                       
                                                         Quantity = JobDetail.Quantity,
                                                         
                                                         TestInfo = JobDetail.TestInfo,
                                                         JobInfo = objJobInfoArchive,
                                                         ParentId = JobDetail.ParentId,
                                                         IndustryId = JobDetail.IndustryId,
                                                     };

                    _mPersistenceManager.Save(objJobDetailArchive);
                    _mPersistenceManager.Delete(JobDetail);
                }
                _mPersistenceManager.Delete(JobInfo);
            }
        }


        public List<JobInfo> GetJobInfo()
        {
            var listJobInfo = _mPersistenceManager.RetrieveAll<JobInfo>();
            return listJobInfo.Count > 0 ? listJobInfo.ToList() : new List<JobInfo>();
        }



        public List<JobInfo> GetPaidJob()
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("Status", "In Progress");
            return listJobInfo.Count > 0 ? listJobInfo.ToList() : new List<JobInfo>();
        }

    public int getJobCountByDate(DateTime date)
    {
        IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("CreateDate", date);
        if (listJobInfo.Count > 0)
            return listJobInfo.Count;
        else
            return 0;
    }
    public int getJobCountByStatus(string status)
    {
        IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("Status", status);
        if (listJobInfo.Count > 0)
            return listJobInfo.Count;
        else return 0;

    }

        public JobInfo GetJobInfo(int JobId)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("JobId",JobId);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new JobInfo();
        }

        public JobInfo GetJobInfoByCustomer(int customerId)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("Customer.CustID", customerId);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new JobInfo();
        }

        
        public List<JobInfo> GetJobInfoByStatus(string status)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("Status", status);
            return listJobInfo.Count > 0 ? listJobInfo.ToList() : new List<JobInfo>();
        }


        public void UpdateJobInfoByTestMasterStatus(int JobId)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobDetail>("JobInfo.JobId", JobId);
            if( listJobInfo.Count > 0 )
            {
                foreach (var JobDetail in listJobInfo)
                {
                    var listActivetest = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("JobDetail.JobDetailId", JobDetail.JobDetailId);
                    foreach (var activeTestsInfo in listActivetest)
                    {
                        if (activeTestsInfo.CurrentStatus != "Completed")
                           return;
                    }
                }
            }

            JobInfo objJobInfo = GetJobInfo(JobId);
            objJobInfo.CompleteDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            objJobInfo.Status = "Completed";
            _mPersistenceManager.Update(objJobInfo);

        }



#endregion 

        #region JobDetail
        public int AddJobDetail(JobDetail objJobDetail)
        {
            return (int)_mPersistenceManager.Save(objJobDetail);
        }

        public void AddJobDetail(List<JobDetail> listJobDetail, JobInfo objJobInfo)
        {
            var parentId = 0;
            foreach (var JobDetail in listJobDetail)
            {
                JobDetail.JobInfo = objJobInfo;
                if(JobDetail.Descriptation != null)
                {
                    parentId = AddJobDetail(JobDetail);
                }
                else
                {
                    JobDetail.ParentId = parentId;
                     AddJobDetail(JobDetail);
                }
            }

            
        }

        public void UpdateJobDetail(JobDetail objJobDetail)
        {
            _mPersistenceManager.Update(objJobDetail);
        }
        public void DeleteJobDetail(int JobDetailId)
        {

            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobDetail>("JobDetailId",JobDetailId);
            foreach (var JobDetail in listJobInfo)
            {

                if (JobDetail.ParentId == 0)
                {
                    var listJobDetailChild = _mPersistenceManager.RetrieveEquals<JobDetail>("ParentId", JobDetail.JobDetailId);
                    foreach (var JobDetailChild in listJobDetailChild)
                    {
                        _mPersistenceManager.Delete(JobDetailChild);
                    }
                }

                int JobId = JobDetail.JobInfo.JobId;
                
                    int paretnId = JobDetail.ParentId;
                
                _mPersistenceManager.Delete(JobDetail);


                if(paretnId!= 0)
                {
                    var listJobDetailChild = _mPersistenceManager.RetrieveEquals<JobDetail>("ParentId", paretnId); 
                    if(listJobDetailChild.Count == 0)
                    {
                        var parentJobInfo = _mPersistenceManager.RetrieveEquals<JobDetail>("JobDetailId", paretnId);
                        _mPersistenceManager.Delete(parentJobInfo[0]);
                    }

                }
                List<JobDetail> ListJobs = CurrentJobDetail(JobId);

                int index = 1;
            foreach (JobDetail jobDetail in ListJobs)
            {
                jobDetail.PointNumber = index++;
                UpdateJobDetail(jobDetail);
            }
            }
        }


        public List<JobDetail> CurrentJobDetail(int JobId)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobDetail>("JobInfo.JobId", JobId);
            return listJobInfo.Count > 0 ? listJobInfo.ToList() : new List<JobDetail>();
        }


        public List<JobDetail> GetJobDetailByParent(int parentId)
        {
            var listJobDetailChild = _mPersistenceManager.RetrieveEquals<JobDetail>("ParentId", parentId);
            return listJobDetailChild.Count > 0 ? listJobDetailChild.ToList() : new List<JobDetail>();
        }

      
        public List<JobDetail> JobDescriptionDetail(int JobId)
        {
            string[] colName = {"JobInfo.JobId"};
            object[] data = {JobId};

            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobDetail>(colName, data);
            
            return listJobInfo.Count > 0 ? listJobInfo.ToList() : new List<JobDetail>();
        }


        public JobDetail GetJobDetail(int JobDetailId)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobDetail>("JobDetailId", JobDetailId);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new JobDetail();
        }



   
        #endregion 


        #region Convert Job to Test Master
        
        public void ConvertJobToTestMaster(JobInfo objJobInfo)
        {
            List<JobDetail> listJobDetail = CurrentJobDetail(objJobInfo.JobId);
            var objDbController = new DbController();
            foreach (var jobDetail in listJobDetail)
            {


                int id = objDbController.AddActiveTestInfo(jobDetail.IndustryId,
                                                           objJobInfo.Customer.CustID, DateTime.Now, "", "", null, "",
                                                           "",
                                                           0, "Inactive", 0, "", "", objJobInfo.Attention, jobDetail,
                                                           jobDetail.Point, jobDetail.Urgent, jobDetail.Specification,
                                                           jobDetail.Standard, jobDetail.PointNumber);
                try
                {
                    SampleDetail objSampleDetail = SampleDetailController.GetByJobDetailId(jobDetail.JobDetailId);
                    objSampleDetail.TestId = id;
                    SampleDetailController.Update(objSampleDetail);
                }
                catch (Exception ex)
                {
                    
                }

            }

        }
        
        
        
        #endregion



        #region Job Info Archive Detail 
       
        public int AddJobInfoArchive(JobInfoArchive objJobInfoArchive)
        {
            return (int)_mPersistenceManager.Save(objJobInfoArchive);
        }

        public List<JobInfoArchive> GetJobInfoArchive()
        {
            var listJobInfo = _mPersistenceManager.RetrieveAll<JobInfoArchive>();
            return listJobInfo.Count > 0 ? listJobInfo.ToList() : new List<JobInfoArchive>();
        }
        public JobInfoArchive GetJobInfoArchive(int JobId)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfoArchive>("JobId", JobId);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new JobInfoArchive();
        }
        public List<JobDetailArchive> CurrentJobDetailArchive(int JobId)
        {
            var listJobInfo = _mPersistenceManager.RetrieveEquals<JobDetailArchive>("JobInfo.JobId", JobId);
            return listJobInfo.Count > 0 ? listJobInfo.ToList() : new List<JobDetailArchive>();
        }

        #endregion
    }
}