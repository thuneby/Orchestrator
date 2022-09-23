using Core.CoreModels;
using FileHelpers;

namespace Parse.Models.Bs601Format
{
    [FixedLengthRecord]
    public class BsFixedBase: TextModelBase 
    {
        [FieldFixedLength(2)] public string SystemId;
        [FieldFixedLength(3)] public string DataRecordType;
    }
}
