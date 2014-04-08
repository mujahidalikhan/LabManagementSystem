using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class PointsInfo
    {
        private int _id;
        private int _custId;
        private String  _points;
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
        public virtual String Points
        {
            set { _points = value; }
            get { return _points; }
        }
        
    }
}