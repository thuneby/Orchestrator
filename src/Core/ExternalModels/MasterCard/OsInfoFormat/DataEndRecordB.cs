using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class DataEndRecordB : DataEndRecordBase
    {
        [FieldFixedLength(14)] public string NITALLER;
        [FieldFixedLength(18)] public string NULLER;
        [FieldFixedLength(14)] public string NITALLER2;
        [FieldFixedLength(8)] public string DATALEVERANDORNUMMER;
        [FieldFixedLength(21)] public string NULLER2;
    }
}
