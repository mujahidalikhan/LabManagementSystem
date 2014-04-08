using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Engine;

namespace LMIS.DBModel
{
    public class JobDetail
    {

        public virtual int JobDetailId { set; get; }
        public virtual string Descriptation { set; get; }
        public virtual string Frequency { set; get; }
        public virtual int Quantity { set; get; }
        public virtual string TestInfo { set; get; }
        public virtual JobInfo JobInfo { set; get; }
        public virtual int ParentId { set; get; }
        public virtual int IndustryId { set; get; }
       


        public virtual string Point { set; get; }
        public virtual string Urgent { set; get; }
        public virtual string Specification { set; get; }
        public virtual string Standard { set; get; }
        public virtual int LabNumber { set; get; }
        public virtual int TestPoint { set; get; }
        public virtual int PointNumber { set; get; }
    }

}