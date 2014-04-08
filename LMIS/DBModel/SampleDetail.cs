using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class SampleDetail
    {
        public virtual int Id { set; get; }
        public virtual int JobBottleDetailId { set; get; }
        public virtual string NumberOfBottleCollect { set; get; }
        public virtual DateTime? SampleCollectDate { set; get; }
        public virtual int EventId { set; get; }
        public virtual int TestId { set; get; }
        public virtual DateTime? AssigneDate { set; get; }
        public virtual String TracingPoint { set; get; }
        public virtual bool IsSampleTaken { set; get; }
        public virtual string SampleInformation { set; get; }
        public virtual string SampleDescription { set; get; }
        public virtual string TypeOfSampling { set; get; }
        public virtual int PackingId { set; get; }
        public virtual string BottleList { set; get; }
        public virtual int JobDetailID { set; get; }
    }

}