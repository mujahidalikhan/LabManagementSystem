using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMIS.DBModel;
using LMIS.DBPersistence;

namespace LMIS.DBController
{
    public class DbController
    {
        readonly PersistenceManager _mPersistenceManager = new PersistenceManager();

        public void AddSystemUser(String firstName, string lastName, string email, string userName, string Password, char type)
        {
            var objSystemUser = new SystemUsers
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
                UserName = userName,
                Password = Password,
                Type = type
            };
            _mPersistenceManager.Save(objSystemUser);
        }

        public int AddActiveTestInfo(int IndustryId, int customerId,
            DateTime dateCreated, string sampleInformation,
            string sampleDescription, DateTime? sampleRecivedOn,
            string typeOfsampling, String analysisCondition,
            int packingid, string currentStatus, int assignTo,
            string labNumber, string specificationType,
            int attention, JobDetail objJobDetail, String point, String urgent, String sepc, String standard, int PointNumber)
        {
            var objActiveTestInfor = new ActiveTestsInfo()
            {
                IndustryId = IndustryId,
                CustomerId = customerId,
                DateCreated = dateCreated,
                SampleInformation = sampleInformation,
                SampleDescription = sampleDescription,
                SampleRecievedOn = sampleRecivedOn,
                TypeOfSampling = typeOfsampling,
                AnalysisCondition = analysisCondition,
                PackingId = packingid,
                CurrentStatus = currentStatus,
                AssignTo = assignTo,
                LabNumber = labNumber,
                SpecificationType = specificationType,
                Attention = attention,
                JobDetail = objJobDetail,
                JobInfoId = objJobDetail.JobInfo.JobId,
                Point = point,
                Urgent = urgent,
                Specification = sepc,
                Standard = standard,
                PointNumber = PointNumber
                
            };
            objActiveTestInfor.Customer = GetCustomerInfo(customerId);
          //  objActiveTestInfor.Industry = GetIndustryInfo(IndustryId);
            int ActiveTestId = (int)_mPersistenceManager.Save(objActiveTestInfor);

            TestResult objTestResult = new TestResult();
            objTestResult.ActiveTestId = ActiveTestId;

            string[] currnetTestList = objJobDetail.TestInfo.Split(',');
            foreach (var test in currnetTestList)
            {
                IList<TestParameterInfo> listTestParameterInfo = _mPersistenceManager.RetrieveEquals<TestParameterInfo>("AccreditedTestParameter",test);
                objTestResult.TestParameterInfoId = listTestParameterInfo[0].TestParameterId;
                _mPersistenceManager.Save(objTestResult);
            }

            return ActiveTestId;

        }


        public TestParameterInfo GetByTestName(string testName)
        {
            IList<TestParameterInfo> listTestParameterInfo = _mPersistenceManager.RetrieveEquals<TestParameterInfo>("AccreditedTestParameter", testName);
            if (listTestParameterInfo.Count > 0)
                return listTestParameterInfo[0];
            else
            {
                return  new TestParameterInfo();
            }
         
        }
        public List<ActiveTestsInfo> GetActiveTestInfoByQoutationId(int JobId)
        {
            IList<ActiveTestsInfo> listActiveTestInfo = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("JobInfoId",JobId);
            if (listActiveTestInfo.Count > 0)
                return listActiveTestInfo.ToList();
            else
            {
                return  new List<ActiveTestsInfo>();
            }
        }
        //public List<JobInfo> GetJobInfoBySpecName(string SpecName)
        //{
        //    IList<JobInfo> listActiveTestInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("Specification", SpecName);
        //    if (listActiveTestInfo.Count > 0)
        //        return listActiveTestInfo.ToList();
        //    else
        //    {
        //        return new List<JobInfo>();
        //    }
        //}

