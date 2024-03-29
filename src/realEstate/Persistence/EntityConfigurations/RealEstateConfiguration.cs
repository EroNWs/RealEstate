using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Persistence.EntityConfigurations;

public class RealEstateConfiguration : IEntityTypeConfiguration<RealEstate>
{
    public void Configure(EntityTypeBuilder<RealEstate> builder)
    {
        builder.ToTable("RealEstates")
            .HasKey(re => re.Id);


        builder.Property(re => re.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(re => re.Type)
            .HasColumnName("Type");

        builder.Property(re => re.Status)
            .HasColumnName("Status");

        builder.Property(re => re.SquareMeters)
            .HasColumnName("SquareMeters")
            .HasColumnType("decimal(18,2)");

        builder.Property(re => re.Address)
            .HasColumnName("Address").HasMaxLength(100);

        builder.Property(re => re.City)
            .HasColumnName("City").HasMaxLength(27);

        builder.Property(re => re.District)
            .HasColumnName("District")
            .HasMaxLength(27);

        builder.Property(re => re.TransactionType)
            .HasColumnName("TransactionType");

        builder.Property(re => re.CreatedDate)
            .HasColumnName("CreatedDate")
            .IsRequired();

        builder.Property(re => re.UpdatedDate)
            .HasColumnName("UpdatedDate");

        builder.Property(re => re.DeletedDate)
            .HasColumnName("DeletedDate");


        builder.HasQueryFilter(re => !re.DeletedDate.HasValue);


        builder.HasDiscriminator<string>("RealEstateType")
                   .HasValue<RealEstate>("BaseType")
                   .HasValue<RealEstatePropertyForBuilding>("Building")
                   .HasValue<RealEstatePropertyForLand>("Land");


    }
}