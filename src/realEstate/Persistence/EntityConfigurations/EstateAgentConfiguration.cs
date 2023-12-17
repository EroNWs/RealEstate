using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EstateAgentConfiguration : IEntityTypeConfiguration<EstateAgent>
{
    public void Configure(EntityTypeBuilder<EstateAgent> builder)
    {
        builder.ToTable("EstateAgents").HasKey(ea => ea.Id);

        builder.Property(ea => ea.Id).HasColumnName("Id").IsRequired();
        builder.Property(ea => ea.AgentName).HasColumnName("AgentName");
        builder.Property(ea => ea.AuthorizedName).HasColumnName("AuthorizedName");
        builder.Property(ea => ea.AuthorizedSurname).HasColumnName("AuthorizedSurname");
        builder.Property(ea => ea.AuthorizedSecondSurname).HasColumnName("AuthorizedSecondSurname");
        builder.Property(ea => ea.AuthorizedSecondName).HasColumnName("AuthorizedSecondName");
        builder.Property(ea => ea.Address).HasColumnName("Address");
        builder.Property(ea => ea.City).HasColumnName("City");
        builder.Property(ea => ea.District).HasColumnName("District");
        builder.Property(ea => ea.PostalCode).HasColumnName("PostalCode");
        builder.Property(ea => ea.Phone).HasColumnName("Phone");
        builder.Property(ea => ea.Fax).HasColumnName("Fax");
        builder.Property(ea => ea.EmployeeCount).HasColumnName("EmployeeCount");
        builder.Property(ea => ea.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ea => ea.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ea => ea.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ea => !ea.DeletedDate.HasValue);

        builder.HasMany(ea => ea.Customers)
        .WithOne(c => c.EstateAgent)
        .HasForeignKey(c => c.EstateAgentId);

        builder.HasMany(ea => ea.RealEstateTransactionForRentals)
              .WithOne(r => r.EstateAgent)
              .HasForeignKey(r => r.EtateAgentId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(ea => ea.RealEstateTransactionForSales)
              .WithOne(s => s.EstateAgent)
              .HasForeignKey(s => s.EstateAgentId)
              .OnDelete(DeleteBehavior.Restrict);




    }
}