using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class DataEndRecordBase : OsBase
    {
        [FieldFixedLength(2)] public string KONSTANT;
    }
}
