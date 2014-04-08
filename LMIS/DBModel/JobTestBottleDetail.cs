namespace LMIS.DBModel
{
    public class JobTestBottleDetail 
    {
        public virtual int ID { set; get; }
        public virtual int JobDetailId { set; get; }
        public virtual int BottleId { set; get; }
        public virtual int BottleRequired { set; get; }
        public virtual int TestId { set; get; }
        public virtual string BottleType { set; get; }
        public virtual int JobDetailParentId { set; get; }
        public virtual int JobInfoId { set; get; }
    }
}