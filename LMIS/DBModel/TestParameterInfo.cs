using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class TestParameterInfo
    {


        public virtual int TestParameterId{set; get; }
        public virtual string AccreditedTestParameter{ set; get; }
        public virtual string TestMethod { set; get; }
        public virtual string Unit{ set; get; }
        public virtual string Equipment{ set; get; }
        public virtual string MDL{ set; get; }
        public virtual string ShortTerm{ set; get; }


    }
}