        public List<ActiveTestsInfo> GetUrgentCount(string Specification, string Urgent)
        {
            try
            {

            string[] propertyName = { "Specification", "Urgent" };
            object[] propertyValue = { Specification, Urgent };
            var objList = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>(propertyName, propertyValue);
            return objList.Count > 0 ? objList.ToList() : new List<ActiveTestsInfo>();

            }
            catch (Exception)
            {
                return  new List<ActiveTestsInfo>();
            }
        }

        public List<ActiveTestsInfo> GetComopletedCount(string Specification, string Status)
        {
            string[] propertyName = { "Specification", "CurrentStatus" };
            object[] propertyValue = { Specification, Status };
            var objList = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>(propertyName, propertyValue);
            return objList.Count > 0 ? objList.ToList() : new List<ActiveTestsInfo>();
        }
      

        public ActiveTestsInfo GetActiveTestInfoByQoutationDetailId(int JobDetailID)
        {
            IList<ActiveTestsInfo> listActiveTestInfo = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("JobDetail.JobDetailId", JobDetailID);
            return listActiveTestInfo.Count > 0 ? listActiveTestInfo[0] : new ActiveTestsInfo();
        }

        public JobInfo GetJobInfoByJobId(int JobInfoID)
        {
            IList<JobInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<JobInfo>("JobId", JobInfoID);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new JobInfo();
        }

        public SampleDetail GetSampleDetailByTestId(int TestID)
        {
            IList<SampleDetail> listJobInfo = _mPersistenceManager.RetrieveEquals<SampleDetail>("TestId", TestID);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new SampleDetail();
        }

        public List<SampleDetail> GetSampleList(int TestID)
        {
            string[] propertyName = { "TestId" };
            object[] propertyValue = { TestID };
            var objList = _mPersistenceManager.RetrieveEquals<SampleDetail>(propertyName, propertyValue);
            return objList.Count > 0 ? objList.ToList() : new List<SampleDetail>();
        }

        public Bottle GetBottleBybbottleId(int bottleId)
        {
            IList<Bottle> listJobInfo = _mPersistenceManager.RetrieveEquals<Bottle>("bottleId", bottleId);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new Bottle();
        }


        public ActiveTestsInfo GetActiveTestInfoByQoutationInfoId(int JobInfoID)
        {
            IList<ActiveTestsInfo> listActiveTestInfo = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("JobInfoId", JobInfoID);
            return listActiveTestInfo.Count > 0 ? listActiveTestInfo[0] : new ActiveTestsInfo();
        }


        public int AddCustomer(CustomerInfo objCustomerInfo)
        {

            return (int)_mPersistenceManager.Save(objCustomerInfo);
        }

        public int AddContact(ContactInfo objContactInfo)
        {

            return (int)_mPersistenceManager.Save(objContactInfo);
        }

        public int AddPoints(PointsInfo objPointsInfo)
        {
            return (int)_mPersistenceManager.Save(objPointsInfo);
        }



        public List<PointsInfo> GetPoints(int custId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<PointsInfo>("CustID", custId);
            return objList.Count > 0 ? objList.ToList() : new List<PointsInfo>();
        }

        public PointsInfo GetPointById(int Id)
        {
            IList<PointsInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<PointsInfo>("Id", Id);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new PointsInfo();
        }

        public PointsInfo GetPointByCustID(int CustID)
        {
            IList<PointsInfo> listJobInfo = _mPersistenceManager.RetrieveEquals<PointsInfo>("CustID", CustID);
            return listJobInfo.Count > 0 ? listJobInfo[0] : new PointsInfo();
        }


        public int AddRecordHistory(RecordHistory objRecordHistory)
        {
            return (int)_mPersistenceManager.Save(objRecordHistory);
        }

        public int AddIntermediateCustomerContact(IntermediateCustomerContact objInter)
        {
            return (int)_mPersistenceManager.Save(objInter);
        }

