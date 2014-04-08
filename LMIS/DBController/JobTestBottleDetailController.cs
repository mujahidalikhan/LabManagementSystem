using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMIS.DBModel;
using LMIS.DBPersistence;
namespace LMIS.DBController
{
    public class JobTestBottleDetailController
    {
        readonly PersistenceManager _mPersistenceManager = new PersistenceManager();

        public int Add(JobTestBottleDetail objJobTestBottleDetail)
        {
            return (int)_mPersistenceManager.Save(objJobTestBottleDetail);
        }

        public void Update(JobTestBottleDetail objJobTestBottleDetail)
        {
            _mPersistenceManager.Update(objJobTestBottleDetail);
        }

        public void Delete(int id)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<JobTestBottleDetail>("ID", id);
            foreach (var objEvent in EeventList)
            {
                _mPersistenceManager.Delete(objEvent);
            }
        }

        public JobTestBottleDetail Get(int id)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<JobTestBottleDetail>("ID", id);
            return EeventList.Count > 0 ? EeventList[0] : new JobTestBottleDetail();
        }


        public List<JobTestBottleDetail> GetByJobID(int id)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<JobTestBottleDetail>("JobInfoId", id);
            return EeventList.Count > 0 ? EeventList.ToList() : new List<JobTestBottleDetail>();
        }

        public JobTestBottleDetail GetByJobDetailId(int id)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<JobTestBottleDetail>("JobDetailId", id);
            return EeventList.Count > 0 ? EeventList[0] : new JobTestBottleDetail();
        }

        public JobTestBottleDetail GetByTestId(int id)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<JobTestBottleDetail>("TestId", id);
            return EeventList.Count > 0 ? EeventList[0] : new JobTestBottleDetail();
        } 


        public List<JobTestBottleDetail> Get()
        {
            var bottleList = _mPersistenceManager.RetrieveAll<JobTestBottleDetail>();
            return bottleList.Count > 0 ? bottleList.ToList() : new List<JobTestBottleDetail>();
        }

        public List<JobTestBottleDetail> GetByJobIDAndTestDetail(int JobId)
        {
            string[] colName = { "JobInfoId"};
            object[] colData = { JobId};
            var EeventList = _mPersistenceManager.RetrieveEquals<JobTestBottleDetail>(colName, colData);
            return EeventList.Count > 0 ? EeventList.ToList() : new List<JobTestBottleDetail>();
        }

        public List<JobTestBottleDetail> GetTestDescription(int JobNumber )
        {
            IList<JobTestBottleDetail> retvalue =
                _mPersistenceManager.RetrieveDistinctEquals<JobTestBottleDetail>("JobDetailParentId",
                                                                                       JobNumber);

            foreach (var JobTestBottleDetail in retvalue)
            {
                
            }
            if(retvalue.Count>0)
            return retvalue.ToList();
            else
            {
                return  new List<JobTestBottleDetail>();
            }
        }
        
    }
}