using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixed22: BsFixedRecordBase
    {
        [FieldFixedLength(9)] public string Filler01;
        [FieldFixedLength(35)] public string Name;
        [FieldFixedLength(42)] public string Filler02;
    }
}