        public string[] GetUserContact(int userid)
        {
            IList<CustomerInfo> objSystemUsers = _mPersistenceManager.RetrieveEquals<CustomerInfo>("CustID", userid);
            if (objSystemUsers.Count > 0)
            {
                string[] userList = {objSystemUsers[0].Person1, objSystemUsers[0].Person2, objSystemUsers[0].Person3};

                return userList;
            }
            return  new string[0];
        }
        public void UpdateActiveTestInfo(ActiveTestsInfo objActiveTestsInfo)
        {
            if (objActiveTestsInfo.CustomerId != 0)
                objActiveTestsInfo.Customer = GetCustomerInfo(objActiveTestsInfo.CustomerId);
            //if (objActiveTestsInfo.IndustryId != 0)
            //    objActiveTestsInfo.Industry = GetIndustryInfo(objActiveTestsInfo.IndustryId);
            _mPersistenceManager.Update(objActiveTestsInfo);
        }

        public void UpdateCustomer(CustomerInfo objCustomerInfo)
        {
            _mPersistenceManager.Update(objCustomerInfo);
        }

        public void UpdateContact(ContactInfo objContactInfo)
        {
            _mPersistenceManager.Update(objContactInfo);
        }

        public void UpdatePoints(PointsInfo objPointsInfo)
        {
            _mPersistenceManager.Update(objPointsInfo);
        }

        public void UpdateRecordHistory(RecordHistory objRecordHistory)
        {
            _mPersistenceManager.Update(objRecordHistory);
        }



        public void AddSystemTestParameter(TestParameterInfo objTestParameterInfo)
        {

            _mPersistenceManager.Save(objTestParameterInfo);
        }
        public int AddPackingInfo(String packingName, string description)
        {
            var objPackingInfo = new PackingInfo()
            {
                PackingName = packingName,
                PackingDescription = description

            };
            return (int)_mPersistenceManager.Save(objPackingInfo);
        }
        public int AddSystemIndustry(String industryName, string comments)
        {
            var objIndustryInfo = new IndustryInfo()
            {
                IndustryName = industryName,
                Comments = comments

            };
            return (int)_mPersistenceManager.Save(objIndustryInfo);
        }

        public void AddSystemIndustry(int industryId, int[] testId)
        {
            var objIndustryTestInfo = new IndustryTestInfo()
            {
                IndustryInfoId = industryId,

            };

            foreach (var i in testId)
            {
                objIndustryTestInfo.TestParameterId = i;
                _mPersistenceManager.Save(objIndustryTestInfo);
            }

        }
        public void UpdateSystemIndustry(int industryId, int[] testId)
        {

            var objList = _mPersistenceManager.RetrieveEquals<IndustryTestInfo>("IndustryInfoId", industryId);
            foreach (var industryTestInfo in objList)
            {
                _mPersistenceManager.Delete(industryTestInfo);
            }


            var objIndustryTestInfo = new IndustryTestInfo()
            {
                IndustryInfoId = industryId,

            };

            foreach (var i in testId)
            {
                objIndustryTestInfo.TestParameterId = i;
                _mPersistenceManager.Save(objIndustryTestInfo);
            }

        }
        public void DeleteIndustry(int industryId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<IndustryInfo>("IndustryID", industryId);
            foreach (var industryInfo in objList)
            {
                _mPersistenceManager.Delete(industryInfo);
            }

            var objList1 = _mPersistenceManager.RetrieveEquals<IndustryTestInfo>("IndustryInfoId", industryId);
            foreach (var industryInfo in objList1)
            {
                _mPersistenceManager.Delete(industryInfo);
            }
        }
        public void DeletPackingInfo(int packinfInfoId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<PackingInfo>("PackingInfoId", packinfInfoId);
            foreach (var packingInfo in objList)
            {
                _mPersistenceManager.Delete(packingInfo);
            }


        }

        public List<SystemUsers> GetSystemUserByRole(char roleType)
        {
            var objList = _mPersistenceManager.RetrieveEquals<SystemUsers>("Type", roleType);
            if (objList.Count > 0)
                return objList.ToList();
            else
            {
                return new List<SystemUsers>();
            }
        }

