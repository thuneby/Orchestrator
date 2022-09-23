using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class Delivery601End: DeliveryEndBase
    {
        [StringLength(15)]
        public string TotalAmount { get; set; }
        [StringLength(11)]
        public string NumberOfRecord5262 { get; set; }
        [StringLength(15)]
        public string Filler01 { get; set; }
        [StringLength(11)]
        public string NumberOfRecord22 { get; set; }
        [StringLength(34)]
        public string Filler02 { get; set; }
        public Delivery601Start DeliveryStart { get; set; }
    }
}
