using Core.Persistence.Repositories;

namespace Domain.Entities;
public class EstateAgent : Entity<Guid>
{
    public string AgentName { get; set; }

    public string AuthorizedName { get; set; }

    public string AuthorizedSurname { get; set; }

    public string? AuthorizedSecondSurname { get; set; }

    public string? AuthorizedSecondName { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string PostalCode { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public byte EmployeeCount { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }

    public virtual ICollection<RealEstateTransactionForSale> RealEstateTransactionForSales { get; set; }

    public virtual ICollection<RealEstateTransactionForRental> RealEstateTransactionForRentals { get; set; }

}
