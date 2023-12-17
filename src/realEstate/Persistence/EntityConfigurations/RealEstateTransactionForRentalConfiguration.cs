using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RealEstateTransactionForRentalConfiguration : IEntityTypeConfiguration<RealEstateTransactionForRental>
{
    public void Configure(EntityTypeBuilder<RealEstateTransactionForRental> builder)
    {
        builder.ToTable("RealEstateTransactionForRentals").HasKey(retfr => retfr.Id);

        builder.Property(retfr => retfr.Id).HasColumnName("Id").IsRequired();
        builder.Property(retfr => retfr.RealEstateId).HasColumnName("RealEstateId");
        builder.Property(retfr => retfr.RealEstate).HasColumnName("RealEstate");
        builder.Property(retfr => retfr.EtateAgentId).HasColumnName("EtateAgentId");
        builder.Property(retfr => retfr.EstateAgent).HasColumnName("EstateAgent");
        builder.Property(retfr => retfr.TenantId).HasColumnName("TenantId");
        builder.Property(retfr => retfr.Tenant).HasColumnName("Tenant");
        builder.Property(retfr => retfr.RenterId).HasColumnName("RenterId");
        builder.Property(retfr => retfr.Renter).HasColumnName("Renter");
        builder.Property(retfr => retfr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(retfr => retfr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(retfr => retfr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(retfr => !retfr.DeletedDate.HasValue);
    }
}