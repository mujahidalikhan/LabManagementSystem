using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMIS.DBModel
{
    public class CustomerInfo
    {
        private int _custId;
        private string _custName ;
        private string _nature ;
        private string _specification ;
        private string _address ;
        private string _city ;
        private string _state ;
        private long _poscode ;
        private string _salutation1 ;
        private string _person1 ;
        private string _position1 ;
        private string _phone1;
        private string _hPhone1;
        private string _fax1;
        private string _email1 ;
        private string _salutation2 ;
        private string _person2 ;
        private string _position2 ;
        private string _phone2;
        private string _hPhone2;
        private string _fax2;
        private string _email2 ;
        private string _salutation3 ;
        private string _person3 ;
        private string _position3 ;
        private string _phone3;
        private string _hPhone3;
        private string _fax3;
        private string _email3;
        private DateTime _member_Since ;


                public virtual int CustID{
            set { _custId = value; }
            get { return _custId; }
        }
        public virtual string CustName {
            set {  _custName= value; }
            get { return _custName; }
        }
        public virtual string Nature {
            set {  _nature= value; }
            get { return _nature; }
        }
        public virtual string Specification {
            set {  _specification= value; }
            get { return _specification; }
        }
        public virtual string Address {
            set {  _address= value; }
            get { return _address; }
        }
        public virtual string City {
            set {  _city= value; }
            get { return _city; }
        }
        public virtual string State {
            set {  _state= value; }
            get { return _state; }
        }
        public virtual long Poscode {
            set {  _poscode= value; }
            get { return _poscode; }
        }
        public virtual string Salutation1 {
            set {  _salutation1= value; }
            get { return _salutation1; }
        }
        public virtual string Person1 {
            set {  _person1= value; }
            get { return _person1; }
        }
        public virtual string Position1 {
            set {  _position1= value; }
            get { return _position1; }
        }
        public virtual string Phone1
        {
            set { _phone1= value; }
            get { return _phone1; }
        }
        public virtual string HPhone1
        {
            set {  _hPhone1= value; }
            get { return _hPhone1; }
        }
        public virtual string Fax1
        {
            set { _fax1 = value; }
            get { return _fax1; }
        }
        public virtual string Email1 {
            set {  _email1= value; }
            get { return _email1; }
        }
        public virtual string Salutation2
        {
            set {  _salutation2= value; }
            get { return _salutation2; }
        }
        public virtual string Person2 {
            set {  _person2= value; }
            get { return _person2; }
        }
        public virtual string Position2 {
            set {  _position2= value; }
            get { return _position2; }
        }
        public virtual string Phone2
        {
            set { _phone2= value; }
            get { return _phone2; }
        }
        public virtual string HPhone2
        {
            set {  _hPhone2= value; }
            get { return _hPhone2; }
        }
        public virtual string Fax2
        {
            set { _fax2 = value; }
            get { return _fax2; }
        }
        public virtual string Email2 {
            set {  _email2= value; }
            get { return _email2; }
        }
                public virtual string Salutation3 {
            set {  _salutation3= value; }
            get { return _salutation3; }
        }
        public virtual string Person3 {
            set {  _person3= value; }
            get { return _person3; }
        }
        public virtual string Position3 {
            set {  _position3= value; }
            get { return _position3; }
        }
        public virtual string Phone3
        {
            set { _phone3= value; }
            get { return _phone3; }
        }
        public virtual string HPhone3
        {
            set {  _hPhone3= value; }
            get { return _hPhone3; }
        }
        public virtual string Fax3
        {
            set { _fax3 = value; }
            get { return _fax3; }
        }
        public virtual string Email3 {
            set {  _email3= value; }
            get { return _email3; }
        }
        public virtual DateTime Member_Since {
            set {  _member_Since= value; }
            get { return _member_Since; }
        }

        public virtual int Reward { set; get; }
        public virtual string Country { set; get; }
        public virtual string Status { set; get; }
    }
}