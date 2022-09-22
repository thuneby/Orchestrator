﻿// <auto-generated />
using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Convert.Migrations
{
    [DbContext(typeof(DomainContext))]
    partial class DomainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.DomainModels.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cvr")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("DataProviderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("Date");

                    b.Property<int>("InformationType")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("Date");

                    b.Property<string>("PaymentReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PbsNumberRecepient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReconcileStatus")
                        .HasColumnType("int");

                    b.Property<string>("RoutingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TenantÍd")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Core.DomainModels.PaymentDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Cpr")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cvr")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("Date");

                    b.Property<int>("PaymentDetailType")
                        .HasColumnType("int");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("TenantÍd")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentDetail");
                });

            modelBuilder.Entity("Core.DomainModels.PaymentDetail", b =>
                {
                    b.HasOne("Core.DomainModels.Payment", null)
                        .WithMany("PaymentDetails")
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("Core.DomainModels.Payment", b =>
                {
                    b.Navigation("PaymentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
