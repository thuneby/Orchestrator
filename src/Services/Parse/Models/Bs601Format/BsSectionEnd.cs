using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsSectionEnd: BsFixedBase
    {
        [FieldFixedLength(8)] public string PbsNumber;
        [FieldFixedLength(4)] public string SectionNumber;
        [FieldFixedLength(5)] public string Filler01;
        [FieldFixedLength(5)] public string DebtorGroupNumber;
        [FieldFixedLength(4)] public string Filler02;
        [FieldFixedLength(11)] public string NumberOfRecord42;
        [FieldFixedLength(15)] public string TotalAmount;
        [FieldFixedLength(11)] public string NumberOfRecord5262;
        [FieldFixedLength(15)] public string Filler03;
        [FieldFixedLength(11)] public string NumberOfRecord22;
        [FieldFixedLength(34)] public string Filler04;
    }
}
