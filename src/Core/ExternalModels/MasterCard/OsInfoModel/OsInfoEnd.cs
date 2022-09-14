using Core.Models;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoEnd : GuidModelBase
    {
        [StringLength(2)] public string SYSTEMKODE { get; set; }
        [StringLength(1)] public string RECORDTYPE { get; set; }
        [StringLength(2)] public string KONSTANT { get; set; }
        [StringLength(10)] public string TOTALANTAL { get; set; }
        [StringLength(12)] public string TOTALBELOB { get; set; }
        [StringLength(8)] public string DATALEVERANDORNUMMER { get; set; }

        public OsInfoStart OsStart { get; set; }
    }
}
