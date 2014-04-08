using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class CustomerTestParameters
    {
        public virtual int CustomerTestParameterId { set; get; }
        public virtual int TestParametersId{set; get; }
        public virtual int CustomerId { set; get; }
        public virtual string Specification { set; get; }
        public virtual bool StdA { set; get; }
        public virtual bool StdB { set; get; }
        public virtual bool DefaultVal { set; get; }
        public virtual bool Customized { set; get; }
        public virtual int IndustyID { set; get; }

    }
}