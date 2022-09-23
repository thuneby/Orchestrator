using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixed52: BsFixedRecordBase
    {
        [FieldFixedLength(9)] public string MandateNumber;
        [FieldFixedLength(1)] public string Filler01;
        [FieldFixedLength(60)] public string TextLine;
        [FieldFixedLength(1)] [FieldOptional] public string Filler02;
        [FieldFixedLength(15)] [FieldOptional] public string Filler03; 
    }
}
