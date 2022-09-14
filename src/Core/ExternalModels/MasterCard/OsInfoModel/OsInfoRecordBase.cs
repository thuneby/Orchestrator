using Core.Models;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoRecordBase : GuidModelBase
    {
        [StringLength(2)] public string SYSTEMKODE { get; set; }
        [StringLength(1)] public string RECORDTYPE { get; set; }
        [StringLength(2)] public string OVERFORSELSTYPE { get; set; }
        [StringLength(3)] public string INFOTYPE { get; set; }
        [StringLength(2)] public string INFORECORDTYPE { get; set; }
        [StringLength(7)] public string SEKVENSNUMMER { get; set; }

    }
}
