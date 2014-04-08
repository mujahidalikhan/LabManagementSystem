using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Engine;

namespace LMIS.DBModel
{
    public class JobDetailArchive 
    {

        public virtual int JobDetailId { set; get; }
        public virtual string Descriptation { set; get; }
        public virtual string Frequency { set; get; }
        public virtual decimal UnitPrice { set; get; }
        public virtual int Quantity { set; get; }
        public virtual decimal TotalAmount { set; get; }
        public virtual string TestInfo { set; get; }
        public virtual JobInfoArchive JobInfo { set; get; }
        public virtual int ParentId { set; get; }
        public virtual int IndustryId { set; get; }

    }

}