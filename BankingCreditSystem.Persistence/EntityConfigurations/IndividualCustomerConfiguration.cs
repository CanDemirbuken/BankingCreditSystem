using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations
{
    public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            builder.ToTable("IndividualCustomers");

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.NationalId).IsRequired().HasMaxLength(11);
            builder.Property(c => c.MotherName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.FatherName).IsRequired().HasMaxLength(50);
            
            builder.HasIndex(c => c.NationalId).IsUnique();
        }
    }
} 