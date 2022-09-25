using ExternalModels.MasterCard.Bs601Model;
using ExternalModels.MasterCard.OsInfoModel;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccess.Models
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {
        }

        // OsInfo
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

        // Bs601
        public DbSet<Delivery601Start> Bs601Start { get; set; }
        public DbSet<Delivery601End> Bs601End { get; set; }
        public DbSet<Section0112Start> Bs601SectionStart { get; set; }
        public DbSet<Section0112End> Bs601SectionEnd { get; set; }
        public DbSet<BsRecord22> BsRecord22 { get; set; }
        public DbSet<BsRecord2209> BsRecord2209 { get; set; }
        public DbSet<BsRecord2210> BsRecord2210 { get; set; }
        public DbSet<BsRecord42> BsRecord42 { get; set; }
        public DbSet<BsRecord52> BsRecord52 { get; set; }
        public DbSet<BsRecord62> BsRecord62 { get; set; }

    }
}
