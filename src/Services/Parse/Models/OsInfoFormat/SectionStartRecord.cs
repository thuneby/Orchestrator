using FileHelpers;

// ReSharper disable InconsistentNaming

namespace Parse.Models.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class SectionStartRecord : OsBase
    {
        [FieldFixedLength(2)] public string OVERFORSELSART;
        [FieldFixedLength(3)] public string INFOTYPE;
        [FieldFixedLength(23)] public string NULLER;
        [FieldFixedLength(6)] public string DISPOSITIONSDATO;
        [FieldFixedLength(4)] public string REGISTRERINGSNUMMER;
        [FieldFixedLength(10)] public string KONTONUMMER;
        [FieldFixedLength(8)] public string DATALEVERANDORNUMMER;
        [FieldFixedLength(8)] public string CVRNUMMERAFSENDER;
        [FieldFixedLength(8)] public string PBSNUMMERMODTAGER;
        [FieldFixedLength(5)] public string NULLER2;
    }
}

