namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecordChild: BsRecordBase
    {
        public Guid? BsRecord42Id { get; set; } 
        public virtual BsRecord42 BsRecord42 { get; set; }

    }
}
