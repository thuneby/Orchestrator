using Core.Models;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsSectionEnd : GuidModelBase
    {
        [StringLength(2)] public string SYSTEMKODE { get; set; }
        [StringLength(1)] public string RECORDTYPE { get; set; }
        [StringLength(2)] public string OVERFORSELSTYPE { get; set; }
        [StringLength(3)] public string INFOTYPE { get; set; }
        [StringLength(10)] public string ANTAL { get; set; }
        [StringLength(12)] public string BELOB { get; set; }
        [StringLength(6)] public string DISPOSITIONSDATO { get; set; }
        [StringLength(4)] public string AFSENDERREGISTRERINGSNUMMER { get; set; }
        [StringLength(10)] public string AFSENDERKONTONUMMER { get; set; }
        [StringLength(8)] public string DATALEVERANDORNUMMER { get; set; }
        [StringLength(8)] public string CVRNUMMERAFSENDER { get; set; }
        [StringLength(8)] public string PBSNUMMERMODTAGER { get; set; }

        public OsSectionStart OsSectionStart { get; set; }
    }
}
