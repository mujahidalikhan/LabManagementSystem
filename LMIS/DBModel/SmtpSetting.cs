using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{

    public class SmtpSetting
    {

        // Property variables
        private int _smtpID;
        private string _serverAddress;
        private int _serverPort;
        private string _userName;
        private string _password;
        private string _fromName;
        private string _fromEmail;
        private bool _enableSSL;

        public virtual int SmtpID
        {
            set { _smtpID = value; }
            get { return _smtpID; }
        }

        public virtual string ServerAddress
        {
            set { _serverAddress = value; }
            get { return _serverAddress; }
        }

        public virtual int ServerPort
        {
            set { _serverPort = value; }
            get { return _serverPort; }
        }

        public virtual string UserName
        {
            set { _userName = value; }
            get { return _userName; }
        }

        public virtual string FromName
        {
            set { _fromName = value; }
            get { return _fromName; }
        }

        public virtual string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        public virtual string FromEmail
        {
            set { _fromEmail = value; }
            get { return _fromEmail; }
        }
        public virtual bool EnableSSL
        {
            set { _enableSSL = value; }
            get { return _enableSSL; }
        }
    }
}