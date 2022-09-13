using Core.Models;
using Core.QueueModels;
using Microsoft.EntityFrameworkCore;

namespace PersistanceTest.TestStorage
{
    public class TestStorageContext: DbContext
    {
        public TestStorageContext(DbContextOptions<TestStorageContext> options) : base(options)
        {
        }

        public DbSet<InputFile> InputFile { get; set; }
        public DbSet<QueueMessage> QueueMessage { get; set; }
    }
}
