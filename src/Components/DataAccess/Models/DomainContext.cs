using Core.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public class DomainContext: DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentDetail> PaymentDetail { get; set; }
    }
}
