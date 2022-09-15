using ExternalModels.MasterCard.OsInfoModel;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccess.Models
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {
        }


        public DbSet<OsInfoStart> OsInfoStart { get; set; }
        public DbSet<OsInfoEnd> OsInfoEnd { get; set; }
        public DbSet<OsInfoSectionStart> OsSectionStart { get; set; }
        public DbSet<OsInfoSectionEnd> OsSectionEnd { get; set; }
        public DbSet<OsInfoRecord00> OsRecord00 { get; set; }
        public DbSet<OsInfoRecord01> OsRecord01 { get; set; }
        public DbSet<OsInfoRecord02> OsRecord02 { get; set; }
        public DbSet<OsInfoRecord03> OsRecord03 { get; set; }
        public DbSet<OsInfoRecord04> OsRecord04 { get; set; }
        public DbSet<OsInfoRecord05> OsRecord05 { get; set; }
        public DbSet<OsInfoRecord10> OsRecord10 { get; set; }
    }
}
