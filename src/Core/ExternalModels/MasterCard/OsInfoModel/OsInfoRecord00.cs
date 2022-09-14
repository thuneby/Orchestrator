using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsInfoRecord00 : OsInfoRecordBase
    {
        public OsInfoRecord00()
        {
            OsRecord01Collection = new HashSet<OsInfoRecord01>();
            OsRecord02Collection = new HashSet<OsInfoRecord02>();
            OsRecord03Collection = new HashSet<OsInfoRecord03>();
            OsRecord04Collection = new HashSet<OsInfoRecord04>();
            OsRecord05Collection = new HashSet<OsInfoRecord05>();
            OsRecord10Collection = new HashSet<OsInfoRecord10>();
        }

        [StringLength(2)] public string ANTAL_INFO_RECORDS { get; set; }
        [StringLength(8)] public string PBSNUMMER { get; set; }
        [StringLength(5)] public string AFDELINGSNUMMER { get; set; }
        [StringLength(8)] public string AFTALENUMMER { get; set; }
        [StringLength(10)] public string CPR_NUMMER { get; set; }
        [StringLength(15)] public string KUNDENUMMER_AFSENDER { get; set; }
        [StringLength(15)] public string KUNDENUMMER_MODTAGER { get; set; }
        [StringLength(12)] public string INDBETALT_BELOB { get; set; }
        [StringLength(1)] public string FORTEGN { get; set; }
        [StringLength(8)] public string PERIODE_FRA { get; set; }
        [StringLength(8)] public string PERIODE_TIL { get; set; }
        [StringLength(5)] public string OVERENSKOMSTNUMMER { get; set; }
        [StringLength(12)] public string SPECIFICERET_BELOB { get; set; }

        public OsInfoSectionStart OsSectionStart { get; set; }
        public ICollection<OsInfoRecord01> OsRecord01Collection { get; set; }
        public ICollection<OsInfoRecord02> OsRecord02Collection { get; set; }
        public ICollection<OsInfoRecord03> OsRecord03Collection { get; set; }
        public ICollection<OsInfoRecord04> OsRecord04Collection { get; set; }
        public ICollection<OsInfoRecord05> OsRecord05Collection { get; set; }
        public ICollection<OsInfoRecord10> OsRecord10Collection { get; set; }
    }
}
