using Core.Models;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoSectionStart : GuidModelBase
    {
        public OsInfoSectionStart()
        {
            OsRecord00Collection = new HashSet<OsInfoRecord00>();
        }

        [StringLength(2)] public string SYSTEMKODE { get; set; }
        [StringLength(1)] public string RECORDTYPE { get; set; }
        [StringLength(2)] public string OVERFORSELSART { get; set; }
        [StringLength(6)] public string DISPOSITIONSDATO { get; set; }
        [StringLength(4)] public string REGISTRERINGSNUMMER { get; set; }
        [StringLength(10)] public string KONTONUMMER { get; set; }
        [StringLength(8)] public string DATALEVERANDORNUMMER { get; set; }
        [StringLength(8)] public string CVRNUMMERAFSENDER { get; set; }
        [StringLength(8)] public string PBSNUMMERMODTAGER { get; set; }

        public OsInfoStart OsStart { get; set; }
        public OsInfoSectionEnd OsSectionEnd { get; set; }
        public ICollection<OsInfoRecord00> OsRecord00Collection { get; set; }
    }
}
