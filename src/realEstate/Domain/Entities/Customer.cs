using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Customer : Entity<Guid>
{
    public string CustomerName { get; set; }

    public string CustomerSurName { get; set; }

    public string? CustomerSecondSurname { get; set; }

    public string? CustomerSecondName { get; set; }

    public DateTime BirthDate { get; set; }

    public Gender Gender { get; set; }

    public Occupation Occupatipon { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public string HomePhone { get; set; }

    public string MobilePhone { get; set; }

    public byte NumberOfChildren { get; set; }

    public string Email { get; set; }

    public Occupation SpouseOccupation { get; set; }

    public DateTime SpouseBirthDate { get; set; }

    public bool IsBuyerCustomer { get; set; } = false;

    public bool IsSellerCustomer { get; set; } = false;

    public bool IsTenantCustomer { get; set; } = false;

    public bool IsRenterCustomer { get; set; } = false;

    public string Address { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public Guid EstateAgentId { get; set; }

    public EstateAgent EstateAgent { get; set; }

    public virtual ICollection<RealEstateTransactionForSale> Purchases { get; set; }

    public virtual ICollection<RealEstateTransactionForSale> Sales { get; set; }

    public virtual ICollection<RealEstateTransactionForRental> Rentings { get; set; }

    public virtual ICollection<RealEstateTransactionForRental> Tenancies { get; set; }


}
