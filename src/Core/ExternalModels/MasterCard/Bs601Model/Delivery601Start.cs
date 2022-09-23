namespace ExternalModels.MasterCard.Bs601Model
{
    public class Delivery601Start: DeliveryStartBase
    {
        public Delivery601Start()
        {
            DeliveryEnd = new HashSet<Delivery601End>();
            BsSectionStart = new HashSet<Section0112Start>();
        }

        public ICollection<Delivery601End> DeliveryEnd { get; set; }
        public ICollection<Section0112Start> BsSectionStart { get; set; }

    }
}
