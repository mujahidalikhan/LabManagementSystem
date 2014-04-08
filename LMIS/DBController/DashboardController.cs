using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMIS.DBPersistence;
using LMIS.DBModel;

namespace LMIS.DBController
{
    public class DashboardController
    {
        readonly PersistenceManager _mPersistenceManager = new PersistenceManager();
        public int getJobCountByDate(DateTime date)
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("CreateDate", date.Date);
            if (listJobInfo.Count > 0)
                return listJobInfo.Count;
            else
                return 0;
        }

        public int getJobCountByDateBetween(DateTime date)
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("CompleteDate", date.Date, date.AddDays(DateTime.DaysInMonth(date.Year, date.Month)));
            if (listJobInfo.Count > 0)
                return listJobInfo.Count;
            else
                return listJobInfo.Count;
        }


        public List<JobInfo> getListJobCountByDate(DateTime date)
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("CreateDate", date.Date);
        //   listJobInfo = _mPersistenceManager.RetrieveAll<JobInfo>();
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
                return new  List<JobInfo> ();
        }
        public int getJobCountByStatus(string status)
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("Status", status);
           if(listJobInfo.Count >0)
            return listJobInfo.Count;
           else
           {
               return 0;
           }
        }
        public List<JobInfo> getListPaidJobOfLastSevenDays(DateTime date)
        {

            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("PaidDate", date.Date - (new TimeSpan(7, 0, 0, 0)), date.Date);
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
            {
                return new List<JobInfo>();
            }
        }
        public List<JobInfo> getListApprovedDateJobOfThisWeek(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("ApprovedDate", date.Date, date.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
                return new List<JobInfo>();
        }
        public List<JobInfo> getListEmailByLastSevenDays(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("EmailSend", date.Date, date.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
            {
                return new List<JobInfo>();
            }
        }
        public List<JobInfo> getListCompleteInSevenDays(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("CompleteDate", date.Date, date.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
            {
                return new List<JobInfo>();
            }
        }

        public List<JobInfo> getJobInfoByStatus(string status)
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("Status", status);
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
            {
                return new List<JobInfo>();
            }
        }

        public List<ActiveTestsInfo> getListJobCardCountByStatus(string status)
        {
            IList<ActiveTestsInfo> listActiveTestsInfo = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("CurrentStatus", status);
            if (listActiveTestsInfo.Count > 0)
                return listActiveTestsInfo.ToList();
            else
            {
               return new List<ActiveTestsInfo>();
            }
        }

        public List<ActiveTestsInfo> getListJobCardCompleteInSevenDays(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<ActiveTestsInfo>("ActualEndTime", date.Date, date.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
            {
                return new List<ActiveTestsInfo>();
            }
        }

        public List<ActiveTestsInfo> getListActiveTestInfoByDate(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listActiveTestsInfo = _mPersistenceManager.RetrieveAllBetween<ActiveTestsInfo>("DateCreated", date.Date, date.Date.AddDays(6));
            if (listActiveTestsInfo.Count > 0)
                return listActiveTestsInfo.ToList();
            else
            {
                return new List<ActiveTestsInfo>();
            }

        }

        public List<ActiveTestsInfo> getListSampleCollectOfWeek(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<ActiveTestsInfo>("SampleRecievedOn", date.Date, date.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
                return new List<ActiveTestsInfo>();
        }

        public List<ActiveTestsInfo> getListJobCardCompleteLastSevenDays(DateTime date)
        {
            var mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<ActiveTestsInfo>("ActualEndTime", mondayOfLastWeek.Date, mondayOfLastWeek.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.ToList();
            else
            {
                return new List<ActiveTestsInfo>();
            }
        }


        public int getActiveTestInfoByDate(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listActiveTestsInfo = _mPersistenceManager.RetrieveAllBetween<ActiveTestsInfo>("DateCreated", date.Date, date.Date.AddDays(6));
           if(listActiveTestsInfo.Count >0)
            return listActiveTestsInfo.Count;
           else
           {
               return 0;
           }

        }
        public int getJobCardCountByStatus(string status)
        {
            IList<ActiveTestsInfo> listActiveTestsInfo = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("CurrentStatus", status);
          if(listActiveTestsInfo.Count >0)
            return listActiveTestsInfo.Count;
          else
          {
              return 0;
          }
        }

        public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        public int getPaidJobOfLastSevenDays(DateTime date)
        {
          
                IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("PaidDate", date.Date - (new TimeSpan(7, 0, 0, 0)), date.Date);
            if(listJobInfo.Count > 0)
                return listJobInfo.Count;
            else
            {
                return 0;
            }
        }

       

        public int getJobPaidCountByDate(DateTime date)
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("PaidDate", date.Date);
           if(listJobInfo.Count >0)
            return listJobInfo.Count;
           else
           {
               return 0;
           }
        }

        public Decimal getJobPaidAmountByDate(DateTime date)
        {
            Decimal returnVal = 0;
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("CompleteDate", date.Date, date.AddDays(DateTime.DaysInMonth(date.Year, date.Month)));
            return listJobInfo.Count;
        }

        public int getApprovedDateJobOfLastSevenDays(DateTime date)
        {
            var mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("ApprovedDate", mondayOfLastWeek, mondayOfLastWeek.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.Count;
            else
                return 0;
        }

        public int getApprovedDateJobOfThisWeek(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("ApprovedDate", date.Date, date.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.Count;
            else
                return 0;
        }


        public int getEmailByLastSevenDays(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("EmailSend", date.Date, date.Date.AddDays(6));
           if(listJobInfo.Count > 0)
            return listJobInfo.Count;
           else
           {
               return 0;
           }
        }


        public int getCompleteInSevenDays(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<JobInfo>("CompleteDate", date.Date, date.Date.AddDays(6));
           if(listJobInfo.Count>0)
            return listJobInfo.Count;
           else
           {
               return 0;
           }
        }


        public int getJobCardCompleteInSevenDays(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<ActiveTestsInfo>("ActualEndTime", date.Date, date.Date.AddDays(6));
          if(listJobInfo.Count >0)
            return listJobInfo.Count;
          else
          {
              return 0;
          }
        }

        public int getTestKeyInSevenDays(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<TestResult>("LastUpdateTime", date.Date, date.Date.AddDays(6));
        if(listJobInfo.Count >0)
            return listJobInfo.Count;
        else
        {
            return 0;
        }
        }

        public int getJobCardCompleteLastSevenDays(DateTime date)
        {
            var mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<ActiveTestsInfo>("ActualEndTime", mondayOfLastWeek.Date, mondayOfLastWeek.Date.AddDays(6));
            if(listJobInfo.Count>0)
            return listJobInfo.Count;
            else
            {
                return 0;
            }
        }

        public int getSampleCollectOfWeek(DateTime date)
        {
            date = StartOfWeek(date, DayOfWeek.Monday);
            var listJobInfo = _mPersistenceManager.RetrieveAllBetween<SampleDetail>("SampleCollectDate", date.Date, date.Date.AddDays(6));
            if (listJobInfo.Count > 0)
                return listJobInfo.Count;
            else
                return 0;
        }
    }
}