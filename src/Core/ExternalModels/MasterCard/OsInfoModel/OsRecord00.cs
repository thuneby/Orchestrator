using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsRecord00 : OsRecordBase
    {
        public OsRecord00()
        {
            OsRecord01Collection = new HashSet<OsRecord01>();
            OsRecord02Collection = new HashSet<OsRecord02>();
            OsRecord03Collection = new HashSet<OsRecord03>();
            OsRecord04Collection = new HashSet<OsRecord04>();
            OsRecord05Collection = new HashSet<OsRecord05>();
            OsRecord10Collection = new HashSet<OsRecord10>();
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

        public OsSectionStart OsSectionStart { get; set; }
        public ICollection<OsRecord01> OsRecord01Collection { get; set; }
        public ICollection<OsRecord02> OsRecord02Collection { get; set; }
        public ICollection<OsRecord03> OsRecord03Collection { get; set; }
        public ICollection<OsRecord04> OsRecord04Collection { get; set; }
        public ICollection<OsRecord05> OsRecord05Collection { get; set; }
        public ICollection<OsRecord10> OsRecord10Collection { get; set; }
    }
}