        public SystemUsers GetSystemUser(int userId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<SystemUsers>("UserId", userId);
            if (objList.Count > 0)
                return objList[0];
            else
                return new SystemUsers();
        }

        public IndustryInfo GetIndustryInfo(int industryInfo)
        {
            var objList = _mPersistenceManager.RetrieveEquals<IndustryInfo>("IndustryID", industryInfo);
            if (objList.Count > 0)
                return objList[0];
            else
                return new IndustryInfo();
        }
        public PackingInfo GetPackingInfo(int packingInfoId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<PackingInfo>("PackingInfoId", packingInfoId);
            if (objList.Count > 0)
                return objList[0];
            else
               return new PackingInfo();
        }
        public void DeleteSystemUser(int userId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<SystemUsers>("UserId", userId);
            _mPersistenceManager.Delete(objList[0]);
        }


        public void DeleteClient(int customerId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<CustomerInfo>("CustID", customerId);
            _mPersistenceManager.Delete(objList[0]);
        }

        public void DeleteContact(int contactId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<ContactInfo>("Id", contactId);
            _mPersistenceManager.Delete(objList[0]);
        }

        public void DeletePoints(int pointId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<PointsInfo>("Id", pointId);
            _mPersistenceManager.Delete(objList[0]);
        }

        public void DeleteobjActiveTestsInfo(int activeTestId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("ActiveTestId", activeTestId);
            foreach (var activeTestsInfo in objList)
            {
                _mPersistenceManager.Delete(activeTestsInfo);
            }

        }
        public void DeleteSystemTestParameterInfo(int testId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<TestParameterInfo>("TestParameterId", testId);
            IList<IndustryTestInfo> listIndustryTestInfo = _mPersistenceManager.RetrieveEquals<IndustryTestInfo>("TestParameterId", testId);
            foreach (var industryTestInfo in listIndustryTestInfo)
            {
                _mPersistenceManager.Delete(industryTestInfo);
            }
            _mPersistenceManager.Delete(objList[0]);
        }

        public void UpdateTestParameter(TestParameterInfo objTestParameterInfo)
        {

            _mPersistenceManager.Update(objTestParameterInfo);
        }

        public void UpdateSystemUser(SystemUsers objSystemUsers)
        {

            _mPersistenceManager.Update(objSystemUsers);
        }

        public void UpdateIndustry(IndustryInfo objIndustryInfo)
        {

            _mPersistenceManager.Update(objIndustryInfo);
        }


        public void UpdatePackingInfo(PackingInfo objPackingInfo)
        {

            _mPersistenceManager.Update(objPackingInfo);
        }


        public void UpdateTestResult(TestResult objTestResult)
        {
            objTestResult.IsLocked = false;
            _mPersistenceManager.Update(objTestResult);
        }


        public List<TestResult> GetTempUpdateResultByUser(int userId, int testId)
        {
            var propertyName = new string[2];
            var propertyValue = new object[2];
            propertyName[0] = "TmpChangeBy";
            propertyName[1] = "ActiveTestId";
            propertyValue[0] = userId;
            propertyValue[1] = testId;

            var getUpdateResult = _mPersistenceManager.RetrieveEquals<TestResult>(propertyName, propertyValue);
            return getUpdateResult.Count > 0 ? getUpdateResult.ToList() : new List<TestResult>();
        }

        public SystemUsers ValidateUser(string userName, string passwrod)
        {
            var propertyName = new string[2];
            var propertyValue = new object[2];
            propertyName[0] = "UserName";
            propertyName[1] = "Password";
            propertyValue[0] = userName;
            propertyValue[1] = passwrod;
            var getSystemUsers = _mPersistenceManager.RetrieveEquals<SystemUsers>(propertyName, propertyValue);


            return getSystemUsers.Count > 0 ? getSystemUsers[0] : null;
        }



        public List<SystemUsers> GetSystemUser()
        {
            var objList = _mPersistenceManager.RetrieveAll<SystemUsers>();
            if(objList.Count >0)
            return objList.ToList();
            else 
              return  new List<SystemUsers>();
        }

