using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixedRecordBase: BsFixedBase
    {
        [FieldFixedLength(8)] public string PbsNumber;
        [FieldFixedLength(4)] public string TransactionCode;
        [FieldFixedLength(5)] public string DataRecordNumber;
        [FieldFixedLength(5)] public string DebtorGroupNumber;
        [FieldFixedLength(15)] public string CustomerNumber;
    }
}
