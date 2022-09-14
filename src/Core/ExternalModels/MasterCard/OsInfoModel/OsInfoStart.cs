using Core.Models;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoStart : GuidModelBase
    {
        public OsInfoStart()
        {
            OsSectionStart = new HashSet<OsInfoSectionStart>();
        }

        [StringLength(2)] public string SYSTEMKODE { get; set; }
        [StringLength(1)] public string RECORDTYPE { get; set; }
        [StringLength(2)] public string KONSTANT { get; set; }
        [StringLength(14)] public string SYSTEMTEKST { get; set; }
        [StringLength(20)] public string IDENTIFIKATION { get; set; }
        [StringLength(8)] public string DATALEVERANDORNUMMER { get; set; }
        [StringLength(1)] public string LEVERANCEKVITTERING { get; set; }

        public OsInfoEnd OsEnd { get; set; }
        public ICollection<OsInfoSectionStart> OsSectionStart { get; set; }
    }
}
