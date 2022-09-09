using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsRecordFixed04 : OsFixedRecordBase
    {
        [FieldFixedLength(2)][FieldOptional] public string REGULERINGSKODE1;
        [FieldFixedLength(12)][FieldOptional] public string REGULERINGSBELOB1;
        [FieldFixedLength(1)][FieldOptional] public string FORTEGN1;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_REGULERING1;
        [FieldFixedLength(8)][FieldOptional] public string SLUTDATO_REGULERING1;
        [FieldFixedLength(2)][FieldOptional] public string REGULERINGSKODE2;
        [FieldFixedLength(12)][FieldOptional] public string REGULERINGSBELOB2;
        [FieldFixedLength(1)][FieldOptional] public string FORTEGN2;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_REGULERING2;
        [FieldFixedLength(8)][FieldOptional] public string SLUTDATO_REGULERING2;
        [FieldFixedLength(2)][FieldOptional] public string REGULERINGSKODE3;
        [FieldFixedLength(12)][FieldOptional] public string REGULERINGSBELOB3;
        [FieldFixedLength(1)][FieldOptional] public string FORTEGN3;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_REGULERING3;
        [FieldFixedLength(8)][FieldOptional] public string SLUTDATO_REGULERING3;
        [FieldFixedLength(18)][FieldOptional] public string FILLER;
    }
}
