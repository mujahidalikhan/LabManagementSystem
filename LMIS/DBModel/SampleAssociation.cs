using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class SampleAssociation
    {
        public virtual int Id { set; get; }
        public virtual int SampleDetailID { set; get; }
        public virtual int eventId { set; get; }
        public virtual int SamplerID { set; get; }
        public virtual DateTime AssignDate { set; get; }
        public virtual int TestId { set; get; }
      
    }
}