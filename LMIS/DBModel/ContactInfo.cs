using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class ContactInfo
    {
        private int _id;
        private int _custId;
        private string _salutation;
        private string _name;
        private string _position;
        private string _phone;
        private string _hPhone;
        private string _fax;
        private string _email;
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
        public virtual string Salutation
        {
            set { _salutation = value; }
            get { return _salutation; }
        }
        public virtual string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public virtual string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        public virtual string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        public virtual string HPhone
        {
            set { _hPhone = value; }
            get { return _hPhone; }
        }
        public virtual string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        public virtual string Email
        {
            set { _email = value; }
            get { return _email; }
        }
    }
}