using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixed2210: BsFixedRecordBase
    {
        [FieldFixedLength(40)] public string Filler01;
        [FieldFixedLength(10)] public string DebtorCvrCpr;
        [FieldFixedLength(1)] public string DispatchSpeed;
        [FieldFixedLength(1)] public string MandatoryPrint;
        [FieldFixedLength(34)] public string Filler02;
    }
}