        public List<IndustryInfo> GetIndustryInfo()
        {
            var objList = _mPersistenceManager.RetrieveAll<IndustryInfo>();
            if(objList.Count>0)
            return objList.ToList();
            else 
                return new List<IndustryInfo>();
        }



        public TestResult GetTestResultById(int testResultId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<TestResult>("TestResultId", testResultId);
            return objList.Count > 0 ? objList[0] : new TestResult();
        }

        public List<TestResult> GetTestResultByTestParameterInfoId(int testParameterInfoId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<TestResult>("TestParameterInfoId", testParameterInfoId);
            if(objList.Count >0)
            return objList.ToList();
            else 
                return  new List<TestResult>();
        }


        public List<TestResult> GetTestResult(int activeTestId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<TestResult>("ActiveTestId", activeTestId);
            if (objList.Count > 0)
                return objList.ToList();
            else
                return new List<TestResult>();
        }


        public TestResult GetTestResultByUserAndTestParam(int UserId, int TestParameterId)
        {
            var propertyName = new string[2];
            var propertyValue = new object[2];
            propertyName[0] = "LastUpdateBy";
            propertyName[1] = "TestParameterInfoId";
            propertyValue[0] = UserId;
            propertyValue[1] = TestParameterId;
            var getTestResult = _mPersistenceManager.RetrieveEquals<TestResult>(propertyName, propertyValue);
            return getTestResult.Count > 0 ? getTestResult[0] : new TestResult();
        }

        public List<TestParameterInfo> GetIndustryTestInfo()
        {
            var objList = _mPersistenceManager.RetrieveAll<TestParameterInfo>();
            if(objList.Count>0)
            return objList.ToList();
            else
            {
                return new List<TestParameterInfo>();
            }
        }
        public TestParameterInfo GetTestParameterInfo(int testId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<TestParameterInfo>("TestParameterId", testId);
            if (objList.Count >0)
            return objList[0];
            else 
                return new TestParameterInfo();
        }
        public bool IsTestParameterInfoExist(String accreditedTestParameter)
        {
            var objList = _mPersistenceManager.RetrieveEquals<TestParameterInfo>("AccreditedTestParameter", accreditedTestParameter);
            if (objList.Count > 0)
                return true;
            else
                return false;
        }
        public List<TestParameterInfo> GetIndustryTestInfo(int IndustryId)
        {
            try
            {
                var objList = _mPersistenceManager.RetrieveEquals<IndustryTestInfo>("IndustryInfoId", IndustryId);
                if (objList.Count>0)
                return objList.Select(industryTestInfo =>
                                      _mPersistenceManager.RetrieveEquals<TestParameterInfo>
                                          ("TestParameterId", industryTestInfo.TestParameterId)).Select(
                                              objTestParameterInfoList => objTestParameterInfoList[0]).ToList();
                else
                {
                    return new List<TestParameterInfo>();
                }
            }
            catch(Exception ex)
            {
                return new List<TestParameterInfo>();
            }
        }
        public List<TestParameterInfo> GetTestInfo()
        {
            try
            {
                var objList = _mPersistenceManager.RetrieveAll<IndustryTestInfo>();
                if (objList.Count > 0)
                    return objList.Select(industryTestInfo =>
                                          _mPersistenceManager.RetrieveEquals<TestParameterInfo>
                                              ("TestParameterId", industryTestInfo.TestParameterId)).Select(
                                                  objTestParameterInfoList => objTestParameterInfoList[0]).ToList();
                else
                {
                    return new List<TestParameterInfo>();
                }
            }
            catch (Exception ex)
            {
                return new List<TestParameterInfo>();
            }
        }
        public List<CustomerInfo> GetCustomerInfo()
        {
            var objList = _mPersistenceManager.RetrieveAll<CustomerInfo>();
            return objList.Count > 0 ? objList.Where(x =>  x.Status != "Deleted").ToList() : new List<CustomerInfo>();
        }

