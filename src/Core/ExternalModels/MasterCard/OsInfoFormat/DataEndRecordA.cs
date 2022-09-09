using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class DataEndRecordA : DataEndRecordBase
    {
        [FieldFixedLength(4)] public string NULLER;
        [FieldFixedLength(10)] public string TOTALANTAL;
        [FieldFixedLength(12)] public string TOTALBELOB;
        [FieldFixedLength(6)] public string NULLER2;
        [FieldFixedLength(14)] public string NITALLER;
        [FieldFixedLength(8)] public string DATALEVERANDORNUMMER;
        [FieldFixedLength(21)] public string NULLER3;
    }
}
