using FileHelpers;

// ReSharper disable InconsistentNaming

namespace Parse.Models.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsInfoEndRecordBase : OsBase
    {
        [FieldFixedLength(2)] public string KONSTANT;
    }
}
