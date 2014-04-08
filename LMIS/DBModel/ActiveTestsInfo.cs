using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class ActiveTestsInfo
    {
        private int _activeTestId;
        private int _industryId;
        private int _customerId;
        private DateTime _dateCreated;
        private string _sampleInformation;
        private string _sampleDescription;
        private DateTime? _sampleRecievedOn;
        private string _typeOfSampling;
        private string _analysisCondition;
        private int _packingId;
        private string _currentStatus;
        private int _assignTo;
        private string _labNumber;
        private string _specificationType;
        private int _testPoint;

        public virtual int ActiveTestId
        {
            set { _activeTestId = value; }
            get { return _activeTestId; }
        }

        public virtual int IndustryId
        {
            set { _industryId = value; }
            get { return _industryId; }
        }

        public virtual int CustomerId
        {
            set { _customerId = value; }
            get { return _customerId; }
        }

        public virtual DateTime DateCreated
        {
            set { _dateCreated = value; }
            get { return _dateCreated; }
        }

        public virtual string SampleInformation
        {
            set { _sampleInformation = value; }
            get { return _sampleInformation; }
        }

        public virtual string SampleDescription
        {
            set { _sampleDescription = value; }
            get { return _sampleDescription; }
        }

        public virtual DateTime? SampleRecievedOn
        {
            set { _sampleRecievedOn = value; }
            get { return _sampleRecievedOn; }
        }

        public virtual string TypeOfSampling
        {
            set { _typeOfSampling = value; }
            get { return _typeOfSampling; }
        }

        public virtual string AnalysisCondition
        {
            set { _analysisCondition = value; }
            get { return _analysisCondition; }
        }

        public virtual int PackingId
        {
            set { _packingId = value; }
            get { return _packingId; }
        }

        public virtual string CurrentStatus
        {
            set { _currentStatus = value; }
            get { return _currentStatus; }
        }

        public virtual int AssignTo
        {
            set { _assignTo = value; }
            get { return _assignTo; }
        }

        public virtual string LabNumber
        {
            set { _labNumber = value; }
            get { return _labNumber; }
        }

        public virtual string SpecificationType
        {
            set { _specificationType = value; }
            get { return _specificationType; }
        }

        public virtual int TestPoint
        {
            set { _testPoint = value; }
            get { return _testPoint; }
        }

        public virtual CustomerInfo Customer { get; set; }
        public virtual int Industry { get; set; }
        public virtual int Attention { set; get; }
        public virtual JobDetail JobDetail { set; get; }
        public int JobInfoId { set; get; }
        public virtual DateTime? EstimatedEndTime { set; get; }
        public virtual DateTime? ActualEndTime { set; get; }
        public int LastKeyInBy { set; get; }
        public DateTime? LastUpdateDateTime { set; get; }




        public virtual string Point { set; get; }
        public virtual string Urgent { set; get; }
        public virtual string Specification { set; get; }
        public virtual string Standard { set; get; }
        public virtual int PointNumber { set; get; }
    }
}