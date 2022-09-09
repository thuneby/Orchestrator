using Microsoft.EntityFrameworkCore;

namespace DocumentAccess.Models
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var accountEndpoint = "";
            var accountKey = "";
            var dbName = "";
            optionsBuilder.UseCosmos(accountEndpoint, accountKey, dbName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}
