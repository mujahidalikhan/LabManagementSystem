using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class IndustryTestInfo
    {
        private int _industryTestId;
        private int _industryInfoId;
        private int _testParameterId;


        public virtual int IndustryTestId
        {
            set { _industryTestId = value; }
            get { return _industryTestId; }
        }
        public virtual int IndustryInfoId
        {
            set { _industryInfoId = value; }
            get { return _industryInfoId; }
        }
        public virtual int TestParameterId
        {
            set { _testParameterId = value; }
            get { return _testParameterId; }
        }
    }
}