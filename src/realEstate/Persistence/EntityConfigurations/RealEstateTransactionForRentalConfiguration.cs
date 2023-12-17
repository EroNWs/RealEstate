using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RealEstateTransactionForRentalConfiguration : IEntityTypeConfiguration<RealEstateTransactionForRental>
{
    public void Configure(EntityTypeBuilder<RealEstateTransactionForRental> builder)
    {
        builder.ToTable("RealEstateTransactionForRentals").HasKey(retfr => retfr.Id);

        builder.Property(retfr => retfr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(retfr => retfr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(retfr => retfr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(retfr => !retfr.DeletedDate.HasValue);
        builder.HasOne(r => r.Tenant)
              .WithMany(c => c.Tenancies)
              .HasForeignKey(r => r.TenantId)
              .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(r => r.Renter)
              .WithMany(c => c.Rentings)
              .HasForeignKey(r => r.RenterId)
              .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(r => r.EstateAgent)
              .WithMany(ea => ea.RealEstateTransactionForRentals)
              .HasForeignKey(r => r.EtateAgentId)
              .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(t => t.RealEstate)
              .WithOne()
              .HasForeignKey<RealEstateTransactionForRental>(t => t.RealEstateId)
              .OnDelete(DeleteBehavior.Restrict);

    }
}