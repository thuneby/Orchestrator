using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsSectionStart: BsFixedBase
    {
        [FieldFixedLength(8)] public string PbsNumber;
        [FieldFixedLength(4)] public string SectionNumber;
        [FieldFixedLength(5)] public string Filler01;
        [FieldFixedLength(5)] public string DebtorGroupNumber;
        [FieldFixedLength(15)] public string DataSupplierId;
        [FieldFixedLength(4)] public string Filler02;
        [FieldFixedLength(8)] public string DeliveryCreationDate;
        [FieldFixedLength(4)] public string Filler03;
        [FieldFixedLength(10)] public string Filler04;
        [FieldFixedLength(60)] public string MainTextLine;
    }
}
