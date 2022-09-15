using ExternalModels.MasterCard.OsInfoModel;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccess.Models
{
    public class CosmosDocumentContext: DocumentContext
    {
        public CosmosDocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OsInfoStart>()
                .ToContainer("OsInfo")
                .HasNoDiscriminator()
                .HasPartitionKey(p => p.Id);
        }

    }
}
