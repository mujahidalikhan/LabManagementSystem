using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class TestResult
    {
        private int _testResultId;
        private int _activeTestId;
        private int _testParameterInfoId;
        private float _result;



        public virtual int TestResultId
        {
            set { _testResultId = value; }
            get { return _testResultId; }
        }

        public virtual int ActiveTestId
        {
            set { _activeTestId = value; }
            get { return _activeTestId; }
        }

        public virtual int TestParameterInfoId
        {
            set { _testParameterInfoId = value; }
            get { return _testParameterInfoId; }
        }

        public virtual float Result
        {
            set { _result = value; }
            get { return _result; }
        }

        public virtual bool IsValueEntered { set; get; }
        public virtual int LastUpdateBy { set; get; }
        public virtual DateTime? LastUpdateTime { set; get; }


        public virtual float TempResultVal { set; get; }
        public virtual bool IsLocked { set; get; }
        public virtual int TmpChangeBy { set; get; }
        public virtual bool IsValueModify { set; get; }
        public virtual string Status { set; get; }
    }
}