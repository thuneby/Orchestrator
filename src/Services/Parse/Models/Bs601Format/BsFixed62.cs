using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixed62: BsFixedRecordBase
    {
        [FieldFixedLength(9)] public string Filler01;
        [FieldFixedLength(1)] public string Filler02;
        [FieldFixedLength(60)] public string TextLine;
        [FieldFixedLength(16)] public string Filler03;
    }
}
