namespace Core.Dtos
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            ValidationErrors = new List<string>();
        }
        
        public Guid PaymentId { get; set; }
        public bool Valid { get; set; }
        public ICollection<string> ValidationErrors { get; set; }
    }
}
