using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsRecordFixed02 : OsFixedRecordBase
    {
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_PENSIONSGIVENDE_LON;
        [FieldFixedLength(12)][FieldOptional] public string PENSIONSGIVENDE_LON;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_PENSIONSTYPE;
        [FieldFixedLength(2)][FieldOptional] public string PENSIONSTYPE;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_NORMALBIDRAG;
        [FieldFixedLength(12)][FieldOptional] public string NORMALBIDRAG;
        [FieldFixedLength(12)][FieldOptional] public string ARBEJDSGIVERS_ANDEL_AF_NORMALBIDRAG;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_PENSIONSBIDRAGSPROCENT;
        [FieldFixedLength(4)][FieldOptional] public string PENSIONSBIDRAGSPROCENT;
        [FieldFixedLength(4)][FieldOptional] public string ARBEJDSGIVER_PENSIONSBIDRAGSPROCENT;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_LONTRIN;
        [FieldFixedLength(5)][FieldOptional] public string LONTRIN;
        [FieldFixedLength(8)][FieldOptional] public string STARTDATO_GRUPPELIVSANDEL;
        [FieldFixedLength(12)][FieldOptional] public string GRUPPELIVSANDEL_AF_INDBETALT_BELOB;
    }
}
