using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class PackingInfo
    {
        private int _packingInfoId;
        private string _packingName;
        private string _packingDescription;


        public virtual int PackingInfoId
        {
            set { _packingInfoId = value; }
            get { return _packingInfoId; }
        }
        public virtual string PackingName
        {
            set { _packingName = value; }
            get { return _packingName; }
        }
        public virtual string PackingDescription
        {
            set { _packingDescription = value; }
            get { return _packingDescription; }
        }
    }
}