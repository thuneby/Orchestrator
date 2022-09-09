using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsRecordFixed10 : OsFixedRecordBase
    {
        [FieldFixedLength(3)][FieldOptional] public string RESERVE1KODE;
        [FieldFixedLength(8)][FieldOptional] public string RESERVE1;
        [FieldFixedLength(3)][FieldOptional] public string RESERVE2KODE;
        [FieldFixedLength(10)][FieldOptional] public string RESERVE2;
        [FieldFixedLength(3)][FieldOptional] public string RESERVE3KODE;
        [FieldFixedLength(20)][FieldOptional] public string RESERVE3;
        [FieldFixedLength(3)][FieldOptional] public string RESERVE4KODE;
        [FieldFixedLength(61)][FieldOptional] public string RESERVE4;
    }
}
