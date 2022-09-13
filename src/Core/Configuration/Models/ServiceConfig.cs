namespace Configuration.Models
{
    public class ServiceConfig
    {
        public string IngestionUri { get; set; }
        public string ParseUri { get; set; }
        public string ValidateUri { get; set; }
        public string PayUri { get; set; }
        public string ConsolidateUri { get; set; }
        public string TransferUri { get; set; }
    }
}
