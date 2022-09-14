using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoRecord04 : OsInfoSubRecordBase
    {
        [StringLength(2)] public string REGULERINGSKODE1 { get; set; }
        [StringLength(12)] public string REGULERINGSBELOB1 { get; set; }
        [StringLength(1)] public string FORTEGN1 { get; set; }
        [StringLength(8)] public string STARTDATO_REGULERING1 { get; set; }
        [StringLength(8)] public string SLUTDATO_REGULERING1 { get; set; }
        [StringLength(2)] public string REGULERINGSKODE2 { get; set; }
        [StringLength(12)] public string REGULERINGSBELOB2 { get; set; }
        [StringLength(1)] public string FORTEGN2 { get; set; }
        [StringLength(8)] public string STARTDATO_REGULERING2 { get; set; }
        [StringLength(8)] public string SLUTDATO_REGULERING2 { get; set; }
        [StringLength(2)] public string REGULERINGSKODE3 { get; set; }
        [StringLength(12)] public string REGULERINGSBELOB3 { get; set; }
        [StringLength(1)] public string FORTEGN3 { get; set; }
        [StringLength(8)] public string STARTDATO_REGULERING3 { get; set; }
        [StringLength(8)] public string SLUTDATO_REGULERING3 { get; set; }
        [StringLength(18)] public string FILLER { get; set; }
    }
}
