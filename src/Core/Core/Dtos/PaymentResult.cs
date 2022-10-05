namespace Core.Dtos
{
    public class PaymentResult
    {
        public Guid PaymentId { get; set; }
        public bool Paid { get; set; }
        public string PaymentError { get; set; } = string.Empty; 
    }
}
