using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsRecordFixed05 : OsFixedRecordBase
    {
        [FieldFixedLength(32)][FieldOptional] public string ADRESSE1;
        [FieldFixedLength(32)][FieldOptional] public string ADRESSE2;
        [FieldFixedLength(20)][FieldOptional] public string BYNAVN;
        [FieldFixedLength(4)][FieldOptional] public string POSTNUMMER;
        [FieldFixedLength(4)][FieldOptional] public string TAL1;
        [FieldFixedLength(10)][FieldOptional] public string TAL2;
        [FieldFixedLength(9)][FieldOptional] public string RESERVETEKST;
    }
}
