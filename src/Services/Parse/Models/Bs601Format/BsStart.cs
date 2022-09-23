using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsStart: BsFixedBase
    {
        [FieldFixedLength(8)] public string DataSupplierCvr;
        [FieldFixedLength(3)] public string SubSystem;
        [FieldFixedLength(4)] public string DeliveryType;
        [FieldFixedLength(10)] public string DeliveryId;
        [FieldFixedLength(19)] public string Filler01;
        [FieldFixedLength(6)] public string DeliveryCreationDate;
        [FieldFixedLength(73)] public string Filler02;
    }
}
