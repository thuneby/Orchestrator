using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsRecord01 : OsSubRecordBase
    {
        [StringLength(8)] public string STARTDATO_KUNDE { get; set; }
        [StringLength(35)] public string KUNDENAVN { get; set; }
        [StringLength(1)] public string OPLYSNINGSKODE { get; set; }
        [StringLength(2)] public string PENSIONSALDERKODE { get; set; }
        [StringLength(2)] public string PENSIONSALDER { get; set; }
        [StringLength(8)] public string STARTDATO_AFLONNINGSFORM { get; set; }
        [StringLength(2)] public string AFLONNINGSFORM { get; set; }
        [StringLength(8)] public string ANCIENNITET_FRA_DATO { get; set; }
        [StringLength(8)] public string FRATRAEDELSESDATO { get; set; }
        [StringLength(37)] public string RESERVETEKST { get; set; }

    }
}
