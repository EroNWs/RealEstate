using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Customers
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Delete" });
        #endregion
        #region EstateAgents
        seeds.Add(new OperationClaim { Id = ++id, Name = "EstateAgents.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EstateAgents.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EstateAgents.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EstateAgents.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EstateAgents.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EstateAgents.Delete" });
        #endregion
        #region RealEstates
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstates.Delete" });
        #endregion
        #region RealEstateTransactionForRentals
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForRentals.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForRentals.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForRentals.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForRentals.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForRentals.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForRentals.Delete" });
        #endregion
        #region RealEstateTransactionForSales
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForSales.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForSales.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForSales.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForSales.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForSales.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RealEstateTransactionForSales.Delete" });
        #endregion
        return seeds;
    }

}
