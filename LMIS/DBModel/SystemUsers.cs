using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class SystemUsers
    {
        private int _userId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _userName;
        private string _password;
        private char _type;


        public virtual  int UserId
        {
            set
            {
            	_userId = value;
            }
            get
            {
                return _userId;
            }
        }

        public virtual  string FirstName
        {
            set { _firstName = value; }
            get
            {
                return _firstName;
            }
        }
        public  virtual  string LastName
        {
            set
            {
            	_lastName = value;
            }
            get { return _lastName; }
        }
        public  virtual  string EmailAddress
        {
            set
            {
            	_email = value;
            }
            get
            {
                return _email;
            }
        }
        public virtual string UserName
        {
            set
            {
            	_userName = value;
            }
            get
            {
                return _userName;
            }
        }
        public  virtual  string Password
        {
            set
            {
            	_password = value;
            }
            get
            {
                return _password;
            }
        }
        public virtual char Type
        {
            set
            {
            	_type = value;
            }
            get
            {
                return  _type;
            }
        }

    }
}