using Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    [Table("OsInfoStart")]
    public class OsInfoStart : GuidModelBase
    {
        public OsInfoStart()
        {
            OsInfoSectionStartCollection = new HashSet<OsInfoSectionStart>();
            OsInfoEndCollection = new HashSet<OsInfoEnd>();
        }

        [StringLength(2)] public string SYSTEMKODE { get; set; }
        [StringLength(1)] public string RECORDTYPE { get; set; }
        [StringLength(2)] public string KONSTANT { get; set; }
        [StringLength(14)] public string SYSTEMTEKST { get; set; }
        [StringLength(20)] public string IDENTIFIKATION { get; set; }
        [StringLength(8)] public string DATALEVERANDORNUMMER { get; set; }
        [StringLength(1)] public string LEVERANCEKVITTERING { get; set; }

        public ICollection<OsInfoSectionStart> OsInfoSectionStartCollection { get; set; }
        public ICollection<OsInfoEnd> OsInfoEndCollection { get; set; }
    }
}