        public List<PackingInfo> GetPackingInfo()
        {
            var objList = _mPersistenceManager.RetrieveAll<PackingInfo>();
            if(objList.Count>0)
            return objList.ToList();
            else
            {
                return new List<PackingInfo>();
            }
        }
        public ActiveTestsInfo GetActiveTestInfo(int activeTestId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<ActiveTestsInfo>("ActiveTestId", activeTestId);
            return objList.Count > 0 ? objList[0] : new ActiveTestsInfo();
        }

        public CustomerInfo GetCustomerInfo(int customerId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<CustomerInfo>("CustID", customerId);
            if(objList.Count>0)
            return objList[0];
            else 
                return new CustomerInfo();
        }

        public ContactInfo GetContactInfo(int contactID)
        {
            var objList = _mPersistenceManager.RetrieveEquals<ContactInfo>("CustID", contactID);
            if (objList.Count > 0)
                return objList[0];
            else
                return new ContactInfo();
        }

        public ContactInfo GetContactInfoById(int ID)
        {
            var objList = _mPersistenceManager.RetrieveEquals<ContactInfo>("Id", ID);
            if (objList.Count > 0)
                return objList[0];
            else
                return new ContactInfo();
        }


        public List< ContactInfo > GetCusotmerContactInfo(int contactID)
        {
            var objList = _mPersistenceManager.RetrieveEquals<ContactInfo>("CustID", contactID);
            if (objList.Count > 0)
                return objList.ToList();
            else
                return new List<ContactInfo>();
        }

        public CustomerInfo GetCustomerData(string customerName)
        {
            IList<CustomerInfo> objList = _mPersistenceManager.RetrieveEqualLike<CustomerInfo>("CustName", customerName);
            return objList.Count > 0 ? objList[0] : new CustomerInfo();
        }

        public CustomerInfo GetCustomerbyId(int custId)
        {
            IList<CustomerInfo> objList = _mPersistenceManager.RetrieveEquals<CustomerInfo>("CustID", custId);
            return objList.Count > 0 ? objList[0] : new CustomerInfo();
        }

        public string[] GetCustomerInfo(string name)
        {
            var objList = _mPersistenceManager.RetrieveLike<CustomerInfo>("CustName", name);
            if (objList.Count <= 0)
                return null;
            var Name = new string[objList.Count];
            for (var i = 0; i < objList.Count; i++)
            {
                Name[i] = objList[i].CustName;
            }
            return Name;
        }


        public IList<ActiveTestsInfo> RetrieveAllTestInfo()
        {
            
            var objList = _mPersistenceManager.RetrieveAll<ActiveTestsInfo>(); 
            if(objList.Count >0)
            {
                return objList;
            }
            return new List<ActiveTestsInfo>();

        }

        public IList<PointsInfo> RetrieveAllPointsInfo()
        {

            var objList = _mPersistenceManager.RetrieveAll<PointsInfo>();
            if (objList.Count > 0)
            {
                return objList;
            }
            return new List<PointsInfo>();

        }

        public IList<RecordHistory> RetrieveAllRecordHistory()
        {

            var objList = _mPersistenceManager.RetrieveAll<RecordHistory>();
            if (objList.Count > 0)
            {
                return objList;
            }
            return new List<RecordHistory>();

        }


