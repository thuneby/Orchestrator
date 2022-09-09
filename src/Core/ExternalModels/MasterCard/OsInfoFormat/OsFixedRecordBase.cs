using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsFixedRecordBase : OsBase
    {
        [FieldFixedLength(2)] public string OVERFORSELSART;
        [FieldFixedLength(3)] public string INFOTYPE;
        [FieldFixedLength(2)] public string INFORECORDTYPE;
        [FieldFixedLength(7)] public string SEKVENSNUMMER;
    }
}
