using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class DataStartRecord : OsBase
    {
        [FieldFixedLength(2)] public string KONSTANT;
        [FieldFixedLength(14)] public string SYSTEMTEKST;
        [FieldFixedLength(9)] public string NULLER;
        [FieldFixedLength(20)] public string IDENTIFIKATION;
        [FieldFixedLength(3)] public string NULLER2;
        [FieldFixedLength(8)] public string DATALEVERANDORNUMMER;
        [FieldFixedLength(1)] public string LEVERANCEKVITTERING;
        [FieldFixedLength(20)] public string NULLER3;
    }
}