        public void UpdateSmtpSettings(string serverAddress, int serverPort, string userName, string password, string fromName, string fromEmail, bool enableSSL)
        {
            IList<SmtpSetting> objSmtpSetting = _mPersistenceManager.RetrieveAll<SmtpSetting>(SessionAction.BeginAndEnd);

            if (objSmtpSetting.Count <= 0)
            {
                SmtpSetting objAddSmtpSetting = new SmtpSetting
                                                 {
                                                     FromName = fromEmail,
                                                     FromEmail = fromEmail,
                                                     Password = password,
                                                     ServerAddress = serverAddress,
                                                     ServerPort = serverPort,
                                                     UserName = userName,
                                                     EnableSSL = enableSSL
                                                 };
                _mPersistenceManager.Save(objAddSmtpSetting);
            }
            else
            {
                if (!String.IsNullOrEmpty(serverAddress))
                    objSmtpSetting[0].ServerAddress = serverAddress;

                objSmtpSetting[0].ServerPort = serverPort;

                if (!String.IsNullOrEmpty(userName))
                    objSmtpSetting[0].UserName = userName;

                if (!String.IsNullOrEmpty(password))
                    objSmtpSetting[0].Password = password;

                if (!String.IsNullOrEmpty(fromName))
                    objSmtpSetting[0].FromName = fromName;

                if (!String.IsNullOrEmpty(fromEmail))
                    objSmtpSetting[0].FromEmail = fromEmail;

                _mPersistenceManager.Update(objSmtpSetting[0]);
            }
        }
        public SmtpSetting GetSmtpSetting()
        {
            var listSmtpSetting = _mPersistenceManager.RetrieveAll<SmtpSetting>();
            return listSmtpSetting.Count >0 ? listSmtpSetting[0] : new SmtpSetting();
        }


        public int AddCustomerTestParameters(int customerId, int testParametersId, string specification, bool stdA, bool stdB, bool defaultVal, int industyID)
        {
            var objCustomerTestParameters = new CustomerTestParameters
            {
                CustomerId = customerId,
                TestParametersId = testParametersId,
                Specification = specification,
                StdA = stdA,
                StdB = stdB,
                DefaultVal = defaultVal,
                IndustyID = industyID
            };

            return (int)_mPersistenceManager.Save(objCustomerTestParameters);
        }




        public List<CustomerTestParameters> GetCustomerTestParameters(int customerId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<CustomerTestParameters>("CustomerId", customerId);
            if(objList.Count>0)
            return objList.ToList();
            else
            {
                return new List<CustomerTestParameters>();
            }
        }



        public void DeleteCustomerTestParameters(int customerTestParameterId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<CustomerTestParameters>("CustomerTestParameterId", customerTestParameterId);
            _mPersistenceManager.Delete(objList[0]);
        }


        public List<CustomerTestParameters> GetCustomerTestParameters(int customerId, int industyID)
        {
            string[] propertyName = { "CustomerId", "IndustyID" };

            object[] propertyValue = { customerId, industyID };

            var objList = _mPersistenceManager.RetrieveEquals<CustomerTestParameters>(propertyName, propertyValue);

            return objList.Count > 0 ? objList.ToList() : new List<CustomerTestParameters>();
        }

        public List<CustomerTestParameters> GetCustomerTestParameters(int customerId, int industyID, int testParametersId)
        {
            string[] propertyName = { "CustomerId", "IndustyID", "TestParametersId" };

            object[] propertyValue = { customerId, industyID, testParametersId };

            var objList = _mPersistenceManager.RetrieveEquals<CustomerTestParameters>(propertyName, propertyValue);

            return objList.Count > 0 ? objList.ToList() : new List<CustomerTestParameters>();
        }

        public CustomerTestParameters GetCustomerTestSpecification(int customerId, int industyID, int testParametersId)
        {
            string[] propertyName = { "CustomerId", "IndustyID", "TestParametersId" };

            object[] propertyValue = { customerId, industyID, testParametersId };

            var objList = _mPersistenceManager.RetrieveEquals<CustomerTestParameters>(propertyName, propertyValue);

            return objList.Count > 0 ? objList[0] : new CustomerTestParameters();
        }


        public void UpdateRewardValue (RewardValue objRewardValue)
        {
            _mPersistenceManager.Update(objRewardValue);
        }

        public RewardValue GetRewardValue()
        {
            IList<RewardValue> listRewardValue = _mPersistenceManager.RetrieveAll<RewardValue>();
            if (listRewardValue.Count>0)
                return listRewardValue[0];
            else 
                return new RewardValue();
        }
    }
}