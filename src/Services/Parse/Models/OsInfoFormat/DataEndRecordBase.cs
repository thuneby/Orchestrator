using FileHelpers;

// ReSharper disable InconsistentNaming

namespace Parse.Models.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class DataEndRecordBase : OsBase
    {
        [FieldFixedLength(2)] public string KONSTANT;
    }
}
