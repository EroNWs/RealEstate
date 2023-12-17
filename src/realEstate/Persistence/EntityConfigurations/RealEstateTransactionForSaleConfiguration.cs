using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RealEstateTransactionForSaleConfiguration : IEntityTypeConfiguration<RealEstateTransactionForSale>
{
    public void Configure(EntityTypeBuilder<RealEstateTransactionForSale> builder)
    {
        builder.ToTable("RealEstateTransactionForSales").HasKey(retfs => retfs.Id);

        builder.Property(retfs => retfs.Id).HasColumnName("Id").IsRequired();
        builder.Property(retfs => retfs.RealEstateId).HasColumnName("RealEstateId");
        builder.Property(retfs => retfs.RealEstate).HasColumnName("RealEstate");
        builder.Property(retfs => retfs.EstateAgentId).HasColumnName("EstateAgentId");
        builder.Property(retfs => retfs.EstateAgent).HasColumnName("EstateAgent");
        builder.Property(retfs => retfs.BuyerId).HasColumnName("BuyerId");
        builder.Property(retfs => retfs.Buyer).HasColumnName("Buyer");
        builder.Property(retfs => retfs.SellerId).HasColumnName("SellerId");
        builder.Property(retfs => retfs.Seller).HasColumnName("Seller");
        builder.Property(retfs => retfs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(retfs => retfs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(retfs => retfs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(retfs => !retfs.DeletedDate.HasValue);
    }
}