using Core.Application.Responses;

namespace Application.Features.RealEstateTransactionForRentals.Commands.Delete;

public class DeletedRealEstateTransactionForRentalResponse : IResponse
{
    public Guid Id { get; set; }
}