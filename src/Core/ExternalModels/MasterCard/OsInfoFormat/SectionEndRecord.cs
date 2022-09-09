using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class SectionEndRecord : OsBase
    {
        [FieldFixedLength(2)] public string OVERFORSELSTYPE;
        [FieldFixedLength(3)] public string INFOTYPE;
        [FieldFixedLength(1)] public string NULLER;
        [FieldFixedLength(10)] public string ANTAL;
        [FieldFixedLength(12)] public string BELOB;
        [FieldFixedLength(6)] public string DISPOSITIONSDATO;
        [FieldFixedLength(4)] public string AFSENDERREGISTRERINGSNUMMER;
        [FieldFixedLength(10)] public string AFSENDERKONTONUMMER;
        [FieldFixedLength(8)] public string DATALEVERANDORNUMMER;
        [FieldFixedLength(8)] public string CVRNUMMERAFSENDER;
        [FieldFixedLength(8)] public string PBSNUMMERMODTAGER;
        [FieldFixedLength(5)] public string FILLER;
    }
}
