using System.ComponentModel.DataAnnotations;

namespace ExternalModels.IndustriensPension
{
    public class IpExtendedRecord : IpRecordBase
    {
        [StringLength(8)]
        public string DatoForAfvigelse { get; set; } = "";

        [StringLength(2)]
        public string AfvigelsesKode { get; set; } = "";

        [StringLength(12)]
        public string PensionsgivendeLoen { get; set; } = "";
    }
}
