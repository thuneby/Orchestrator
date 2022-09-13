using FileHelpers;

// ReSharper disable InconsistentNaming

namespace Parse.Models.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsRecordFixed03 : OsFixedRecordBase
    {
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_AFVIGELSE;
        [FieldFixedLength(2)][FieldOptional] public string AFVIGELSESKODE;
        [FieldFixedLength(12)][FieldOptional] public string AFVIGELSESBELOB;
        [FieldFixedLength(1)][FieldOptional] public string FORTEGN;
        [FieldFixedLength(5)][FieldOptional] public string AFVIGELSESPROCENT;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_BESKAEFTIGELSESGRAD;
        [FieldFixedLength(5)][FieldOptional] public string BESKAEFTIGELSESGRAD;
        [FieldFixedLength(6)][FieldOptional] public string BESKAEFTIGELSESGRAD_TAELLER;
        [FieldFixedLength(6)][FieldOptional] public string BESKAEFTIGELSESGRAD_NAEVNER;
        [FieldFixedLength(58)][FieldOptional] public string RESERVETEKST;
    }
}
