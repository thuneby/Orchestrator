using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoRecord05 : OsInfoSubRecordBase
    {
        [StringLength(32)] public string ADRESSE1 { get; set; }
        [StringLength(32)] public string ADRESSE2 { get; set; }
        [StringLength(20)] public string BYNAVN { get; set; }
        [StringLength(4)] public string POSTNUMMER { get; set; }
        [StringLength(4)] public string TAL1 { get; set; }
        [StringLength(10)] public string TAL2 { get; set; }
        [StringLength(9)] public string RESERVETEKST { get; set; }
    }
}
