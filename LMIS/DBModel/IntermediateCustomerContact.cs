using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class IntermediateCustomerContact
    {
        private int _id;
        private int _custId;
        private int _contactId;
        private string _jobId;

        public virtual int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public virtual int CustID
        {
            set { _custId = value; }
            get { return _custId; }
        }
        public virtual int ContactID
        {
            set { _contactId = value; }
            get { return _contactId; }
        }
        public virtual string JobID
        {
            set { _jobId = value; }
            get { return _jobId; }
        }
    }
}