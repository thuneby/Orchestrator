using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixed42: BsFixedRecordBase
    {
        [FieldFixedLength(9)] public string MandateNumber;
        [FieldFixedLength(8)] public string PaymentDate;
        [FieldFixedLength(1)] public string SignCode;
        [FieldFixedLength(13)] public string Amount;
        [FieldFixedLength(30)] public string Reference;
        [FieldFixedLength(2)] public string Filler01;
        [FieldFixedLength(15)] public string PayerId;
        [FieldFixedLength(8)] public string Filler02;
    }
}
