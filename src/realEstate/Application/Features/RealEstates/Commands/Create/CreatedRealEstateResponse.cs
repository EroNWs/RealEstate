using Core.Application.Responses;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.RealEstates.Commands.Create;

public class CreatedRealEstateResponse : IResponse
{
    public Guid Id { get; set; }
    public RealEstateType Type { get; set; }
    public Status Status { get; set; }
    public decimal SquareMeters { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public Guid? TransactionId { get; set; }
    public TransactionType TransactionType { get; set; }
}