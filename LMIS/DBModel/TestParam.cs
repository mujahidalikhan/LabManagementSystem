using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class TestParam
    {
        private int _testId;
        private string _parameter;
        private string _units;
        private string _category;
        private float _stdAMin;
        private float _stdAMax;
        private float _stdBMin;
        private float _stdBMax;
        private DateTime _assignTime;


        public virtual int TestID
        {
            set { _testId = value; }
            get { return _testId; }
        }
        public virtual string Parameter
        {
            set { _parameter = value; }
            get { return _parameter; }
        }
        public virtual string Units
        {
            set { _units = value; }
            get { return _units; }
        }
        public virtual string Category
        {
            set { _category = value; }
            get { return _category; }
        }

        public virtual float StdA_Min
        {
            set { _stdAMin = value; }
            get { return _stdAMin; }
        }
        public virtual float StdA_Max
        {
            set { _stdAMax = value; }
            get { return _stdAMax; }
        }
        public virtual float StdB_Min
        {
            set { _stdBMin = value; }
            get { return _stdBMin; }
        }
        public virtual float StdB_Max
        {
            set { _stdBMax = value; }
            get { return _stdBMax; }
        }
        public virtual DateTime AssignTime
        {
            set { _assignTime = value; }
            get { return _assignTime; }
        }

    }
}