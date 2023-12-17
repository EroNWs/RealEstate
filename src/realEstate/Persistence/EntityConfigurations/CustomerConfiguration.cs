using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(c => c.CustomerName)
            .HasColumnName("CustomerName")
            .HasMaxLength(30);

        builder.Property(c => c.CustomerSurName)
            .HasColumnName("CustomerSurName")
            .HasMaxLength(30);

        builder.Property(c => c.CustomerSecondSurname).HasColumnName("CustomerSecondSurname").HasMaxLength(30);
        builder.Property(c => c.CustomerSecondName).HasColumnName("CustomerSecondName").HasMaxLength(30);
        builder.Property(c => c.BirthDate).HasColumnName("BirthDate");
        builder.Property(c => c.Gender).HasColumnName("Gender");
        builder.Property(c => c.Occupatipon).HasColumnName("Occupatipon");
        builder.Property(c => c.MaritalStatus).HasColumnName("MaritalStatus");
        builder.Property(c => c.HomePhone).HasColumnName("HomePhone").HasMaxLength(11);
        builder.Property(c => c.MobilePhone).HasColumnName("MobilePhone").HasMaxLength(11);
        builder.Property(c => c.NumberOfChildren).HasColumnName("NumberOfChildren");
        builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(40);
        builder.Property(c => c.SpouseOccupation).HasColumnName("SpouseOccupation");
        builder.Property(c => c.SpouseBirthDate).HasColumnName("SpouseBirthDate");
        builder.Property(c => c.IsBuyerCustomer).HasColumnName("IsBuyerCustomer");
        builder.Property(c => c.IsSellerCustomer).HasColumnName("IsSellerCustomer");
        builder.Property(c => c.IsTenantCustomer).HasColumnName("IsTenantCustomer");
        builder.Property(c => c.IsRenterCustomer).HasColumnName("IsRenterCustomer");
        builder.Property(c => c.Address).HasColumnName("Address");
        builder.Property(c => c.City).HasColumnName("City");
        builder.Property(c => c.District).HasColumnName("District");   
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(c => c.EstateAgent)
            .WithMany(c => c.Customers)
            .HasForeignKey(c => c.EstateAgentId);

        builder.HasMany(c => c.Rentings)
                .WithOne(r => r.Renter)
                .HasForeignKey(r => r.RenterId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Tenancies)
              .WithOne(r => r.Tenant)
              .HasForeignKey(r => r.TenantId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Purchases)
              .WithOne(p => p.Buyer)
              .HasForeignKey(p => p.BuyerId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Sales)
              .WithOne(s => s.Seller)
              .HasForeignKey(s => s.SellerId)
              .OnDelete(DeleteBehavior.Restrict);


    }
}