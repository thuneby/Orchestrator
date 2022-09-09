using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsRecordFixed00 : OsFixedRecordBase
    {
        [FieldFixedLength(2)] public string ANTAL_INFO_RECORDS;
        [FieldFixedLength(8)] public string PBSNUMMER;
        [FieldFixedLength(5)] public string AFDELINGSNUMMER;
        [FieldFixedLength(8)] public string AFTALENUMMER;
        [FieldFixedLength(10)] public string CPR_NUMMER;
        [FieldFixedLength(15)] public string KUNDENUMMER_AFSENDER;
        [FieldFixedLength(15)] public string KUNDENUMMER_MODTAGER;
        [FieldFixedLength(12)] public string INDBETALT_BELOB;
        [FieldFixedLength(1)] public string FORTEGN;
        [FieldFixedLength(8)][FieldOptional] public string PERIODE_FRA;
        [FieldFixedLength(8)][FieldOptional] public string PERIODE_TIL;
        [FieldFixedLength(5)][FieldOptional] public string OVERENSKOMSTNUMMER;
        [FieldFixedLength(12)][FieldOptional] public string SPECIFICERET_BELOB;
        [FieldFixedLength(2)][FieldOptional] public string BLANKE;
    }
}
