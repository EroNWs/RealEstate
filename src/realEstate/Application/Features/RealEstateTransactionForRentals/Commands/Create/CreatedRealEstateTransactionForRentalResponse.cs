using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.RealEstateTransactionForRentals.Commands.Create;

public class CreatedRealEstateTransactionForRentalResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RealEstateId { get; set; }
    public RealEstate RealEstate { get; set; }
    public Guid EtateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }
    public Guid TenantId { get; set; }
    public Customer Tenant { get; set; }
    public Guid RenterId { get; set; }
    public Customer Renter { get; set; }
}