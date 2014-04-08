using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class RecordHistory
    {
        private int _id;
        private string _userName;
        private int _jobID;
        private string _timestamp;
        private string _status;
        private string _description;

        public virtual int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public virtual string UserName
        {
            set { _userName = value; }
            get { return _userName; }
        }
        public virtual int JobID
        {
            set { _jobID = value; }
            get { return _jobID; }
        }
        public virtual string Timestamp
        {
            set { _timestamp = value; }
            get { return _timestamp; }
        }
        public virtual string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        public virtual string Description
        {
            set { _description = value; }
            get { return _description; }
        }
    }
}