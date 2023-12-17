using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CustomerName).HasColumnName("CustomerName");
        builder.Property(c => c.CustomerSurName).HasColumnName("CustomerSurName");
        builder.Property(c => c.CustomerSecondSurname).HasColumnName("CustomerSecondSurname");
        builder.Property(c => c.CustomerSecondName).HasColumnName("CustomerSecondName");
        builder.Property(c => c.BirthDate).HasColumnName("BirthDate");
        builder.Property(c => c.Gender).HasColumnName("Gender");
        builder.Property(c => c.Occupatipon).HasColumnName("Occupatipon");
        builder.Property(c => c.MaritalStatus).HasColumnName("MaritalStatus");
        builder.Property(c => c.HomePhone).HasColumnName("HomePhone");
        builder.Property(c => c.MobilePhone).HasColumnName("MobilePhone");
        builder.Property(c => c.NumberOfChildren).HasColumnName("NumberOfChildren");
        builder.Property(c => c.Email).HasColumnName("Email");
        builder.Property(c => c.SpouseOccupation).HasColumnName("SpouseOccupation");
        builder.Property(c => c.SpouseBirthDate).HasColumnName("SpouseBirthDate");
        builder.Property(c => c.IsBuyerCustomer).HasColumnName("IsBuyerCustomer");
        builder.Property(c => c.IsSellerCustomer).HasColumnName("IsSellerCustomer");
        builder.Property(c => c.IsTenantCustomer).HasColumnName("IsTenantCustomer");
        builder.Property(c => c.IsRenterCustomer).HasColumnName("IsRenterCustomer");
        builder.Property(c => c.Address).HasColumnName("Address");
        builder.Property(c => c.City).HasColumnName("City");
        builder.Property(c => c.District).HasColumnName("District");
        builder.Property(c => c.EstateAgentId).HasColumnName("EstateAgentId");
        builder.Property(c => c.EstateAgent).HasColumnName("EstateAgent");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}