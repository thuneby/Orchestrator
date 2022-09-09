using Core.Models;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsSectionStart : GuidModelBase
    {
        public OsSectionStart()
        {
            OsRecord00Collection = new HashSet<OsRecord00>();
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

        public OsStart OsStart { get; set; }
        public OsSectionEnd OsSectionEnd { get; set; }
        public ICollection<OsRecord00> OsRecord00Collection { get; set; }
    }
}
