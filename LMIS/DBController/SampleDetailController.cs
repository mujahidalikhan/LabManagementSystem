using System.Collections.Generic;
using System.Linq;
using LMIS.DBModel;
using LMIS.DBPersistence;
namespace LMIS.DBController
{
    public class SampleDetailController
    {
        private static  readonly PersistenceManager _mPersistenceManager = new PersistenceManager();

        public static  int Add(SampleDetail objSampleDetail)
        {
            return (int)_mPersistenceManager.Save(objSampleDetail);
        }

        public static void Update(SampleDetail objSampleDetail)
        {
            _mPersistenceManager.Update(objSampleDetail);
        }

        public static void Delete(int sampleDetailId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<SampleDetail>("Id", sampleDetailId);
            foreach (var objEvent in EeventList)
            {
                _mPersistenceManager.Delete(objEvent);
            }
        }

        public static SampleDetail Get(int sampleDetailId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<SampleDetail>("Id", sampleDetailId);
            return EeventList.Count > 0 ? EeventList[0] : new SampleDetail();
        }


        public static SampleDetail GetByEventId(int eventId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<SampleDetail>("EventId", eventId);
            return EeventList.Count > 0 ? EeventList[0] : new SampleDetail();
        }

        public static   List<SampleDetail> Get()
        {
            var sampleDetailList = _mPersistenceManager.RetrieveAll<SampleDetail>();
            return sampleDetailList.Count > 0 ? sampleDetailList.ToList() : new List<SampleDetail>();
        }

        public static List<SampleDetail> Get(int activeTestId, bool status)
        {
            string[] colName = { "TestId", "IsSampleTaken" };
            object[] colData = {activeTestId, status};
            var sampleDetailList = _mPersistenceManager.RetrieveEquals<SampleDetail>(colName, colData);
            return sampleDetailList.Count > 0 ? sampleDetailList.ToList() : new List<SampleDetail>();
        }

        public static List<SampleDetail> GetByEventID(int eventId)
        {
            string[] colName = { "EventId" };
            object[] colData = { eventId };
            var sampleDetailList = _mPersistenceManager.RetrieveEquals<SampleDetail>(colName, colData);
            return sampleDetailList.Count > 0 ? sampleDetailList.ToList() : new List<SampleDetail>();
        }
        public static SampleDetail GetByTestid(int activeTestId)
        {
         
            var sampleDetailList = _mPersistenceManager.RetrieveEquals<SampleDetail>("TestId", activeTestId);
            return sampleDetailList.Count > 0 ? sampleDetailList[0] : new SampleDetail();
        }
        public static List<SampleDetail> GetSamplerTest()
        {

            var returnList = _mPersistenceManager.RetrieveAll<SampleDetail>();
            
            return returnList.Count > 0 ? returnList.ToList() : new List<SampleDetail>();
        }

        public static int GetSamplerTestCount(int TestId)
        {
            string[] ColName = new string[] { "TestId", "IsSampleTaken" };
            object[] ColData = new object[] { TestId,true };
            var returnList = _mPersistenceManager.RetrieveEquals<SampleDetail>(ColName, ColData);

            return returnList.Count > 0 ? returnList.Count : 0;
        }

        public static string GetSamplerdescription(int TestId)
        {
            string[] ColName = new string[] {"TestId", "IsSampleTaken"};
            object[] ColData = new object[] {TestId, true};
            string returnValue = "";
            var returnList = _mPersistenceManager.RetrieveEquals<SampleDetail>(ColName, ColData);
            foreach (var sampleDetail in returnList)
            {
                if (!string.IsNullOrEmpty(sampleDetail.SampleDescription))
                {
                    returnValue = sampleDetail.SampleDescription;
                    break;
                }
             
            }
            return returnValue;
        }


        public static SampleDetail GetByJobDetailId(int jobDetailId)
        {
            var sampleDetailList = _mPersistenceManager.RetrieveEquals<SampleDetail>("JobDetailID", jobDetailId);
            if (sampleDetailList.Count > 0)
            {
                return (SampleDetail)sampleDetailList[0];
            }
            else return new SampleDetail();
        }


    }
}