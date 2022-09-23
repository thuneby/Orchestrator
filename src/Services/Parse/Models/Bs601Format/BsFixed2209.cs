using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixed2209: BsFixedRecordBase
    {
        [FieldFixedLength(9)] public string Filler01;
        [FieldFixedLength(15)] public string Filler02;
        [FieldFixedLength(4)] public string Postcode;
        [FieldFixedLength(3)] public string Country;
        [FieldFixedLength(55)] public string Filler03;
    }
}
