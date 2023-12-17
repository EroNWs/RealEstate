using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;
public class RealEstate : Entity<Guid>
{
    public RealEstateType Type { get; set; }

    public Status Status { get; set; }

    public decimal SquareMeters { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public Guid? TransactionId { get; set; }

    public TransactionType TransactionType { get; set; }


}
