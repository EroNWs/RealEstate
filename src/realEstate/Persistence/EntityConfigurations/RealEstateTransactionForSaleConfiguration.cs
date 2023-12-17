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
        builder.Property(retfs => retfs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(retfs => retfs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(retfs => retfs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(retfs => !retfs.DeletedDate.HasValue);

        builder.HasOne(t => t.Buyer)
            .WithMany(c => c.Purchases)
            .HasForeignKey(t => t.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Seller)
              .WithMany(c => c.Sales) 
              .HasForeignKey(t => t.SellerId)
              .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.EstateAgent)
              .WithMany(ea => ea.RealEstateTransactionForSales)
              .HasForeignKey(s => s.EstateAgentId)
              .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.RealEstate)
              .WithOne()
              .HasForeignKey<RealEstateTransactionForSale>(s => s.RealEstateId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}