﻿using Core.CoreModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public class BlobContext : DbContext
    {
        public BlobContext(DbContextOptions<BlobContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<InputFile> InputFiles { get; set; }
        public DbSet<OutputFile> OutputFiles { get; set; }
    }
}
