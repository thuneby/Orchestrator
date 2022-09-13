using FileHelpers;

// ReSharper disable InconsistentNaming

namespace Parse.Models.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsRecordFixed01 : OsFixedRecordBase
    {
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_KUNDE;
        [FieldFixedLength(35)][FieldOptional] public string KUNDENAVN;
        [FieldFixedLength(1)][FieldOptional] public string OPLYSNINGSKODE;
        [FieldFixedLength(2)][FieldOptional] public string PENSIONSALDERKODE;
        [FieldFixedLength(2)][FieldOptional] public string PENSIONSALDER;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_AFLONNINGSFORM;
        [FieldFixedLength(2)][FieldOptional] public string AFLONNINGSFORM;
        [FieldFixedLength(8)][FieldOptional] public string ANCIENNITET_FRA_DATO;
        [FieldFixedLength(8)][FieldOptional] public string FRATRAEDELSESDATO;
        [FieldFixedLength(37)][FieldOptional] public string RESERVETEKST;
    }
}
