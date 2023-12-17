using Core.Application.Responses;

namespace Application.Features.RealEstates.Commands.Delete;

public class DeletedRealEstateResponse : IResponse
{
    public Guid Id { get; set; }
}