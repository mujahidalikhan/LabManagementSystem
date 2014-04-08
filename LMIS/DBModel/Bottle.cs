namespace LMIS.DBModel
{
    public class Bottle
    {
        public virtual int bottleId { set; get; }
        public virtual string PreservativeChemical { set; get; }
        public virtual string VolumeType1 { set; get; }
        public virtual string VolumeType2 { set; get; }
        public virtual string VolumeType3 { set; get; }
        
    }
}