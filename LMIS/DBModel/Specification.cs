using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class Specification
    {
        public virtual int SpecificationId{set; get; }
        public virtual TestParameterInfo TestId { set; get; }
        public virtual string StdA{set; get; }
        public virtual string StdB{set; get; }
        public virtual string SpecificationName{set; get; }
        public virtual string Others{set; get; }

     
    }
}