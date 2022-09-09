namespace BlobAccess.Models
{
    public class AzureStorageConfig
    {
        public string AccountName { get; set; }
        public string FileContainer { get; set; }
        public string BlobContainer { get; set; }
        public string ConnectionString { get; set; }
        public string NameSpace { get; set; }
    }
}
