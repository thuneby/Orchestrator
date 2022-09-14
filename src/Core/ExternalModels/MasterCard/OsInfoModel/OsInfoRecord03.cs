using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoRecord03 : OsInfoSubRecordBase
    {
        [StringLength(8)] public string STARTDATO_AFVIGELSE { get; set; }
        [StringLength(2)] public string AFVIGELSESKODE { get; set; }
        [StringLength(12)] public string AFVIGELSESBELOB { get; set; }
        [StringLength(1)] public string FORTEGN { get; set; }
        [StringLength(5)] public string AFVIGELSESPROCENT { get; set; }
        [StringLength(8)] public string STARTDATO_BESKAEFTIGELSESGRAD { get; set; }
        [StringLength(5)] public string BESKAEFTIGELSESGRAD { get; set; }
        [StringLength(6)] public string BESKAEFTIGELSESGRAD_TAELLER { get; set; }
        [StringLength(6)] public string BESKAEFTIGELSESGRAD_NAEVNER { get; set; }
        [StringLength(58)] public string RESERVETEKST { get; set; }
    }
}
