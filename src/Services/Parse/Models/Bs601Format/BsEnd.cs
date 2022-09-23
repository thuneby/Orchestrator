using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsEnd: BsFixedBase
    {
        [FieldFixedLength(8)] public string DataSupplierCvr;
        [FieldFixedLength(3)] public string SubSystem;
        [FieldFixedLength(4)] public string DeliveryType;
        [FieldFixedLength(11)] public string NumberOfSections;
        [FieldFixedLength(11)] public string NumberOfRecord42;
        [FieldFixedLength(15)] public string TotalAmount;
        [FieldFixedLength(11)] public string NumberOfRecord5262;
        [FieldFixedLength(15)] public string Filler01;
        [FieldFixedLength(11)] public string NumberOfRecord22;
        [FieldFixedLength(34)] public string Filler02;
    }
}
