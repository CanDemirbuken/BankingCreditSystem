﻿// <auto-generated />
using System;
using BankingCreditSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingCreditSystem.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankingCreditSystem.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("BankingCreditSystem.Domain.Entities.CorporateCustomer", b =>
                {
                    b.HasBaseType("BankingCreditSystem.Domain.Entities.Customer");

                    b.Property<string>("AuthorizedPerson")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CompanyFoundationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CompanyRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("TaxNumber")
                        .IsUnique()
                        .HasFilter("[TaxNumber] IS NOT NULL");

                    b.ToTable("CorporateCustomers", (string)null);
                });

            modelBuilder.Entity("BankingCreditSystem.Domain.Entities.IndividualCustomer", b =>
                {
                    b.HasBaseType("BankingCreditSystem.Domain.Entities.Customer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasIndex("NationalId")
                        .IsUnique()
                        .HasFilter("[NationalId] IS NOT NULL");

                    b.ToTable("IndividualCustomers", (string)null);
                });

            modelBuilder.Entity("BankingCreditSystem.Domain.Entities.CorporateCustomer", b =>
                {
                    b.HasOne("BankingCreditSystem.Domain.Entities.Customer", null)
                        .WithOne()
                        .HasForeignKey("BankingCreditSystem.Domain.Entities.CorporateCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankingCreditSystem.Domain.Entities.IndividualCustomer", b =>
                {
                    b.HasOne("BankingCreditSystem.Domain.Entities.Customer", null)
                        .WithOne()
                        .HasForeignKey("BankingCreditSystem.Domain.Entities.IndividualCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
