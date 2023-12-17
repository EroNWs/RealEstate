using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EstateAgentConfiguration : IEntityTypeConfiguration<EstateAgent>
{
    public void Configure(EntityTypeBuilder<EstateAgent> builder)
    {
        builder.ToTable("EstateAgents")
            .HasKey(ea => ea.Id);


        builder.Property(ea => ea.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(ea => ea.AgentName)
            .HasColumnName("AgentName")
            .HasMaxLength(27);

        builder.Property(ea => ea.AuthorizedName)
            .HasColumnName("AuthorizedName")
            .HasMaxLength(27);

        builder.Property(ea => ea.AuthorizedSurname)
            .HasColumnName("AuthorizedSurname")
            .HasMaxLength(27);

        builder.Property(ea => ea.AuthorizedSecondSurname)
            .HasColumnName("AuthorizedSecondSurname")
            .HasMaxLength(27);

        builder.Property(ea => ea.AuthorizedSecondName)
            .HasColumnName("AuthorizedSecondName")
            .HasMaxLength(27);

        builder.Property(ea => ea.Address)
            .HasColumnName("Address")
            .HasMaxLength(100);

        builder.Property(ea => ea.City)
            .HasColumnName("City")
            .HasMaxLength(27);

        builder.Property(ea => ea.District)
            .HasColumnName("District")
            .HasMaxLength(27);

        builder.Property(ea => ea.PostalCode)
            .HasColumnName("PostalCode")
            .HasMaxLength(27);

        builder.Property(ea => ea.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(11);

        builder.Property(ea => ea.Fax)
            .HasColumnName("Fax")
            .HasMaxLength(11);

        builder.Property(ea => ea.EmployeeCount)
            .HasColumnName("EmployeeCount");

        builder.Property(ea => ea.CreatedDate)
            .HasColumnName("CreatedDate")
            .IsRequired();

        builder.Property(ea => ea.UpdatedDate)
            .HasColumnName("UpdatedDate");

        builder.Property(ea => ea.DeletedDate)
            .HasColumnName("DeletedDate");


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