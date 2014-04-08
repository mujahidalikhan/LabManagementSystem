using System;

namespace LMIS.DBModel
{
    public class JobInfoArchive
    {
        public virtual int JobId { set; get; }
        public virtual string JobNumber { set; get; }
        public virtual int Attention { set; get; }
        public virtual string CC { set; get; }
        public virtual DateTime CreateDate { set; get; }
        public virtual DateTime Validatily { set; get; }
        public virtual DateTime TermOfPayment { set; get; }
        public virtual decimal TotalAmount { set; get; }
        public virtual int RewardPoint { set; get; }
        public virtual decimal Payable { set; get; }
        public virtual DateTime? PaymentDate { set; get; }
        public virtual string Status { set; get; }
        public virtual int Reward { set; get; }
        public virtual CustomerInfo Customer { set; get; }
        public virtual decimal RewardValue { set; get; }
        public virtual DateTime? PaidDate { set; get; }
        public virtual Decimal MicItemsCost { set; get; }
        public virtual string MicItemsDescription { set; get; }
        public virtual string DeleteReason { set; get; }
        public virtual string Comments { set; get; }
    }
}