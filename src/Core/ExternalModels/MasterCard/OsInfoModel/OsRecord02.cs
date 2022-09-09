using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsRecord02 : OsSubRecordBase
    {
        [StringLength(8)] public string STARTDATO_PENSIONSGIVENDE_LON { get; set; }
        [StringLength(12)] public string PENSIONSGIVENDE_LON { get; set; }
        [StringLength(8)] public string STARTDATO_PENSIONSTYPE { get; set; }
        [StringLength(2)] public string PENSIONSTYPE { get; set; }
        [StringLength(8)] public string STARTDATO_NORMALBIDRAG { get; set; }
        [StringLength(12)] public string NORMALBIDRAG { get; set; }
        [StringLength(12)] public string ARBEJDSGIVERS_ANDEL_AF_NORMALBIDRAG { get; set; }
        [StringLength(8)] public string STARTDATO_PENSIONSBIDRAGSPROCENT { get; set; }
        [StringLength(4)] public string PENSIONSBIDRAGSPROCENT { get; set; }
        [StringLength(4)] public string ARBEJDSGIVER_PENSIONSBIDRAGSPROCENT { get; set; }
        [StringLength(8)] public string STARTDATO_LONTRIN { get; set; }
        [StringLength(5)] public string LONTRIN { get; set; }
        [StringLength(8)] public string STARTDATO_GRUPPELIVSANDEL { get; set; }
        [StringLength(12)] public string GRUPPELIVSANDEL_AF_INDBETALT_BELOB { get; set; }

    }
}
