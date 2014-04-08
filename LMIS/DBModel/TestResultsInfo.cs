using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class TestResultsInfo
    {
        private int _testInfoId;
        private int _activeTestId;
        private int _testParameterId;
        private float _testResult;


        public virtual int TestInfoId
        {
            set { _testInfoId = value; }
            get { return _testInfoId; }
        }
        public virtual int ActiveTestId
        {
            set { _activeTestId = value; }
            get { return _activeTestId; }
        }
        public virtual int TestParameterId
        {
            set { _testParameterId = value; }
            get { return _testParameterId; }
        }
        public virtual float TestResult
        {
            set { _testResult = value; }
            get { return _testResult; }
        }
    }
}