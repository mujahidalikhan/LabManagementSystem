using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class IndustryInfo
    {
        private int _industryId;
        private string _industryName;
        private string _comments;


        public virtual int IndustryID
        {
            set { _industryId = value; }
            get { return _industryId; }
        }
        public virtual string IndustryName
        {
            set { _industryName = value; }
            get { return _industryName; }
        }
        public virtual string Comments
        {
            set { _comments = value; }
            get { return _comments; }
        }
    }
}