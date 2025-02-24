using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations
{
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("CorporateCustomers");

            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(150);
            builder.Property(c => c.TaxNumber).IsRequired().HasMaxLength(10);
            builder.Property(c => c.TaxOffice).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CompanyRegistrationNumber).IsRequired();
            builder.Property(c => c.AuthorizedPerson).IsRequired().HasMaxLength(100);
            
            builder.HasIndex(c => c.TaxNumber).IsUnique();
        }
    }
} 